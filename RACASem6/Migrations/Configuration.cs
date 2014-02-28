using System.Collections.Generic;
using RACASem6.Models;

namespace RACASem6.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RACASem6.DAL.TourContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RACASem6.DAL.TourContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
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
        }   // end Seed()
    }   // end Configuration
}
