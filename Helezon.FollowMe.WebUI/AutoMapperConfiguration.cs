//using AutoMapper;
//using Helezon.FollowMe.Entities.Models;
//using Helezon.FollowMe.Service.DataTransferObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Helezon.FollowMe.Service
//{
//    public class AutoMapperConfiguration
//    {
//        //https://www.infoworld.com/article/3192900/c-sharp/how-to-work-with-automapper-in-c.html
//        private static IMapper _mapper;
//        public static IMapper Mapper
//        {
//            get
//            {
//                if (_mapper != null)
//                    return _mapper;

//                var config = new MapperConfiguration(cfg =>
//                {
//                    cfg.CreateMap<Company, CompanyDto>();
//                    cfg.CreateMap<ZetaCodeNormalIplik, ZetaCodeNormalIplikDto>();
//                    cfg.CreateMap<PantoneRenk, PantoneRenk>();
//                    cfg.CreateMap<Renk, RenkDto>();
//                    cfg.CreateMap<IplikNo, IplikNoDto>();
//                });

//                _mapper = config.CreateMapper();
//                return _mapper;
//            }
//        }
//    }
//}
