using AutoMapper;
using Helezon.FollowMe.Service.Models.Mapping.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service.Mappings.AutoMapper.Profiles
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BusinessProfile());
            });

            return config;
        }
    }
}
