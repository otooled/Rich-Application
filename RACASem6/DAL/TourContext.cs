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
            /*Database.SetInitializer(new TripDB() ); JK*/
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TourContext, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    /*public class TripDB : DropCreateDatabaseIfModelChanges<TourContext>
    {
        protected override void Seed(TourContext context)
        {
            var trips = new List<Trip>
                            {
                                new Trip
                                    {
                                        TripName = "Dublin",
                                        TripStartDate = DateTime.Parse("2012-05-02"),
                                        TripFinishDate = DateTime.Parse("2012-05-08"),
                                        NoOfLegs = 2,
                                        TripNoOfGuests = 7
                                    },
                                new Trip
                                    {
                                        TripName = "London",
                                        TripStartDate = DateTime.Parse("2013-07-04"),
                                        TripFinishDate = DateTime.Parse("2013-07-11"),
                                        NoOfLegs = 1,
                                        TripNoOfGuests = 3
                                    }
                            };
            trips.ForEach(t => context.Trips.Add(t));
            context.SaveChanges();
        }
    }*/
}