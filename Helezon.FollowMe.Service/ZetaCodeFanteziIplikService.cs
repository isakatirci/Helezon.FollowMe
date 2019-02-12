using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.ContainerDtos;
using Helezon.FollowMe.Service.DataTransferObjects;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        void InsertOrUpdate(FanteziIplikContainerDto entity);
        List<ZetaCodeFanteziIplikDto> GetAllFanteziIplikler(int? id = null, string companyId = null);
        ZetaCodeFanteziIplikDto GetFanteziIplikById(int value, string companyId, bool includeNormalIplikler = false);
        List<ZetaCodeFanteziIplikDto> GetAllZetaCodeAndUrunIsmiOfFantaziIplikler(int? fanteziIplikId = null);
        ZetaCodeFanteziIplikDto GetRenklerOfFanteziIplik(int fanteziplikId);
        List<ZetaCodeFanteziIplikDto> GetZetaCodeIsimler(string companyId);
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
        private readonly IRepositoryAsync<ZetaCodeFanteziIplikNormalIplik> _repoFanteziIplikNormalIplik;
        private readonly IZetaCodeService _zetaCodeService;


        public FanteziIplikService(IRepositoryAsync<ZetaCodeFanteziIplik> repository) : base(repository)
        {
            _repository = repository;
            _termService = new TermService(_repository.GetRepositoryAsync<Term>());
            _othersService = new OthersService();
            _repoNormalIplik = _repository.GetRepositoryAsync<ZetaCodeNormalIplik>();
            _repoFanteziIplikNormalIplik= _repository.GetRepositoryAsync<ZetaCodeFanteziIplikNormalIplik>();
            _zetaCodeService = new ZetaCodeService(_repository.GetRepositoryAsync<ZetaCodes>());
        }


        public List<ZetaCodeFanteziIplikDto> GetZetaCodeIsimler(string companyId)
        {
            return _repository.QueryableNoTracking().Where(x => /*x.CompanyId == companyId &&*/ !x.IsPassive)
                .Select(x => new ZetaCodeFanteziIplikDto
                {
                    ZetaCode = x.ZetaCode,
                    UrunIsmi = x.UrunIsmi,
                    Id = x.Id
                }).ToList();
        }
        //private readonly IRepositoryAsync<Renk> _repoNormalIplik;
        //private readonly IRepositoryAsync<PantoneRenk> _repoNormalIplik;
     

        public ZetaCodeFanteziIplikDto GetRenklerOfFanteziIplik(int fanteziplikId)
        {
            var fanteziIplik = _repository.QueryableNoTracking()
                //.Include(x => x.Renk).Include(x => x.PantoneRenk)
                .Where(x => x.Id == fanteziplikId && !x.IsPassive)
                .Select(x => x)
                .FirstOrDefault();
            if (fanteziIplik == null)
            {
                return null;
            }
            var temp = AutoMapperConfig.Mapper.Map<ZetaCodeFanteziIplik, ZetaCodeFanteziIplikDto>(fanteziIplik);
            //temp.Renk = AutoMapperConfig.Mapper.Map<Renk, RenkDto>(fanteziIplik.Renk);
            //temp.PantoneRenk = AutoMapperConfig.Mapper.Map<PantoneRenk, PantoneRenkDto>(fanteziIplik.PantoneRenk);

            return temp;
        }
        public override void Update(ZetaCodeFanteziIplik entity)
        {
            base.Update(entity);
        }

        public override void Insert(ZetaCodeFanteziIplik entity)
        {
            //var zetaCode = _repository.Queryable().Max(x => (int?)x.ZetaCode) ?? 0;
            //zetaCode++;
            //var blueSiparisNo = _repository.Queryable()
            //    .Where(x => x.SirketId == entity.SirketId)
            //    .Max(x => (int?)x.BlueSiparisNo) ?? 0;
            //blueSiparisNo++;
            ////Daha sonra bunu başla bir metoda taşı
            //if (zetaCode > 1400)
            //    throw new Exception("ZetaCode 1400 olamaz");
            //entity.BlueSiparisNo = blueSiparisNo;
            //entity.ZetaCode = zetaCode;
            var code = _zetaCodeService.GetZetaCodeForIplikInsert();
            //entity.ZetaCode = code;
            entity.Id = code;
            base.Insert(entity);
        }

        public void InsertOrUpdate(FanteziIplikContainerDto container)
        {
            try
            {
                var fanteziIplik = AutoMapperConfig.Mapper.Map<ZetaCodeFanteziIplikDto, ZetaCodeFanteziIplik>(container.FanteziIplik);
             
                _repository.UnitOfWorkAsync().BeginTransaction();
                fanteziIplik.SirketId = container.Company.Id;
                fanteziIplik.SirketId = container.Company.Id;
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
                //.Include(x => x.ZetaCodeNormalIplik)
                //.Include(x => x.Company)
                .Select(x => x).ToList();
            var zetaCodeNormalIplikDtos = new List<ZetaCodeFanteziIplikDto>();

            //foreach (var iplik in zetaCodeNormalIplikler)
            //{
            //    var iplikDto = AutoMapperConfig.Mapper.Map<ZetaCodeFanteziIplik, ZetaCodeFanteziIplikDto>(iplik);
            //    iplikDto.ZetaCodeNormalIplik = AutoMapperConfig.Mapper.Map<ICollection<ZetaCodeNormalIplik>, List<ZetaCodeNormalIplikDto>>(iplik.ZetaCodeNormalIplik);
            //    iplikDto.Company = AutoMapperConfig.Mapper.Map<Company, CompanyDto>(iplik.Company);
            //    if (iplikDto.UlkeId.HasValue)
            //        iplikDto.Ulke = _othersService.GetCountryById(iplikDto.UlkeId.Value.ToString());
            //    zetaCodeNormalIplikDtos.Add(iplikDto);
            //}

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
            //var query = _repository.Query(x => x.Id == fantaziIplikId && x.SirketId == companyId);
            //if (includeNormalIplikler)
            //{
            //    query = query.Include(x => x.ZetaCodeNormalIplik);
            //}
            //var fantezIplik = query.Select(x => x).FirstOrDefault();
            //if (fantezIplik == null)
            //{
            //    return null;
            //}
            //var fanteziIplikDto = AutoMapperConfig.Mapper.Map<ZetaCodeFanteziIplik, ZetaCodeFanteziIplikDto>(fantezIplik);
            //if (includeNormalIplikler)
            //{
            //    fanteziIplikDto.ZetaCodeNormalIplik = AutoMapperConfig.Mapper.Map<ICollection<ZetaCodeNormalIplik>, List<ZetaCodeNormalIplikDto>>(fantezIplik.ZetaCodeNormalIplik);
            //    fanteziIplikDto.RafyeriTurkiye = _termService.GetTermById(fantezIplik.RafyeriTurkiyeId);
            //    fanteziIplikDto.RafyeriYunanistan = _termService.GetTermById(fantezIplik.RafyeriYunanistanId);
            //    fanteziIplikDto.IplikKategosi = _termService.GetTermById(fantezIplik.IplikKategosiId);
            //}
            //return fanteziIplikDto;
            return null;
        }


        public List<ZetaCodeFanteziIplikDto> GetAllZetaCodeAndUrunIsmiOfFantaziIplikler(int? fanteziIplikId = null)
        {
            IQueryable<ZetaCodeFanteziIplik> query = null;

            if (fanteziIplikId.HasValue)
            {
                query = _repository.QueryableNoTracking().Where(x => x.Id == fanteziIplikId.Value && !x.IsPassive);
            }
            else
            {
                query = _repository.QueryableNoTracking().Where(x => !x.IsPassive);
            }
            return query.Select(x => new ZetaCodeFanteziIplikDto
            {
                Id = x.Id,
                UrunIsmi = x.UrunIsmi,
                ZetaCode = x.ZetaCode
            }).ToList();
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
