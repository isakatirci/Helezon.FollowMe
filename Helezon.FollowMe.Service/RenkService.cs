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
    public interface IRenkService : IService<Renk>
    {
        Renk GetRenkById(int? id);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class RenkService : Service<Renk>, IRenkService
    {
        private readonly IRepositoryAsync<Renk> _repoRenk;

        public RenkService(IRepositoryAsync<Renk> repository) : base(repository)
        {
            _repoRenk = repository;
        }

        public Renk GetRenkById(int? id)
        {
            if (!id.HasValue)
            {
                return new Renk();
            }
            var renk = _repoRenk.QueryableNoTracking().FirstOrDefault(x => x.Id == id.Value);
            if (renk != null)
            {
                return renk;
            }
            return new Renk();
        }
    }

    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface IPantoneRenkService : IService<PantoneRenk>
    {
        PantoneRenk GetPantoneRenkById(int? id);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class PantoneRenkService : Service<PantoneRenk>, IPantoneRenkService
    {
        private readonly IRepositoryAsync<PantoneRenk> _repoPantoneRenk;

        public PantoneRenkService(IRepositoryAsync<PantoneRenk> repository) : base(repository)
        {
            _repoPantoneRenk = repository;
        }

        public PantoneRenk GetPantoneRenkById(int? id)
        {
            if (!id.HasValue)
            {
                return new PantoneRenk();
            }
            var pantoneRenk = _repoPantoneRenk.QueryableNoTracking().FirstOrDefault(x => x.Id == id.Value);
            if (pantoneRenk != null)
            {
                return pantoneRenk;
            }
            return new PantoneRenk();
        }
    }
}
