using Helezon.FollowMe.Entities.Models;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Repository.Repositories
{
    public static class CompanyRepository
    {
        public static IEnumerable<Company> CompaniesByCompanyRootTypeId(this IRepositoryAsync<Company> repository, int companyRootTypeId)
        {
            return repository
                .Queryable()
                .Where(x => x.CompanyRootTypeId == companyRootTypeId)
                .AsEnumerable();
        }

        public static string FistCompanyName(this IRepositoryAsync<Company> repository)
        {
            return repository.Queryable().First().Name;
        }
    }
}
