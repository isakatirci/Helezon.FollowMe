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

    // ZetaCodeNormalIplikPicture
    [Table("ZetaCodeNormalIplikPicture", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class ZetaCodeNormalIplikPicture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Index(@"PK_ZetaCodeNormalIplikPicture", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"Name", Order = 2, TypeName = "nvarchar")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(200)]
        [StringLength(200)]
        [Display(Name = "Name")]
        public string Name { get; set; } // Name (length: 200)

        [Column(@"Extension", Order = 3, TypeName = "nvarchar")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Extension")]
        public string Extension { get; set; } // Extension (length: 50)

        [Column(@"IsFeatured", Order = 4, TypeName = "bit")]
        [Required]
        [Display(Name = "Is featured")]
        public bool IsFeatured { get; set; } // IsFeatured

        [Column(@"ZetaCodeNormalIplikId", Order = 5, TypeName = "int")]
        [Required]
        [Display(Name = "Zeta code normal iplik ID")]
        public int ZetaCodeNormalIplikId { get; set; } // ZetaCodeNormalIplikId

        [Column(@"CompanyId", Order = 6, TypeName = "nvarchar")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(128)]
        [StringLength(128)]
        [Display(Name = "Company ID")]
        public string CompanyId { get; set; } // CompanyId (length: 128)

        [Column(@"IsPassive", Order = 7, TypeName = "bit")]
        [Required]
        [Display(Name = "Is passive")]
        public bool IsPassive { get; set; } // IsPassive

        [Column(@"CreatedOn", Order = 8, TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Created on")]
        public System.DateTime? CreatedOn { get; set; } // CreatedOn

        [Column(@"CreatedBy", Order = 9, TypeName = "nvarchar")]
        [MaxLength(128)]
        [StringLength(128)]
        [Display(Name = "Created by")]
        public string CreatedBy { get; set; } // CreatedBy (length: 128)

        // Foreign keys

        /// <summary>
        /// Parent ZetaCodeNormalIplik pointed by [ZetaCodeNormalIplikPicture].([ZetaCodeNormalIplikId]) (FK_ZetaCodeNormalIplikPicture_ZetaCodeNormalIplik)
        /// </summary>
        [ForeignKey("ZetaCodeNormalIplikId")] public virtual ZetaCodeNormalIplik ZetaCodeNormalIplik { get; set; } // FK_ZetaCodeNormalIplikPicture_ZetaCodeNormalIplik

        public ZetaCodeNormalIplikPicture()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
