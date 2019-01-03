using Helezon.FollowMe.Entities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helezon.FollowMe.Repository.Repositories;

namespace Helezon.FollowMe.Service
{
    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface IPersonnelTermService : IService<PersonnelTerm>
    {
        //List<PersonnelTerm> GetPositions();
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class PersonnelTermService : Service<PersonnelTerm>, IPersonnelTermService
    {
        private readonly IRepositoryAsync<PersonnelTerm> _repository;
        public PersonnelTermService(IRepositoryAsync<PersonnelTerm> repository) : base(repository)
        {
            _repository = repository;
        }

        //public List<PersonnelTerm> GetPositions()
        //{
        //    return _repository.GetRepository<Term>().
        //}
    }

}
