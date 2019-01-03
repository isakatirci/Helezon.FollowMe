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
        List<RenkDto> GetRenkler(int dilId = 1);
        //int GetSiparisNoByCompanyCode(int code);
        ZetaCodeNormalIplikDto GetZetaCodeNormalIplikById(int id);
        List<ZetaCodeNormalIplikDto> GetAllZetaCodeNormalIplikler();
        void GetSequenceBlueSiparisNo(SequenceBlueSiparisNo sequenceBlueSiparisNo);
        List<IplikNoGuideDto> GetIplikNoGuideByColumnName(string column);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class ZetaCodeNormalIplikService : Service<ZetaCodeNormalIplik>, IZetaCodeNormalIplikService
    {
        private readonly IRepositoryAsync<ZetaCodeNormalIplik> _repository;

        public ZetaCodeNormalIplikService(IRepositoryAsync<ZetaCodeNormalIplik> repository) : base(repository)
        {
            _repository = repository;
        }

        public List<RenkDto> GetRenkler(int dilId = 2)
        {
            var repository = _repository.GetRepository<Renk>().Queryable();
            return repository.Select(x=>new { x.Id , x.Ad, x.HtmlKod, x.IplikRenkKodu })
                .ToList()
                .Select(x => new RenkDto { Id = x.Id, Ad = x.Ad 
                + "|" + x.HtmlKod 
                + (!string.IsNullOrWhiteSpace(x.IplikRenkKodu) ? "|" + x.IplikRenkKodu : string.Empty)
                }).ToList();
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

        public ZetaCodeNormalIplikDto GetZetaCodeNormalIplikById(int id)
        {
            var entity = _repository.Queryable().FirstOrDefault();
            if (entity == null)
            {
                return null;
            }
            return AutoMapperConfig.Mapper.Map<ZetaCodeNormalIplik, ZetaCodeNormalIplikDto>(entity);
        }

        public override void Insert(ZetaCodeNormalIplik zetaCodeNormalIplikDto)
        {
            base.Insert(zetaCodeNormalIplikDto);
        }

        public List<ZetaCodeNormalIplikDto> GetAllZetaCodeNormalIplikler()
        {
            var zetaCodeNormalIplikler = _repository.Query().Include(x => x.PantoneRenk).Include(x => x.Renk).Include(x => x.IplikNo).Select().ToList();
            var zetaCodeNormalIplikDtos = new List<ZetaCodeNormalIplikDto>();
            foreach (var iplik in zetaCodeNormalIplikler)
            {
                var iplikDto = AutoMapperConfig.Mapper.Map<ZetaCodeNormalIplik, ZetaCodeNormalIplikDto>(iplik);
                iplikDto.IplikNo = AutoMapperConfig.Mapper.Map<ICollection<IplikNo>, List<IplikNoDto>>(iplik.IplikNo);
                iplikDto.PantoneRenk = AutoMapperConfig.Mapper.Map<PantoneRenk, PantoneRenkDto>(iplik.PantoneRenk);
                iplikDto.Renk = AutoMapperConfig.Mapper.Map<Renk, RenkDto>(iplik.Renk);
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
    }
}
