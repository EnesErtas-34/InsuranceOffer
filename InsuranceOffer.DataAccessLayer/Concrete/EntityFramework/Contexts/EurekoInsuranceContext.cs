using InsuranceOffer.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InsuranceOffer.DataAccessLayer.Concrete.EntityFramework.Contexts
{
    public class EurekoInsuranceContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-RO7ES1P;initial catalog=DbEureko;integrated security=true;TrustServerCertificate=True;");
        }
        public DbSet<Insured> Insureds { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Assurance> Assurances { get; set; }
        public DbSet<PoliceAssurance> PoliceAssurances { get; set; }

        public DbSet<Pay> Pays { get; set; }
        public DbSet<VerificationCodes> VerificationCodes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  modelBuilder.Entity<Policy>()
            //      .HasOne(p => p.InsuredNo)
            //      .WithMany(i => i.PoliciesAsInsured)
            //      .HasForeignKey(p => p.InsuredID)
            //      .OnDelete(DeleteBehavior.ClientSetNull);

            //  modelBuilder.Entity<Policy>()
            //      .HasOne(p => p.InsurerNo)
            //      .WithMany(i => i.PoliciesAsInsurer)
            //      .HasForeignKey(p => p.InsurerID)
            //      .OnDelete(DeleteBehavior.ClientSetNull);
            //  modelBuilder.Entity<Policy>()
            //.HasOne(p => p.Pay)
            //.WithOne(p => p.Policy)
            //.HasForeignKey<Pay>(p => p.PolicyID);

            //  modelBuilder.Entity<Pay>()
            //      .HasOne(p => p.Insured)
            //      .WithMany(i => i.Pays)
            //      .HasForeignKey(p => p.InsuredID);

            //  modelBuilder.Entity<PoliceAssurance>()
            //      .HasKey(pa => pa.PoliceAssuranceID);

            //  modelBuilder.Entity<PoliceAssurance>()
            //      .HasOne(pa => pa.Policy)
            //      .WithMany(p => p.PoliceAssurances)
            //      .HasForeignKey(pa => pa.PolicyID);

            //  modelBuilder.Entity<PoliceAssurance>()
            //      .HasOne(pa => pa.Assurance)
            //      .WithMany(a => a.PoliceTeminats)
            //      .HasForeignKey(pa => pa.AssuranceCode);
            //  modelBuilder.Entity<Pay>()
            //  .HasOne(p => p.Policy)
            //  .WithOne(p => p.Pay)
            //  .HasForeignKey<Policy>(p => p.PayID);

            modelBuilder.Entity<Policy>()
           .HasOne(p => p.InsuredNo)
           .WithMany(i => i.PoliciesAsInsured)
           .HasForeignKey(p => p.InsuredID)
           .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Policy>()
                .HasOne(p => p.InsurerNo)
                .WithMany(i => i.PoliciesAsInsurer)
                .HasForeignKey(p => p.InsurerID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Pay>()
                .HasOne(p => p.Policy)
                .WithOne(p => p.Pay)
                .HasForeignKey<Pay>(p => p.PolicyID);

            modelBuilder.Entity<Pay>()
                .HasOne(p => p.Insured)
                .WithMany(i => i.Pays)
                .HasForeignKey(p => p.InsuredID);

            modelBuilder.Entity<PoliceAssurance>()
                .HasKey(pa => pa.PoliceAssuranceID);

            modelBuilder.Entity<PoliceAssurance>()
                .HasOne(pa => pa.Policy)
                .WithMany(p => p.PoliceAssurances)
                .HasForeignKey(pa => pa.PolicyID);

            modelBuilder.Entity<PoliceAssurance>()
                .HasOne(pa => pa.Assurance)
                .WithMany(a => a.PoliceTeminats)
                .HasForeignKey(pa => pa.AssuranceCode);

        }
       
    }
}
