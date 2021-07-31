using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Hahn.ApplicatonProcess.July2021.Domain.Models;

namespace Hahn.ApplicatonProcess.July2021.Data.DataAccess
{   /********************************************************
    *                         Context                       *
    *********************************************************/
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserAsset> UserAssets { get; set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            modelBuilder.Entity<User>()
            .HasOne(x => x.Address)
            .WithOne()
            .HasForeignKey<User>(x => x.AddressId);
            modelBuilder.Entity<UserAsset>()
            .HasKey(bc => new { bc.UserId, bc.AssetId });  
            modelBuilder.Entity<UserAsset>()
            .HasOne(bc => bc.Asset)
            .WithMany(b => b.UserAssets)
            .HasForeignKey(bc => bc.AssetId);  
            modelBuilder.Entity<UserAsset>()
            .HasOne(bc => bc.User)
            .WithMany(c => c.UserAssets)
            .HasForeignKey(bc => bc.UserId);
            
        }

    }
}