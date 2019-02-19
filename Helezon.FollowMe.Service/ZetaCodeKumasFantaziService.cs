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
    public interface IKumasFanteziService : IService<ZetaCodeKumasFantazi>
    {
        void InsertOrUpdate(KumasFantaziContainerDto container);
        List<ZetaCodeKumasFantaziDto> GetZetaCodeIsimler(string companyId);
        KumasFantaziContainerDto GetCard(int id, string companyId);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class KumasFanteziService : Service<ZetaCodeKumasFantazi>, IKumasFanteziService
    {
        private readonly IRepositoryAsync<ZetaCodeKumasFantazi> _repository;
        private readonly IRepositoryAsync<ZetaCodeKumasMakine> _repoKumasMakine;
        private readonly IRepositoryAsync<ZetaCodeYikamaTalimati> _repoYikamaTalimati;
        private readonly IRepositoryAsync<ZetaCodeNormalIplik> _repoNormalIplik;
        private readonly IRepositoryAsync<ZetaCodeFanteziIplik> _repoFanteziIplik;
        private readonly IRepositoryAsync<ZetaCodeKumasFanteziKumasFantezi> _repoKumasFanteziKumasFantezi;
        private readonly IRepositoryAsync<ZetaCodeKumasFanteziKumasOrmeDokuma> _repoKumasFanteziKumasOrmeDokuma;
        private readonly IZetaCodeService _zetaCodeService;

        public KumasFanteziService(IRepositoryAsync<ZetaCodeKumasFantazi> repository) : base(repository)
        {
            _repository = repository;
            _repoKumasMakine = _repository.GetRepositoryAsync<ZetaCodeKumasMakine>();
            _repoYikamaTalimati = _repository.GetRepositoryAsync<ZetaCodeYikamaTalimati>();
            _repoNormalIplik = _repository.GetRepositoryAsync<ZetaCodeNormalIplik>();
            _repoFanteziIplik = _repository.GetRepositoryAsync<ZetaCodeFanteziIplik>();
            _repoKumasFanteziKumasFantezi = _repository.GetRepositoryAsync<ZetaCodeKumasFanteziKumasFantezi>();
            _repoKumasFanteziKumasOrmeDokuma = _repository.GetRepositoryAsync<ZetaCodeKumasFanteziKumasOrmeDokuma>();
            _zetaCodeService = new ZetaCodeService(_repository.GetRepositoryAsync<ZetaCodes>());
        }


        public List<ZetaCodeKumasFantaziDto> GetZetaCodeIsimler(string companyId)
        {
            return _repository.QueryableNoTracking().Where(x => /*x.CompanyId == companyId &&*/ !x.IsPassive)
                .Select(x => new ZetaCodeKumasFantaziDto
                {
                    ZetaCode = x.ZetaCode,
                    UrunIsmi = x.UrunIsmi,
                    Id=x.Id
                }).ToList();
        }

        private void MetreKgOraniHesapla(ZetaCodeKumasFantaziDto kumasFantazi)
        {
            //normal Kumaştan farklıdır: metre/kg oranı formül: 100000/gram gr/baskılı en cm (çıkan sonuçta virgülden sonra sağda 2 basamak görünsün)  
            kumasFantazi.MetreTulOrani = (100000 / decimal.Parse(kumasFantazi.Gramaj) / decimal.Parse(kumasFantazi.BaskiliEn)).ToString("####.00");
        }

        public override void Insert(ZetaCodeKumasFantazi entity)
        {
            var code = _zetaCodeService.GetZetaCodeForKumasAksesuarInsert();
            //entity.ZetaCode = code;
            entity.Id = code;
            base.Insert(entity);    
        }

        public void InsertOrUpdate(KumasFantaziContainerDto container)
        {
            try
            {
                _repository.UnitOfWorkAsync().BeginTransaction();

                var kumasFantazi = container.KumasFantazi;
                if (kumasFantazi.Id > 0)
                {
                    this.Update(kumasFantazi);
                }
                else
                {
                    this.Insert(kumasFantazi);
                }
                _repository.UnitOfWorkAsync().SaveChanges();

                var yikamaTalimati = container.YikamaTalimati;             

                if (yikamaTalimati.Id > 0)
                {
                    _repoYikamaTalimati.Update(yikamaTalimati);
                }
                else
                {
                    _repoYikamaTalimati.Insert(yikamaTalimati);
                }

                var kumasMakine = container.KumasMakine;
                if (kumasMakine.Id > 0)
                {
                    _repoKumasMakine.Update(kumasMakine);
                }
                else
                {
                    _repoKumasMakine.Insert(kumasMakine);
                }

                _repository.UnitOfWorkAsync().SaveChanges();

                kumasFantazi.YikamaTalimatiId = yikamaTalimati.Id;
                kumasFantazi.KumasMakineId = kumasMakine.Id;
                this.Update(kumasFantazi);
                _repository.UnitOfWorkAsync().SaveChanges();
                if (container.KumasFanteziler != null && container.KumasFanteziler.Any())
                {
                    var kumasFanteziler = container.KumasFanteziler;
                    for (int i = 0; i < kumasFanteziler.Count; i++)
                    {
                        //if (kumasFanteziler[i].KumasOtherFanteziId < 1)
                        //    continue;
                        //kumasFanteziler[i].KumasFanteziId = kumasFantazi.Id;
                        //if (kumasFanteziler[i].Id > 0)
                        //{
                        //    _repoKumasFanteziKumasFantezi.Update(kumasFanteziler[i]);
                        //}
                        //else
                        //{
                        //    _repoKumasFanteziKumasFantezi.Insert(kumasFanteziler[i]);
                        //}
                    }
                }              

                if (container.KumasOrmeDokumalar != null && container.KumasOrmeDokumalar.Any())
                {
                    var ormeDokumalar= container.KumasOrmeDokumalar;
                    for (int i = 0; i < ormeDokumalar.Count; i++)
                    {
                        //if (ormeDokumalar[i].KumasOrmeDokumaId < 1)                        
                        //    continue;                        
                        //ormeDokumalar[i].KumasFanteziId = kumasFantazi.Id;
                        //if (ormeDokumalar[i].Id > 0)
                        //{
                        //    _repoKumasFanteziKumasOrmeDokuma.Update(ormeDokumalar[i]);
                        //}
                        //else
                        //{
                        //    _repoKumasFanteziKumasOrmeDokuma.Insert(ormeDokumalar[i]);
                        //}
                    }
                }
                _repository.UnitOfWorkAsync().SaveChanges();
                _repository.UnitOfWorkAsync().Commit();
            }
            catch (Exception)
            {
                _repository.UnitOfWorkAsync().Rollback();
                throw;
            }
        }

        public KumasFantaziContainerDto GetCard(int id, string companyId)
        {
            var container = new KumasFantaziContainerDto();
            var kumasFantazi = _repository.QueryableNoTracking().FirstOrDefault(x => x.Id == id);
            if (kumasFantazi == null)
            {
                return container;
            }
            container.KumasFantazi = kumasFantazi;
            if (kumasFantazi.YikamaTalimatiId.HasValue)
            {
                container.YikamaTalimati = _repoYikamaTalimati.QueryableNoTracking().FirstOrDefault(x => x.Id == kumasFantazi.YikamaTalimatiId);
            }
            if (kumasFantazi.KumasMakineId.HasValue)
            {
                container.KumasMakine = _repoKumasMakine.QueryableNoTracking().FirstOrDefault(x => x.Id == kumasFantazi.KumasMakineId);
            }
            return container;
        }
    }

}
