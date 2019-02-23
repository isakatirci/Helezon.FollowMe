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

    public class MyPairNameValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class ZetaCodeFanteziIplikEditVm
    {
        public ZetaCodeFanteziIplik FanteziIplik { get;  set; }
        public ZetaCodeFanteziIplikViewCollections Collections { get; set; }
        public CompanyDto Company { get; set; }
        public List<MyPairNameValue> KarsimdakiIplikler { get; set; }
        public Term RafyeriTurkiye { get; set; }
        public Term RafyeriYunanistan { get; set; }
        public PairIdNameDto Ulke { get; set; }
        public Term IplikKategosi { get; set; }

        public Renk Renk { get; set; }
        public PantoneRenk PantoneRenk { get; set; }
        public string RenkIdHtmlKod { get;  set; }

        public ZetaCodeFanteziIplikEditVm()
        {
            PantoneRenk = new PantoneRenk();
            Renk = new Renk();
            Ulke = new PairIdNameDto();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            IplikKategosi = new Term();
            Collections = new ZetaCodeFanteziIplikViewCollections();
            FanteziIplik = new ZetaCodeFanteziIplik();
            Company = new CompanyDto();
            KarsimdakiIplikler = new List<MyPairNameValue>();
            //ZetaCodeFanteziIplikDto.ZetaCodeNormalIplik = new List<ZetaCodeNormalIplikDto>();
            //ZetaCodeFanteziIplikDto.ZetaCodeNormalIplik.Add(new ZetaCodeNormalIplikDto());
        }
    }
  
    public class ZetaCodeFanteziIplikViewCollections
    {
        public List<CompanyDto> Sirketler { get; set; }
        public List<PairIdNameDto> Ulkeler { get; set; }
        public SelectList IplikKategorileri { get; set; }
        public List<MyPairNameValue> TumIplikler { get; set; }
        public List<SelectListItem> EaIpliNolar { get; internal set; }
        public List<SelectListItem> DnyIpliNolar { get; internal set; }
        public List<SelectListItem> NmIpliNolar { get; internal set; }
        public List<SelectListItem> FlIpliNolar { get; internal set; }
        public SelectList PantoneRenkleri { get; internal set; }
        public List<SelectListItem> Renkler { get; internal set; }

        //public SelectList BoyaYonu { get; internal set; }
        //public SelectList BoyaTipi { get; internal set; }

        public ZetaCodeFanteziIplikViewCollections()
        {
            TumIplikler = new List<MyPairNameValue>();
        }
    }
}