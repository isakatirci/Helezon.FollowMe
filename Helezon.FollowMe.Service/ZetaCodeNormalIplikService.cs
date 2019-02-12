﻿using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.ContainerDtos;
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
        List<ZetaCodeNormalIplikDto> GetAllNormalIplikler(int? id = null, string companyId = null,bool include = false);
        void GetSequenceBlueSiparisNo(SequenceBlueSiparisNo sequenceBlueSiparisNo);
        List<IplikNoGuideDto> GetIplikNoGuideByColumnName(string column);
        void InsertOrUpdate(NormalIplikContainerDto normalIplikContainerDto);
        IplikKategoriSimDto GetIplikKategoriSimByZetaCodeNormalIplikId(int? normalIplikId);
        IplikKategoriDegredeDto GetIplikKategoriDegredeByZetaCodeNormalIplikId(int? normalIplikId);
        IplikKategoriKrepDto GetIplikKategoriKrepByZetaCodeNormalIplikId(int? normalIplikId);
        IplikKategoriNopeliDto GetIplikKategoriNopeliByZetaCodeNormalIplikId(int? normalIplikId);
        IplikKategoriKirciliDto GetIplikKategoriKirciliByZetaCodeNormalIplikId(int? normalIplikId);
        ZetaCodeNormalIplikDto GetZetaCodeNormalIplikByMaster();
        IplikKategoriFlamDto GetIplikKategoriFlamByZetaCodeNormalIplikId(int? normalIplikId);
        ZetaCodeNormalIplikDto GetRenklerOfNormalIplik(int normalIplikId);
        List<ZetaCodeNormalIplikDto> GetAllZetaCodeAndUrunIsmiOfNormalIplikler(int? normalIplikId = null);
        List<ZetaCodeNormalIplikDto> GetZetaCodeIsimler(string companyId);
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
        private readonly ICompanyService _companyService;


        private readonly IRepositoryAsync<IplikKategoriDegrede> _repoDegrede;
        private readonly IRepositoryAsync<IplikKategoriFlam> _repoFlam;
        private readonly IRepositoryAsync<IplikKategoriKircili> _repoKircili;
        private readonly IRepositoryAsync<IplikKategoriKrep> _repoKrep;
        private readonly IRepositoryAsync<IplikKategoriNopeli> _repoNopeli;
        private readonly IRepositoryAsync<IplikKategoriSim> _repoSim;
        private readonly IZetaCodeService _zetaCodeService;



        public ZetaCodeNormalIplikService(IRepositoryAsync<ZetaCodeNormalIplik> repository) : base(repository)
        {
            _repository = repository;
            _repoDegrede = repository.GetRepositoryAsync<IplikKategoriDegrede>();
            _repoFlam = repository.GetRepositoryAsync<IplikKategoriFlam>();
            _repoKircili = repository.GetRepositoryAsync<IplikKategoriKircili>();
            _repoKrep = repository.GetRepositoryAsync<IplikKategoriKrep>();
            _repoNopeli = repository.GetRepositoryAsync<IplikKategoriNopeli>();
            _repoSim = repository.GetRepositoryAsync<IplikKategoriSim>();
            _termService = new TermService(_repository.GetRepositoryAsync<Term>());
            _othersService = new OthersService();
            _companyService = new CompanyService(_repository.GetRepositoryAsync<Company>());
            _zetaCodeService = new ZetaCodeService(_repository.GetRepositoryAsync<ZetaCodes>());
        }
        public List<ZetaCodeNormalIplikDto> GetZetaCodeIsimler(string companyId)
        {
            return _repository.QueryableNoTracking().Where(x => /*x.CompanyId == companyId &&*/ !x.IsPassive)
                .Select(x => new ZetaCodeNormalIplikDto
                {
                    ZetaCode = x.ZetaCode,
                    UrunIsmi = x.UrunIsmi,
                    Id = x.Id
                }).ToList();
        }

        public List<RenkDto> GetRenkler(int dilId)
        {
            var repository = _repository.GetRepository<Renk>().Queryable();
            return AutoMapperConfig.Mapper.Map<IOrderedEnumerable<Renk>, List<RenkDto>>(repository.Where(x => x.DilId == dilId).ToList().OrderBy(x => x.Ad));
        }
        public List<PantoneRenkDto> GetPantoneRenkler()
        {
            var reposiyory = _repository.GetRepository<PantoneRenk>().QueryableNoTracking();
            return AutoMapperConfig.Mapper.Map<List<PantoneRenk>, List<PantoneRenkDto>>(reposiyory.ToList());

            //return reposiyory.Select(x => new PantoneRenkDto { Id = x.Id, PantoneKodu = x.PantoneKodu + " " + x.PantoneRengi }).ToList();
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

            //var normalIplikDto = AutoMapperConfig.Mapper.Map<ZetaCodeNormalIplik, ZetaCodeNormalIplikDto>(entity);
            //if (includeIplikNo)
            //{
            //    normalIplikDto.IplikNo = AutoMapperConfig.Mapper.Map<List<IplikNo>, List<IplikNoDto>>(entity.IplikNo.Where(x => !x.IsPassive).ToList());

            //    normalIplikDto.RafyeriTurkiyeName = _termService.GetTermNameById(normalIplikDto.RafyeriTurkiyeId);
            //    normalIplikDto.RafyeriYunanistanName = _termService.GetTermNameById(normalIplikDto.RafyeriYunanistanId);
            //    normalIplikDto.IplikKategosiName = _termService.GetTermNameById(normalIplikDto.IplikKategosiId);

            //    normalIplikDto.Company = AutoMapperConfig.Mapper.Map<Company, CompanyDto>(entity.Company);
            //    foreach (var item in normalIplikDto.IplikNo)
            //    {
            //        item.ElyafCinsiKalitesiName = _termService.GetTermNameById(item.ElyafCinsiKalitesi);
            //    }
            //}   
            //return normalIplikDto;
            return null;
        }

        private Expression<Func<ZetaCodeNormalIplik, bool>> QueryNormalIplik(int? id = null, string companyId = null)
        {
            if (id.HasValue && !string.IsNullOrWhiteSpace(companyId))            
                return x => x.Id == id && x.SirketId == companyId;
            return null;
        }

        public ZetaCodeNormalIplikDto GetRenklerOfNormalIplik(int normalIplikId)
        {
            //var normalIplik = _repository.Query(x => x.Id == normalIplikId).Include(x => x.Renk).Include(x => x.PantoneRenk).Select(x => x).FirstOrDefault();
            //if (normalIplik == null)
            //{
            //    return null;
            //}

            //var temp = AutoMapperConfig.Mapper.Map<ZetaCodeNormalIplik, ZetaCodeNormalIplikDto>(normalIplik);
            //temp.Renk = AutoMapperConfig.Mapper.Map<Renk, RenkDto>(normalIplik.Renk);
            //temp.PantoneRenk = AutoMapperConfig.Mapper.Map<PantoneRenk, PantoneRenkDto>(normalIplik.PantoneRenk);

            //return temp;
            return null;
        }
        public List<ZetaCodeNormalIplikDto> GetAllZetaCodeAndUrunIsmiOfNormalIplikler(int? normalIplikId = null)
        {
            IQueryFluent<ZetaCodeNormalIplik> query = null;

            if (normalIplikId.HasValue)
            {
                query = _repository.Query(x => x.Id == normalIplikId.Value);
            }
            else
            {
                query = _repository.Query();
            }

            return query.Select(x => new ZetaCodeNormalIplikDto
            {
                Id = x.Id,
                UrunIsmi = x.UrunIsmi,
                ZetaCode = x.ZetaCode
            }).ToList();
        }


  

        public List<ZetaCodeNormalIplikDto> GetAllNormalIplikler(int? id = null, string companyId = null, bool include = false)
        {
            //var query = _repository.QueryableNoTracking().ToList();

            //if (include)            
            //    query = query.Include(x => x.PantoneRenk).Include(x => x.Renk).Include(x => x.IplikNo)
            //        .Include(x=>x.IplikKategoriFlam)
            //        .Include(x => x.IplikKategoriKircili)
            //        .Include(x => x.IplikKategoriKrep)
            //        .Include(x => x.IplikKategoriNopeli)
            //        .Include(x => x.IplikKategoriSim)
            //        .Include(x => x.IplikKategoriDegrede);

            //var zetaCodeNormalIplikler = query.Select(x => x).ToList();
            //var zetaCodeNormalIplikDtos = new List<ZetaCodeNormalIplikDto>();

            //foreach (var iplik in zetaCodeNormalIplikler)
            //{
            //    var iplikDto = AutoMapperConfig.Mapper.Map<ZetaCodeNormalIplik, ZetaCodeNormalIplikDto>(iplik);
            //    if (include)
            //    {
            //        iplikDto.IplikNo = AutoMapperConfig.Mapper.Map<ICollection<IplikNo>, List<IplikNoDto>>(iplik.IplikNo);
            //        iplikDto.PantoneRenk = AutoMapperConfig.Mapper.Map<PantoneRenk, PantoneRenkDto>(iplik.PantoneRenk);
            //        iplikDto.Renk = AutoMapperConfig.Mapper.Map<Renk, RenkDto>(iplik.Renk);

            //        iplikDto.IplikKategoriFlam = AutoMapperConfig.Mapper.Map<IplikKategoriFlam, IplikKategoriFlamDto>(iplik.IplikKategoriFlam);
            //        iplikDto.IplikKategoriKircili = AutoMapperConfig.Mapper.Map<IplikKategoriKircili, IplikKategoriKirciliDto>(iplik.IplikKategoriKircili);
            //        iplikDto.IplikKategoriKrep = AutoMapperConfig.Mapper.Map<IplikKategoriKrep, IplikKategoriKrepDto>(iplik.IplikKategoriKrep);
            //        iplikDto.IplikKategoriNopeli = AutoMapperConfig.Mapper.Map<IplikKategoriNopeli, IplikKategoriNopeliDto>(iplik.IplikKategoriNopeli);
            //        iplikDto.IplikKategoriSim = AutoMapperConfig.Mapper.Map<IplikKategoriSim, IplikKategoriSimDto>(iplik.IplikKategoriSim);
            //        iplikDto.IplikKategoriDegrede = AutoMapperConfig.Mapper.Map<IplikKategoriDegrede, IplikKategoriDegredeDto>(iplik.IplikKategoriDegrede);


            //        if (iplikDto.IplikKategosiId.HasValue)
            //            iplikDto.IplikKategosiName = _termService.GetTermNameById(iplik.IplikKategosiId);
            //        iplikDto.Company = AutoMapperConfig.Mapper.Map<Company, CompanyDto>(iplik.Company);
            //        if (iplikDto.UlkeId.HasValue)
            //            iplikDto.Ulke = _othersService.GetCountryById(iplikDto.UlkeId.Value.ToString());
            //        //if (!string.IsNullOrWhiteSpace(iplikDto.SirketId))
            //        //    iplikDto.Company = _companyService.GetCompanyById(iplikDto.SirketId);
            //        if (iplikDto.UretimTeknolojisiId.HasValue)
            //            iplikDto.UretimTeknolojisiName = _termService.GetTermNameById(iplikDto.UretimTeknolojisiId.Value);
            //        if (iplikDto.RafyeriTurkiyeId.HasValue)
            //            iplikDto.RafyeriTurkiyeName = _termService.GetTermNameById(iplikDto.RafyeriTurkiyeId.Value);
            //        if (iplikDto.RafyeriYunanistanId.HasValue)
            //            iplikDto.RafyeriYunanistanName = _termService.GetTermNameById(iplikDto.RafyeriYunanistanId.Value);

            //    } 
            //    zetaCodeNormalIplikDtos.Add(iplikDto);
            //}            

            //return zetaCodeNormalIplikDtos;  
            return AutoMapperConfig.Mapper.Map<List<ZetaCodeNormalIplik>, List<ZetaCodeNormalIplikDto>>(_repository.QueryableNoTracking().ToList()); 
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
        public override void Insert(ZetaCodeNormalIplik entity)
        {
            //var zetaCode = _repository.Queryable().Max(x => (int?)x.ZetaCode)??0;
            //zetaCode++;
            //var blueSiparisNo = _repository.Queryable()
            //    .Where(x => x.SirketId == zetaCodeNormalIplik.SirketId && x.ZetaCode == zetaCode)
            //    .Max(x => (int?)x.BlueSiparisNo)??0;
            //blueSiparisNo++;
            //Daha sonra bunu başla bir metoda taşı

            var code = _zetaCodeService.GetZetaCodeForIplikInsert();
            //entity.ZetaCode = code;
            entity.Id = code;         
            base.Insert(entity);
        }

        private bool MyInvariantEquals(string s1,string s2)
        {
            return string.Equals(s1, s2, StringComparison.InvariantCultureIgnoreCase);
        }

        Dictionary<int, string> elyafKisaltmalar = new Dictionary<int, string> {
                    {348 ,"CO" },
                    {344 ,"PES"},
                    {350 ,"CV" },
                    {352 ,"LI" },
                    {347 ,"WO" },
                    {353 ,"PA" },
                    {349 ,"EL" },
                    {351 ,"SE" },
                    {354 ,"PAN"},
                    {345 ,"CMD"},
                    {365 ,"CLY"},
                    {364 ,"CA" },
                    {422 ,"CTA"},
                    {423 ,"PP" },
                    {363 ,"PE "},
                    {343 ,"PU" },
                    {346 ,"BAM"},
                    {366 ,"SPF"},
                    {355 ,"CUP"},
                    {362 ,"WN" },
                    {425 ,"WP" },
                    {424 ,"WS" }
        };
        private string GetElyafKisaltma(int termId, string termName)
        {
            if (elyafKisaltmalar.ContainsKey(termId))
                return elyafKisaltmalar[termId];
            return termName;
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

            //foreach (var iplikNo in normalIplikDto.IplikNo)
            //{
            //    var parlaklik = string.Empty;
            //    var elyaf = string.Empty;
            //    if (iplikNo.ElyafCinsiKalitesi.HasValue)
            //    {
            //        var parents = _termService.GetAllParentsById(iplikNo.ElyafCinsiKalitesi.Value);
            //        parents.Reverse();
            //        var count = parents.Count;
            //        if (count == 1)
            //        {
            //            elyaf = parents[0].Name;
            //        }
            //        else if (count == 2)
            //        {
            //            elyaf = GetElyafKisaltma(parents[1].Id, parents[1].Name);
            //        }
            //        else if (count == 3)
            //        {
            //            elyaf = GetElyafKisaltma(parents[1].Id, parents[1].Name);
            //            parlaklik = parents[2].Name;
            //        }                   
            //    }
            //    else
            //    {
            //        elyaflar.Add(string.Empty);
            //    }
            //    elyaflar.Add(elyaf);
            //    parlakliklar.Add(parlaklik);
            //    elyafOranlari.Add(iplikNo.ElyafOrani ?? 0);
            //}
            var urunIsmi = string.Format("{0} - {1} - {2} - {3} - {4}", iplikNoCinsi, iplikKategorisi, string.Join("/", elyafOranlari), string.Join("/", elyaflar), string.Join("/", parlakliklar));
            normalIplikDto.UrunIsmi = urunIsmi;
        }

        public void InsertOrUpdate(NormalIplikContainerDto normalIplikContainerDto)
        {
            try
            {
                _repository.UnitOfWorkAsync().BeginTransaction();
                var normalIplikDto = normalIplikContainerDto.NormalIplik;
                IplikUrunIsmiOlustur(normalIplikDto);
                if (normalIplikDto.Master)
                    _repository.UnitOfWorkAsync().ExecuteSqlCommand("UPDATE ZetaCodeNormalIplik SET Master = 0 WHERE MASTER = 1");
                var normalIplik = AutoMapperConfig.Mapper.Map<ZetaCodeNormalIplikDto, ZetaCodeNormalIplik>(normalIplikDto);
                var iplikNoService = new IplikNoService(_repository.GetRepositoryAsync<IplikNo>());
                var repoSim = _repository.GetRepositoryAsync<IplikKategoriSim>();
                var repoDegrede = _repository.GetRepositoryAsync<IplikKategoriDegrede>();
                var repoFlam = _repository.GetRepositoryAsync<IplikKategoriFlam>();
                var repoKircili = _repository.GetRepositoryAsync<IplikKategoriKircili>();
                var repoKrep = _repository.GetRepositoryAsync<IplikKategoriKrep>();
                var repoNopeli = _repository.GetRepositoryAsync<IplikKategoriNopeli>();

                normalIplik.SirketId = normalIplikContainerDto.Company.Id;

                if (normalIplik.Id > 0)
                {
                    this.Update(normalIplik);
                }
                else
                {
                    this.Insert(normalIplik);
                }

                _repository.UnitOfWorkAsync().SaveChanges();          


                if (normalIplikContainerDto.Degrede != null)
                {
                    var degrede = AutoMapperConfig.Mapper.Map<IplikKategoriDegredeDto, IplikKategoriDegrede>(normalIplikContainerDto.Degrede);
                    degrede.ZetaCodeNormalIplikId = normalIplik.Id;
                    if (degrede.Id > 0)
                    {
                        _repoDegrede.Update(degrede);
                    }
                    else
                    {
                        _repoDegrede.Insert(degrede);
                    }
                }
                var flam = normalIplikContainerDto.Degrede;
                if (flam != null)
                {
                    flam.ZetaCodeNormalIplikId = normalIplik.Id;
                }
                var kircili = normalIplikContainerDto.Degrede;
                if (kircili != null)
                {
                    kircili.ZetaCodeNormalIplikId = normalIplik.Id;
                }
                var krep = normalIplikContainerDto.Degrede;
                if (krep != null)
                {
                    krep.ZetaCodeNormalIplikId = normalIplik.Id;
                }

                var nopeli = normalIplikContainerDto.Degrede;
                if (nopeli != null)
                {
                    nopeli.ZetaCodeNormalIplikId = normalIplik.Id;
                }
                var sim = normalIplikContainerDto.Degrede;
                if (sim != null)
                {
                    sim.ZetaCodeNormalIplikId = normalIplik.Id;
                }

                var activeIplikNoIds = new List<int>();    
                
                var sum = 0;
                var iplikNolar= AutoMapperConfig.Mapper.Map<List<IplikNoDto>, List<IplikNo>>(normalIplikContainerDto.IplikNolar); 
                foreach (var iplikNo in iplikNolar)
                {
                    sum += iplikNo.ElyafOrani ?? 0;
                    if (iplikNo.Id > 0)
                    {
                        iplikNoService.Update(iplikNo);
                        activeIplikNoIds.Add(iplikNo.Id);
                    }
                    else
                    {
                        iplikNoService.Insert(iplikNo);
                    }
                }

                if (normalIplik.Id > 0)
                {
                    var passiveIplikNolar = iplikNoService.Queryable()
                        .Where(x => x.ZetaCodeNormalIplikId == normalIplik.Id && !activeIplikNoIds.Contains(x.Id) && !x.IsPassive).ToList();
                    foreach (var passiveIplikNo in passiveIplikNolar)
                    {
                        passiveIplikNo.IsPassive = true;
                        iplikNoService.Update(passiveIplikNo);
                    }
                }

                _repository.UnitOfWorkAsync().SaveChanges();

                if (iplikNolar != null && iplikNolar.Any() && sum != 100)
                {
                    throw new Exception("Elyaf Oranı %100 olmalıdır");
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

        //           iplikDto.IplikKategoriFlam = ;
        //                    iplikDto.IplikKategoriKircili = 
        //                    iplikDto.IplikKategoriKrep = 
        //                    iplikDto.IplikKategoriNopeli = 
        //                    iplikDto.IplikKategoriSim = AutoMapperConfig.Mapper.Map<IplikKategoriSim, IplikKategoriSimDto>(iplik.IplikKategoriSim);
        //                    iplikDto.IplikKategoriDegrede = AutoMapperConfig.Mapper.Map<IplikKategoriDegrede, IplikKategoriDegredeDto>(iplik.IplikKategoriDegrede);



        public IplikKategoriSimDto GetIplikKategoriSimByZetaCodeNormalIplikId(int? normalIplikId)
        {
            if (!normalIplikId.HasValue)
                return null;
            var repoSim = _repository.GetRepositoryAsync<IplikKategoriSim>();

            var sim = repoSim.Queryable().FirstOrDefault(x => x.ZetaCodeNormalIplikId == normalIplikId);
            return AutoMapperConfig.Mapper.Map<IplikKategoriSim, IplikKategoriSimDto>(sim); 
        }
        public IplikKategoriDegredeDto GetIplikKategoriDegredeByZetaCodeNormalIplikId(int? normalIplikId)
        {
            if (!normalIplikId.HasValue)
                return null;
            var repoDegrede = _repository.GetRepositoryAsync<IplikKategoriDegrede>();

            var degrede = repoDegrede.Queryable().FirstOrDefault(x => x.ZetaCodeNormalIplikId == normalIplikId);
            return AutoMapperConfig.Mapper.Map<IplikKategoriDegrede, IplikKategoriDegredeDto>(degrede);
        }
        public IplikKategoriKrepDto GetIplikKategoriKrepByZetaCodeNormalIplikId(int? normalIplikId)
        {
            if (!normalIplikId.HasValue)
                return null;
            var repoKrep = _repository.GetRepositoryAsync<IplikKategoriKrep>();

            var krep = repoKrep.Queryable().FirstOrDefault(x => x.ZetaCodeNormalIplikId == normalIplikId);
            return AutoMapperConfig.Mapper.Map<IplikKategoriKrep, IplikKategoriKrepDto>(krep);
        }

        public IplikKategoriNopeliDto GetIplikKategoriNopeliByZetaCodeNormalIplikId(int? normalIplikId)
        {
            if (!normalIplikId.HasValue)
                return null;
            var repoNopeli = _repository.GetRepositoryAsync<IplikKategoriNopeli>();
            var nopeli = repoNopeli.Queryable().FirstOrDefault(x => x.ZetaCodeNormalIplikId == normalIplikId);
            return AutoMapperConfig.Mapper.Map<IplikKategoriNopeli, IplikKategoriNopeliDto>(nopeli);
        }
        public IplikKategoriKirciliDto GetIplikKategoriKirciliByZetaCodeNormalIplikId(int? normalIplikId)
        {
            if (!normalIplikId.HasValue)
                return null;
            var repoKircili = _repository.GetRepositoryAsync<IplikKategoriKircili>();
            var kircili = repoKircili.Queryable().FirstOrDefault(x => x.ZetaCodeNormalIplikId == normalIplikId);
            return AutoMapperConfig.Mapper.Map<IplikKategoriKircili, IplikKategoriKirciliDto>(kircili);
        }
        public IplikKategoriFlamDto GetIplikKategoriFlamByZetaCodeNormalIplikId(int? normalIplikId)
        {
            if (!normalIplikId.HasValue)            
                return null;
                
            
            var repoFlam = _repository.GetRepositoryAsync<IplikKategoriFlam>();
            var flam = repoFlam.Queryable().FirstOrDefault(x => x.ZetaCodeNormalIplikId == normalIplikId);
            return AutoMapperConfig.Mapper.Map<IplikKategoriFlam, IplikKategoriFlamDto>(flam);
        }

        public ZetaCodeNormalIplikDto GetZetaCodeNormalIplikByMaster()
        {
            //var master = _repository.Queryable().Where(x => x.Master).Select(x => new { x.Id, x.SirketId }).FirstOrDefault();
            //if (master != null)
            //{

            //    var temp = GetZetaCodeNormalIplikById(master.Id, master.SirketId);
            //    temp.Id = 0;
            //    foreach (var iplikNo in temp.IplikNo)
            //    {
            //        iplikNo.Id = 0;
            //        iplikNo.ZetaCodeNormalIplikId = 0;
            //        iplikNo.ZetaCodeNormalIplik = null;
            //    }
            //    return temp;

            //}
            return null;
        }
    }
}
