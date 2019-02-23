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


    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class FollowMeDbContext : System.Data.Entity.DbContext, IFollowMeDbContext
    {
        public System.Data.Entity.DbSet<AddressGuide> AddressGuide { get; set; } // AddressGuide
        public System.Data.Entity.DbSet<BankGuide> BankGuide { get; set; } // BankGuide
        public System.Data.Entity.DbSet<BedenOlculeri> BedenOlculeri { get; set; } // BedenOlculeri
        public System.Data.Entity.DbSet<Company> Company { get; set; } // Company
        public System.Data.Entity.DbSet<CompanyAddress> CompanyAddress { get; set; } // CompanyAddress
        public System.Data.Entity.DbSet<CompanyBank> CompanyBank { get; set; } // CompanyBank
        public System.Data.Entity.DbSet<CompanyPicture> CompanyPicture { get; set; } // CompanyPicture
        public System.Data.Entity.DbSet<CompanyTelephone> CompanyTelephone { get; set; } // CompanyTelephone
        public System.Data.Entity.DbSet<CompanyTerm> CompanyTerm { get; set; } // CompanyTerm
        public System.Data.Entity.DbSet<Error> Error { get; set; } // Error
        public System.Data.Entity.DbSet<IplikKategoriDegrede> IplikKategoriDegrede { get; set; } // IplikKategoriDegrede
        public System.Data.Entity.DbSet<IplikKategoriFlam> IplikKategoriFlam { get; set; } // IplikKategoriFlam
        public System.Data.Entity.DbSet<IplikKategoriKircili> IplikKategoriKircili { get; set; } // IplikKategoriKircili
        public System.Data.Entity.DbSet<IplikKategoriKrep> IplikKategoriKrep { get; set; } // IplikKategoriKrep
        public System.Data.Entity.DbSet<IplikKategoriNopeli> IplikKategoriNopeli { get; set; } // IplikKategoriNopeli
        public System.Data.Entity.DbSet<IplikKategoriSim> IplikKategoriSim { get; set; } // IplikKategoriSim
        public System.Data.Entity.DbSet<IplikNo> IplikNo { get; set; } // IplikNo
        public System.Data.Entity.DbSet<IplikNoGuide> IplikNoGuide { get; set; } // IplikNoGuide
        public System.Data.Entity.DbSet<JsonObject> JsonObject { get; set; } // JsonObject
        public System.Data.Entity.DbSet<LogisticsCompany> LogisticsCompany { get; set; } // LogisticsCompany
        public System.Data.Entity.DbSet<PantoneRenk> PantoneRenk { get; set; } // PantoneRenk
        public System.Data.Entity.DbSet<Person> Person { get; set; } // Person
        public System.Data.Entity.DbSet<PersonnelAddress> PersonnelAddress { get; set; } // PersonnelAddress
        public System.Data.Entity.DbSet<PersonnelBank> PersonnelBank { get; set; } // PersonnelBank
        public System.Data.Entity.DbSet<PersonnelEducation> PersonnelEducation { get; set; } // PersonnelEducation
        public System.Data.Entity.DbSet<PersonnelPicture> PersonnelPicture { get; set; } // PersonnelPicture
        public System.Data.Entity.DbSet<PersonnelTelephone> PersonnelTelephone { get; set; } // PersonnelTelephone
        public System.Data.Entity.DbSet<PersonnelTerm> PersonnelTerm { get; set; } // PersonnelTerm
        public System.Data.Entity.DbSet<Product> Product { get; set; } // Product
        public System.Data.Entity.DbSet<RafBilgisi> RafBilgisi { get; set; } // RafBilgisi
        public System.Data.Entity.DbSet<Renk> Renk { get; set; } // Renk
        public System.Data.Entity.DbSet<SequenceBlueSiparisNo> SequenceBlueSiparisNo { get; set; } // SequenceBlueSiparisNo
        public System.Data.Entity.DbSet<Term> Term { get; set; } // Term
        public System.Data.Entity.DbSet<TermRelationship> TermRelationship { get; set; } // TermRelationship
        public System.Data.Entity.DbSet<TermTaxonomy> TermTaxonomy { get; set; } // TermTaxonomy
        public System.Data.Entity.DbSet<ZetaCodeAksesuar> ZetaCodeAksesuar { get; set; } // ZetaCodeAksesuar
        public System.Data.Entity.DbSet<ZetaCodeAksesuarKompozisyon> ZetaCodeAksesuarKompozisyon { get; set; } // ZetaCodeAksesuarKompozisyon
        public System.Data.Entity.DbSet<ZetaCodeAksesuarPicture> ZetaCodeAksesuarPicture { get; set; } // ZetaCodeAksesuarPicture
        public System.Data.Entity.DbSet<ZetaCodeFanteziIplik> ZetaCodeFanteziIplik { get; set; } // ZetaCodeFanteziIplik
        public System.Data.Entity.DbSet<ZetaCodeFanteziIplikNormalIplik> ZetaCodeFanteziIplikNormalIplik { get; set; } // ZetaCode_FanteziIplik_NormalIplik
        public System.Data.Entity.DbSet<ZetaCodeFanteziIplikPicture> ZetaCodeFanteziIplikPicture { get; set; } // ZetaCodeFanteziIplikPicture
        public System.Data.Entity.DbSet<ZetaCodeHazirGiyim> ZetaCodeHazirGiyim { get; set; } // ZetaCodeHazirGiyim
        public System.Data.Entity.DbSet<ZetaCodeHazirGiyimAksesuar> ZetaCodeHazirGiyimAksesuar { get; set; } // ZetaCode_HazirGiyim_Aksesuar
        public System.Data.Entity.DbSet<ZetaCodeHazirGiyimKumasFantezi> ZetaCodeHazirGiyimKumasFantezi { get; set; } // ZetaCode_HazirGiyim_KumasFantezi
        public System.Data.Entity.DbSet<ZetaCodeHazirGiyimKumasOrmeDokuma> ZetaCodeHazirGiyimKumasOrmeDokuma { get; set; } // ZetaCode_HazirGiyim_KumasOrmeDokuma
        public System.Data.Entity.DbSet<ZetaCodeKumasFantazi> ZetaCodeKumasFantazi { get; set; } // ZetaCodeKumasFantazi
        public System.Data.Entity.DbSet<ZetaCodeKumasFantaziPicture> ZetaCodeKumasFantaziPicture { get; set; } // ZetaCodeKumasFantaziPicture
        public System.Data.Entity.DbSet<ZetaCodeKumasFantezi3AdimIslemleri> ZetaCodeKumasFantezi3AdimIslemleri { get; set; } // ZetaCodeKumasFantezi3AdimIslemleri
        public System.Data.Entity.DbSet<ZetaCodeKumasFanteziKumasFantezi> ZetaCodeKumasFanteziKumasFantezi { get; set; } // ZetaCode_KumasFantezi_KumasFantezi
        public System.Data.Entity.DbSet<ZetaCodeKumasFanteziKumasOrmeDokuma> ZetaCodeKumasFanteziKumasOrmeDokuma { get; set; } // ZetaCode_KumasFantezi_KumasOrmeDokuma
        public System.Data.Entity.DbSet<ZetaCodeKumasMakine> ZetaCodeKumasMakine { get; set; } // ZetaCodeKumasMakine
        public System.Data.Entity.DbSet<ZetaCodeKumasOrmeDokuma> ZetaCodeKumasOrmeDokuma { get; set; } // ZetaCodeKumasOrmeDokuma
        public System.Data.Entity.DbSet<ZetaCodeKumasOrmeDokumaPicture> ZetaCodeKumasOrmeDokumaPicture { get; set; } // ZetaCodeKumasOrmeDokumaPicture
        public System.Data.Entity.DbSet<ZetaCodeNormalIplik> ZetaCodeNormalIplik { get; set; } // ZetaCodeNormalIplik
        public System.Data.Entity.DbSet<ZetaCodeNormalIplikPicture> ZetaCodeNormalIplikPicture { get; set; } // ZetaCodeNormalIplikPicture
        public System.Data.Entity.DbSet<ZetaCodeNormalKumasFanteziIplik> ZetaCodeNormalKumasFanteziIplik { get; set; } // ZetaCode_NormalKumas_FanteziIplik
        public System.Data.Entity.DbSet<ZetaCodeNormalKumasNormalIplik> ZetaCodeNormalKumasNormalIplik { get; set; } // ZetaCode_NormalKumas_NormalIplik
        public System.Data.Entity.DbSet<ZetaCodes> ZetaCodes { get; set; } // ZetaCodes
        public System.Data.Entity.DbSet<ZetaCodeYikamaTalimati> ZetaCodeYikamaTalimati { get; set; } // ZetaCodeYikamaTalimati

        static FollowMeDbContext()
        {
            System.Data.Entity.Database.SetInitializer<FollowMeDbContext>(null);
        }

        public FollowMeDbContext()
            : base("Name=FollowMeMsSqlServerConnection")
        {
            InitializePartial();
        }

        public FollowMeDbContext(string connectionString)
            : base(connectionString)
        {
            InitializePartial();
        }

        public FollowMeDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
            InitializePartial();
        }

        public FollowMeDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            InitializePartial();
        }

        public FollowMeDbContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
            InitializePartial();
        }

        protected override void Dispose(bool disposing)
        {
            DisposePartial(disposing);
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AddressGuideMap());
            modelBuilder.Configurations.Add(new BankGuideMap());
            modelBuilder.Configurations.Add(new BedenOlculeriMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new CompanyAddressMap());
            modelBuilder.Configurations.Add(new CompanyBankMap());
            modelBuilder.Configurations.Add(new CompanyPictureMap());
            modelBuilder.Configurations.Add(new CompanyTelephoneMap());
            modelBuilder.Configurations.Add(new CompanyTermMap());
            modelBuilder.Configurations.Add(new ErrorMap());
            modelBuilder.Configurations.Add(new IplikKategoriDegredeMap());
            modelBuilder.Configurations.Add(new IplikKategoriFlamMap());
            modelBuilder.Configurations.Add(new IplikKategoriKirciliMap());
            modelBuilder.Configurations.Add(new IplikKategoriKrepMap());
            modelBuilder.Configurations.Add(new IplikKategoriNopeliMap());
            modelBuilder.Configurations.Add(new IplikKategoriSimMap());
            modelBuilder.Configurations.Add(new IplikNoMap());
            modelBuilder.Configurations.Add(new IplikNoGuideMap());
            modelBuilder.Configurations.Add(new JsonObjectMap());
            modelBuilder.Configurations.Add(new LogisticsCompanyMap());
            modelBuilder.Configurations.Add(new PantoneRenkMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new PersonnelAddressMap());
            modelBuilder.Configurations.Add(new PersonnelBankMap());
            modelBuilder.Configurations.Add(new PersonnelEducationMap());
            modelBuilder.Configurations.Add(new PersonnelPictureMap());
            modelBuilder.Configurations.Add(new PersonnelTelephoneMap());
            modelBuilder.Configurations.Add(new PersonnelTermMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new RafBilgisiMap());
            modelBuilder.Configurations.Add(new RenkMap());
            modelBuilder.Configurations.Add(new SequenceBlueSiparisNoMap());
            modelBuilder.Configurations.Add(new TermMap());
            modelBuilder.Configurations.Add(new TermRelationshipMap());
            modelBuilder.Configurations.Add(new TermTaxonomyMap());
            modelBuilder.Configurations.Add(new ZetaCodeAksesuarMap());
            modelBuilder.Configurations.Add(new ZetaCodeAksesuarKompozisyonMap());
            modelBuilder.Configurations.Add(new ZetaCodeAksesuarPictureMap());
            modelBuilder.Configurations.Add(new ZetaCodeFanteziIplikMap());
            modelBuilder.Configurations.Add(new ZetaCodeFanteziIplikNormalIplikMap());
            modelBuilder.Configurations.Add(new ZetaCodeFanteziIplikPictureMap());
            modelBuilder.Configurations.Add(new ZetaCodeHazirGiyimMap());
            modelBuilder.Configurations.Add(new ZetaCodeHazirGiyimAksesuarMap());
            modelBuilder.Configurations.Add(new ZetaCodeHazirGiyimKumasFanteziMap());
            modelBuilder.Configurations.Add(new ZetaCodeHazirGiyimKumasOrmeDokumaMap());
            modelBuilder.Configurations.Add(new ZetaCodeKumasFantaziMap());
            modelBuilder.Configurations.Add(new ZetaCodeKumasFantaziPictureMap());
            modelBuilder.Configurations.Add(new ZetaCodeKumasFantezi3AdimIslemleriMap());
            modelBuilder.Configurations.Add(new ZetaCodeKumasFanteziKumasFanteziMap());
            modelBuilder.Configurations.Add(new ZetaCodeKumasFanteziKumasOrmeDokumaMap());
            modelBuilder.Configurations.Add(new ZetaCodeKumasMakineMap());
            modelBuilder.Configurations.Add(new ZetaCodeKumasOrmeDokumaMap());
            modelBuilder.Configurations.Add(new ZetaCodeKumasOrmeDokumaPictureMap());
            modelBuilder.Configurations.Add(new ZetaCodeNormalIplikMap());
            modelBuilder.Configurations.Add(new ZetaCodeNormalIplikPictureMap());
            modelBuilder.Configurations.Add(new ZetaCodeNormalKumasFanteziIplikMap());
            modelBuilder.Configurations.Add(new ZetaCodeNormalKumasNormalIplikMap());
            modelBuilder.Configurations.Add(new ZetaCodesMap());
            modelBuilder.Configurations.Add(new ZetaCodeYikamaTalimatiMap());

            OnModelCreatingPartial(modelBuilder);
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AddressGuideMap(schema));
            modelBuilder.Configurations.Add(new BankGuideMap(schema));
            modelBuilder.Configurations.Add(new BedenOlculeriMap(schema));
            modelBuilder.Configurations.Add(new CompanyMap(schema));
            modelBuilder.Configurations.Add(new CompanyAddressMap(schema));
            modelBuilder.Configurations.Add(new CompanyBankMap(schema));
            modelBuilder.Configurations.Add(new CompanyPictureMap(schema));
            modelBuilder.Configurations.Add(new CompanyTelephoneMap(schema));
            modelBuilder.Configurations.Add(new CompanyTermMap(schema));
            modelBuilder.Configurations.Add(new ErrorMap(schema));
            modelBuilder.Configurations.Add(new IplikKategoriDegredeMap(schema));
            modelBuilder.Configurations.Add(new IplikKategoriFlamMap(schema));
            modelBuilder.Configurations.Add(new IplikKategoriKirciliMap(schema));
            modelBuilder.Configurations.Add(new IplikKategoriKrepMap(schema));
            modelBuilder.Configurations.Add(new IplikKategoriNopeliMap(schema));
            modelBuilder.Configurations.Add(new IplikKategoriSimMap(schema));
            modelBuilder.Configurations.Add(new IplikNoMap(schema));
            modelBuilder.Configurations.Add(new IplikNoGuideMap(schema));
            modelBuilder.Configurations.Add(new JsonObjectMap(schema));
            modelBuilder.Configurations.Add(new LogisticsCompanyMap(schema));
            modelBuilder.Configurations.Add(new PantoneRenkMap(schema));
            modelBuilder.Configurations.Add(new PersonMap(schema));
            modelBuilder.Configurations.Add(new PersonnelAddressMap(schema));
            modelBuilder.Configurations.Add(new PersonnelBankMap(schema));
            modelBuilder.Configurations.Add(new PersonnelEducationMap(schema));
            modelBuilder.Configurations.Add(new PersonnelPictureMap(schema));
            modelBuilder.Configurations.Add(new PersonnelTelephoneMap(schema));
            modelBuilder.Configurations.Add(new PersonnelTermMap(schema));
            modelBuilder.Configurations.Add(new ProductMap(schema));
            modelBuilder.Configurations.Add(new RafBilgisiMap(schema));
            modelBuilder.Configurations.Add(new RenkMap(schema));
            modelBuilder.Configurations.Add(new SequenceBlueSiparisNoMap(schema));
            modelBuilder.Configurations.Add(new TermMap(schema));
            modelBuilder.Configurations.Add(new TermRelationshipMap(schema));
            modelBuilder.Configurations.Add(new TermTaxonomyMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeAksesuarMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeAksesuarKompozisyonMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeAksesuarPictureMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeFanteziIplikMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeFanteziIplikNormalIplikMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeFanteziIplikPictureMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeHazirGiyimMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeHazirGiyimAksesuarMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeHazirGiyimKumasFanteziMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeHazirGiyimKumasOrmeDokumaMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeKumasFantaziMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeKumasFantaziPictureMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeKumasFantezi3AdimIslemleriMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeKumasFanteziKumasFanteziMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeKumasFanteziKumasOrmeDokumaMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeKumasMakineMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeKumasOrmeDokumaMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeKumasOrmeDokumaPictureMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeNormalIplikMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeNormalIplikPictureMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeNormalKumasFanteziIplikMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeNormalKumasNormalIplikMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodesMap(schema));
            modelBuilder.Configurations.Add(new ZetaCodeYikamaTalimatiMap(schema));
            OnCreateModelPartial(modelBuilder, schema);
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void DisposePartial(bool disposing);
        partial void OnModelCreatingPartial(System.Data.Entity.DbModelBuilder modelBuilder);
		static partial void OnCreateModelPartial(System.Data.Entity.DbModelBuilder modelBuilder, string schema);        
    }
}
// </auto-generated>
