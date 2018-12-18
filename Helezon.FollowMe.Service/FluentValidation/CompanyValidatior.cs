using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Helezon.FollowMe.Entities.Models;

namespace Helezon.FollowMe.Service.ValidationRules.FluentValidation
{
    public class CompanyValidatior : AbstractValidator<Company>
    {
        public CompanyValidatior()
        {
            //RuleFor(p => p.CategoryId).NotEmpty();
            //RuleFor(p => p.ProductName).NotEmpty();
            //RuleFor(p => p.UnitPrice).GreaterThan(0);
            //RuleFor(p => p.QuantityPerUnit).NotEmpty();
            //RuleFor(p => p.ProductName).Length(2, 20);
            //RuleFor(p => p.UnitPrice).GreaterThan(20).When(p=>p.CategoryId==1);
            //RuleFor(p => p.ProductName).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
