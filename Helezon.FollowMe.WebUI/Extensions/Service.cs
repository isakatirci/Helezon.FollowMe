using FollowMe.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Controllers
{
    public class EntityTermServices
    {
        private readonly string _entityId;
        private readonly string _companyId;
        private readonly GLCEmasModel _db;
        public  EntityTermServices(GLCEmasModel db, string entityId,string companyId)
        {
            _entityId = entityId;
            _companyId = companyId;
            _db = db;
        }
        public List<Term> GetTermList(int taxonomy)
        {
            var list= (from r in _db.TermRelationship
                    join t in _db.Term on r.TermId equals t.Id
                    where r.EntityId == _entityId && r.CompanyId == _companyId && r.TaxonomyId == taxonomy
                    select t).ToList();

            if (list.IsEmpty())           
                list.Add(new Term { TaxonomyId = taxonomy });            

            return list;
        }

        private static readonly Lazy<Term> lazyTerm = new Lazy<Term>(() => new Term()
        {
            Id = 0,
            TaxonomyId = 0,
            Name = string.Empty,
            CompanyId = Guid.Empty.ToString(),
            Color = string.Empty,
            NoChildrenClass = false,
            NoDragClass = false,
            IsPassive = false,
            CreatedOn = DateTime.MinValue,
            CreatedBy = Guid.Empty.ToString(),
            ChangedOn = DateTime.MinValue,
            ChangedBy = Guid.Empty.ToString()
        });

        public static Term NullTerm { get { return lazyTerm.Value; } }

        public Term GetTerm(int taxonomy)
        {
            return (from r in _db.TermRelationship
                    join t in _db.Term on r.TermId equals t.Id
                    where r.EntityId == _entityId && r.CompanyId == _companyId && r.TaxonomyId == taxonomy
                    select t).FirstOrDefault()?? NullTerm;
        }

        public Term GetTermByTermId(int? termId)
        {
            if (termId.HasValue.Not())            
                return NullTerm;
            
            return (from t in _db.Term
                    where t.Id == termId
                    select t).FirstOrDefault() ?? NullTerm;
        }

        public List<Term> GetTermListForPosition()
        {
            return GetTermList((int)TaxonomyType.Position); 
        }

        public Term GetTermForPosition()
        {
            return GetTerm((int)TaxonomyType.Position);
        }

        public Term GetTermNameForPosition()
        {
            return GetTerm((int)TaxonomyType.Position);
        }

        public Term GetTermForAuthority()
        {
            return GetTerm((int)TaxonomyType.Authority);
        }

        public Term GetTermForRegion()
        {
            return GetTerm((int)TaxonomyType.Region);
        }

        public Term GetTermForPersonCategory()
        {
            return GetTerm((int)TaxonomyType.PersonCategory);
        }

        public Term GetTermForNationality()
        {
            return GetTerm((int)TaxonomyType.Nationality);
        }

        public Term GetTermForJobExperience()
        {
            return GetTerm((int)TaxonomyType.JobExperience);
        }

        public Term GetTermForReligion()
        {
            return GetTerm((int)TaxonomyType.Religion);
        }

        public Term GetTermForHobby()
        {
            return GetTerm((int)TaxonomyType.Hobby);
        }

        public Term GetTermForDepartment()
        {
            return GetTerm((int)TaxonomyType.Department);
        }

        public Term GetTermForBloodGroup()
        {
            return GetTerm((int)TaxonomyType.BloodGroup);
        }

        //***********************************************      

        public List<Term> GetTermListForAuthority()
        {
            return GetTermList((int)TaxonomyType.Authority);
        }

        public List<Term> GetTermListForRegion()
        {
            return GetTermList((int)TaxonomyType.Region);
        }

        public List<Term> GetTermListForPersonCategory()
        {
            return GetTermList((int)TaxonomyType.PersonCategory);
        }

        public List<Term> GetTermListForNationality()
        {
            return GetTermList((int)TaxonomyType.Nationality);
        }

        public List<Term> GetTermListForJobExperience()
        {
            return GetTermList((int)TaxonomyType.JobExperience);
        }

        public List<Term> GetTermListForReligion()
        {
            return GetTermList((int)TaxonomyType.Religion);
        }

        public List<Term> GetTermListForHobby()
        {
            return GetTermList((int)TaxonomyType.Hobby);
        }
        public List<Term> GetTermListForLanguage()
        {
            return GetTermList((int)TaxonomyType.Language);
        }
        public List<Term> GetTermListForComputerSkills()
        {
            return GetTermList((int)TaxonomyType.ComputerSkills);
        }
        public List<Term> GetTermListForDepartment()
        {
            return GetTermList((int)TaxonomyType.Department);
        }
        public List<Term> GetTermListForCompanyType()
        {
            return GetTermList((int)TaxonomyType.CompanyType);
        }
        public List<Term> GetTermListForProductType()
        {
            return GetTermList((int)TaxonomyType.ProductType);
        }
        public List<Term> GetTermListForRelationshipStatus()
        {
            return GetTermList((int)TaxonomyType.RelationshipStatus);
        }
        //
    }
}