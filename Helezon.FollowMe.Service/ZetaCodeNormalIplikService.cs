using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.DataTransferObjects;
using Newtonsoft.Json;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
        ZetaCodeNormalIplikDto GetZetaCodeNormalIplikById(int id, string companyId, bool includeIplikNo = true);
        List<ZetaCodeNormalIplikDto> GetAllZetaCodeNormalIplikler(int? id = null, string companyId = null);
        void GetSequenceBlueSiparisNo(SequenceBlueSiparisNo sequenceBlueSiparisNo);
        List<IplikNoGuideDto> GetIplikNoGuideByColumnName(string column);
        void InsertOrUpdate(ZetaCodeNormalIplikDto zetaCodeNormalIplikDto);
        IplikKategoriSim GetIplikKategoriSimByZetaCodeNormalIplikId(int? normalIplikId);
        IplikKategoriDegrede GetIplikKategoriDegredeByZetaCodeNormalIplikId(int? normalIplikId);
        IplikKategoriKrep GetIplikKategoriKrepByZetaCodeNormalIplikId(int? normalIplikId);
        IplikKategoriNopeli GetIplikKategoriNopeliByZetaCodeNormalIplikId(int? normalIplikId);
        IplikKategoriKircili GetIplikKategoriKirciliByZetaCodeNormalIplikId(int? normalIplikId);
        ZetaCodeNormalIplikDto GetZetaCodeNormalIplikByMaster();
        IplikKategoriFlam GetIplikKategoriFlamByZetaCodeNormalIplikId(int? normalIplikId);
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

        public ZetaCodeNormalIplikDto GetZetaCodeNormalIplikById(int id, string companyId, bool includeIplikNo = true)
        {
            var entity = _repository.Queryable().FirstOrDefault(x => x.Id == id && !x.IsPassive && x.SirketId == companyId);
            if (entity == null)
            {
                return null;
            }

            //var sequence = _repository.GetRepository<IplikNo>().Queryable();

            var normalIplikDto = AutoMapperConfig.Mapper.Map<ZetaCodeNormalIplik, ZetaCodeNormalIplikDto>(entity);
            if (includeIplikNo)
            {
                normalIplikDto.IplikNo = AutoMapperConfig.Mapper.Map<List<IplikNo>, List<IplikNoDto>>(entity.IplikNo.Where(x => !x.IsPassive).ToList());

                normalIplikDto.RafyeriTurkiyeName = _termService.GetTermNameById(normalIplikDto.RafyeriTurkiyeId);
                normalIplikDto.RafyeriYunanistanName = _termService.GetTermNameById(normalIplikDto.RafyeriYunanistanId);
                normalIplikDto.IplikKategosiName = _termService.GetTermNameById(normalIplikDto.IplikKategosiId);

                normalIplikDto.Company = AutoMapperConfig.Mapper.Map<Company, CompanyDto>(entity.Company);
                foreach (var item in normalIplikDto.IplikNo)
                {
                    item.ElyafCinsiKalitesiName = _termService.GetTermNameById(item.ElyafCinsiKalitesi);
                }
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

        private bool MyInvariantEquals(string s1,string s2)
        {
            return string.Equals(s1, s2, StringComparison.InvariantCultureIgnoreCase);
        }

        private void IplikUrunIsmiOlustur(ZetaCodeNormalIplikDto normalIplikDto) {
            var iplikNoCinsi = string.Empty;
            var iplikKategorisi = string.Empty;
            var uretimTeknolojisi = string.Empty;
            var elyafCinsiKalitesi = string.Empty;
            //( İplik No Cinsi) DYN 300, FL 50 
            //-(IplikKategorisiId, Parenti al) HAM 
            //- (üretim teknolojisi) AIRJET 
            //- (Elyaf Cinsi - Kalitesi - Parlaklık) 50/50 PAMUK ,SILK MAT-YARIMAT (IplikKategorisiId, Child ) KIRCILI
            if (!string.IsNullOrWhiteSpace(normalIplikDto.IplikNoCinsi))
            {
                if (MyInvariantEquals(normalIplikDto.IplikNoCinsi,"DNY"))
                {
                    iplikNoCinsi = string.Format("DYN {0}, FL {1}", normalIplikDto.Dny, normalIplikDto.Fl);
                }
                else if (MyInvariantEquals(normalIplikDto.IplikNoCinsi, "NE"))
                {
                    iplikNoCinsi = string.Format("NE {0}", normalIplikDto.Ne);
                }
                else if (MyInvariantEquals(normalIplikDto.IplikNoCinsi, "NM"))
                {
                    iplikNoCinsi = string.Format("NM {0}", normalIplikDto.Nm);
                }
            }
            if (normalIplikDto.IplikKategosiId.HasValue)
            {
                var parents = _termService.GetAllParentsById(normalIplikDto.IplikKategosiId.Value);
                parents.Reverse();
                if (parents.Count > 1)
                {
                    iplikKategorisi = parents[1].Name;
                }              
            }
            if (normalIplikDto.UretimTeknolojisiId.HasValue)
            {
                uretimTeknolojisi = _termService.GetTermNameById(normalIplikDto.UretimTeknolojisiId.Value);
            }

            var elyafOranlari = new List<int>();
            var elyaflar = new List<string>();
            var parlakliklar = new List<string>();

            foreach (var iplikNo in normalIplikDto.IplikNo)
            {
                var parlaklik = string.Empty;
                var elyaf = string.Empty;
                if (iplikNo.ElyafCinsiKalitesi.HasValue)
                {
                    var parents = _termService.GetAllParentsById(iplikNo.ElyafCinsiKalitesi.Value);
                    parents.Reverse();
                    var count = parents.Count;
                    if (count == 1)
                    {
                        elyaf = parents[0].Name;
                    }
                    else if (count == 2)
                    {
                        elyaf = parents[1].Name;
                    }
                    else if (count == 3)
                    {
                        elyaf = parents[1].Name;
                        parlaklik = parents[2].Name;
                    }                   
                }
                else
                {
                    elyaflar.Add(string.Empty);
                }
                elyaflar.Add(elyaf);
                parlakliklar.Add(parlaklik);
                elyafOranlari.Add(iplikNo.ElyafOrani ?? 0);
            }
            var urunIsmi = string.Format("{0} - {1} - {2} - {3} - {4}", iplikNoCinsi, iplikKategorisi, string.Join("/", elyafOranlari), string.Join("/", elyaflar), string.Join("/", parlakliklar));
            normalIplikDto.UrunIsmi = urunIsmi;
        }

        public void InsertOrUpdate(ZetaCodeNormalIplikDto zetaCodeNormalIplikDto)
        {
            try
            {
                _repository.UnitOfWorkAsync().BeginTransaction();
                IplikUrunIsmiOlustur(zetaCodeNormalIplikDto);
                if (zetaCodeNormalIplikDto.Master)
                    _repository.UnitOfWorkAsync().ExecuteSqlCommand("UPDATE ZetaCodeNormalIplik SET Master = 0 WHERE MASTER = 1");
                var zetaCodeNormalIplik = AutoMapperConfig.Mapper.Map<ZetaCodeNormalIplikDto, ZetaCodeNormalIplik>(zetaCodeNormalIplikDto);
                var iplikNoService = new IplikNoService(_repository.GetRepositoryAsync<IplikNo>());
                var repoSim = _repository.GetRepositoryAsync<IplikKategoriSim>();
                var repoDegrede = _repository.GetRepositoryAsync<IplikKategoriDegrede>();
                var repoFlam = _repository.GetRepositoryAsync<IplikKategoriFlam>();
                var repoKircili = _repository.GetRepositoryAsync<IplikKategoriKircili>();
                var repoKrep = _repository.GetRepositoryAsync<IplikKategoriKrep>();
                var repoNopeli = _repository.GetRepositoryAsync<IplikKategoriNopeli>();


                

                if (zetaCodeNormalIplik.IplikKategoriDegrede != null)
                {
                    zetaCodeNormalIplik.IplikKategoriDegrede.ZetaCodeNormalIplikId = zetaCodeNormalIplik.Id;
                }
                if (zetaCodeNormalIplik.IplikKategoriFlam != null)
                {
                    zetaCodeNormalIplik.IplikKategoriFlam.ZetaCodeNormalIplikId = zetaCodeNormalIplik.Id;
                }
                if (zetaCodeNormalIplik.IplikKategoriKircili != null)
                {
                    zetaCodeNormalIplik.IplikKategoriKircili.ZetaCodeNormalIplikId = zetaCodeNormalIplik.Id;
                }
                if (zetaCodeNormalIplik.IplikKategoriKrep != null)
                {
                    zetaCodeNormalIplik.IplikKategoriKrep.ZetaCodeNormalIplikId = zetaCodeNormalIplik.Id;
                }
                if (zetaCodeNormalIplik.IplikKategoriNopeli != null)
                {
                    zetaCodeNormalIplik.IplikKategoriNopeli.ZetaCodeNormalIplikId = zetaCodeNormalIplik.Id;
                }
                if (zetaCodeNormalIplik.IplikKategoriSim != null)
                {
                    zetaCodeNormalIplik.IplikKategoriSim.ZetaCodeNormalIplikId = zetaCodeNormalIplik.Id;
                }



                //http://www.entityframeworktutorial.net/entityframework6/save-entity-graph.aspx

                if (zetaCodeNormalIplik.IplikKategoriDegrede != null)
                {
                    if (zetaCodeNormalIplik.IplikKategoriDegrede.Id > 0)
                    {
                        repoDegrede.Update(zetaCodeNormalIplik.IplikKategoriDegrede);
                    }
                    else
                    {
                        repoDegrede.Insert(zetaCodeNormalIplik.IplikKategoriDegrede);
                    }
                }
                if (zetaCodeNormalIplik.IplikKategoriFlam != null)
                {
                    if (zetaCodeNormalIplik.IplikKategoriFlam.Id > 0)
                    {
                        repoFlam.Update(zetaCodeNormalIplik.IplikKategoriFlam);
                    }
                    else
                    {
                        repoFlam.Insert(zetaCodeNormalIplik.IplikKategoriFlam);
                    }
                }
                if (zetaCodeNormalIplik.IplikKategoriKircili != null)
                {
                    if (zetaCodeNormalIplik.IplikKategoriKircili.Id > 0)
                    {
                        repoKircili.Update(zetaCodeNormalIplik.IplikKategoriKircili);
                    }
                    else
                    {
                        repoKircili.Insert(zetaCodeNormalIplik.IplikKategoriKircili);
                    }
                }
                if (zetaCodeNormalIplik.IplikKategoriKrep != null)
                {
                    if (zetaCodeNormalIplik.IplikKategoriKrep.Id > 0)
                    {
                        repoKrep.Update(zetaCodeNormalIplik.IplikKategoriKrep);
                    }
                    else
                    {
                        repoKrep.Insert(zetaCodeNormalIplik.IplikKategoriKrep);
                    }

                }
                if (zetaCodeNormalIplik.IplikKategoriNopeli != null)
                {
                    if (zetaCodeNormalIplik.IplikKategoriNopeli.Id > 0)
                    {
                        repoNopeli.Update(zetaCodeNormalIplik.IplikKategoriNopeli);
                    }
                    else
                    {
                        repoNopeli.Insert(zetaCodeNormalIplik.IplikKategoriNopeli);
                    }
                }

                if (zetaCodeNormalIplik.IplikKategoriSim != null)
                {
                    if (zetaCodeNormalIplik.IplikKategoriSim.Id > 0)
                    {
                        repoSim.Update(zetaCodeNormalIplik.IplikKategoriSim);
                    }
                    else
                    {
                        repoSim.Insert(zetaCodeNormalIplik.IplikKategoriSim);
                    }
                }


                var activeIplikNoIds = new List<int>();
                foreach (var iplikNo in zetaCodeNormalIplik.IplikNo)
                {
                    iplikNo.ZetaCodeNormalIplikId = zetaCodeNormalIplik.Id;
                    if (iplikNo.Id > 0)
                    {
                        activeIplikNoIds.Add(iplikNo.Id);
                    }                  
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
                    this.Update(zetaCodeNormalIplik);
                }
                else
                {
                    this.Insert(zetaCodeNormalIplik);
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

        //private string MyToString(decimal value)
        //{
        //    return value.ToString("N", CultureInfo.InvariantCulture);
        //}
  
        public IplikKategoriSim GetIplikKategoriSimByZetaCodeNormalIplikId(int? normalIplikId)
        {
            if (!normalIplikId.HasValue)
                return null;
            var repoSim = _repository.GetRepositoryAsync<IplikKategoriSim>();

            var sim = repoSim.Queryable().FirstOrDefault(x => x.ZetaCodeNormalIplikId == normalIplikId);
            return sim;
        }
        public IplikKategoriDegrede GetIplikKategoriDegredeByZetaCodeNormalIplikId(int? normalIplikId)
        {
            if (!normalIplikId.HasValue)
                return null;
            var repoDegrede = _repository.GetRepositoryAsync<IplikKategoriDegrede>();

            var degrede = repoDegrede.Queryable().FirstOrDefault(x => x.ZetaCodeNormalIplikId == normalIplikId);
            return degrede;
        }
        public IplikKategoriKrep GetIplikKategoriKrepByZetaCodeNormalIplikId(int? normalIplikId)
        {
            if (!normalIplikId.HasValue)
                return null;
            var repoKrep = _repository.GetRepositoryAsync<IplikKategoriKrep>();

            var krep = repoKrep.Queryable().FirstOrDefault(x => x.ZetaCodeNormalIplikId == normalIplikId);
            return krep;
        }

        public IplikKategoriNopeli GetIplikKategoriNopeliByZetaCodeNormalIplikId(int? normalIplikId)
        {
            if (!normalIplikId.HasValue)
                return null;
            var repoNopeli = _repository.GetRepositoryAsync<IplikKategoriNopeli>();
            var nopeli = repoNopeli.Queryable().FirstOrDefault(x => x.ZetaCodeNormalIplikId == normalIplikId);
            return nopeli;
        }
        public IplikKategoriKircili GetIplikKategoriKirciliByZetaCodeNormalIplikId(int? normalIplikId)
        {
            if (!normalIplikId.HasValue)
                return null;
            var repoKircili = _repository.GetRepositoryAsync<IplikKategoriKircili>();
            var kircili = repoKircili.Queryable().FirstOrDefault(x => x.ZetaCodeNormalIplikId == normalIplikId);
            return kircili;
        }
        public IplikKategoriFlam GetIplikKategoriFlamByZetaCodeNormalIplikId(int? normalIplikId)
        {
            if (!normalIplikId.HasValue)            
                return null;
                
            
            var repoFlam = _repository.GetRepositoryAsync<IplikKategoriFlam>();
            var flam = repoFlam.Queryable().FirstOrDefault(x => x.ZetaCodeNormalIplikId == normalIplikId);
            return flam;
        }

        public ZetaCodeNormalIplikDto GetZetaCodeNormalIplikByMaster()
        {
            var master = _repository.Queryable().Where(x => x.Master).Select(x => new { x.Id, x.SirketId }).FirstOrDefault();
            if (master != null)
            {

                var temp = GetZetaCodeNormalIplikById(master.Id, master.SirketId);
                temp.Id = 0;
                foreach (var iplikNo in temp.IplikNo)
                {
                    iplikNo.Id = 0;
                    iplikNo.ZetaCodeNormalIplikId = 0;
                    iplikNo.ZetaCodeNormalIplik = null;
                }
                return temp;

            }
            return null;
        }
    }
}
