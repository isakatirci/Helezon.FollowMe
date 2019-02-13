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

        public AksesuarService(IRepositoryAsync<ZetaCodeAksesuar> repository) : base(repository)
        {
            _repository = repository;
            _repoKompozisyon = _repository.GetRepositoryAsync<ZetaCodeAksesuarKompozisyon>();
            _zetaCodeService = new ZetaCodeService(_repository.GetRepositoryAsync<ZetaCodes>());
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
                var aksesuar = AutoMapperConfig.Mapper.Map<ZetaCodeAksesuarDto, ZetaCodeAksesuar>(container.Aksesuar);
                if (aksesuar.Id > 0)
                {
                    this.Update(aksesuar);
                }
                else
                {
                    this.Insert(aksesuar);
                }
                _repository.UnitOfWorkAsync().SaveChanges();

                var kompozisyonlar = AutoMapperConfig.Mapper.Map<List<ZetaCodeAksesuarKompozisyonDto>,List<ZetaCodeAksesuarKompozisyon>>(container.AksesuarKompozisyonlar); ;

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
