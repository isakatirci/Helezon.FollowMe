﻿using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.DataTransferObjects;
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


    public class IplikNoVm
    {
        public int Id { get; set; } // Id (Primary key)
        public int ElyafOrani { get; set; } // Name (length: 200)  
        public int TermId { get; set; } // Id (Primary key)
        public string TermName { get; set; } // Name (length: 200)      

    }

    public class ZetaCodeNormalIplikEditVm
    {
        //public string Operation { get; set; }
        public ZetaCodeNormalIplik NormalIplik { get; set; }
        public string RenkIdHtmlKod { get; set; }
        public ZetaCodeNormalIplikViewCollections Collections { get; set; }
        public List<IplikNoVm> IplikNolar { get; set; }
        public Term IplikKategosi { get; set; }
        public Term RafyeriYunanistan { get; set; }
        public Term RafyeriTurkiye { get; set; }

        public ZetaCodeNormalIplikEditVm()
        {
            Renk = new Renk();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            Collections = new ZetaCodeNormalIplikViewCollections();       
            NormalIplik = new ZetaCodeNormalIplik();
            Company = new Company();
            IplikNolar = new List<IplikNoVm>();
            Ulke = new PairIdNameDto();
            IplikKategosi = new Term();
            //ZetaCodeNormalIplik.IplikNo = new List<IplikNo>();
            //ZetaCodeNormalIplik.IplikNo.Add(new IplikNo());
        }
        public Company Company { get; set; }
        public PairIdNameDto Ulke { get; set; }        

        public IplikNoGuideMethod NE { get; set; }
        public IplikNoGuideMethod NM { get; set; }
        public IplikNoGuideMethod DYN { get; set; }
        public IplikNoGuideMethod FL { get; set; }
        public IplikNoGuideMethod EA { get; set; }
       
        public ElyafOraniMethod ElyafOrani { get; set; }
        public Renk Renk { get; set; }
        public IplikKategoriDegrede Degrede { get; set; }//IplikKategoriFlam
        public IplikKategoriFlam Flam { get; set; }
        public IplikKategoriKircili Kircili { get; set; }
        public IplikKategoriKrep Krep { get; set; }
        public IplikKategoriNopeli Nopeli { get; set; }
        public IplikKategoriSim Sim { get; set; }
    }

    public class ZetaCodeNormalIplikViewCollections
    {
        public List<SelectListItem> Renkler { get; set; }
        public List<CompanyDto> Sirketler { get; set; }
        public List<PairIdNameDto> Ulkeler { get; set; }
        public SelectList PantoneRenkleri { get; set; }
        public SelectList UretimTeknolojileri { get; set; }

        public SelectList IplikKategorileri { get; set; } 
    }

}