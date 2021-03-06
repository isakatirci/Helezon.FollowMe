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

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FollowMe.Web.Models
{

    // SequenceBlueSiparisNo
    [Table("SequenceBlueSiparisNo", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class SequenceBlueSiparisNo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Index(@"PK_dbo.Sequences", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"BlueCompanyId", Order = 2, TypeName = "nvarchar")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(128)]
        [StringLength(128)]
        [Display(Name = "Blue company ID")]
        public string BlueCompanyId { get; set; } // BlueCompanyId (length: 128)

        [Column(@"SiparisNo", Order = 3, TypeName = "int")]
        [Required]
        [Display(Name = "Siparis no")]
        public int SiparisNo { get; set; } // SiparisNo

        [Column(@"CreatedOn", Order = 4, TypeName = "datetime2")]
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Created on")]
        public System.DateTime CreatedOn { get; set; } // CreatedOn

        [Column(@"Description", Order = 5, TypeName = "nvarchar")]
        [MaxLength(250)]
        [StringLength(250)]
        [Display(Name = "Description")]
        public string Description { get; set; } // Description (length: 250)

        public SequenceBlueSiparisNo()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
