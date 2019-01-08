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
        List<TermDto> GetTermsByTaxonomyId(int taxonomyId);
        string GetTermNameById(int? id);
        TermDto GetTermById(int? id);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class TermService : Service<Term>, ITermService
    {
        private readonly IRepositoryAsync<Term> _repository;
        public TermService(IRepositoryAsync<Term> repository) : base(repository)
        {
            _repository = repository;
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
                var termTaxonomy = _repository.GetRepository<TermTaxonomy>().Queryable();

                var term = _repository.GetRepository<Term>().Queryable();

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

        public List<TermDto> GetTermsByTaxonomyId(int taxonomyId)
        {
            return AutoMapperConfig.Mapper.Map<List<Term>,List<TermDto>>(_repository.Queryable().Where(x=>x.TaxonomyId == taxonomyId).ToList());
        }

        public TermDto GetTermById(int? id)
        {
            if (!id.HasValue)            
                return new TermDto();            
            return AutoMapperConfig.Mapper.Map<Term,TermDto>(_repository.Queryable().FirstOrDefault(x => x.Id == id));
        }
        public string GetTermNameById(int? id)
        {
            if (!id.HasValue)
                return string.Empty;
            return GetTermById(id).Name ?? string.Empty;
        }
    }
}
