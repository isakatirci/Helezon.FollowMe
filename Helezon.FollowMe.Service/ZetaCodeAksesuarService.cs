using Helezon.FollowMe.Entities.Models;
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
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class AksesuarService : Service<ZetaCodeAksesuar>, IAksesuarService
    {
        private IRepositoryAsync<ZetaCodeAksesuar> _repository;
        public AksesuarService(IRepositoryAsync<ZetaCodeAksesuar> repository) : base(repository)
        {
            _repository = repository;
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
    }
}
