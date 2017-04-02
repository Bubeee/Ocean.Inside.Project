﻿using System.Data.Entity;
using Ocean.Inside.DAL.DbConfiguration;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL
{
    public class OceanDbContext : DbContext
    {
        public OceanDbContext() : base("Ocean.db") { }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourProgram> TourPrograms { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TourConfiguration());
            modelBuilder.Configurations.Add(new TourProgramConfiguration());
        }
    }
}
