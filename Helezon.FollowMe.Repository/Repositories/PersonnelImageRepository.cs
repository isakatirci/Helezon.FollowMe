using Helezon.FollowMe.Entities.Models;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Repository.Repositories
{
    public static class PersonnelImageRepository
    {
        private static readonly Lazy<PersonnelImage> lazy = new Lazy<PersonnelImage>(() => new PersonnelImage()
        {
            Id = 0,
            Name = "noimage.png",
            IsPassive = true,
            CreatedOn = DateTime.MinValue,
            CreatedBy = Guid.Empty.ToString(),
            CompanyId = string.Empty,
            PersonnelId = string.Empty
        });

        public static PersonnelImage NullPersonnelImage { get { return lazy.Value; } }
        public static string GetPersonnelImageName(this IRepositoryAsync<PersonnelImage> repository, string personnelId, string companyId)
        {
            return repository.Queryable()
              .Where(x => x.CompanyId == companyId && x.PersonnelId == personnelId)
              .Select(x => x.Name)
              .FirstOrDefault() ?? "noimage.png";
        }

        public static PersonnelImage GetPersonnelImageByPersonnelId(this IRepositoryAsync<PersonnelImage> repository, string personnelId, string companyId)
        {
            return repository.Queryable()
                .FirstOrDefault(x => x.CompanyId == companyId && x.PersonnelId == personnelId) ?? NullPersonnelImage;
        }
    }
}
