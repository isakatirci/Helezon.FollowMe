using Helezon.FollowMe.Entities.Models;
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
      
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class ZetaCodeAksesuarService : Service<ZetaCodeAksesuar>, IAksesuarService
    {
        public ZetaCodeAksesuarService(IRepositoryAsync<ZetaCodeAksesuar> repository) : base(repository)
        {
        }
    }
}
