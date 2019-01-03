using Helezon.FollowMe.Entities.Models;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Repository.Repositories
{
    public static class CompanyPictureRepository
    {
        //private static readonly Lazy<CompanyPicture>
        //    lazyTerm = new Lazy<CompanyPicture>(() => new CompanyPicture()
        //    {
        //        Id = 0,
        //        Name = "noimage.png",
        //        IsPassive = true,
        //        CreatedOn = DateTime.MinValue,
        //        CreatedBy = Guid.Empty.ToString(),
        //        CompanyId = string.Empty
        //    });

        //public static CompanyPicture NullCompanyPicture { get { return lazyTerm.Value; } }
        //public static CompanyPicture GetCompanyPictureByCompanyId(this IRepositoryAsync<CompanyPicture> repository, string companyId)
        //{
        //    return repository
        //        .Queryable()
        //        .FirstOrDefault(x => x.CompanyId == companyId) ?? NullCompanyPicture;
        //}
        public static string GetCompanyPictureName(this IRepositoryAsync<CompanyPicture> repository, string companyId)
        {
            return repository
                .Queryable()
                .Where(x => x.CompanyId == companyId && x.IsFeatured && !x.IsPassive)
                .Select(x => x.Name)
                .FirstOrDefault();
        }


        public static CompanyPicture GetByPictureName(this IRepositoryAsync<CompanyPicture> repository, string pictureName)
        {
            return repository
                    .Queryable()
                    .SingleOrDefault(x => x.Name == pictureName && !x.IsPassive);
        }

        public static List<CompanyPicture> GetAllByFeatured(this IRepositoryAsync<CompanyPicture> repository, string companyId)
        {
            return repository
                .Queryable()
                .Where(x => x.IsFeatured && x.CompanyId == companyId && !x.IsPassive)
                .ToList();
        }

        public static List<CompanyPicture> GetAll(this IRepositoryAsync<CompanyPicture> repository, string companyId)
        {
            return repository
                .Queryable()
                .Where(x => x.CompanyId == companyId && !x.IsPassive)
                .ToList();
        }
        //
    }
}
