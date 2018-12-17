using FollowMe.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using static FollowMe.Web.Controllers.Utils;

namespace FollowMe.Web.Controllers
{
    public static class Predicates
    {
        public static Expression<Func<TermRelationship, bool>> TermRelationship(string personnelId,string companyId,int taxonomyType)
        {
            //personnel.Positions = db.TermRelationship.Where(x => x.EntityId == personnel.Id
            // && x.CompanyId == x.CompanyId && x.TaxonomyId == (int)TaxonomyType.Position).SingleOrDefault();
            return r => 
                r.EntityId == personnelId
             && r.CompanyId == companyId
             && r.TaxonomyId == taxonomyType;
        }

        //public void GetId(this List<Term> terms)
        //{
        //    if (terms.IsEmpty().Not())
        //    {
        //        return string.Join(",");

        //    }
        //}
    }
    //                    company.Person_Position = (db.TermRelationship.FirstOrDefault(x => x.EntityId == personnel.Id
    //                && x.CompanyId == x.CompanyId && x.TaxonomyId == (int)TaxonomyType.Position)??new TermRelationship()).TermName;


}