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
            //Add trips to database
            var trips = new List<Trip>
                            {
                                //This trip is complete
                                new Trip
                                    {TripName = "Dublin", TripStartDate = DateTime.Parse("2014-05-02"), TripFinishDate = DateTime.Parse("2014-06-08"),
                                        TripNoOfGuests = 7},

                                //This trip is viable    
                                new Trip
                                    {TripName = "London", TripStartDate = DateTime.Parse("2014-03-04"), TripFinishDate = DateTime.Parse("2014-04-11"),
                                         TripNoOfGuests = 4},

                                 //This trip is complete and viable
                                 new Trip
                                     {TripName = "New York", TripStartDate = DateTime.Parse("2014-05-10"), TripFinishDate = DateTime.Parse("2014-06-11"),
                                        TripNoOfGuests = 5},

                                 //This trip is not complete i.e legs are not spanning trip duration
                                 new Trip
                                     {TripName = "Paris", TripStartDate = DateTime.Parse("2014-08-15"), TripFinishDate = DateTime.Parse("2014-09-17"),
                                         TripNoOfGuests = 14},

                                 //This trip is not viable i.e not enough guests
                                 new Trip
                                    {TripName = "Athens", TripStartDate = DateTime.Parse("2014-04-22"), TripFinishDate = DateTime.Parse("2014-05-11"),
                                         TripNoOfGuests = 14}
                            };
            trips.ForEach(t => context.Trips.Add(t));
            context.SaveChanges();   
  
            //Add legs to database
            var legs = new List<Leg>
                           {
                               //Legs for trip 1
                               new Leg
                               {StartLocation = "Cork", FinishLocation = "Kerry", LegStartDate = DateTime.Parse("2014-05-02"),
                                       LegFinishDate = DateTime.Parse("2014-05-09"), Trip = trips[0]},

                               new Leg
                               {StartLocation = "Kerry", FinishLocation = "Clare", LegStartDate = DateTime.Parse("2014-05-10"),
                                           LegFinishDate = DateTime.Parse("2014-05-17"), Trip = trips[0]},
                                
                               new Leg
                                {
                                   StartLocation = "Clare", FinishLocation = "Galway", LegStartDate = DateTime.Parse("2014-05-18"),
                                           LegFinishDate = DateTime.Parse("2014-05-20"), Trip = trips[0] 
                                },

                                new Leg
                                {
                                   StartLocation = "Galway", FinishLocation = "Roscommon", LegStartDate = DateTime.Parse("2014-05-21"),
                                           LegFinishDate = DateTime.Parse("2014-05-26"), Trip = trips[0] 
                                },

                                new Leg
                                {
                                   StartLocation = "Roscommon", FinishLocation = "Tipperary", LegStartDate = DateTime.Parse("2014-05-27"),
                                           LegFinishDate = DateTime.Parse("2014-05-30"), Trip = trips[0] 
                                },
                                new Leg
                                {
                                   StartLocation = "Tipperary", FinishLocation = "Dublin", LegStartDate = DateTime.Parse("2014-05-31"),
                                           LegFinishDate = DateTime.Parse("2014-06-08"), Trip = trips[0]
                                }

                           };
            
            legs.ForEach(l => context.Legs.Add(l));
            context.SaveChanges();
        }   // end Seed()
    }   // end Configuration
}
