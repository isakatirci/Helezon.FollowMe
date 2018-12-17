#region

using System.Collections.Generic;
using Repository.Pattern.Repositories;
using Service.Pattern;
using Helezon.FollowMe.Entities;

#endregion

namespace Helezon.FollowMe.Service
{
    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface ICompanyService : IService<Company>
    {
        //decimal CustomerOrderTotalByYear(string customerId, int year);
        //IEnumerable<Customer> CustomersByCompany(string companyName);
        //IEnumerable<CustomerOrder> GetCustomerOrder(string country);
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

        //public decimal CustomerOrderTotalByYear(string customerId, int year)
        //{
        //    // add business logic here
        //    return _repository.GetCustomerOrderTotalByYear(customerId, year);
        //}

        //public IEnumerable<Customer> CustomersByCompany(string companyName)
        //{
        //    // add business logic here
        //    return _repository.CustomersByCompany(companyName);
        //}

        //public IEnumerable<CustomerOrder> GetCustomerOrder(string country)
        //{
        //    // add business logic here
        //    return _repository.GetCustomerOrder(country);
        //}

        //public override void Insert(Customer entity)
        //{
        //    // e.g. add business logic here before inserting
        //    base.Insert(entity);
        //}

        //public override void Delete(object id)
        //{
        //    // e.g. add business logic here before deleting
        //    base.Delete(id);
        //}
    }
}