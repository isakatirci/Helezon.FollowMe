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

    public partial interface IFollowMeDbContext : System.IDisposable
    {
        System.Data.Entity.DbSet<AddressGuide> AddressGuide { get; set; } // AddressGuide
        System.Data.Entity.DbSet<BankGuide> BankGuide { get; set; } // BankGuide
        System.Data.Entity.DbSet<Company> Company { get; set; } // Company
        System.Data.Entity.DbSet<CompanyAddress> CompanyAddress { get; set; } // CompanyAddress
        System.Data.Entity.DbSet<CompanyBank> CompanyBank { get; set; } // CompanyBank
        System.Data.Entity.DbSet<CompanyPicture> CompanyPicture { get; set; } // CompanyPicture
        System.Data.Entity.DbSet<CompanyTelephone> CompanyTelephone { get; set; } // CompanyTelephone
        System.Data.Entity.DbSet<CompanyTerm> CompanyTerm { get; set; } // CompanyTerm
        System.Data.Entity.DbSet<Error> Error { get; set; } // Error
        System.Data.Entity.DbSet<IplikKategoriDegrede> IplikKategoriDegrede { get; set; } // IplikKategoriDegrede
        System.Data.Entity.DbSet<IplikKategoriFlam> IplikKategoriFlam { get; set; } // IplikKategoriFlam
        System.Data.Entity.DbSet<IplikKategoriKircili> IplikKategoriKircili { get; set; } // IplikKategoriKircili
        System.Data.Entity.DbSet<IplikKategoriKrep> IplikKategoriKrep { get; set; } // IplikKategoriKrep
        System.Data.Entity.DbSet<IplikKategoriNopeli> IplikKategoriNopeli { get; set; } // IplikKategoriNopeli
        System.Data.Entity.DbSet<IplikKategoriSim> IplikKategoriSim { get; set; } // IplikKategoriSim
        System.Data.Entity.DbSet<IplikNo> IplikNo { get; set; } // IplikNo
        System.Data.Entity.DbSet<IplikNoGuide> IplikNoGuide { get; set; } // IplikNoGuide
        System.Data.Entity.DbSet<JsonObject> JsonObject { get; set; } // JsonObject
        System.Data.Entity.DbSet<LogisticsCompany> LogisticsCompany { get; set; } // LogisticsCompany
        System.Data.Entity.DbSet<PantoneRenk> PantoneRenk { get; set; } // PantoneRenk
        System.Data.Entity.DbSet<Person> Person { get; set; } // Person
        System.Data.Entity.DbSet<PersonnelAddress> PersonnelAddress { get; set; } // PersonnelAddress
        System.Data.Entity.DbSet<PersonnelBank> PersonnelBank { get; set; } // PersonnelBank
        System.Data.Entity.DbSet<PersonnelEducation> PersonnelEducation { get; set; } // PersonnelEducation
        System.Data.Entity.DbSet<PersonnelPicture> PersonnelPicture { get; set; } // PersonnelPicture
        System.Data.Entity.DbSet<PersonnelTelephone> PersonnelTelephone { get; set; } // PersonnelTelephone
        System.Data.Entity.DbSet<PersonnelTerm> PersonnelTerm { get; set; } // PersonnelTerm
        System.Data.Entity.DbSet<RafBilgisi> RafBilgisi { get; set; } // RafBilgisi
        System.Data.Entity.DbSet<Renk> Renk { get; set; } // Renk
        System.Data.Entity.DbSet<SequenceBlueSiparisNo> SequenceBlueSiparisNo { get; set; } // SequenceBlueSiparisNo
        System.Data.Entity.DbSet<Term> Term { get; set; } // Term
        System.Data.Entity.DbSet<TermRelationship> TermRelationship { get; set; } // TermRelationship
        System.Data.Entity.DbSet<TermTaxonomy> TermTaxonomy { get; set; } // TermTaxonomy
        System.Data.Entity.DbSet<ZetaCodeFanteziIplik> ZetaCodeFanteziIplik { get; set; } // ZetaCodeFanteziIplik
        System.Data.Entity.DbSet<ZetaCodeNormalIplik> ZetaCodeNormalIplik { get; set; } // ZetaCodeNormalIplik
        System.Data.Entity.DbSet<ZetaCodeNormalIplikPicture> ZetaCodeNormalIplikPicture { get; set; } // ZetaCodeNormalIplikPicture

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
        System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get; }
        System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get; }
        System.Data.Entity.Database Database { get; }
        System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
        System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors();
        System.Data.Entity.DbSet Set(System.Type entityType);
        System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
    }

}
// </auto-generated>
