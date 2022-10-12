using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Data
{
    public class AppDataInit
    {

        public static void SeedRestaurant(ApplicationDbContext context)
        {
            if (!context.Restaurants.Any())
            {
                for (int i = 1; i <= 1000; i++)
                {
                    context.Restaurants.Add(
                    new Restaurant
                    {
                        Name = $"McDonalds {i}",
                        City = "Tallinn",
                        Country = "Estonia",
                        Review = new List<RestarauntReview>()
                        {
                            new RestarauntReview()
                            {
                                Rating = 10,
                                Body = "It's Shit"
                            }
                        }
                    });
                    context.Restaurants.Add(
                    new Restaurant
                    {
                        Name = $"Hesburger{i}",
                        City = "Tallinn",
                        Country = "Estonia",
                        Review = new List<RestarauntReview>()
                        {
                            new RestarauntReview()
                            {
                                Rating = 10,
                                Body = "It's Not Bad"
                            }
                        }
                    });
                    context.Restaurants.Add(
                        new Restaurant
                        {
                            Name = $"BabyBack Ribs & BBQ{i}",
                            City = "Tallinn",
                            Country = "Estonia",
                            Review = new List<RestarauntReview>()
                            {
                            new RestarauntReview()
                            {
                                Rating = 10,
                                Body = "It's Perfection"
                            }
                            }
                        });
                    context.Restaurants.Add(
                        new Restaurant
                        {
                            Name = $"Burger King{i}",
                            City = "Stockholm",
                            Country = "Finland",
                            Review = new List<RestarauntReview>()
                            {
                            new RestarauntReview()
                            {
                                Rating = 10,
                                Body = "It's Okay"
                            }
                            }
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
