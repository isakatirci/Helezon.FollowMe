using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.DataTransferObjects;
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
    public interface IKumasOrmeDokumaService : IService<ZetaCodeKumasOrmeDokuma>
    {
        void InsertOrUpdate(ZetaCodeKumasOrmeDokumaDto entity);
        List<ZetaCodeKumasOrmeDokumaDto> GetZetaCodeIsimler(string companyId);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class KumasOrmeDokumaService : Service<ZetaCodeKumasOrmeDokuma>, IKumasOrmeDokumaService
    {
        private readonly IRepositoryAsync<ZetaCodeKumasOrmeDokuma> _repository;

        public KumasOrmeDokumaService(IRepositoryAsync<ZetaCodeKumasOrmeDokuma> repository) : base(repository)
        {
            _repository = repository;
        }   

        public List<ZetaCodeKumasOrmeDokumaDto> GetZetaCodeIsimler(string companyId)
        {
            return _repository.QueryableNoTracking().Where(x => /*x.CompanyId == companyId &&*/ !x.IsPassive)
                .Select(x => new ZetaCodeKumasOrmeDokumaDto
                {
                    ZetaCode = x.ZetaCode,
                    UrunIsmi = x.UrunIsmi,
                    Id=x.Id
                }).ToList();
        }

        public override void Insert(ZetaCodeKumasOrmeDokuma entity)
        {
            var zetaCode = _repository.Queryable().Max(x => (int?)x.ZetaCode) ?? 1401;
            zetaCode++;
            entity.ZetaCode = zetaCode;
            base.Insert(entity);    
        }

        public void InsertOrUpdate(ZetaCodeKumasOrmeDokumaDto entity)
        {
            var kumasOrmeDokuma = AutoMapperConfig.Mapper.Map<ZetaCodeKumasOrmeDokumaDto, ZetaCodeKumasOrmeDokuma>(entity);
            if (entity.Id > 0)
            {
                this.Update(kumasOrmeDokuma);
            }
            else
            {
                this.Insert(kumasOrmeDokuma);
            }

        }
    }

}
