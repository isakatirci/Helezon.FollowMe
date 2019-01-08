using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.DataTransferObjects;
using Newtonsoft.Json;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service
{
    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface IZetaCodeNormalIplikService : IService<ZetaCodeNormalIplik>
    {
        List<PantoneRenkDto> GetPantoneRenkler();
        List<RenkDto> GetRenkler(int dilId = 2);
        //int GetSiparisNoByCompanyCode(int code);
        ZetaCodeNormalIplikDto GetZetaCodeNormalIplikById(int id,string companyId);
        List<ZetaCodeNormalIplikDto> GetAllZetaCodeNormalIplikler(int? id = null, string companyId = null);
        void GetSequenceBlueSiparisNo(SequenceBlueSiparisNo sequenceBlueSiparisNo);
        List<IplikNoGuideDto> GetIplikNoGuideByColumnName(string column);
        void InsertOrUpdate(ZetaCodeNormalIplikDto zetaCodeNormalIplikDto);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class ZetaCodeNormalIplikService : Service<ZetaCodeNormalIplik>, IZetaCodeNormalIplikService
    {
        private readonly IRepositoryAsync<ZetaCodeNormalIplik> _repository;
        private readonly ITermService _termService;
        private readonly IOthersService _othersService;
        public ZetaCodeNormalIplikService(IRepositoryAsync<ZetaCodeNormalIplik> repository) : base(repository)
        {
            _repository = repository;
             _termService = new TermService(_repository.GetRepositoryAsync<Term>());
            _othersService = new OthersService();

        }

        public List<RenkDto> GetRenkler(int dilId)
        {
            var repository = _repository.GetRepository<Renk>().Queryable();
            return repository.Where(x => x.DilId == dilId).Select(x => new { x.Id, x.Ad, x.HtmlKod, x.IplikRenkKodu }).ToList()
                .Select(x => new RenkDto
                {
                    Id = x.Id,
                    Ad = x.Ad,
                    HtmlKod = x.HtmlKod
                    //+ (!string.IsNullOrWhiteSpace(x.IplikRenkKodu) ? "|" + x.IplikRenkKodu : string.Empty)
                }).OrderBy(x => x.Ad).ToList();
        }
        public List<PantoneRenkDto> GetPantoneRenkler()
        {
            var reposiyory = _repository.GetRepository<PantoneRenk>().Queryable();
            return reposiyory.Select(x => new PantoneRenkDto { Id = x.Id, PantoneKodu = x.PantoneKodu + " " + x.PantoneRengi }).ToList();
        }

        //public int GetSiparisNoByCompanyCode(int code)
        //{
        //    var temp = _repository.Queryable().Where(x => x.BlueKod == code).Select(x => x.BlueSiparisNo).FirstOrDefault();
        //    return temp == 0 ? 1 : (++temp);           
        //}

        public ZetaCodeNormalIplikDto GetZetaCodeNormalIplikById(int id, string companyId)
        {
            var entity = _repository.Queryable().FirstOrDefault(x => x.Id == id && !x.IsPassive && x.SirketId == companyId);
            if (entity == null)
            {
                return null;
            }

            var sequence = _repository.GetRepository<IplikNo>().Queryable();

            var normalIplikDto = AutoMapperConfig.Mapper.Map<ZetaCodeNormalIplik, ZetaCodeNormalIplikDto>(entity);
            normalIplikDto.IplikNo = AutoMapperConfig.Mapper.Map<List<IplikNo>,List<IplikNoDto>>(entity.IplikNo.Where(x=>!x.IsPassive).ToList());

            normalIplikDto.RafyeriTurkiyeName = _termService.GetTermNameById(normalIplikDto.RafyeriTurkiyeId);
            normalIplikDto.RafyeriYunanistanName = _termService.GetTermNameById(normalIplikDto.RafyeriYunanistanId);
            normalIplikDto.IplikKategosiName = _termService.GetTermNameById(normalIplikDto.IplikKategosiId);

            normalIplikDto.Company = AutoMapperConfig.Mapper.Map<Company, CompanyDto>(entity.Company);

            foreach (var item in normalIplikDto.IplikNo)
            {
                item.ElyafCinsiKalitesiName = _termService.GetTermNameById(item.ElyafCinsiKalitesi);
            }


            return normalIplikDto;
        }

        private Expression<Func<ZetaCodeNormalIplik, bool>> QueryNormalIplik(int? id = null, string companyId = null)
        {
            if (id.HasValue && !string.IsNullOrWhiteSpace(companyId))            
                return x => x.Id == id && x.SirketId == companyId;
            return null;
        }
        public List<ZetaCodeNormalIplikDto> GetAllZetaCodeNormalIplikler(int? id = null, string companyId = null)
        {
            var zetaCodeNormalIplikler = _repository.Query(QueryNormalIplik(id, companyId)).Include(x => x.PantoneRenk).Include(x => x.Renk).Include(x => x.IplikNo).Select().ToList();
            var zetaCodeNormalIplikDtos = new List<ZetaCodeNormalIplikDto>();

            foreach (var iplik in zetaCodeNormalIplikler)
            {
                var iplikDto = AutoMapperConfig.Mapper.Map<ZetaCodeNormalIplik, ZetaCodeNormalIplikDto>(iplik);
                iplikDto.IplikNo = AutoMapperConfig.Mapper.Map<ICollection<IplikNo>, List<IplikNoDto>>(iplik.IplikNo);
                iplikDto.PantoneRenk = AutoMapperConfig.Mapper.Map<PantoneRenk, PantoneRenkDto>(iplik.PantoneRenk);
                iplikDto.Renk = AutoMapperConfig.Mapper.Map<Renk, RenkDto>(iplik.Renk);
                if (iplikDto.IplikKategosiId.HasValue)                
                    iplikDto.IplikKategosiName = _termService.GetTermNameById(iplik.IplikKategosiId);
                iplikDto.Company= AutoMapperConfig.Mapper.Map<Company, CompanyDto>(iplik.Company);
                if (iplikDto.Ulke.HasValue)                
                    iplikDto.UlkeAdi = _othersService.GetCountryNameById(iplikDto.Ulke.Value.ToString());
                if (iplikDto.UretimTeknolojisiId.HasValue)                
                    iplikDto.UretimTeknolojisiName = _termService.GetTermNameById(iplikDto.UretimTeknolojisiId.Value);
                if (iplikDto.RafyeriTurkiyeId.HasValue)
                    iplikDto.RafyeriTurkiyeName = _termService.GetTermNameById(iplikDto.RafyeriTurkiyeId.Value);
                if (iplikDto.RafyeriYunanistanId.HasValue)
                    iplikDto.RafyeriYunanistanName = _termService.GetTermNameById(iplikDto.RafyeriYunanistanId.Value);
                zetaCodeNormalIplikDtos.Add(iplikDto);
            }            

            return zetaCodeNormalIplikDtos;            
        }

        public void GetSequenceBlueSiparisNo(SequenceBlueSiparisNo sequenceBlueSiparisNo)
        {
            var sequence = _repository.GetRepository<SequenceBlueSiparisNo>().Queryable();
            var no = sequence.Where(x => x.BlueCompanyId == sequenceBlueSiparisNo.BlueCompanyId).Max(x => ((int?)x.SiparisNo))??0;
            sequenceBlueSiparisNo.CreatedOn = DateTime.UtcNow;
            no++;
            sequenceBlueSiparisNo.SiparisNo = no;
            _repository.GetRepository<SequenceBlueSiparisNo>().Insert(sequenceBlueSiparisNo);
        }

        public List<IplikNoGuideDto> GetIplikNoGuideByColumnName(string column)
        {
            var sequence = _repository.GetRepository<IplikNoGuide>().Queryable();
            var serialized =  JsonConvert.SerializeObject(sequence.Where(column + " != null").Select("new ("+column+")"));
            return JsonConvert.DeserializeObject<List<IplikNoGuideDto>>(serialized);
        }

        public override void Update(ZetaCodeNormalIplik entity)
        {
            base.Update(entity);
        }
        public override void Insert(ZetaCodeNormalIplik zetaCodeNormalIplik)
        {
            var zetaCode = _repository.Queryable().Max(x => (int?)x.ZetaCode)??0;
            zetaCode++;
            var blueSiparisNo = _repository.Queryable()
                .Where(x => x.SirketId == zetaCodeNormalIplik.SirketId)
                .Max(x => (int?)x.BlueSiparisNo)??0;
            blueSiparisNo++;
            //Daha sonra bunu başla bir metoda taşı
            if (zetaCode > 1400)
                throw new Exception("ZetaCode 1400 olamaz");
            zetaCodeNormalIplik.BlueSiparisNo = blueSiparisNo;
            zetaCodeNormalIplik.ZetaCode = zetaCode;
            base.Insert(zetaCodeNormalIplik);
        }


        public void InsertOrUpdate(ZetaCodeNormalIplikDto zetaCodeNormalIplikDto)
        {
            try
            {
                _repository.UnitOfWorkAsync().BeginTransaction();
                if (zetaCodeNormalIplikDto.Master)
                    _repository.UnitOfWorkAsync().ExecuteSqlCommand("UPDATE ZetaCodeNormalIplik SET Master = 0 WHERE MASTER = 1");
                var zetaCodeNormalIplik = AutoMapperConfig.Mapper.Map<ZetaCodeNormalIplikDto, ZetaCodeNormalIplik>(zetaCodeNormalIplikDto);
                var iplikNoService = new IplikNoService(_repository.GetRepositoryAsync<IplikNo>());
                //http://www.entityframeworktutorial.net/entityframework6/save-entity-graph.aspx

                var activeIplikNoIds = new List<int>();
                foreach (var iplikNo in zetaCodeNormalIplik.IplikNo)
                {
                    iplikNo.ZetaCodeNormalIplikId = zetaCodeNormalIplik.Id;
                    if (iplikNo.Id > 0)
                    {
                        activeIplikNoIds.Add(iplikNo.Id);
                    }                  
                }

                if (zetaCodeNormalIplik.Id > 0)
                {
                    this.Update(zetaCodeNormalIplik);
                }
                else
                {
                    this.Insert(zetaCodeNormalIplik);
                }

                var sum = 0;
                foreach (var iplikNo in zetaCodeNormalIplik.IplikNo)
                {
                    sum += iplikNo.ElyafOrani??0;
                    if (iplikNo.Id > 0)
                    {
                        iplikNoService.Update(iplikNo);
                    }
                    else
                    {
                        iplikNoService.Insert(iplikNo);
                    }
                }

                if (sum != 100)
                {
                    throw new Exception("Elyaf Oranı %100 olmalıdır");
                }

                if (zetaCodeNormalIplik.Id > 0)
                {
                    var passiveIplikNolar = iplikNoService.Queryable()
                        .Where(x => x.ZetaCodeNormalIplikId == zetaCodeNormalIplik.Id && !activeIplikNoIds.Contains(x.Id) && !x.IsPassive).ToList();
                    foreach (var passiveIplikNo in passiveIplikNolar)
                    {
                        passiveIplikNo.IsPassive = true;
                        iplikNoService.Update(passiveIplikNo);
                    }
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
    }
}
