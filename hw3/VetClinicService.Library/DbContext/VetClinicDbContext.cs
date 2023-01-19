using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VetClinicService.Library.Models;

namespace VetClinicService.Library.DBContext
{
	public class VetClinicDbContext : DbContext
	{
        public DbSet<Client> Clients { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Consultation> Consultations { get; set; }



        public VetClinicDbContext(DbContextOptions options) : base(options)
		{
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }



        #region Creating connection

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=VCS.db;");
        }

        #endregion


        #region Creating tables

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>();
            modelBuilder.Entity<Pet>();
            modelBuilder.Entity<Consultation>().HasOne(x => x.Pet).WithMany(y => y.Consultations).HasForeignKey(k => k.PetId).OnDelete(DeleteBehavior.NoAction);
        }

        #endregion
    }
}

