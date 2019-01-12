// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Helezon.FollowMe.Entities.Models
{
    using Repository.Pattern.Ef6;

    // AddressGuide
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class AddressGuide: Entity
    {
        public int Id { get; set; } // Id (Primary key)
        public string Country { get; set; } // Country
        public string SortCountry { get; set; } // SortCountry
        public string Province { get; set; } // Province
        public string District { get; set; } // District
        public string ZipCode { get; set; } // ZipCode
        public string SuburbArea { get; set; } // SuburbArea
        public string Town { get; set; } // Town
        public int? CountryId { get; set; } // CountryId
        public int? Priority { get; set; } // Priority

        public AddressGuide()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
