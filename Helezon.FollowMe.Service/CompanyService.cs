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
using System.Linq.Expressions;
using System;

#endregion

namespace Helezon.FollowMe.Service
{
    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface ICompanyService : IService<Company>
    {
        string FistCompanyName();
        List<CompanyDto> GetParentCompanyIdAndNames(int companyRootType, string sirketId);
        Company GetCompanyById(string companyId);
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

        public Company GetCompanyById(string companyId)
        {
            var company  = _repository.QueryableNoTracking().FirstOrDefault(x => x.Id == companyId);
            if (company == null)            
                return new Company();            
            return company;            
        }

        public Expression<Func<Company, bool>> p1(int companyRootType, string sirketId)
        {
            if (string.IsNullOrWhiteSpace(sirketId))

            {
                return x => x.CompanyRootTypeId == companyRootType && x.ParentId == null;
            }
            else
            {
                return x => x.Id == sirketId && x.CompanyRootTypeId == companyRootType && x.ParentId == null;
            }
        }
        public List<CompanyDto> GetParentCompanyIdAndNames(int companyRootType,string sirketId)
        {

            return _repository
                     .Queryable()
                     .Where(p1(companyRootType,sirketId))
                     .Select(x => new CompanyDto { Id = x.Id, Name = x.Code + " " + x.Name })
                     .ToList();
        }
      
    }
}