﻿using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public delegate string IplikNoGuideMethod(string value);
    public delegate string ElyafOraniMethod(int? value);
    public delegate string GetSelectListWithId(int? id);
 
    public class ZetaCodeNormalIplikVm
    {
        //public string Operation { get; set; }
        public ZetaCodeNormalIplikDto NormalIplik { get; set; }
        public ZetaCodeNormalIplikViewCollections Collections { get; set; }
        public List<IplikNoDto> IplikNolar { get; set; }
        public ZetaCodeNormalIplikVm()
        {
            Collections = new ZetaCodeNormalIplikViewCollections();       
            NormalIplik = new ZetaCodeNormalIplikDto();
            Company = new CompanyDto();
            IplikNolar = new List<IplikNoDto>();
            //ZetaCodeNormalIplikDto.IplikNo = new List<IplikNoDto>();
            //ZetaCodeNormalIplikDto.IplikNo.Add(new IplikNoDto());
        }
        public CompanyDto Company { get; set; }

        public IplikNoGuideMethod NE { get; set; }
        public IplikNoGuideMethod NM { get; set; }
        public IplikNoGuideMethod DYN { get; set; }
        public IplikNoGuideMethod FL { get; set; }
        public IplikNoGuideMethod EA { get; set; }
        public GetSelectListWithId Renkler { get; set; }
        public ElyafOraniMethod ElyafOrani { get; set; }

        public IplikKategoriDegredeDto Degrede { get; set; }//IplikKategoriFlam
        public IplikKategoriFlamDto Flam { get; set; }
        public IplikKategoriKirciliDto Kircili { get; set; }
        public IplikKategoriKrepDto Krep { get; set; }
        public IplikKategoriNopeliDto Nopeli { get; set; }
        public IplikKategoriSimDto Sim { get; set; }
    }

    public class ZetaCodeNormalIplikViewCollections
    {
        public SelectList Sirketler { get; set; }
        public List<SelectListItem> Ulkeler { get; set; }
        public SelectList PantoneRenkleri { get; set; }
        public SelectList UretimTeknolojileri { get; set; }

        public SelectList IplikKategorileri { get; set; } 
    }

}