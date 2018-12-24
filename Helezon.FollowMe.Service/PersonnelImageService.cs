using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Repository.Repositories;
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
    public interface IPersonnelImageService : IService<PersonnelImage>
    {
        void InsertOrUpdate(PersonnelImage entity);
        PersonnelImage GetPersonnelImageByPersonnelId(string personnelId, string companyId);
        string GetPersonnelImageName(string personnelId, string companyId);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class PersonnelImageService : Service<PersonnelImage>, IPersonnelImageService
    {
        private readonly IRepositoryAsync<PersonnelImage> _repository;
        public PersonnelImageService(IRepositoryAsync<PersonnelImage> repository) : base(repository)
        {
            _repository = repository;
        }

        public void InsertOrUpdate(PersonnelImage entity)
        {
            if (entity.Id > 0)
            {
                Update(entity);
            }
            else
            {
                Insert(entity);
            }
        }
        public PersonnelImage GetPersonnelImageByPersonnelId(string personnelId,string companyId)
        {
            return _repository.GetPersonnelImageByPersonnelId(personnelId,companyId);
        }
        
        public string GetPersonnelImageName(string personnelId,string companyId)
        {
            return _repository.GetPersonnelImageName(personnelId, companyId);
        }

        public override void Update(PersonnelImage entity)
        {
            base.Update(entity);
        }

        public override void Insert(PersonnelImage entity)
        {
            // e.g. add business logic here before inserting
            base.Insert(entity);
        }

        public override void Delete(object id)
        {
            // e.g. add business logic here before deleting
            base.Delete(id);
        }
    }
}
