using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Models.ViewModels
{
    public class CompanyCardViewModel
    {
        public CompanyCardViewModel()
        {
            PersonnelList = new List<CompanyCardPersonnelViewModel>();
            AddressList = new List<CompanyAddress>();
            TelephoneList = new List<CompanyTelephone>();
            BankList = new List<CompanyBank>();
            LogisticsCompanyList = new List<LogisticsCompany>();
            TelephoneListRotated = new List<List<string>>();
            SubChildCompanyList = new List<Tuple<string, string, string,string>>();
        }
        public string ImageName { get; set; }
        public Company Company { get; set; }
        public List<CompanyCardPersonnelViewModel> PersonnelList { get; set; }
        public List<CompanyAddress> AddressList { get; set; }
        public List<CompanyTelephone> TelephoneList { get; set; }
        public List<List<string>> TelephoneListRotated { get; set; }
        public string FirmaCodeName { get; set; }

        public List<CompanyBank> BankList { get; set; }
        public List<LogisticsCompany> LogisticsCompanyList { get; set; }
        public List<Tuple<string, string, string,string>> SubChildCompanyList { get; set; }
   
        public string CompanyLogoUrl { get; set; }
        public string EditCompanyLogoUrl { get; internal set; }
    }

    public class CompanyCardPersonnelViewModel
    {
        public string PersonnelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int? PositionId { get; internal set; }
    }
}