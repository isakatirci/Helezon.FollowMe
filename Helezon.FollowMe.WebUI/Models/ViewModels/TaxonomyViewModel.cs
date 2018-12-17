using FollowMe.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static FollowMe.Web.Controllers.Utils;

namespace FollowMe.Web.Models
{
    public class TaxonomyViewModel
    {
        public List<Term> TermList { get; set; }
        private string _taxonomyName;
        private string _taxonomyEnumName;
        private string _treeId;
        private TaxonomyType _taxonomyType;
        public TaxonomyViewModel(TaxonomyType taxonomyType)
        {
            _taxonomyType = taxonomyType;
            TermList = new List<Term>();
        }
        public string TaxonomyName
        {
            get
            {
                return _taxonomyName ??
                    (_taxonomyName = Utils.GetTaxonomyName((int)_taxonomyType));
            }
        }

        public string TaxonomyEnumName
        {
            get
            {
                return _taxonomyEnumName ??
                 (_taxonomyEnumName = _taxonomyType.ToString());
            }
        }

        public string TreeId
        {
            get
            {

                return _treeId ??
                 (_treeId = "tree_" + _taxonomyType.ToString().ToLowerInvariant());

            }
        }
        public string TermNames
        {
            get
            {
                var termNames = string.Empty;
                if (TermList.IsEmpty().Not())
                {
                    termNames = string.Join(", ", TermList.Select(x => x.Name));
                }
                return termNames;
            }
        }
        public string TermIds
        {
            get
            {
                var termNames = string.Empty;
                if (TermList.IsEmpty().Not())
                    termNames = string.Join(", ", TermList.Select(x => x.Id));
                return termNames;
            }
        }
      
    }
}

//public string PanelTitle { get; set; }
//public string PortletTitle { get; set; }
//public string TaxonomyName { get; set; }
//public string TermName { get; set; }
//public string TermId { get; set; }