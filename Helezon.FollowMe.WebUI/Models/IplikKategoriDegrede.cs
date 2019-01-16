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

    // IplikKategoriDegrede
    [Table("IplikKategoriDegrede", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class IplikKategoriDegrede
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id

        [Column(@"BoyamaProsesi", Order = 2, TypeName = "nvarchar")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(200)]
        [StringLength(200)]
        [Display(Name = "Boyama prosesi")]
        public string BoyamaProsesi { get; set; } // BoyamaProsesi (length: 200)

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(@"ZetaCodeNormalIplikId", Order = 3, TypeName = "int")]
        [Index(@"PK_IplikKategoriDegrede", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Zeta code normal iplik ID")]
        [ForeignKey("ZetaCodeNormalIplik")]
        public int ZetaCodeNormalIplikId { get; set; } // ZetaCodeNormalIplikId (Primary key)

        // Foreign keys

        /// <summary>
        /// Parent ZetaCodeNormalIplik pointed by [IplikKategoriDegrede].([ZetaCodeNormalIplikId]) (FK_IplikKategoriDegrede_ZetaCodeNormalIplik)
        /// </summary>
        [ForeignKey("ZetaCodeNormalIplikId")] public virtual ZetaCodeNormalIplik ZetaCodeNormalIplik { get; set; } // FK_IplikKategoriDegrede_ZetaCodeNormalIplik

        public IplikKategoriDegrede()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>