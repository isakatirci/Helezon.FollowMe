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

    using System.Linq;

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class GLCEmasModel : System.Data.Entity.DbContext, IGLCEmasModel
    {
        public System.Data.Entity.DbSet<AddressGuide> AddressGuide { get; set; } // AddressGuide
        public System.Data.Entity.DbSet<BankGuide> BankGuide { get; set; } // BankGuide
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
        public System.Data.Entity.DbSet<RafBilgisi> RafBilgisi { get; set; } // RafBilgisi
        public System.Data.Entity.DbSet<Renk> Renk { get; set; } // Renk
        public System.Data.Entity.DbSet<SequenceBlueSiparisNo> SequenceBlueSiparisNo { get; set; } // SequenceBlueSiparisNo
        public System.Data.Entity.DbSet<Term> Term { get; set; } // Term
        public System.Data.Entity.DbSet<TermRelationship> TermRelationship { get; set; } // TermRelationship
        public System.Data.Entity.DbSet<TermTaxonomy> TermTaxonomy { get; set; } // TermTaxonomy
        public System.Data.Entity.DbSet<ZetaCodeFanteziIplik> ZetaCodeFanteziIplik { get; set; } // ZetaCodeFanteziIplik
        public System.Data.Entity.DbSet<ZetaCodeNormalIplik> ZetaCodeNormalIplik { get; set; } // ZetaCodeNormalIplik
        public System.Data.Entity.DbSet<ZetaCodeNormalIplikPicture> ZetaCodeNormalIplikPicture { get; set; } // ZetaCodeNormalIplikPicture

        static GLCEmasModel()
        {
            System.Data.Entity.Database.SetInitializer<GLCEmasModel>(null);
        }

        public GLCEmasModel()
            : base("Name=GLCEmasEntities")
        {
            InitializePartial();
        }

        public GLCEmasModel(string connectionString)
            : base(connectionString)
        {
            InitializePartial();
        }

        public GLCEmasModel(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
            InitializePartial();
        }

        public GLCEmasModel(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            InitializePartial();
        }

        public GLCEmasModel(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
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

            modelBuilder.Configurations.Add(new AddressGuideConfiguration());
            modelBuilder.Configurations.Add(new BankGuideConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new CompanyAddressConfiguration());
            modelBuilder.Configurations.Add(new CompanyBankConfiguration());
            modelBuilder.Configurations.Add(new CompanyPictureConfiguration());
            modelBuilder.Configurations.Add(new CompanyTelephoneConfiguration());
            modelBuilder.Configurations.Add(new CompanyTermConfiguration());
            modelBuilder.Configurations.Add(new ErrorConfiguration());
            modelBuilder.Configurations.Add(new IplikKategoriDegredeConfiguration());
            modelBuilder.Configurations.Add(new IplikKategoriFlamConfiguration());
            modelBuilder.Configurations.Add(new IplikKategoriKirciliConfiguration());
            modelBuilder.Configurations.Add(new IplikKategoriKrepConfiguration());
            modelBuilder.Configurations.Add(new IplikKategoriNopeliConfiguration());
            modelBuilder.Configurations.Add(new IplikKategoriSimConfiguration());
            modelBuilder.Configurations.Add(new IplikNoConfiguration());
            modelBuilder.Configurations.Add(new IplikNoGuideConfiguration());
            modelBuilder.Configurations.Add(new JsonObjectConfiguration());
            modelBuilder.Configurations.Add(new LogisticsCompanyConfiguration());
            modelBuilder.Configurations.Add(new PantoneRenkConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new PersonnelAddressConfiguration());
            modelBuilder.Configurations.Add(new PersonnelBankConfiguration());
            modelBuilder.Configurations.Add(new PersonnelEducationConfiguration());
            modelBuilder.Configurations.Add(new PersonnelPictureConfiguration());
            modelBuilder.Configurations.Add(new PersonnelTelephoneConfiguration());
            modelBuilder.Configurations.Add(new PersonnelTermConfiguration());
            modelBuilder.Configurations.Add(new RafBilgisiConfiguration());
            modelBuilder.Configurations.Add(new RenkConfiguration());
            modelBuilder.Configurations.Add(new SequenceBlueSiparisNoConfiguration());
            modelBuilder.Configurations.Add(new TermConfiguration());
            modelBuilder.Configurations.Add(new TermRelationshipConfiguration());
            modelBuilder.Configurations.Add(new TermTaxonomyConfiguration());
            modelBuilder.Configurations.Add(new ZetaCodeFanteziIplikConfiguration());
            modelBuilder.Configurations.Add(new ZetaCodeNormalIplikConfiguration());
            modelBuilder.Configurations.Add(new ZetaCodeNormalIplikPictureConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AddressGuideConfiguration(schema));
            modelBuilder.Configurations.Add(new BankGuideConfiguration(schema));
            modelBuilder.Configurations.Add(new CompanyConfiguration(schema));
            modelBuilder.Configurations.Add(new CompanyAddressConfiguration(schema));
            modelBuilder.Configurations.Add(new CompanyBankConfiguration(schema));
            modelBuilder.Configurations.Add(new CompanyPictureConfiguration(schema));
            modelBuilder.Configurations.Add(new CompanyTelephoneConfiguration(schema));
            modelBuilder.Configurations.Add(new CompanyTermConfiguration(schema));
            modelBuilder.Configurations.Add(new ErrorConfiguration(schema));
            modelBuilder.Configurations.Add(new IplikKategoriDegredeConfiguration(schema));
            modelBuilder.Configurations.Add(new IplikKategoriFlamConfiguration(schema));
            modelBuilder.Configurations.Add(new IplikKategoriKirciliConfiguration(schema));
            modelBuilder.Configurations.Add(new IplikKategoriKrepConfiguration(schema));
            modelBuilder.Configurations.Add(new IplikKategoriNopeliConfiguration(schema));
            modelBuilder.Configurations.Add(new IplikKategoriSimConfiguration(schema));
            modelBuilder.Configurations.Add(new IplikNoConfiguration(schema));
            modelBuilder.Configurations.Add(new IplikNoGuideConfiguration(schema));
            modelBuilder.Configurations.Add(new JsonObjectConfiguration(schema));
            modelBuilder.Configurations.Add(new LogisticsCompanyConfiguration(schema));
            modelBuilder.Configurations.Add(new PantoneRenkConfiguration(schema));
            modelBuilder.Configurations.Add(new PersonConfiguration(schema));
            modelBuilder.Configurations.Add(new PersonnelAddressConfiguration(schema));
            modelBuilder.Configurations.Add(new PersonnelBankConfiguration(schema));
            modelBuilder.Configurations.Add(new PersonnelEducationConfiguration(schema));
            modelBuilder.Configurations.Add(new PersonnelPictureConfiguration(schema));
            modelBuilder.Configurations.Add(new PersonnelTelephoneConfiguration(schema));
            modelBuilder.Configurations.Add(new PersonnelTermConfiguration(schema));
            modelBuilder.Configurations.Add(new RafBilgisiConfiguration(schema));
            modelBuilder.Configurations.Add(new RenkConfiguration(schema));
            modelBuilder.Configurations.Add(new SequenceBlueSiparisNoConfiguration(schema));
            modelBuilder.Configurations.Add(new TermConfiguration(schema));
            modelBuilder.Configurations.Add(new TermRelationshipConfiguration(schema));
            modelBuilder.Configurations.Add(new TermTaxonomyConfiguration(schema));
            modelBuilder.Configurations.Add(new ZetaCodeFanteziIplikConfiguration(schema));
            modelBuilder.Configurations.Add(new ZetaCodeNormalIplikConfiguration(schema));
            modelBuilder.Configurations.Add(new ZetaCodeNormalIplikPictureConfiguration(schema));
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
