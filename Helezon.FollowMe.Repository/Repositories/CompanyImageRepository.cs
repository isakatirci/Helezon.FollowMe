using Helezon.FollowMe.Entities.Models;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Repository.Repositories
{
    public static class CompanyImageRepository
    {
        private static readonly Lazy<CompanyImage>
            lazyTerm = new Lazy<CompanyImage>(() => new CompanyImage()
            {
                Id = 0,
                Name = "noimage.png",
                IsPassive = true,
                CreatedOn = DateTime.MinValue,
                CreatedBy = Guid.Empty.ToString(),
                CompanyId = string.Empty
            });

        public static CompanyImage NullCompanyImage { get { return lazyTerm.Value; } }
        public static CompanyImage GetCompanyImageByCompanyId(this IRepositoryAsync<CompanyImage> repository, string companyId)
        {
            return repository
                .Queryable()
                .FirstOrDefault(x => x.CompanyId == companyId) ?? NullCompanyImage;
        }
        public static string GetCompanyImageName(this IRepositoryAsync<CompanyImage> repository, string companyId)
        {
            return repository
                .Queryable()
                .Where(x => x.CompanyId == companyId)
                .Select(x => x.Name)
                .FirstOrDefault() ?? "noimage.png";
        }
        //
    }
}
