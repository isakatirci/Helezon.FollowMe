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
    using FollowMe.Entities.Models.Mapping;
    using Repository.Pattern.Ef6;

    // Error
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class Error: Entity
    {
        public int Id { get; set; } // Id (Primary key)
        public string UserId { get; set; } // UserId (length: 128)
        public System.DateTime? ErrorDate { get; set; } // ErrorDate
        public string IpAddress { get; set; } // IpAddress (length: 40)
        public string UserAgent { get; set; } // UserAgent
        public string Exception { get; set; } // Exception
        public string Message { get; set; } // Message
        public string Everything { get; set; } // Everything
        public string HttpReferer { get; set; } // HttpReferer (length: 500)
        public string PathAndQuery { get; set; } // PathAndQuery (length: 500)
        public bool IsPassive { get; set; } // IsPassive

        public Error()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>