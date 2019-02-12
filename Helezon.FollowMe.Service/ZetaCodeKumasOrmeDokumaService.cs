using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.ContainerDtos;
using Helezon.FollowMe.Service.DataTransferObjects;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service
{

    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface IKumasOrmeDokumaService : IService<ZetaCodeKumasOrmeDokuma>
    {
        void InsertOrUpdate(KumasOrmeDokumaContainerDto container);
        List<ZetaCodeKumasOrmeDokumaDto> GetZetaCodeIsimler(string companyId);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class KumasOrmeDokumaService : Service<ZetaCodeKumasOrmeDokuma>, IKumasOrmeDokumaService
    {
        private readonly IRepositoryAsync<ZetaCodeKumasOrmeDokuma> _repository;
        private readonly IRepositoryAsync<ZetaCodeKumasMakine> _repoKumasMakine;
        private readonly IRepositoryAsync<ZetaCodeYikamaTalimati> _repoYikamaTalimati;
        private readonly IRepositoryAsync<ZetaCodeNormalIplik> _repoNormalIplik;
        private readonly IRepositoryAsync<ZetaCodeFanteziIplik> _repoFanteziIplik;
        private readonly ZetaCodeService _zetaCodeService;
        //
        public KumasOrmeDokumaService(IRepositoryAsync<ZetaCodeKumasOrmeDokuma> repository) : base(repository)
        {
            _repository = repository;
            _repoKumasMakine = _repository.GetRepositoryAsync<ZetaCodeKumasMakine>();
            _repoYikamaTalimati = _repository.GetRepositoryAsync<ZetaCodeYikamaTalimati>();
            _repoNormalIplik= _repository.GetRepositoryAsync<ZetaCodeNormalIplik>();
            _repoFanteziIplik = _repository.GetRepositoryAsync<ZetaCodeFanteziIplik>();
            _zetaCodeService = new ZetaCodeService(_repository.GetRepositoryAsync<ZetaCodes>());
        }

        private void MetreKgOraniHesapla(ZetaCodeKumasOrmeDokuma kumasOrmeDokuma)
        {
            //metre/kg oranı formül: 100000/gram gr/en cm (çıkan sonuçta virgülden sonra sağda 2 basamak görünsün)
            kumasOrmeDokuma.MetreTulOrani = (100000 / decimal.Parse(kumasOrmeDokuma.Gramaj) / decimal.Parse(kumasOrmeDokuma.En)).ToString("####.00");
        }

        public List<ZetaCodeKumasOrmeDokumaDto> GetZetaCodeIsimler(string companyId)
        {
            return _repository.QueryableNoTracking().Where(x => /*x.CompanyId == companyId &&*/ !x.IsPassive)
                .Select(x => new ZetaCodeKumasOrmeDokumaDto
                {
                    ZetaCode = x.ZetaCode,
                    UrunIsmi = x.UrunIsmi,
                    Id=x.Id
                }).ToList();
        }

        public override void Insert(ZetaCodeKumasOrmeDokuma entity)
        {
            var code = _zetaCodeService.GetZetaCodeForKumasAksesuarInsert();
            //entity.ZetaCode = code;
            entity.Id = code;
            base.Insert(entity);
        }




        public void InsertOrUpdate(KumasOrmeDokumaContainerDto container)
        {
            try
            {
                _repository.UnitOfWorkAsync().BeginTransaction();

                var kumasOrmeDokuma = AutoMapperConfig.Mapper.Map<ZetaCodeKumasOrmeDokumaDto, ZetaCodeKumasOrmeDokuma>(container.KumasOrmeDokuma);
                if (kumasOrmeDokuma.Id > 0)
                {
                    this.Update(kumasOrmeDokuma);
                }
                else
                {
                    this.Insert(kumasOrmeDokuma);
                }

                _repository.UnitOfWorkAsync().SaveChanges();

                var yikamaTalimati = AutoMapperConfig.Mapper.Map<ZetaCodeYikamaTalimatiDto, ZetaCodeYikamaTalimati>(container.YikamaTalimati);



                if (yikamaTalimati.Id > 0)
                {
                    _repoYikamaTalimati.Update(yikamaTalimati);
                }
                else
                {
                    _repoYikamaTalimati.Insert(yikamaTalimati);
                }

                var kumasMakine = AutoMapperConfig.Mapper.Map<ZetaCodeKumasMakineDto, ZetaCodeKumasMakine>(container.KumasMakine);
                if (kumasMakine.Id > 0)
                {
                    _repoKumasMakine.Update(kumasMakine);
                }
                else
                {
                    _repoKumasMakine.Insert(kumasMakine);
                }

                _repository.UnitOfWorkAsync().SaveChanges();

                kumasOrmeDokuma.YikamaTalimatiId = yikamaTalimati.Id;
                kumasOrmeDokuma.KumasMakineId = kumasMakine.Id;
                this.Update(kumasOrmeDokuma);
                _repository.UnitOfWorkAsync().SaveChanges();
                if (container.NormalIplikler != null && container.NormalIplikler.Any())
                {
                    var normalIplikler = AutoMapperConfig.Mapper.Map<List<ZetaCodeNormalKumasNormalIplikDto>, List<ZetaCodeNormalKumasNormalIplik>>(container.NormalIplikler);
                    for (int i = 0; i < normalIplikler.Count; i++)
                    {
                        if (normalIplikler[i].NormalKumasId > 0)
                        {

                        }
                        else
                        {

                        }
                    }
                }

                if (container.FanteziIplikler != null && container.FanteziIplikler.Any())
                {
                    var fanteziIplikler = AutoMapperConfig.Mapper.Map<List<ZetaCodeNormalKumasFanteziIplikDto>, List<ZetaCodeNormalKumasFanteziIplik>>(container.FanteziIplikler);
                    for (int i = 0; i < fanteziIplikler.Count; i++)
                    {
                        if (fanteziIplikler[i].NormalKumasId > 0)
                        {

                        }
                        else
                        {

                        }
                    }
                }

                this.Update(kumasOrmeDokuma);
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
