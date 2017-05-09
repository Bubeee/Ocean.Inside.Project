using System;
using System.Collections.Generic;
using System.Data.Entity;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL.DbConfiguration
{
    public class OceanInsideSeedData : DropCreateDatabaseIfModelChanges<OceanInsideDbContext>
    {
        protected override void Seed(OceanInsideDbContext context)
        {
            GetTours().ForEach(t => context.Tours.Add(t));
            GetGroupTours().ForEach(t => context.GroupTours.Add(t));

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

        private List<GroupTour> GetGroupTours()
        {
            return new List<GroupTour>
            {
                new GroupTour
                {
                    Title = "Лето в Испании",
                    DurationDays = 11,
                    Price = 400,
                    CurrencyCode = Currencies.EUR,
                    ImageUrl = "/images/Home/Turkish_main.jpg",
                    Location = "Испания",
                    DepartFrom = "Минск, Москва или Вильнюс",
                    Dates = new List<DateTime>
                    {
                        DateTime.Now.AddDays(15).AddDays(11),
                        DateTime.Now.AddDays(30).AddDays(11),
                        DateTime.Now.AddDays(45).AddDays(11),
                        DateTime.Now.AddDays(60).AddDays(11),
                    },
                    Images = new List<GroupTourImage>
                    {
                        new GroupTourImage
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new GroupTourImage
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        },
                        new GroupTourImage
                        {
                            Path = "/images/Home/Turkish_main.jpg",
                        }
                    },
                    GroupTourPrograms = new List<GroupTourProgram>
                    {
                        new GroupTourProgram
                        {
                            Title = "Барселона",
                            Description =
                                "Мы посетим Барселону, которая не оставит равнодушным никого: красивейшие парки и впечатляющая архитектура, пикник в порту на лужайке, квартал Гауди, шоу танцующих фонтанов.",
                            StartingDay = 2,
                            Duration = 1,
                        },
                        new GroupTourProgram
                        {
                            Title = "Port Aventura",
                            Description =
                                     "Мы прокатимся на самых высоких горках в Европе - Port Aventura - где выплеснем эмоции и получим море адреналина! ",
                            StartingDay = 3,
                            Duration = 1,
                        },
                        new GroupTourProgram
                        {
                            Title = "Испанские города",
                            Description =
                                "Мы пройдёмся по улочкам небольших Испанских городков, каждый из которых является настоящей историей!",
                            StartingDay = 5,
                            Duration = 1,
                        },
                        new GroupTourProgram
                        {
                            Title = "Частная винодельня",
                            Description =
                                "Мы посетим частную винодельню и виноградники, научимся различать самые известные сорта вин.",
                            StartingDay = 7,
                            Duration = 1,
                        }
                    }
                },
            };
        }
    }
}