using Helezon.FollowMe.Entities.Models;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Repository.Repositories
{
    public static class ZetaCodeFanteziIplikPictureRepository
    {
        public static string GetZetaCodeFanteziIplikPictureName(this IRepositoryAsync<ZetaCodeFanteziIplikPicture> repository
            , int zetaCodeFanteziIplikId
            , string companyId)
        {
            return repository.Queryable()
              .Where(x => x.CompanyId == companyId && x.ZetaCodeFanteziIplikId == zetaCodeFanteziIplikId && x.IsFeatured && !x.IsPassive)
              .Select(x => x.Name)
              .FirstOrDefault();
        }


        public static ZetaCodeFanteziIplikPicture GetByPictureName(this IRepositoryAsync<ZetaCodeFanteziIplikPicture> repository
            , string imageName)
        {
            return repository
                .Queryable()
                .SingleOrDefault(x => x.Name == imageName && !x.IsPassive);
        }

        public static List<ZetaCodeFanteziIplikPicture> GetAllByFeatured(this IRepositoryAsync<ZetaCodeFanteziIplikPicture> repository
            , int zetaCodeFanteziIplikId
            , string companyId)
        {
            return repository
                .Queryable()
                .Where(x => x.IsFeatured && x.CompanyId == companyId && x.ZetaCodeFanteziIplikId == zetaCodeFanteziIplikId && !x.IsPassive)
                .ToList();
        }
        public static List<ZetaCodeFanteziIplikPicture> GetAll(this IRepositoryAsync<ZetaCodeFanteziIplikPicture> repository
            , int zetaCodeFanteziIplikId
            , string companyId)
        {
            return repository
                .Queryable()
                .Where(x => x.CompanyId == companyId && x.ZetaCodeFanteziIplikId == zetaCodeFanteziIplikId && !x.IsPassive)
                .ToList();
        }
    }
}
