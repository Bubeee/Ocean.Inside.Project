using System.Collections.Generic;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ocean.Inside.DAL.OceanInsideDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Ocean.Inside.DAL.OceanInsideDbContext";
        }

        protected override void Seed(Ocean.Inside.DAL.OceanInsideDbContext context)
        {
            GetTours().ForEach(t => context.Tours.Add(t));

            context.Commit();
        }


        private List<Tour> GetTours()
        {
            return new List<Tour>
            {
                new Tour
                {
                    Title = "Турция",
                    DurationDays = 7,
                    DurationNights = 8,
                    Price = 258,
                    CurrencyCode = Currencies.USD,
                    ImageUrl = "/images/Home/Turkish_main.jpg",
                    Location = "Анталия, Сиде",
                    DepartFrom = "Киев",
                    StartDate = DateTime.Now.AddDays(15),
                    Hotel = "HANE SUN 5*",
                    Images = new List<Image>
                    {
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                    }
                },
                new Tour
                {
                    Title = "Египет",
                    DurationDays = 7,
                    DurationNights = 8,
                    Price = 220,
                    CurrencyCode = Currencies.USD,
                    ImageUrl = "/images/Home/box-offer-02-370x310.jpg",
                    Location = "Хургада",
                    DepartFrom = "Киев",
                    StartDate = DateTime.Now.AddDays(15),
                    Hotel = "HANE SUN 5*",
                    Images = new List<Image>
                    {
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                    }
                },
                new Tour
                {
                    Title = "Болгария",
                    DurationDays = 7,
                    DurationNights = 8,
                    Price = 280,
                    CurrencyCode = Currencies.EUR,
                    ImageUrl = "/images/Home/Turkish_main.jpg",
                    Location = "Солнечный берег",
                    DepartFrom = "Минск",
                    StartDate = DateTime.Now.AddDays(15),
                    Hotel = "HANE SUN 5*",
                    Images = new List<Image>
                    {
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new Image
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                    }
                },
                new Tour
                {
                    Title = "Египет",
                    DurationDays = 7,
                    DurationNights = 8,
                    Price = 220,
                    CurrencyCode = Currencies.USD,
                    ImageUrl = "/images/Home/box-offer-02-370x310.jpg",
                    Location = "Хургада",
                    DepartFrom = "Киев",
                    StartDate = DateTime.Now.AddDays(15),
                    Hotel = "HANE SUN 5*"
                },
                new Tour
                {
                    Title = "Болгария",
                    DurationDays = 7,
                    DurationNights = 8,
                    Price = 280,
                    CurrencyCode = Currencies.EUR,
                    ImageUrl = "/images/Home/Turkish_main.jpg",
                    Location = "Солнечный берег",
                    DepartFrom = "Минск",
                    StartDate = DateTime.Now.AddDays(15),
                    Hotel = "HANE SUN 5*"
                },
                new Tour
                {
                    Title = "Египет",
                    DurationDays = 7,
                    DurationNights = 8,
                    Price = 220,
                    CurrencyCode = Currencies.USD,
                    ImageUrl = "/images/Home/box-offer-02-370x310.jpg",
                    Location = "Хургада",
                    DepartFrom = "Киев",
                    StartDate = DateTime.Now.AddDays(15),
                    Hotel = "HANE SUN 5*"
                },
                new Tour
                {
                    Title = "Болгария",
                    DurationDays = 7,
                    DurationNights = 8,
                    Price = 280,
                    CurrencyCode = Currencies.EUR,
                    ImageUrl = "/images/Home/Turkish_main.jpg",
                    Location = "Солнечный берег",
                    DepartFrom = "Минск",
                    StartDate = DateTime.Now.AddDays(15),
                    Hotel = "HANE SUN 5*"
                },
            };
        }
    }
}
