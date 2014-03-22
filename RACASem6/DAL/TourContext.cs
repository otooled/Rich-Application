using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RACASem6.Migrations;
using RACASem6.Models;


namespace RACASem6.DAL
{
    public class TourContext:DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Leg> Legs { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<LegGuest> LegGuests { get; set; } 

        public TourContext()
        :base("TourDatabase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TourContext, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    
}