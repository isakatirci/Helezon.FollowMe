using Helezon.FollowMe.Core.Code;
using Helezon.FollowMe.Entities.Models;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Repository.Repositories
{
    public static class HazirGiyimRepository
    {
        public static List<ZetaCodeHazirGiyim> GetAllHazirGiyim(this IRepositoryAsync<ZetaCodeHazirGiyim> repository, string companyId, int? hazirGiyimId = null)
        {
            return repository
                .QueryableNoTracking()
                .Where(x => x.CompanyId == companyId && !x.IsPassive)
                .WhereIf(hazirGiyimId.HasValue, x => x.Id == hazirGiyimId)
                .ToList();
        }
        public static ZetaCodeHazirGiyim GetHazirGiyim(this IRepositoryAsync<ZetaCodeHazirGiyim> repository, string companyId, int hazirGiyimId)
        {
            return repository.GetAllHazirGiyim(companyId, hazirGiyimId).FirstOrDefault();
        }
    }
}
