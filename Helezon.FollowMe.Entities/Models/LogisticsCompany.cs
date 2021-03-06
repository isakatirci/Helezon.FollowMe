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

    // LogisticsCompany
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class LogisticsCompany: Entity
    {
        public int Id { get; set; } // Id (Primary key)
        public string CompanyId { get; set; } // CompanyId (length: 128)
        public string ImportCode { get; set; } // ImportCode
        public string ExportCode { get; set; } // ExportCode
        public string LogisticsCompanyId { get; set; } // LogisticsCompanyId (length: 128)

        public LogisticsCompany()
        {
            LogisticsCompanyId = "00000000-0000-0000-0000-000000000000";
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
