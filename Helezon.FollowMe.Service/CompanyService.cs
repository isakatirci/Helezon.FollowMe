#region
using System.Linq;
using System.Collections.Generic;
using Repository.Pattern.Repositories;
using Service.Pattern;
using Helezon.FollowMe.Entities;
using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Core.Aspects.Postsharp.ValidationAspects;
using Helezon.FollowMe.Service.ValidationRules.FluentValidation;
using Helezon.FollowMe.Repository.Repositories;
using Helezon.FollowMe.Core.Aspects.Postsharp.CacheAspects;
using Helezon.FollowMe.Core.CrossCuttingConcerns.Caching.Microsoft;
using System.Collections;
using Helezon.FollowMe.Service.DataTransferObjects;

#endregion

namespace Helezon.FollowMe.Service
{
    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface ICompanyService : IService<Company>
    {
        string FistCompanyName();
        List<CompanyDto> GetParentCompanyIdAndNames(int companyRootType);
        CompanyDto GetCompanyById(string companyId);
        CompanyDto GetCompanyCodeById(string companyId);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class CompanyService : Service<Company>, ICompanyService
    {
        private readonly IRepositoryAsync<Company> _repository;

        public CompanyService(IRepositoryAsync<Company> repository) : base(repository)
        {
            _repository = repository;
        }

        [FluentValidationAspect(typeof(CompanyValidatior))]
        [CacheAspect(typeof(MemoryCacheManager))]
        public string FistCompanyName()
        {
            return _repository.FistCompanyName();
        }

        public CompanyDto GetCompanyCodeById(string companyId)
        {
            return _repository.Queryable()
                .Where(x => x.Id == companyId)
                .Select(x => new CompanyDto
                {
                    Id = x.Id,
                    Code = x.Code
                }).FirstOrDefault();
        }

        public CompanyDto GetCompanyById(string companyId)
        {
            var company  = _repository.Queryable().FirstOrDefault(x => x.Id == companyId);
            if (company == null)            
                return null;            
            return AutoMapperConfig.Mapper.Map<Company, CompanyDto>(company);            
        }

        public List<CompanyDto> GetParentCompanyIdAndNames(int companyRootType)
        {
            return _repository
                     .Queryable()
                     .Where(x=>x.CompanyRootTypeId == companyRootType && x.ParentId == null)
                     .Select(x => new CompanyDto { Id = x.Id, Name = x.Code + " " + x.Name })
                     .ToList();
        }
      
    }
}