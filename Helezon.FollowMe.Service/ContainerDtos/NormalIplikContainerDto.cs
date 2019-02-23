using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service.ContainerDtos
{
    public class NormalIplikContainerDto
    {
        public Product NormalIplik { get; set; }
        public IplikKategoriDegrede Degrede { get; set; }//IplikKategoriFlam
        public IplikKategoriFlam Flam { get; set; }
        public IplikKategoriKircili Kircili { get; set; }
        public IplikKategoriKrep Krep { get; set; }
        public IplikKategoriNopeli Nopeli { get; set; }
        public IplikKategoriSim Sim { get; set; }
        //public List<IplikNo> IplikNolar { get; set; }
        public Company Company { get; set; }
        public List<Term> ParentIplikCategories { get;  set; }
        public string PictureUrl { get; set; }
        public Term IplikKategorisi { get; set; }
        public PantoneRenk PantoneRenk { get; set; }
        public Renk Renk { get; set; }
        public Term RafyeriTurkiye { get; set; }
        public Term RafyeriYunanistan { get; set; }
        public List<PairIdNameDto> IplikKategoriDetaylari { get; set; }
        public PairIdNameDto Ulke { get; set; }

        public List<IplikNoDto> IplikNoDtos { get; set; }

        public NormalIplikContainerDto()
        {
            Ulke = new PairIdNameDto();
            IplikKategorisi = new Term();
            PantoneRenk = new PantoneRenk();
            Renk = new Renk();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            NormalIplik = new Product();
            Degrede = new IplikKategoriDegrede();
            Flam = new IplikKategoriFlam();
            Kircili = new IplikKategoriKircili();
            Krep = new IplikKategoriKrep();
            Nopeli = new IplikKategoriNopeli();
            Sim = new IplikKategoriSim();
            //IplikNolar = new List<IplikNo>();
            ParentIplikCategories = new List<Term>();
            Company = new Company();
            IplikKategoriDetaylari = new List<PairIdNameDto>();
            IplikNoDtos = new List<IplikNoDto>();
        }

    }
}
