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
    public interface IAksesuarService : IService<ZetaCodeAksesuar>
    {
        List<ZetaCodeAksesuarDto> GetZetaCodeIsimler(string companyId);
        void InsertOrUpdate(AksesuarContainerDto container);
        AksesuarContainerDto GetCard(int id, string company);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class AksesuarService : Service<ZetaCodeAksesuar>, IAksesuarService
    {
        private readonly IRepositoryAsync<ZetaCodeAksesuar> _repository;
        private readonly IRepositoryAsync<ZetaCodeAksesuarKompozisyon> _repoKompozisyon;
        private readonly IZetaCodeService _zetaCodeService;
        private readonly ITermService _termService;
        private readonly IOthersService _othersService;
        private readonly IRepositoryAsync<Renk> _repoRenk;
        private readonly IRepositoryAsync<PantoneRenk> _repoPantoneRenk;
        private readonly IRepositoryAsync<Company> _repoCompany;

        public AksesuarService(IRepositoryAsync<ZetaCodeAksesuar> repository) : base(repository)
        {
            _repository = repository;
            _repoKompozisyon = _repository.GetRepositoryAsync<ZetaCodeAksesuarKompozisyon>();
            _repoCompany = _repository.GetRepositoryAsync<Company>();
            _repoPantoneRenk = _repository.GetRepositoryAsync<PantoneRenk>();
            _repoRenk = _repository.GetRepositoryAsync<Renk>();
            _zetaCodeService = new ZetaCodeService(_repository.GetRepositoryAsync<ZetaCodes>());
            _termService = new TermService(_repository.GetRepositoryAsync<Term>());
            _othersService = new OthersService();
        }

        public AksesuarContainerDto GetCard(int id, string company)
        {
            var container = new AksesuarContainerDto();
            var aksesuar = _repository.QueryableNoTracking().FirstOrDefault(x => x.Id == id);
            if (aksesuar == null)
            {
                return container;
            }
            if (aksesuar.Renkid.HasValue)
            {
                container.Renk = _repoRenk.QueryableNoTracking().FirstOrDefault(x => x.Id == aksesuar.Renkid);
            }
            if (aksesuar.PantoneId.HasValue)
            {
                container.PantoneRenk = _repoPantoneRenk.QueryableNoTracking().FirstOrDefault(x => x.Id == aksesuar.PantoneId);
            }
            if (!string.IsNullOrWhiteSpace(aksesuar.CompanyId))
            {
                container.Company = _repoCompany.QueryableNoTracking().FirstOrDefault(x => x.Id == aksesuar.CompanyId);
            }
            if (aksesuar.UlkeId.HasValue)
            {
                container.Ulke = _othersService.GetCountryById(aksesuar.UlkeId.Value);
            }            
            container.RafyeriTurkiye = _termService.GetTermById(aksesuar.RafyeriTurkiyeId.Value);
            container.RafyeriTurkiye = _termService.GetTermById(aksesuar.RafyeriYunanistanId.Value);

            return container;
        }

        public List<ZetaCodeAksesuarDto> GetZetaCodeIsimler(string companyId)
        {
            return _repository.QueryableNoTracking().Where(x => /*x.CompanyId == companyId &&*/ !x.IsPassive)
                .Select(x => new ZetaCodeAksesuarDto
                {
                    ZetaCode = x.ZetaCode,
                    UrunKompozisyonu = x.UrunKompozisyonu,
                    Id = x.Id
                }).ToList();
        }

        public override void Insert(ZetaCodeAksesuar entity)
        {
            entity.Id = _zetaCodeService.GetZetaCodeForKumasAksesuarInsert();
            base.Insert(entity);
        }
        public void InsertOrUpdate(AksesuarContainerDto container)
        {
            try
            {
                _repository.UnitOfWorkAsync().BeginTransaction();
                var aksesuar = container.Aksesuar;
                if (aksesuar.Id > 0)
                {
                    this.Update(aksesuar);
                }
                else
                {
                    this.Insert(aksesuar);
                }
                _repository.UnitOfWorkAsync().SaveChanges();

                var kompozisyonlar = container.AksesuarKompozisyonlar; ;

                if (kompozisyonlar != null && kompozisyonlar.Any())
                {
                    foreach (var kompozisyon in kompozisyonlar)
                    {
                        kompozisyon.AksesuarId = aksesuar.Id;
                        if (kompozisyon.Id>0)
                        {
                            _repoKompozisyon.Update(kompozisyon);
                        }
                        else
                        {
                            _repoKompozisyon.Insert(kompozisyon);
                        }
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
