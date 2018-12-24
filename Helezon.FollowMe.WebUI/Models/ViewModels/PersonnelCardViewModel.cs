using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Models.ViewModels
{
    public class PersonnelCardViewModel
    {
        public Person Personnel { get; set; }
        public string Position { get; set; }
        public string PersonelPhotoUrl { get; set; }
        public string ImageName { get; set; }
        public Company Company { get; set; }
        public List<PersonnelAddress> AddressList { get; set; }
        public List<PersonnelTelephone> TelephoneList { get; set; }
        public List<PersonnelBank> BankList { get; set; }
        public List<LogisticsCompany> LogisticsCompanyList { get; set; }
        public List<List<string>> TelephoneListRotated { get; set; }       
        public string Hobby { get; set; }
        public string Languages { get; set; }
        public string ComputerSkills { get; set; }

        public PersonnelCardViewModel()
        {
            AddressList = new List<PersonnelAddress>();
            TelephoneList = new List<PersonnelTelephone>();
            BankList = new List<PersonnelBank>();
            LogisticsCompanyList = new List<LogisticsCompany>();
            TelephoneListRotated = new List<List<string>>();
        }

    }
}