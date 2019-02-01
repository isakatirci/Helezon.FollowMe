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
    public interface IZetaCodeService : IService<ZetaCodes>
    {

    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class ZetaCodeService : Service<ZetaCodes>, IZetaCodeService
    {
        private IRepositoryAsync<ZetaCodes> _repository;
        private const int limit = 50000;

        //Normal ve Fantezi İplik 1-1400 istisna (1401-50000 girme)
        //Normal ve fanztezi kumaş-aksesuar 1401-sonsuz
        //hazır giyim 50000 den başlar
        //
        //0 - 2,147,483,647
        //
        //Card sayfalarından blue sip no butonuna tıkladığında yeniden z code verme sipariş numarasını artır. ve şipariş numaraları şirketin in ayrı
        //ayrı şipariş girilmesi
        //
        //aynı şirket için bile sipariş numarası artacak

        public ZetaCodeService(IRepositoryAsync<ZetaCodes> repository) : base(repository)
        {
            _repository = repository;
        }

        public override void Insert(ZetaCodes entity)
        {
            base.Insert(entity);    
        }

        public int GetZetaCodeForIplik(string companyId)
        {
            var code = _repository.QueryableNoTracking().Where(x => x.ZetaCode < 1401  /*x.CompanyId == ""*/).Max(x => (int?)x.ZetaCode);
            if (!code.HasValue)            
                return 1;
            if (code.Value >= 1400)
                return GetZetaCodeForHazirGiyim(companyId);
            code++;
            return code.Value;
        }

        public int GetZetaCodeForKumasAksesuar(string companyId)
        {
            var code = _repository.QueryableNoTracking().Where(x => x.ZetaCode >= 1401 && x.ZetaCode < limit  /*x.CompanyId == ""*/).Max(x => (int?)x.ZetaCode);
            if (!code.HasValue)
                return 1401;
            if (code.Value >= limit)
                return GetZetaCodeForHazirGiyim(companyId);
            code++;
            return code.Value;
        }


        public int GetZetaCodeForHazirGiyim(string companyId)
        {            
            var code = _repository.QueryableNoTracking().Where(x => x.ZetaCode >= limit /*x.CompanyId == ""*/).Max(x => (int?)x.ZetaCode);
            if (!code.HasValue)
                return limit;
            code++;
            return code.Value;
        }
       

    }
}
