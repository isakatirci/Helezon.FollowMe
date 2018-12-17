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

    // PersonnelTerm
    [Table("PersonnelTerm", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class PersonnelTerm
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Index(@"PK__Personne__3214EC07FB329047", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"TaxonomyId", Order = 2, TypeName = "int")]
        [Required]
        [Display(Name = "Taxonomy ID")]
        public int TaxonomyId { get; set; } // TaxonomyId

        [Column(@"TermId", Order = 3, TypeName = "int")]
        [Required]
        [Display(Name = "Term ID")]
        public int TermId { get; set; } // TermId

        [Column(@"PersonnelId", Order = 4, TypeName = "nvarchar")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(128)]
        [StringLength(128)]
        [Display(Name = "Personnel ID")]
        public string PersonnelId { get; set; } // PersonnelId (length: 128)

        [Column(@"CompanyId", Order = 5, TypeName = "nvarchar")]
        [Required(AllowEmptyStrings = true)]
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

        [Column(@"PassiveOn", Order = 9, TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Passive on")]
        public System.DateTime? PassiveOn { get; set; } // PassiveOn

        [Column(@"PassiveBy", Order = 10, TypeName = "nvarchar")]
        [MaxLength(128)]
        [StringLength(128)]
        [Display(Name = "Passive by")]
        public string PassiveBy { get; set; } // PassiveBy (length: 128)

        // Foreign keys

        /// <summary>
        /// Parent Person pointed by [PersonnelTerm].([PersonnelId]) (FK_PersonnelTerm_Person)
        /// </summary>
        [ForeignKey("PersonnelId")] public virtual Person Person { get; set; } // FK_PersonnelTerm_Person

        /// <summary>
        /// Parent Term pointed by [PersonnelTerm].([TermId]) (FK_PersonnelTerm_Term)
        /// </summary>
        [ForeignKey("TermId")] public virtual Term Term { get; set; } // FK_PersonnelTerm_Term

        public PersonnelTerm()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>