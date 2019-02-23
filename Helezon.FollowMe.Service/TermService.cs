using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Repository.Repositories;
using Helezon.FollowMe.Service.DataTransferObjects;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service
{
    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface ITermService : IService<Term>
    {
        List<JsTreeDataDto> GetJsTreeData(string companyId, int taxonomyId);
        List<Term> GetTermsByTaxonomyId(int taxonomyId);
        string GetTermNameById(int? id);
        Term GetTermById(int? id);
        Term GetParentTermById(int termId);
        List<Term> GetAllParentsById(int? termid);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class TermService : Service<Term>, ITermService
    {
        private readonly IRepositoryAsync<Term> _repoTerm;
        private readonly IRepositoryAsync<TermTaxonomy> _repoTermTaxonomy;

        public TermService(IRepositoryAsync<Term> repository) : base(repository)
        {
            _repoTerm = repository;
            _repoTermTaxonomy = _repoTerm.GetRepositoryAsync<TermTaxonomy>();
        }

        public override void Update(Term entity)
        {
            base.Update(entity);
        }

        public override void Insert(Term entity)
        {
            // e.g. add business logic here before inserting
            base.Insert(entity);
        }

        public override void Delete(object id)
        {
            // e.g. add business logic here before deleting
            base.Delete(id);
        }

        //public void CTE(string companyId, int taxonomyId)
        //{
        //    var sb = new System.Text.StringBuilder(958);
        //    sb.AppendLine(@"WITH CTE (TaxonomyId, Id, Name, Parent, Disabled) AS");
        //    sb.AppendLine(@"  ( SELECT tx.TaxonomyId,");
        //    sb.AppendLine(@"           te.Id,");
        //    sb.AppendLine(@"           te.Name,");
        //    sb.AppendLine(@"           tx.Parent,");
        //    sb.AppendLine(@"           te.Disabled");
        //    sb.AppendLine(@"   FROM TermTaxonomy AS tx");
        //    sb.AppendLine(@"   INNER JOIN Term AS te ON tx.TermId = te.Id");
        //    sb.AppendLine(@"   WHERE (tx.TaxonomyId = ##TaxonomyId##)");
        //    sb.AppendLine(@"     AND (te.TaxonomyId = ##TaxonomyId##)");
        //    sb.AppendLine(@"     AND (tx.CompanyId = N'##CompanyId##')");
        //    sb.AppendLine(@"     AND (te.CompanyId = N'##CompanyId##')");
        //    sb.AppendLine(@"     AND te.Id = 291");
        //    sb.AppendLine(@"   UNION ALL SELECT tx.TaxonomyId,");
        //    sb.AppendLine(@"                    te.Id,");
        //    sb.AppendLine(@"                    te.Name,");
        //    sb.AppendLine(@"                    tx.Parent,");
        //    sb.AppendLine(@"                    te.Disabled");
        //    sb.AppendLine(@"   FROM TermTaxonomy AS tx");
        //    sb.AppendLine(@"   INNER JOIN Term AS te ON tx.TermId = te.Id");
        //    sb.AppendLine(@"   INNER JOIN CTE AS cte ON tx.Parent = cte.Id");
        //    sb.AppendLine(@"   WHERE (tx.TaxonomyId = ##TaxonomyId##)");
        //    sb.AppendLine(@"     AND (te.TaxonomyId = ##TaxonomyId##)");
        //    sb.AppendLine(@"     AND (tx.CompanyId = N'##CompanyId##')");
        //    sb.AppendLine(@"     AND (te.CompanyId = N'##CompanyId##'))");
        //    sb.AppendLine(@"SELECT *");
        //    sb.AppendLine(@"FROM CTE");          

        //}

        private readonly object obj1 = new object();
        public List<JsTreeDataDto> GetJsTreeData(string companyId, int taxonomyId)
        {
            // { "id" : "ajson1", "parent" : "#", "text" : "Simple root node" },
            lock (obj1)
            {
                var termTaxonomy = _repoTerm.GetRepository<TermTaxonomy>().Queryable();

                var term = _repoTerm.GetRepository<Term>().Queryable();

                var jsTreeDataDtos = (from tx in termTaxonomy
                                      join te in term on tx.TermId equals te.Id
                                      where tx.TaxonomyId == taxonomyId && te.TaxonomyId == taxonomyId && tx.CompanyId == companyId && te.CompanyId == companyId
                                      select new JsTreeDataDto
                                      {
                                          id = te.Id.ToString(),
                                          text = te.Name,
                                          parent = tx.Parent.HasValue && tx.Parent == 0 ? "#" : tx.Parent.ToString(),
                                          state = new { disabled = te.Disabled }
                                      }).ToList();

                return jsTreeDataDtos;
            }
          
        }

        public List<Term> GetTermsByTaxonomyId(int taxonomyId)
        {
            return _repoTerm.QueryableNoTracking().Where(x=>x.TaxonomyId == taxonomyId).ToList();
        }

        public Term GetTermById(int? id)
        {
            if (!id.HasValue)
            {
                return new Term();
            }
            var term = _repoTerm.QueryableNoTracking().FirstOrDefault(x => x.Id == id);
            if (term != null)
            {
                return term;
            }
            return new Term();
        }
        public string GetTermNameById(int? id)
        {
            if (!id.HasValue)
                return string.Empty;
            return GetTermById(id)?.Name ?? string.Empty;
        }

        public List<Term> GetAllParentsById(int? termid)
        {
            var parents = new List<Term>();
            if (!termid.HasValue)
            {
                return parents;
            }
            var term = GetTermById(termid);
            if (term == null)
                return parents;
            parents.Add(term);
            while (true)
            {
                var parent = GetParentTermById(termid.Value);
                if (parent != null)
                {
                    parents.Add(parent);
                    termid = parent.Id;
                }
                else
                {
                    break;
                }
            }
            return parents;
        }

        public Term GetParentTermById(int termid)
        {
            var term = GetTermById(termid);
            if (term != null)
            {
                var termTaxonomy = _repoTermTaxonomy.Queryable().FirstOrDefault(x => x.TermId == termid && x.TaxonomyId == x.TaxonomyId);
                if (termTaxonomy != null)
                {
                    var parentTerm = GetTermById(termTaxonomy.Parent);
                    if (parentTerm != null)
                    {
                        return parentTerm;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;        }
    }
}
