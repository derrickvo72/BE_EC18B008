using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Express.Models;

namespace Express.Models
{
    public class DBExpressContext : DbContext
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillStatusDetail> BillStatusDetails { get; set; }
        public DbSet<CommissionsRule> CommissionsRules { get; set; }
        public DbSet<CommissionsRealTime> CommissionsRealTimes { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<ShipCompany> ShipCompanies { get; set; }
        public DbSet<ShipDiscount> ShipDiscounts { get; set; }
        public DbSet<ShippingFee> ShippingFees { get; set; }
        public DbSet<SubDistricts> SubDistricts { get; set; }
        public DbSet<Users> Users { get; set; }

        public DBExpressContext(DbContextOptions<DBExpressContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
            .HasOne<BillStatusDetail>(s => s.StatusDetail)
            .WithOne(ad => ad.Bill)
            .HasForeignKey<BillStatusDetail>(ad => ad.Billid);

            modelBuilder.Entity<Bill>()
            .HasOne<Users>(s => s.User)
            .WithMany(g => g.Bills)
            .HasForeignKey(s => s.Userid);

            modelBuilder.Entity<SubDistricts>()
           .HasOne<Users>(s => s.User)
           .WithOne(ad => ad.SubDistrict)
           .HasForeignKey<Users>(ad => ad.SubDisid);

            modelBuilder.Entity<SubDistricts>()
            .HasOne<Districts>(s => s.District)
            .WithMany(g => g.SubDistricts)
            .HasForeignKey(s => s.Disid);

            modelBuilder.Entity<Districts>()
            .HasOne<Provinces>(s => s.Province)
            .WithMany(g => g.Districts)
            .HasForeignKey(s => s.Proid);

            modelBuilder.Entity<SubDistricts>()
           .HasOne<ShipCompany>(s => s.ShipCompany)
           .WithOne(ad => ad.SubDistrict)
           .HasForeignKey<ShipCompany>(ad => ad.SubDisid);

            modelBuilder.Entity<Bill>()
           .HasOne<CommissionsRealTime>(s => s.CommisstionsRealTime)
           .WithOne(ad => ad.Bill)
           .HasForeignKey<CommissionsRealTime>(ad => ad.Billid);

            modelBuilder.Entity<CommissionsRealTime>()
             .HasOne(sc => sc.CommissionsRule)
             .WithMany(s => s.CommisstionsRealTimes)
             .HasForeignKey(sc => sc.IDComR).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommissionsRule>()
            .HasOne<ShipCompany>(s => s.ShipCompany)
            .WithMany(g => g.CommissionsRules)
            .HasForeignKey(s => s.IDCompany);

            modelBuilder.Entity<ShippingFee>()
            .HasOne<ShipCompany>(s => s.ShipCompany)
            .WithMany(g => g.ShippingFees)
            .HasForeignKey(s => s.Compid);

            modelBuilder.Entity<ShipDiscount>()
            .HasOne<ShipCompany>(s => s.ShipCompany)
            .WithMany(g => g.ShipDiscounts)
            .HasForeignKey(s => s.Compid);
        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch
            {
                return 0;
            }
        }
    }
}
