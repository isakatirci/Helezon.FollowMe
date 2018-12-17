using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FollowMe.Web.Models.Infrastructure
{
    public class WebsiteValidationAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string _comparisonProperty;

        public WebsiteValidationAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule mvr = new ModelClientValidationRule();
            mvr.ErrorMessage = ErrorMessageString;
            mvr.ValidationParameters.Add("comparisonproperty", _comparisonProperty);
            mvr.ValidationType = "websitevalidation";
            return new[] { mvr };
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (string)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (bool?)property.GetValue(validationContext.ObjectInstance);

            //    return !($websiteElementValue === "" && $otherPropValue !== "false");
            if (string.IsNullOrWhiteSpace(currentValue) && (!comparisonValue.HasValue || comparisonValue.Value))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}