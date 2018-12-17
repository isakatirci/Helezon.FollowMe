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

    // TermRelationship
    [Table("TermRelationship", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class TermRelationship
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Index(@"PK_dbo.TermRelationship", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"TermId", Order = 2, TypeName = "int")]
        [Required]
        [Display(Name = "Term ID")]
        public int TermId { get; set; } // TermId

        [Column(@"TaxonomyId", Order = 3, TypeName = "int")]
        [Required]
        [Display(Name = "Taxonomy ID")]
        public int TaxonomyId { get; set; } // TaxonomyId

        [Column(@"EntityId", Order = 4, TypeName = "nvarchar")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(128)]
        [StringLength(128)]
        [Display(Name = "Entity ID")]
        public string EntityId { get; set; } // EntityId (length: 128)

        [Column(@"CompanyId", Order = 5, TypeName = "nvarchar")]
        [MaxLength(128)]
        [StringLength(128)]
        [Display(Name = "Company ID")]
        public string CompanyId { get; set; } // CompanyId (length: 128)

        [Column(@"IsPassive", Order = 6, TypeName = "bit")]
        [Display(Name = "Is passive")]
        public bool? IsPassive { get; set; } // IsPassive

        [Column(@"CreatedOn", Order = 7, TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Created on")]
        public System.DateTime? CreatedOn { get; set; } // CreatedOn

        [Column(@"CreatedBy", Order = 8, TypeName = "nvarchar")]
        [MaxLength(128)]
        [StringLength(128)]
        [Display(Name = "Created by")]
        public string CreatedBy { get; set; } // CreatedBy (length: 128)

        [Column(@"ChangedOn", Order = 9, TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Changed on")]
        public System.DateTime? ChangedOn { get; set; } // ChangedOn

        [Column(@"ChangedBy", Order = 10, TypeName = "nvarchar")]
        [MaxLength(128)]
        [StringLength(128)]
        [Display(Name = "Changed by")]
        public string ChangedBy { get; set; } // ChangedBy (length: 128)

        public TermRelationship()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>