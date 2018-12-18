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

#endregion

namespace Helezon.FollowMe.Service
{
    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface ICompanyService : IService<Company>
    {
        string FistCompanyName();
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
        public string FistCompanyName()
        {
            return _repository.FistCompanyName();
        }
    }
}