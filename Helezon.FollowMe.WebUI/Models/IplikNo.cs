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

    // IplikNo
    [Table("IplikNo", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class IplikNo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Index(@"PK_iplikNo", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"ZetaCodeNormalIplikId", Order = 2, TypeName = "int")]
        [Required]
        [Display(Name = "Zeta code normal iplik ID")]
        public int ZetaCodeNormalIplikId { get; set; } // ZetaCodeNormalIplikId

        [Column(@"ElyafCinsiKalitesi", Order = 3, TypeName = "int")]
        [Display(Name = "Elyaf cinsi kalitesi")]
        public int? ElyafCinsiKalitesi { get; set; } // ElyafCinsiKalitesi

        [Column(@"ElyafOrani", Order = 4, TypeName = "int")]
        [Display(Name = "Elyaf orani")]
        public int? ElyafOrani { get; set; } // ElyafOrani

        [Column(@"IsPassive", Order = 5, TypeName = "bit")]
        [Required]
        [Display(Name = "Is passive")]
        public bool IsPassive { get; set; } // IsPassive

        [Column(@"CreatedOn", Order = 6, TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Created on")]
        public System.DateTime? CreatedOn { get; set; } // CreatedOn

        [Column(@"CreatedBy", Order = 7, TypeName = "nvarchar")]
        [MaxLength(128)]
        [StringLength(128)]
        [Display(Name = "Created by")]
        public string CreatedBy { get; set; } // CreatedBy (length: 128)

        [Column(@"ChangedOn", Order = 8, TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Changed on")]
        public System.DateTime? ChangedOn { get; set; } // ChangedOn

        [Column(@"ChangedBy", Order = 9, TypeName = "nvarchar")]
        [MaxLength(128)]
        [StringLength(128)]
        [Display(Name = "Changed by")]
        public string ChangedBy { get; set; } // ChangedBy (length: 128)

        // Foreign keys

        /// <summary>
        /// Parent ZetaCodeNormalIplik pointed by [IplikNo].([ZetaCodeNormalIplikId]) (FK_IplikNo_ZetaCodeNormaliplik)
        /// </summary>
        [ForeignKey("ZetaCodeNormalIplikId")] public virtual ZetaCodeNormalIplik ZetaCodeNormalIplik { get; set; } // FK_IplikNo_ZetaCodeNormaliplik

        public IplikNo()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
