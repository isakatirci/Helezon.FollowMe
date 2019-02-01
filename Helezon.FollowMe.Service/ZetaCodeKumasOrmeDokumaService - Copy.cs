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
    public interface IKumasFanteziService : IService<ZetaCodeKumasFantazi>
    {
        void InsertOrUpdate(ZetaCodeKumasFantaziDto entity);
        List<ZetaCodeKumasFantaziDto> GetZetaCodeIsimler(string companyId);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class KumasFanteziService : Service<ZetaCodeKumasFantazi>, IKumasFanteziService
    {
        private readonly IRepositoryAsync<ZetaCodeKumasFantazi> _repository;

        public KumasFanteziService(IRepositoryAsync<ZetaCodeKumasFantazi> repository) : base(repository)
        {
            _repository = repository;
        }


        public List<ZetaCodeKumasFantaziDto> GetZetaCodeIsimler(string companyId)
        {
            return _repository.QueryableNoTracking().Where(x => /*x.CompanyId == companyId &&*/ !x.IsPassive)
                .Select(x => new ZetaCodeKumasFantaziDto
                {
                    ZetaCode = x.ZetaCode,
                    UrunIsmi = x.UrunIsmi,
                    Id=x.Id
                }).ToList();
        }

        public override void Insert(ZetaCodeKumasFantazi entity)
        {
            var zetaCode = _repository.Queryable().Max(x => (int?)x.ZetaCode) ?? 1401;
            zetaCode++;
            entity.ZetaCode = zetaCode;
            base.Insert(entity);    
        }

        public void InsertOrUpdate(ZetaCodeKumasFantaziDto entity)
        {
            var kumasOrmeDokuma = AutoMapperConfig.Mapper.Map<ZetaCodeKumasFantaziDto, ZetaCodeKumasFantazi>(entity);
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
