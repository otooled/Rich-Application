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
             if (context.Trips.Count() < 1)
            {
                //Add trips to database
                var trips = new List<Trip>
                                {
                                    //This trip is complete
                                    new Trip
                                        {
                                            TripName = "Dublin",
                                            TripStartDate = DateTime.Parse("2014-05-02"),
                                            TripFinishDate = DateTime.Parse("2014-06-08"),
                                        },

                                    //This trip is complete and viable  
                                    new Trip
                                        {
                                            TripName = "London",
                                            TripStartDate = DateTime.Parse("2014-03-04"),
                                            TripFinishDate = DateTime.Parse("2014-04-11"),
                                        },

                                    //This trip is viable but not complete
                                    new Trip
                                        {
                                            TripName = "New York",
                                            TripStartDate = DateTime.Parse("2014-05-10"),
                                            TripFinishDate = DateTime.Parse("2014-06-11"),
                                        },

                                    //This trip is not complete i.e legs are not spanning trip duration
                                    new Trip
                                        {
                                            TripName = "Paris",
                                            TripStartDate = DateTime.Parse("2014-08-15"),
                                            TripFinishDate = DateTime.Parse("2014-09-17"),
                                        },

                                    //This trip is not viable i.e not enough guests
                                    new Trip
                                        {
                                            TripName = "Athens",
                                            TripStartDate = DateTime.Parse("2014-04-22"),
                                            TripFinishDate = DateTime.Parse("2014-05-29"),
                                        }
                                };
                trips.ForEach(t => context.Trips.Add(t));
                context.SaveChanges();

                //Add legs to database
                var legs = new List<Leg>
                    //Legs for trip 1
                               {
                                   new Leg
                                       {
                                           StartLocation = "Cork",
                                           FinishLocation = "Kerry",
                                           LegStartDate = DateTime.Parse("2014-05-02"),
                                           LegFinishDate = DateTime.Parse("2014-05-09"),
                                           Trip = trips[0]
                                       },
                                   new Leg
                                       {
                                           StartLocation = "Kerry",
                                           FinishLocation = "Clare",
                                           LegStartDate = DateTime.Parse("2014-05-10"),
                                           LegFinishDate = DateTime.Parse("2014-05-17"),
                                           Trip = trips[0]
                                       },
                                   new Leg
                                       {
                                           StartLocation = "Clare",
                                           FinishLocation = "Galway",
                                           LegStartDate = DateTime.Parse("2014-05-18"),
                                           LegFinishDate = DateTime.Parse("2014-05-20"),
                                           Trip = trips[0]
                                       },
                                   new Leg
                                       {
                                           StartLocation = "Galway",
                                           FinishLocation = "Roscommon",
                                           LegStartDate = DateTime.Parse("2014-05-21"),
                                           LegFinishDate = DateTime.Parse("2014-05-26"),
                                           Trip = trips[0]
                                       },
                                   new Leg
                                       {
                                           StartLocation = "Roscommon",
                                           FinishLocation = "Tipperary",
                                           LegStartDate = DateTime.Parse("2014-05-27"),
                                           LegFinishDate = DateTime.Parse("2014-05-30"),
                                           Trip = trips[0]
                                       },
                                   new Leg
                                       {
                                           StartLocation = "Tipperary",
                                           FinishLocation = "Dublin",
                                           LegStartDate = DateTime.Parse("2014-05-31"),
                                           LegFinishDate = DateTime.Parse("2014-06-08"),
                                           Trip = trips[0]
                                       },
                                   //Legs for trip 2
                                   new Leg
                                       {
                                           StartLocation = "Manchester",
                                           FinishLocation = "Liverpool",
                                           LegStartDate = DateTime.Parse("2014-03-04"),
                                           LegFinishDate = DateTime.Parse("2014-03-11"),
                                           Trip = trips[1]
                                       },
                                   new Leg
                                       {
                                           StartLocation = "Liverpool",
                                           FinishLocation = "Newcastle",
                                           LegStartDate = DateTime.Parse("2014-03-12"),
                                           LegFinishDate = DateTime.Parse("2014-03-20"),
                                           Trip = trips[1]
                                       },
                                   new Leg
                                       {
                                           StartLocation = "Newcastle",
                                           FinishLocation = "Edinburgh",
                                           LegStartDate = DateTime.Parse("2014-03-21"),
                                           LegFinishDate = DateTime.Parse("2014-03-28"),
                                           Trip = trips[1]
                                       },
                                   new Leg
                                       {
                                           StartLocation = "Edinburgh",
                                           FinishLocation = "Sunderland",
                                           LegStartDate = DateTime.Parse("2014-03-29"),
                                           LegFinishDate = DateTime.Parse("2014-04-07"),
                                           Trip = trips[1]
                                       },

                                   new Leg
                                       {
                                           StartLocation = "Sunderland",
                                           FinishLocation = "London",
                                           LegStartDate = DateTime.Parse("2014-04-08"),
                                           LegFinishDate = DateTime.Parse("2014-04-16"),
                                           Trip = trips[1]
                                       },

                                   //Legs for trip 3
                                   new Leg
                                       {
                                           StartLocation = "Boston, MA",
                                           FinishLocation = "Providence, RI",
                                           LegStartDate = DateTime.Parse("2014-05-10"),
                                           LegFinishDate = DateTime.Parse("2014-05-16"),
                                           Trip = trips[2]
                                       },

                                   new Leg
                                       {
                                           StartLocation = "Providence, RI",
                                           FinishLocation = "Philadelphia, PA",
                                           LegStartDate = DateTime.Parse("2014-05-17"),
                                           LegFinishDate = DateTime.Parse("2014-05-23"),
                                           Trip = trips[2]
                                       },

                                   new Leg
                                       {
                                           StartLocation = "Philadelphia, Pa",
                                           FinishLocation = "Baltimore, MD",
                                           LegStartDate = DateTime.Parse("2014-05-24"),
                                           LegFinishDate = DateTime.Parse("2014-05-30"),
                                           Trip = trips[2]
                                       },

                                   //Legs for trip 4
                                   new Leg
                                       {
                                           StartLocation = "Bordeaux",
                                           FinishLocation = "Avignon",
                                           LegStartDate = DateTime.Parse("2014-08-15"),
                                           LegFinishDate = DateTime.Parse("2014-08-21"),
                                           Trip = trips[3]
                                       },
                                   new Leg
                                       {
                                           StartLocation = "Avignon",
                                           FinishLocation = "Clichy",
                                           LegStartDate = DateTime.Parse("2014-08-27"),
                                           LegFinishDate = DateTime.Parse("2014-09-03"),
                                           Trip = trips[3]
                                       },

                                   new Leg
                                       {
                                           StartLocation = "Clichy",
                                           FinishLocation = "Lille",
                                           LegStartDate = DateTime.Parse("2014-09-11"),
                                           LegFinishDate = DateTime.Parse("2014-09-18"),
                                           Trip = trips[3]
                                       },

                                   //Legs for trip 5
                                   new Leg
                                       {
                                           StartLocation = "Patras",
                                           FinishLocation = "Heraklion",
                                           LegStartDate = DateTime.Parse("2014-04-22"),
                                           LegFinishDate = DateTime.Parse("2014-04-28"),
                                           Trip = trips[4]
                                       },
                                   new Leg
                                       {
                                           StartLocation = "Heraklion",
                                           FinishLocation = "Larissa",
                                           LegStartDate = DateTime.Parse("2014-04-29"),
                                           LegFinishDate = DateTime.Parse("2014-05-05"),
                                           Trip = trips[4]
                                       },

                                   new Leg
                                       {
                                           StartLocation = "Larissa",
                                           FinishLocation = "Volos",
                                           LegStartDate = DateTime.Parse("2014-05-06"),
                                           LegFinishDate = DateTime.Parse("2014-05-12"),
                                           Trip = trips[4]
                                       },

                                   new Leg
                                       {
                                           StartLocation = "Volos",
                                           FinishLocation = "Rhodes",
                                           LegStartDate = DateTime.Parse("2014-05-12"),
                                           LegFinishDate = DateTime.Parse("2014-05-19"),
                                           Trip = trips[4]
                                       },

                                   new Leg
                                       {
                                           StartLocation = "Rhodes",
                                           FinishLocation = "Chalcis",
                                           LegStartDate = DateTime.Parse("2014-05-20"),
                                           LegFinishDate = DateTime.Parse("2014-05-29"),
                                           Trip = trips[4]
                                       },
                               };

                legs.ForEach(l => context.Legs.Add(l));
                context.SaveChanges();

                var guests = new List<Guest>
                                 {
                                     new Guest
                                         {
                                             FirstName = "David"
                                         },
                                     new Guest
                                         {
                                             FirstName = "Barbara"
                                         },
                                     new Guest
                                         {
                                             FirstName = "John"
                                         },
                                     new Guest
                                         {
                                             FirstName = "Ringo"
                                         },

                                     new Guest
                                         {
                                             FirstName = "George"
                                         },
                                     new Guest
                                         {
                                             FirstName = "Paul"
                                         },
                                     new Guest
                                         {
                                             FirstName = "Sally"
                                         },
                                     new Guest
                                         {
                                             FirstName = "Ann"
                                         },
                                     new Guest
                                         {
                                             FirstName = "Billy Bob"
                                         }
                                 };
                guests.ForEach(g => context.Guests.Add(g));
                context.SaveChanges();

                var legGuests = new List<LegGuest>
                                    {
                                        new LegGuest
                                            {
                                                Leg = legs[1],
                                                Guest = guests[0]
                                            },

                                        //guests to make trip 2 viable and complete
                                        new LegGuest
                                            {
                                                Leg = legs[6],
                                                Guest = guests[1]
                                            },

                                        new LegGuest
                                            {
                                                Leg = legs[7],
                                                Guest = guests[2]
                                            },
                                        new LegGuest
                                            {
                                                Leg = legs[8],
                                                Guest = guests[3]
                                            },

                                            //guests to make trip 3 viable but it's not complete
                                        new LegGuest
                                            {
                                                Leg = legs[12],
                                                Guest = guests[4]
                                            },
                                             new LegGuest
                                            {
                                                Leg = legs[13],
                                                Guest = guests[5]
                                            },
                                             new LegGuest
                                            {
                                                Leg = legs[14],
                                                Guest = guests[6]
                                            }
                                    };
                legGuests.ForEach(lg => context.LegGuests.Add(lg));
                context.SaveChanges();
            }
        }   // end Seed()
    }   // end Configuration
}
