using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.DataTransferObjects;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service
{

    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface IFanteziIplikService : IService<ZetaCodeFanteziIplik>
    {
        void InsertOrUpdate(ZetaCodeFanteziIplikDto entity);
        List<ZetaCodeFanteziIplikDto> GetAllFanteziIplikler(int? id = null, string companyId = null);
        ZetaCodeFanteziIplikDto GetFanteziIplikById(int value, string companyId, bool includeNormalIplikler = false);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class FanteziIplikService : Service<ZetaCodeFanteziIplik>, IFanteziIplikService
    {
        private readonly IRepositoryAsync<ZetaCodeFanteziIplik> _repository;
        private readonly ITermService _termService;
        private readonly IOthersService _othersService;
        private readonly IRepositoryAsync<ZetaCodeNormalIplik> _repoNormalIplik;
        //private readonly IRepositoryAsync<Renk> _repoNormalIplik;
        //private readonly IRepositoryAsync<PantoneRenk> _repoNormalIplik;
        public FanteziIplikService(IRepositoryAsync<ZetaCodeFanteziIplik> repository) : base(repository)
        {
            _repository = repository;
            _termService = new TermService(_repository.GetRepositoryAsync<Term>());
            _othersService = new OthersService();
            _repoNormalIplik = _repository.GetRepositoryAsync<ZetaCodeNormalIplik>();
        }
        public override void Update(ZetaCodeFanteziIplik entity)
        {
            base.Update(entity);
        }
  
        public override void Insert(ZetaCodeFanteziIplik entity)
        {
            var zetaCode = _repository.Queryable().Max(x => (int?)x.ZetaCode) ?? 0;
            zetaCode++;
            var blueSiparisNo = _repository.Queryable()
                .Where(x => x.SirketId == entity.SirketId)
                .Max(x => (int?)x.BlueSiparisNo) ?? 0;
            blueSiparisNo++;
            //Daha sonra bunu başla bir metoda taşı
            if (zetaCode > 1400)
                throw new Exception("ZetaCode 1400 olamaz");
            entity.BlueSiparisNo = blueSiparisNo;
            entity.ZetaCode = zetaCode;
            base.Insert(entity);
        }

        public void InsertOrUpdate(ZetaCodeFanteziIplikDto entity)
        {
            try
            {
                var fanteziIplik = AutoMapperConfig.Mapper.Map<ZetaCodeFanteziIplikDto, ZetaCodeFanteziIplik>(entity);
                var normalIplikIds = fanteziIplik.ZetaCodeNormalIplik.Select(x => x.Id).ToList();
                fanteziIplik.ZetaCodeNormalIplik.Clear();
                foreach (var normalIplikId in normalIplikIds)
                {
                    fanteziIplik.ZetaCodeNormalIplik.Add(_repoNormalIplik.Queryable().FirstOrDefault(x => x.Id == normalIplikId));
                }
                _repository.UnitOfWorkAsync().BeginTransaction();
                if (fanteziIplik.Id > 0)
                {
                    this.Update(fanteziIplik);
                }
                else
                {
                    this.Insert(fanteziIplik);
                }
                _repository.UnitOfWorkAsync().SaveChanges();
                _repository.UnitOfWorkAsync().Commit();
            }
            catch (Exception ex)
            {
                _repository.UnitOfWorkAsync().Rollback();
                throw;
            }

        }

        public List<ZetaCodeFanteziIplikDto> GetAllFanteziIplikler(int? id = null, string companyId = null)
        {
            var zetaCodeNormalIplikler = _repository.Query(QueryFanteziIplik(id, companyId))
                .Include(x => x.ZetaCodeNormalIplik)
                .Include(x => x.Company)
                .Select(x => x).ToList();
            var zetaCodeNormalIplikDtos = new List<ZetaCodeFanteziIplikDto>();

            foreach (var iplik in zetaCodeNormalIplikler)
            {
                var iplikDto = AutoMapperConfig.Mapper.Map<ZetaCodeFanteziIplik, ZetaCodeFanteziIplikDto>(iplik);
                iplikDto.ZetaCodeNormalIplik = AutoMapperConfig.Mapper.Map<ICollection<ZetaCodeNormalIplik>, List<ZetaCodeNormalIplikDto>>(iplik.ZetaCodeNormalIplik);
                iplikDto.Company = AutoMapperConfig.Mapper.Map<Company, CompanyDto>(iplik.Company);
                if (iplikDto.UlkeId.HasValue)
                    iplikDto.Ulke = _othersService.GetCountryById(iplikDto.UlkeId.Value.ToString());
                zetaCodeNormalIplikDtos.Add(iplikDto);
            }

            return zetaCodeNormalIplikDtos;
        }

        private Expression<Func<ZetaCodeFanteziIplik, bool>> QueryFanteziIplik(int? id = null, string companyId = null)
        {
            if (id.HasValue && !string.IsNullOrWhiteSpace(companyId))
                return x => x.Id == id && x.SirketId == companyId;
            return null;
        }

        public ZetaCodeFanteziIplikDto GetFanteziIplikById(int fantaziIplikId, string companyId, bool includeNormalIplikler = false)
        {
            var query = _repository.Query(x => x.Id == fantaziIplikId && x.SirketId == companyId);
            if (includeNormalIplikler)
            {
                query = query.Include(x => x.ZetaCodeNormalIplik);
            }
            var fantezIplik = query.Select(x => x).FirstOrDefault();
            if (fantezIplik == null)
            {
                return null;
            }
            var fanteziIplikDto = AutoMapperConfig.Mapper.Map<ZetaCodeFanteziIplik, ZetaCodeFanteziIplikDto>(fantezIplik);
            if (includeNormalIplikler)
            {
                fanteziIplikDto.ZetaCodeNormalIplik = AutoMapperConfig.Mapper.Map<ICollection<ZetaCodeNormalIplik>, List<ZetaCodeNormalIplikDto>>(fantezIplik.ZetaCodeNormalIplik);
                fanteziIplikDto.RafyeriTurkiye = _termService.GetTermById(fantezIplik.RafyeriTurkiyeId);
                fanteziIplikDto.RafyeriYunanistan = _termService.GetTermById(fantezIplik.RafyeriYunanistanId);
                fanteziIplikDto.IplikKategosi = _termService.GetTermById(fantezIplik.IplikKategosiId);
            }
            return fanteziIplikDto;
        }

        //public ZetaCodeFanteziIplikDto GetNormalIpliklerOfFanteziIplikByFanteziIplikId(int fantaziIplikId, string companyId, bool includeNormalIplikler = false)
        //{
        //    var query = _repository.Query(x => x.Id == fantaziIplikId && x.SirketId == companyId);
        //    if (includeNormalIplikler)
        //    {
        //        query = query.Include(x => x.ZetaCodeNormalIplik);
        //    }
        //    var fantezIplik = query.Select(x => x).FirstOrDefault();
        //    if (fantezIplik == null)
        //    {
        //        return null;
        //    }
        //    var fanteziIplikDto = AutoMapperConfig.Mapper.Map<ZetaCodeFanteziIplik, ZetaCodeFanteziIplikDto>(fantezIplik);
        //    if (includeNormalIplikler)
        //    {
        //        fanteziIplikDto.ZetaCodeNormalIplik = AutoMapperConfig.Mapper.Map<ICollection<ZetaCodeNormalIplik>, List<ZetaCodeNormalIplikDto>>(fantezIplik.ZetaCodeNormalIplik);
        //    }
        //    return fanteziIplikDto;
        //}
    }
}
