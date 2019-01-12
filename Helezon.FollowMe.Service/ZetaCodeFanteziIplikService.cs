using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.DataTransferObjects;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service
{

    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface IFanteziIplikService : IService<ZetaCodeFanteziIplik>
    {
        void InsertOrUpdate(ZetaCodeFanteziIplikDto entity);
        List<ZetaCodeFanteziIplikDto> GetAllFanteziIplikler(int? id = null, string companyId = null);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class FanteziIplikService : Service<ZetaCodeFanteziIplik>, IFanteziIplikService
    {
        private readonly IRepositoryAsync<ZetaCodeFanteziIplik> _repository;
        private readonly ITermService _termService;
        private readonly IOthersService _othersService;
        public FanteziIplikService(IRepositoryAsync<ZetaCodeFanteziIplik> repository) : base(repository)
        {
            _repository = repository;
            _termService = new TermService(_repository.GetRepositoryAsync<Term>());
            _othersService = new OthersService();
        }
        public override void Update(ZetaCodeFanteziIplik entity)
        {
            base.Update(entity);
        }
        public override void Insert(ZetaCodeFanteziIplik entity)
        {
            base.Insert(entity);
        }

        public  void InsertOrUpdate(ZetaCodeFanteziIplikDto entity)
        {

        }

        public List<ZetaCodeFanteziIplikDto> GetAllFanteziIplikler(int? id = null, string companyId = null)
        {
            var zetaCodeNormalIplikler = _repository.Query(QueryFanteziIplik(id, companyId))
                .Include(x => x.ZetaCodeNormalIplik)
                .Select(x => x).ToList();
            var zetaCodeNormalIplikDtos = new List<ZetaCodeFanteziIplikDto>();

            foreach (var iplik in zetaCodeNormalIplikler)
            {
                var iplikDto = AutoMapperConfig.Mapper.Map<ZetaCodeFanteziIplik, ZetaCodeFanteziIplikDto>(iplik);
                iplikDto.ZetaCodeNormalIplik = AutoMapperConfig.Mapper.Map<ICollection<ZetaCodeNormalIplik>, List<ZetaCodeNormalIplikDto>>(iplik.ZetaCodeNormalIplik);
                zetaCodeNormalIplikDtos.Add(iplikDto);
            }

            return zetaCodeNormalIplikDtos;
        }

        private Expression<Func<ZetaCodeFanteziIplik, bool>> QueryFanteziIplik(int? id = null, string companyId = null)
        {
            if (id.HasValue && !string.IsNullOrWhiteSpace(companyId))
                return x => x.Id == id && x.SirketId == companyId;
            return null;
        }
    }
}
