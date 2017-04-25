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
            //GetPrograms().ForEach(tp => context.TourPrograms.Add(tp));

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
                    CurrencySymbol = Currencies.USD,
                    ImageUrl = "/images/Home/Turkish_main.jpg",
                    Location = "Анталия, Сиде",
                    DepartFrom = "Киев",
                    StartDate = DateTime.Now.AddDays(15),
                    Hotel = "HANE SUN 5*"
                },
                new Tour
                {
                    Title = "Египет",
                    DurationDays = 7,
                    DurationNights = 8,
                    Price = 220,
                    CurrencySymbol = Currencies.USD,
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
                    CurrencySymbol = Currencies.EUR,
                    ImageUrl = "/images/Home/Turkish_main.jpg",
                    Location = "Солнечный берег",
                    DepartFrom = "Минск",
                    StartDate = DateTime.Now.AddDays(15),
                    Hotel = "HANE SUN 5*"
                },
            };
        }

        //private List<TourProgram> GetPrograms()
        //{
        //    return new List<TourProgram>
        //    {
        //        new TourProgram
        //        {
        //            Title = "Berlin, Warshaw, Krakov",
        //            TourId =  2,
        //            Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
        //            EndingDay = 3,
        //            StartingDay = 1
        //        },
        //        new TourProgram
        //        {
        //            Title = "Berlin, Warshaw, Krakov",
        //            TourId =  1,
        //            Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
        //            EndingDay = 3,
        //            StartingDay = 1
        //        },
        //        new TourProgram
        //        {
        //            Title = "Berlin, Warshaw, Krakov",
        //            TourId =  4,
        //            Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
        //            EndingDay = 3,
        //            StartingDay = 1
        //        },
        //        new TourProgram
        //        {
        //            Title = "Berlin, Warshaw, Krakov",
        //            TourId =  3,
        //            Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
        //            EndingDay = 3,
        //            StartingDay = 1
        //        },
        //        new TourProgram
        //        {
        //            Title = "Berlin, Warshaw, Krakov",
        //            TourId =  2,
        //            Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
        //            EndingDay = 3,
        //            StartingDay = 1
        //        },
        //        new TourProgram
        //        {
        //            Title = "Berlin, Warshaw, Krakov",
        //            TourId =  2,
        //            Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
        //            EndingDay = 3,
        //            StartingDay = 1
        //        },
        //        new TourProgram
        //        {
        //            Title = "Berlin, Warshaw, Krakov",
        //            TourId =  1,
        //            Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
        //            EndingDay = 3,
        //            StartingDay = 1
        //        },
        //        new TourProgram
        //        {
        //            Title = "Berlin, Warshaw, Krakov",
        //            TourId =  2,
        //            Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
        //            EndingDay = 3,
        //            StartingDay = 1
        //        },
        //        new TourProgram
        //        {
        //            Title = "Berlin, Warshaw, Krakov",
        //            TourId =  1,
        //            Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
        //            EndingDay = 3,
        //            StartingDay = 1
        //        },
        //        new TourProgram
        //        {
        //            Title = "Berlin, Warshaw, Krakov",
        //            TourId =  3,
        //            Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
        //            EndingDay = 3,
        //            StartingDay = 1
        //        },
        //    };
        //}
    }
}