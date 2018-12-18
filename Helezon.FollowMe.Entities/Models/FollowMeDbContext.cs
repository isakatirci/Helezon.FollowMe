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


    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class FollowMeDbContext : System.Data.Entity.DbContext, IFollowMeDbContext
    {
        public System.Data.Entity.DbSet<AddressGuide> AddressGuides { get; set; } // AddressGuide
        public System.Data.Entity.DbSet<BankGuide> BankGuides { get; set; } // BankGuide
        public System.Data.Entity.DbSet<Company> Companies { get; set; } // Company
        public System.Data.Entity.DbSet<CompanyAddress> CompanyAddresses { get; set; } // CompanyAddress
        public System.Data.Entity.DbSet<CompanyBank> CompanyBanks { get; set; } // CompanyBank
        public System.Data.Entity.DbSet<CompanyTelephone> CompanyTelephones { get; set; } // CompanyTelephone
        public System.Data.Entity.DbSet<CompanyTerm> CompanyTerms { get; set; } // CompanyTerm
        public System.Data.Entity.DbSet<JsonObject> JsonObjects { get; set; } // JsonObject
        public System.Data.Entity.DbSet<LogisticsCompany> LogisticsCompanies { get; set; } // LogisticsCompany
        public System.Data.Entity.DbSet<Person> People { get; set; } // Person
        public System.Data.Entity.DbSet<PersonnelAddress> PersonnelAddresses { get; set; } // PersonnelAddress
        public System.Data.Entity.DbSet<PersonnelBank> PersonnelBanks { get; set; } // PersonnelBank
        public System.Data.Entity.DbSet<PersonnelEducation> PersonnelEducations { get; set; } // PersonnelEducation
        public System.Data.Entity.DbSet<PersonnelTelephone> PersonnelTelephones { get; set; } // PersonnelTelephone
        public System.Data.Entity.DbSet<PersonnelTerm> PersonnelTerms { get; set; } // PersonnelTerm
        public System.Data.Entity.DbSet<Sequence> Sequences { get; set; } // Sequence
        public System.Data.Entity.DbSet<Term> Terms { get; set; } // Term
        public System.Data.Entity.DbSet<TermRelationship> TermRelationships { get; set; } // TermRelationship
        public System.Data.Entity.DbSet<TermTaxonomy> TermTaxonomies { get; set; } // TermTaxonomy

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
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new CompanyAddressMap());
            modelBuilder.Configurations.Add(new CompanyBankMap());
            modelBuilder.Configurations.Add(new CompanyTelephoneMap());
            modelBuilder.Configurations.Add(new CompanyTermMap());
            modelBuilder.Configurations.Add(new JsonObjectMap());
            modelBuilder.Configurations.Add(new LogisticsCompanyMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new PersonnelAddressMap());
            modelBuilder.Configurations.Add(new PersonnelBankMap());
            modelBuilder.Configurations.Add(new PersonnelEducationMap());
            modelBuilder.Configurations.Add(new PersonnelTelephoneMap());
            modelBuilder.Configurations.Add(new PersonnelTermMap());
            modelBuilder.Configurations.Add(new SequenceMap());
            modelBuilder.Configurations.Add(new TermMap());
            modelBuilder.Configurations.Add(new TermRelationshipMap());
            modelBuilder.Configurations.Add(new TermTaxonomyMap());

            OnModelCreatingPartial(modelBuilder);
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AddressGuideMap(schema));
            modelBuilder.Configurations.Add(new BankGuideMap(schema));
            modelBuilder.Configurations.Add(new CompanyMap(schema));
            modelBuilder.Configurations.Add(new CompanyAddressMap(schema));
            modelBuilder.Configurations.Add(new CompanyBankMap(schema));
            modelBuilder.Configurations.Add(new CompanyTelephoneMap(schema));
            modelBuilder.Configurations.Add(new CompanyTermMap(schema));
            modelBuilder.Configurations.Add(new JsonObjectMap(schema));
            modelBuilder.Configurations.Add(new LogisticsCompanyMap(schema));
            modelBuilder.Configurations.Add(new PersonMap(schema));
            modelBuilder.Configurations.Add(new PersonnelAddressMap(schema));
            modelBuilder.Configurations.Add(new PersonnelBankMap(schema));
            modelBuilder.Configurations.Add(new PersonnelEducationMap(schema));
            modelBuilder.Configurations.Add(new PersonnelTelephoneMap(schema));
            modelBuilder.Configurations.Add(new PersonnelTermMap(schema));
            modelBuilder.Configurations.Add(new SequenceMap(schema));
            modelBuilder.Configurations.Add(new TermMap(schema));
            modelBuilder.Configurations.Add(new TermRelationshipMap(schema));
            modelBuilder.Configurations.Add(new TermTaxonomyMap(schema));
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