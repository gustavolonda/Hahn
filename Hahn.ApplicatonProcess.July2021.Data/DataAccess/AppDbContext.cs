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
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            modelBuilder.Entity<User>()
            .HasOne(x => x.Address)
            .WithOne()
            .HasForeignKey<User>(x => x.AddressId);
            
        }

    }
}