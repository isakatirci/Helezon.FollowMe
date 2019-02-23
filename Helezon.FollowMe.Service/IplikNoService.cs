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
    public interface IIplikNoService : IService<IplikNo>
    {
        List<IplikNoDto> GetNormalIplikIplikNolar(int normalIplikId);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class IplikNoService : Service<IplikNo>, IIplikNoService
    {
        private readonly IRepositoryAsync<IplikNo> _repoIplikNo;

        public IplikNoService(IRepositoryAsync<IplikNo> repository) : base(repository)
        {
            _repoIplikNo = repository;
        }
        public List<IplikNoDto> GetNormalIplikIplikNolar(int normalIplikId)
        {

            var queryIplikNo = _repoIplikNo.QueryableNoTracking();
            var queryTerm = _repoIplikNo.GetRepositoryAsync<Term>().QueryableNoTracking();

            var temp = (from i in queryIplikNo
                        join t in queryTerm on i.ElyafCinsiKalitesi equals t.Id
                        where i.ZetaCodeNormalIplikId == normalIplikId
                        select new IplikNoDto { ElyafCinsiKalitesi = t, IplikNo = i }).ToList();

            return temp;
        }
    }
}
