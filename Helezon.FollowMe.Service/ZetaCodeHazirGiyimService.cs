using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Repository.Repositories;
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

    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class HazirGiyimService : Service<ZetaCodeHazirGiyim>, IHazirGiyimService
    {
        private readonly IRepositoryAsync<ZetaCodeHazirGiyim> _repository;
        public HazirGiyimService(IRepositoryAsync<ZetaCodeHazirGiyim> repository) : base(repository)
        {
            _repository = repository;
        }

        public List<ZetaCodeHazirGiyim> GetAllHazirGiyim(string companyId, int? hazirGiyimId = null)
        {
            return _repository.GetAllHazirGiyim(companyId, hazirGiyimId);
        }

        public ZetaCodeHazirGiyim GetHazirGiyim(string companyId, int hazirGiyimId)
        {
            return GetAllHazirGiyim(companyId, hazirGiyimId).FirstOrDefault();
        }

    }
}
