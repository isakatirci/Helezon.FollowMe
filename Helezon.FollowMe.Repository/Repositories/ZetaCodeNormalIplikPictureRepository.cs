using Helezon.FollowMe.Entities.Models;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Repository.Repositories
{
    public static class ZetaCodeNormalIplikPictureRepository
    {
        public static string GetZetaCodeNormalIplikPictureName(this IRepositoryAsync<ZetaCodeNormalIplikPicture> repository
            , int zetaCodeNormalIplikId
            , string companyId)
        {
            return repository.Queryable()
              .Where(x => x.CompanyId == companyId && x.ZetaCodeNormalIplikId == zetaCodeNormalIplikId && x.IsFeatured && !x.IsPassive)
              .Select(x => x.Name)
              .FirstOrDefault();
        }


        public static ZetaCodeNormalIplikPicture GetByPictureName(this IRepositoryAsync<ZetaCodeNormalIplikPicture> repository
            , string imageName)
        {
            return repository
                .Queryable()
                .SingleOrDefault(x => x.Name == imageName && !x.IsPassive);
        }

        public static List<ZetaCodeNormalIplikPicture> GetAllByFeatured(this IRepositoryAsync<ZetaCodeNormalIplikPicture> repository
            , int zetaCodeNormalIplikId
            , string companyId)
        {
            return repository
                .Queryable()
                .Where(x => x.IsFeatured && x.CompanyId == companyId && x.ZetaCodeNormalIplikId == zetaCodeNormalIplikId && !x.IsPassive)
                .ToList();
        }
        public static List<ZetaCodeNormalIplikPicture> GetAll(this IRepositoryAsync<ZetaCodeNormalIplikPicture> repository
            , int zetaCodeNormalIplikId
            , string companyId)
        {
            return repository
                .Queryable()
                .Where(x => x.CompanyId == companyId && x.ZetaCodeNormalIplikId == zetaCodeNormalIplikId && !x.IsPassive)
                .ToList();
        }
    }
}
