using AutoMapper;
using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service
{
    public class AutoMapperConfig
    {
        //https://www.infoworld.com/article/3192900/c-sharp/how-to-work-with-automapper-in-c.html
        public static IMapper Mapper;
        static AutoMapperConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company, CompanyDto>()
                .ForMember(dest => dest.CompanyAddress, opt => opt.Ignore())
                .ForMember(dest => dest.CompanyPicture, opt => opt.Ignore())
                .ForMember(dest => dest.CompanyBank, opt => opt.Ignore())
                .ForMember(dest => dest.CompanyTelephone, opt => opt.Ignore())
                .ForMember(dest => dest.LogisticsCompany, opt => opt.Ignore())
                .ForMember(dest => dest.Person, opt => opt.Ignore())
                .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore())
                .ForMember(dest => dest.CompanyTerm, opt => opt.Ignore());


                cfg.CreateMap<ZetaCodeNormalIplik, ZetaCodeNormalIplikDto>()
                .ForMember(dest => dest.IplikNo, opt => opt.Ignore())
                .ForMember(dest => dest.Renk, opt => opt.Ignore())
                .ForMember(dest => dest.PantoneRenk, opt => opt.Ignore());


                cfg.CreateMap<PantoneRenk, PantoneRenkDto>()
                 .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore());

                cfg.CreateMap<Renk, RenkDto>()
                .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore());

                cfg.CreateMap<Term, TermDto>()
                .ForMember(dest => dest.CompanyTerm, opt => opt.Ignore())
                .ForMember(dest => dest.PersonnelTerm, opt => opt.Ignore());


                cfg.CreateMap<IplikNo, IplikNoDto>()
                .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore());


                cfg.CreateMap<ZetaCodeNormalIplikDto, ZetaCodeNormalIplik>();            
                cfg.CreateMap<IplikNoDto, IplikNo>();

            });

            Mapper = config.CreateMapper();
        }
    }
}
