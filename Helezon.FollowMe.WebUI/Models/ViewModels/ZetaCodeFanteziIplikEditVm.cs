using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.DataTransferObjects;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class ZetaCodeFanteziIplikEditVm
    {
        public ZetaCodeFanteziIplik FanteziIplik { get; internal set; }
        public ZetaCodeFanteziIplikViewCollections Collections { get; set; }
        public CompanyDto Company { get; set; }
        public List<ZetaCodeNormalIplik> NormalIplikler { get; set; }
        public Term RafyeriTurkiye { get; set; }
        public Term RafyeriYunanistan { get; set; }
        public PairIdNameDto Ulke { get; set; }
        public Term IplikKategosi { get; set; }
        

        public ZetaCodeFanteziIplikEditVm()
        {
            Ulke = new PairIdNameDto();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            IplikKategosi = new Term();
            Collections = new ZetaCodeFanteziIplikViewCollections();
            FanteziIplik = new ZetaCodeFanteziIplik();
            Company = new CompanyDto();
            NormalIplikler = new List<ZetaCodeNormalIplik>();
            //ZetaCodeFanteziIplikDto.ZetaCodeNormalIplik = new List<ZetaCodeNormalIplikDto>();
            //ZetaCodeFanteziIplikDto.ZetaCodeNormalIplik.Add(new ZetaCodeNormalIplikDto());
        }
    }
    public class ZetaCodeFanteziIplikViewCollections
    {
        public SelectList Sirketler { get; set; }
        public List<SelectListItem> Ulkeler { get; set; }
        public SelectList IplikKategorileri { get; set; }
        public List<SelectListItem> NormalIplikler { get; set; }
        public List<SelectListItem> EaIpliNolar { get; internal set; }
        public List<SelectListItem> DnyIpliNolar { get; internal set; }
        public List<SelectListItem> NmIpliNolar { get; internal set; }
        public List<SelectListItem> FlIpliNolar { get; internal set; }

        //public SelectList BoyaYonu { get; internal set; }
        //public SelectList BoyaTipi { get; internal set; }

        public ZetaCodeFanteziIplikViewCollections()
        {
        
        }
    }
}