using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Repository.Repositories;
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
    public interface IHazirGiyimService : IService<ZetaCodeHazirGiyim>
    {
        void InsertOrUpdate(HazirGiyimContainerDto container);
        HazirGiyimContainerDto GetCard(int id, string companyId);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class HazirGiyimService : Service<ZetaCodeHazirGiyim>, IHazirGiyimService
    {
        private readonly IRepositoryAsync<ZetaCodeHazirGiyim> _repository;
        private readonly IRepositoryAsync<ZetaCodeHazirGiyimAksesuar> _repoAksesuarlar;
        private readonly IRepositoryAsync<ZetaCodeHazirGiyimKumasFantezi> _repoKumasFanteziler;
        private readonly IRepositoryAsync<ZetaCodeHazirGiyimKumasOrmeDokuma> _repoKumasOrmeDokumalar;
        private readonly IZetaCodeService _zetaCodeService;
        private readonly ITermService _termService;
        private readonly IOthersService _othersService;
        private readonly IRepositoryAsync<Renk> _repoRenk;
        private readonly IRepositoryAsync<PantoneRenk> _repoPantoneRenk;
        private readonly IRepositoryAsync<Company> _repoCompany;

        public HazirGiyimService(IRepositoryAsync<ZetaCodeHazirGiyim> repository) : base(repository)
        {
            _repository = repository;
            _repoAksesuarlar = _repository.GetRepositoryAsync<ZetaCodeHazirGiyimAksesuar>();
            _repoKumasFanteziler = _repository.GetRepositoryAsync<ZetaCodeHazirGiyimKumasFantezi>();
            _repoKumasOrmeDokumalar = _repository.GetRepositoryAsync<ZetaCodeHazirGiyimKumasOrmeDokuma>();
            _zetaCodeService = new ZetaCodeService(_repository.GetRepositoryAsync<ZetaCodes>());
            _repoCompany = _repository.GetRepositoryAsync<Company>();
            _repoPantoneRenk = _repository.GetRepositoryAsync<PantoneRenk>();
            _repoRenk = _repository.GetRepositoryAsync<Renk>();
            _zetaCodeService = new ZetaCodeService(_repository.GetRepositoryAsync<ZetaCodes>());
            _termService = new TermService(_repository.GetRepositoryAsync<Term>());
            _othersService = new OthersService();
        }

        public List<ZetaCodeHazirGiyim> GetAllHazirGiyim(string companyId, int? hazirGiyimId = null)
        {
            return _repository.GetAllHazirGiyim(companyId, hazirGiyimId);
        }

        public HazirGiyimContainerDto GetCard(int id, string companyId)
        {
            var container = new HazirGiyimContainerDto();
            var entity = _repository.QueryableNoTracking().FirstOrDefault(x=>x.Id == id);
            if (entity == null)
            {
                return container;
            }
            container.HazirGiyim = entity;
            if (entity.Renkid.HasValue)
            {
                container.Renk = _repoRenk.QueryableNoTracking().FirstOrDefault(x => x.Id == entity.Renkid);
            }
            if (entity.PantoneId.HasValue)
            {
                container.PantoneRenk = _repoPantoneRenk.QueryableNoTracking().FirstOrDefault(x => x.Id == entity.PantoneId);
            }
            if (entity.UlkeId.HasValue)
            {
                container.Ulke = _othersService.GetCountryById(entity.UlkeId.Value);
            }
            if (!string.IsNullOrWhiteSpace(entity.CompanyId))
            {
                container.Company = _repoCompany.QueryableNoTracking().FirstOrDefault(x => x.Id == entity.CompanyId);
            }
            return container;
            
        }

        public ZetaCodeHazirGiyim GetHazirGiyim(string companyId, int hazirGiyimId)
        {
            return GetAllHazirGiyim(companyId, hazirGiyimId).FirstOrDefault();
        }

        public override void Insert(ZetaCodeHazirGiyim entity)
        {
            entity.Id = _zetaCodeService.GetZetaCodeForHazirGiyimInsert();
            base.Insert(entity);
        }


        public void InsertOrUpdate(HazirGiyimContainerDto container)
        {
            try
            {
                _repository.UnitOfWorkAsync().BeginTransaction();
                var hazirGiyim = container.HazirGiyim;
                if (hazirGiyim.Id > 0)
                {
                    this.Update(hazirGiyim);
                }
                else
                {
                    this.Insert(hazirGiyim);
                }
                _repository.UnitOfWorkAsync().SaveChanges();




     

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
