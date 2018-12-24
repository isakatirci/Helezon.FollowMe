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
    public interface ICompanyImageService : IService<CompanyImage>
    {
        void InsertOrUpdate(CompanyImage entity);
        CompanyImage GetCompanyImageByCompanyId(string entityId);
        string GetCompanyImageName(string companyId);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class CompanyImageService : Service<CompanyImage>, ICompanyImageService
    {
        private readonly IRepositoryAsync<CompanyImage> _repository;
        public CompanyImageService(IRepositoryAsync<CompanyImage> repository) : base(repository)
        {
            _repository = repository;
        }

        public string GetCompanyImageName(string companyId)
        {
            return _repository.GetCompanyImageName(companyId);
        }
        public CompanyImage GetCompanyImageByCompanyId(string companyId)
        {
            return _repository.GetCompanyImageByCompanyId(companyId);
        }
        public void InsertOrUpdate(CompanyImage entity)
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

    
        public override void Update(CompanyImage entity)
        {
            base.Update(entity);
        }

        public override void Insert(CompanyImage entity)
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
