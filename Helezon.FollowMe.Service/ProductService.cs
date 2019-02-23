using Helezon.FollowMe.Entities.Models;
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
    public interface IProductService : IService<Product>
    {
        Product GetProductById(int? id);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IRepositoryAsync<Product> _repoProduct;

        public ProductService(IRepositoryAsync<Product> repository) : base(repository)
        {
            _repoProduct = repository;
        }

        public Product GetProductById(int? id)
        {
            if (!id.HasValue)
            {
                return new Product();
            }
            var renk = _repoProduct.QueryableNoTracking().FirstOrDefault(x => x.Id == id.Value);
            if (renk != null)
            {
                return renk;
            }
            return new Product();
        }
    }
}
