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

                cfg.CreateMap<CompanyDto, Company>();
                //.ForMember(dest => dest.CompanyAddress, opt => opt.Ignore())
                //.ForMember(dest => dest.CompanyPicture, opt => opt.Ignore())
                //.ForMember(dest => dest.CompanyBank, opt => opt.Ignore())
                //.ForMember(dest => dest.CompanyTelephone, opt => opt.Ignore())
                //.ForMember(dest => dest.LogisticsCompany, opt => opt.Ignore())
                //.ForMember(dest => dest.Person, opt => opt.Ignore())
                //.ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore())
                //.ForMember(dest => dest.CompanyTerm, opt => opt.Ignore());


                cfg.CreateMap<ZetaCodeNormalIplik, ZetaCodeNormalIplikDto>()
                .ForMember(dest => dest.IplikNo, opt => opt.Ignore())
                .ForMember(dest => dest.Renk, opt => opt.Ignore())
                .ForMember(dest => dest.PantoneRenk, opt => opt.Ignore());


                cfg.CreateMap<ZetaCodeFanteziIplik, ZetaCodeFanteziIplikDto>()
                .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore())
                .ForMember(dest => dest.Company, opt => opt.Ignore());

                cfg.CreateMap<ZetaCodeFanteziIplikDto, ZetaCodeFanteziIplik>();
          

                //.ForMember(dest => dest.IplikNo, opt => opt.Ignore())


                cfg.CreateMap<ZetaCodeNormalIplikDto, ZetaCodeNormalIplik>()
                .ForMember(dest => dest.IplikKategoriDegrede, opt => opt.MapFrom(src => src.IplikKategoriDegrede))
                .ForMember(dest => dest.IplikKategoriFlam, opt => opt.MapFrom(src => src.IplikKategoriFlam))
                .ForMember(dest => dest.IplikKategoriKircili, opt => opt.MapFrom(src => src.IplikKategoriKircili))
                .ForMember(dest => dest.IplikKategoriKrep, opt => opt.MapFrom(src => src.IplikKategoriKrep))
                .ForMember(dest => dest.IplikKategoriNopeli, opt => opt.MapFrom(src => src.IplikKategoriNopeli))
                .ForMember(dest => dest.IplikKategoriSim, opt => opt.MapFrom(src => src.IplikKategoriSim));
                //.ForMember(dest => dest.IplikNo, opt => opt.Ignore())
                //.ForMember(dest => dest.Renk, opt => opt.Ignore())
                //.ForMember(dest => dest.PantoneRenk, opt => opt.Ignore());


                cfg.CreateMap<PantoneRenk, PantoneRenkDto>()
                .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore())
                .ForMember(dest => dest.ZetaCodeFanteziIplik, opt => opt.Ignore());

                cfg.CreateMap<PantoneRenkDto, PantoneRenk>();
                //.ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore());


                cfg.CreateMap<Renk, RenkDto>()
                .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore())
                .ForMember(dest => dest.ZetaCodeFanteziIplik, opt => opt.Ignore());
                cfg.CreateMap<RenkDto, Renk>();
                //.ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore());

                cfg.CreateMap<Term, TermDto>()
                .ForMember(dest => dest.CompanyTerm, opt => opt.Ignore())
                .ForMember(dest => dest.PersonnelTerm, opt => opt.Ignore());

                cfg.CreateMap<TermDto, Term>();
                //.ForMember(dest => dest.CompanyTerm, opt => opt.Ignore())
                //.ForMember(dest => dest.PersonnelTerm, opt => opt.Ignore());

                cfg.CreateMap<IplikNo, IplikNoDto>()
                .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore());

                cfg.CreateMap<IplikNoDto, IplikNo>();
                //.ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore());

                cfg.CreateMap<IplikKategoriDegrede, IplikKategoriDegredeDto>()
                 .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore());
                cfg.CreateMap<IplikKategoriDegredeDto, IplikKategoriDegrede>();

                cfg.CreateMap<IplikKategoriFlam, IplikKategoriFlamDto>()
                 .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore());
                cfg.CreateMap<IplikKategoriFlamDto, IplikKategoriFlam>();

                cfg.CreateMap<IplikKategoriKircili, IplikKategoriKirciliDto>()
                .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore());
                cfg.CreateMap<IplikKategoriKirciliDto, IplikKategoriKircili>();

                cfg.CreateMap<IplikKategoriKrep, IplikKategoriKrepDto>()
                .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore());
                cfg.CreateMap<IplikKategoriKrepDto, IplikKategoriKrep>();

                cfg.CreateMap<IplikKategoriNopeli, IplikKategoriNopeliDto>()
                .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore());
                cfg.CreateMap<IplikKategoriNopeliDto, IplikKategoriNopeli>();


                cfg.CreateMap<IplikKategoriSim, IplikKategoriSimDto>()
                .ForMember(dest => dest.ZetaCodeNormalIplik, opt => opt.Ignore());
                cfg.CreateMap<IplikKategoriSimDto, IplikKategoriSim>();              



            });

            Mapper = config.CreateMapper();
        }
    }
}
