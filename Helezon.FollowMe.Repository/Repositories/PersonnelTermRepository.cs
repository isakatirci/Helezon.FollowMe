using AutoMapper;
using Helezon.FollowMe.Entities.Models;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Repository.Repositories
{
    public static class PersonnelTermRepository
    {
        private const int Position = 2;

        static PersonnelTermRepository()
        {
            Mapper.Initialize(c => { c.CreateMap<Term, PersonnelTerm>(); });
        }
       
        public static List<PersonnelTerm> GetPositions(this IRepositoryAsync<Term> repository)
        {
            var terms = repository
                            .Queryable()
                            .Where(x => x.TaxonomyId == Position && !(x.IsPassive.HasValue && x.IsPassive.Value)).ToList();

            return Mapper.Map<List<Term>,List<PersonnelTerm>>(terms);

        }
    }
}
