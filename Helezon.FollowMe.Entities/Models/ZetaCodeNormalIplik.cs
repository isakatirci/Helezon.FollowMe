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

    // ZetaCodeNormalIplik
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class ZetaCodeNormalIplik: Entity
    {
        public int Id { get; set; } // Id (Primary key)
        public string UrunIsmi { get; set; } // UrunIsmi (length: 800)
        public bool Master { get; set; } // Master
        public int ZetaCode { get; set; } // ZetaCode
        public string ZetaCodePrevious { get; set; } // ZetaCodePrevious (length: 200)
        public int? IplikKategosiId { get; set; } // IplikKategosiId
        public string SirketId { get; set; } // SirketId (length: 128)
        public int? Ulke { get; set; } // Ulke
        public string BlueUrunKodIsmi { get; set; } // BlueUrunKodIsmi (length: 200)
        public int BlueKod { get; set; } // BlueKod
        public int BlueSiparisNo { get; set; } // BlueSiparisNo
        public int? UretimTeknolojisiId { get; set; } // UretimTeknolojisiId
        public int? PantoneId { get; set; } // PantoneId
        public int? Renkid { get; set; } // Renkid
        public int? RafyeriTurkiyeId { get; set; } // RafyeriTurkiyeId
        public int? RafyeriYunanistanId { get; set; } // RafyeriYunanistanId
        public bool IsPassive { get; set; } // IsPassive
        public System.DateTime? CreatedOn { get; set; } // CreatedOn
        public string CreatedBy { get; set; } // CreatedBy (length: 128)
        public System.DateTime? ChangedOn { get; set; } // ChangedOn
        public string ChangedBy { get; set; } // ChangedBy (length: 128)
        public string IplikNoCinsi { get; set; } // IplikNoCinsi (length: 10)
        public string Ne { get; set; } // NE (length: 10)
        public string Nm { get; set; } // NM (length: 10)
        public string Dny { get; set; } // DNY (length: 10)
        public string Fl { get; set; } // FL (length: 10)
        public string Ea { get; set; } // EA (length: 10)

        // Reverse navigation

        /// <summary>
        /// Parent (One-to-One) ZetaCodeNormalIplik pointed by [IplikKategoriDegrede].[ZetaCodeNormalIplikId] (FK_IplikKategoriDegrede_ZetaCodeNormalIplik)
        /// </summary>
        public virtual IplikKategoriDegrede IplikKategoriDegrede { get; set; } // IplikKategoriDegrede.FK_IplikKategoriDegrede_ZetaCodeNormalIplik
        /// <summary>
        /// Parent (One-to-One) ZetaCodeNormalIplik pointed by [IplikKategoriFlam].[ZetaCodeNormalIplikId] (FK_IplikKategoriFlam_ZetaCodeNormalIplik)
        /// </summary>
        public virtual IplikKategoriFlam IplikKategoriFlam { get; set; } // IplikKategoriFlam.FK_IplikKategoriFlam_ZetaCodeNormalIplik
        /// <summary>
        /// Parent (One-to-One) ZetaCodeNormalIplik pointed by [IplikKategoriKircili].[ZetaCodeNormalIplikId] (FK_IplikKategoriKircili_ZetaCodeNormalIplik1)
        /// </summary>
        public virtual IplikKategoriKircili IplikKategoriKircili { get; set; } // IplikKategoriKircili.FK_IplikKategoriKircili_ZetaCodeNormalIplik1
        /// <summary>
        /// Parent (One-to-One) ZetaCodeNormalIplik pointed by [IplikKategoriKrep].[ZetaCodeNormalIplikId] (FK_IplikKategoriKrep_ZetaCodeNormalIplik)
        /// </summary>
        public virtual IplikKategoriKrep IplikKategoriKrep { get; set; } // IplikKategoriKrep.FK_IplikKategoriKrep_ZetaCodeNormalIplik
        /// <summary>
        /// Parent (One-to-One) ZetaCodeNormalIplik pointed by [IplikKategoriNopeli].[ZetaCodeNormalIplikId] (FK_IplikKategoriNopeli_ZetaCodeNormalIplik)
        /// </summary>
        public virtual IplikKategoriNopeli IplikKategoriNopeli { get; set; } // IplikKategoriNopeli.FK_IplikKategoriNopeli_ZetaCodeNormalIplik
        /// <summary>
        /// Parent (One-to-One) ZetaCodeNormalIplik pointed by [IplikKategoriSim].[ZetaCodeNormalIplikId] (FK_IplikKategoriSim_ZetaCodeNormalIplik)
        /// </summary>
        public virtual IplikKategoriSim IplikKategoriSim { get; set; } // IplikKategoriSim.FK_IplikKategoriSim_ZetaCodeNormalIplik
        /// <summary>
        /// Child IplikNo where [IplikNo].[ZetaCodeNormalIplikId] point to this entity (FK_IplikNo_ZetaCodeNormaliplik)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<IplikNo> IplikNo { get; set; } // IplikNo.FK_IplikNo_ZetaCodeNormaliplik
        /// <summary>
        /// Child ZetaCodeFanteziIplik (Many-to-Many) mapped by table [ZetaCodeNormalFantezi]
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ZetaCodeFanteziIplik> ZetaCodeFanteziIplik { get; set; } // Many to many mapping
        /// <summary>
        /// Child ZetaCodeNormalIplikPicture where [ZetaCodeNormalIplikPicture].[ZetaCodeNormalIplikId] point to this entity (FK_ZetaCodeNormalIplikPicture_ZetaCodeNormalIplik)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ZetaCodeNormalIplikPicture> ZetaCodeNormalIplikPicture { get; set; } // ZetaCodeNormalIplikPicture.FK_ZetaCodeNormalIplikPicture_ZetaCodeNormalIplik

        // Foreign keys

        /// <summary>
        /// Parent Company pointed by [ZetaCodeNormalIplik].([SirketId]) (FK_ZetaCodeNormaliplik_Company)
        /// </summary>
        public virtual Company Company { get; set; } // FK_ZetaCodeNormaliplik_Company

        /// <summary>
        /// Parent PantoneRenk pointed by [ZetaCodeNormalIplik].([PantoneId]) (FK_ZetaCodeNormaliplik_PantoneRengi)
        /// </summary>
        public virtual PantoneRenk PantoneRenk { get; set; } // FK_ZetaCodeNormaliplik_PantoneRengi

        /// <summary>
        /// Parent Renk pointed by [ZetaCodeNormalIplik].([Renkid]) (FK_ZetaCodeNormaliplik_Renk)
        /// </summary>
        public virtual Renk Renk { get; set; } // FK_ZetaCodeNormaliplik_Renk

        public ZetaCodeNormalIplik()
        {
            IplikNo = new System.Collections.Generic.List<IplikNo>();
            ZetaCodeNormalIplikPicture = new System.Collections.Generic.List<ZetaCodeNormalIplikPicture>();
            ZetaCodeFanteziIplik = new System.Collections.Generic.List<ZetaCodeFanteziIplik>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
