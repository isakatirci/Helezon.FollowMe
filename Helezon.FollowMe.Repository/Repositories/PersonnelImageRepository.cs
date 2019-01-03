using Helezon.FollowMe.Entities.Models;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Repository.Repositories
{
    public static class PersonnelPictureRepository
    {
        //private static readonly Lazy<PersonnelPicture> lazy = new Lazy<PersonnelPicture>(() => new PersonnelPicture()
        //{
        //    Id = 0,
        //    Name = "noimage.png",
        //    IsPassive = true,
        //    CreatedOn = DateTime.MinValue,
        //    CreatedBy = Guid.Empty.ToString(),
        //    CompanyId = string.Empty,
        //    PersonnelId = string.Empty
        //});

        //public static PersonnelPicture NullPersonnelPicture { get { return lazy.Value; } }

        //public static PersonnelPicture GetPersonnelPictureByPersonnelId(this IRepositoryAsync<PersonnelPicture> repository, string personnelId, string companyId)
        //{
        //    return repository.Queryable()
        //        .FirstOrDefault(x => x.CompanyId == companyId && x.PersonnelId == personnelId) ?? NullPersonnelPicture;
        //}

        public static string GetPersonnelPictureName(this IRepositoryAsync<PersonnelPicture> repository, string personnelId, string companyId)
        {
            return repository.Queryable()
              .Where(x => x.CompanyId == companyId && x.PersonnelId == personnelId && x.IsFeatured && !x.IsPassive)
              .Select(x => x.Name)
              .FirstOrDefault();
        }

    
        public static PersonnelPicture GetByPictureName(this IRepositoryAsync<PersonnelPicture> repository, string imageName)
        {
            return repository
                .Queryable()
                .SingleOrDefault(x => x.Name == imageName && !x.IsPassive);
        }

        public static List<PersonnelPicture> GetAllByFeatured(this IRepositoryAsync<PersonnelPicture> repository,string personnelId, string companyId)
        {
            return repository
                .Queryable()
                .Where(x => x.IsFeatured && x.CompanyId == companyId && x.PersonnelId == personnelId && !x.IsPassive)
                .ToList();
        }
        public static List<PersonnelPicture> GetAll(this IRepositoryAsync<PersonnelPicture> repository, string personnelId ,string companyId)
        {
            return repository
                .Queryable()
                .Where(x => x.CompanyId == companyId && x.PersonnelId == personnelId && !x.IsPassive)
                .ToList();
        }
    }
}
