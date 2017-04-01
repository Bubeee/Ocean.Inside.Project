using System;
using System.Collections.Generic;
using System.Data.Entity;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL
{
    public class OceanInsideSeedData : DropCreateDatabaseIfModelChanges<OceanDbContext>
    {
        protected override void Seed(OceanDbContext context)
        {
            GetTours().ForEach(t => context.Tours.Add(t));
            GetPrograms().ForEach(tp => context.TourPrograms.Add(tp));

            context.Commit();
        }

        private List<Tour> GetTours()
        {
            return new List<Tour>
            {
                new Tour
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14),
                    ShortDescription = "The best trip ever!",
                    Title = "Prague tour",
                    Price = (decimal) 139.99,
                    IsHot = true,
                    Rating = 10
                },
                new Tour
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14),
                    ShortDescription = "The best trip ever!",
                    Title = "Prague tour",
                    Price = (decimal) 139.99,
                    IsHot = true,
                    Rating = 10
                },
                new Tour
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14),
                    ShortDescription = "The best trip ever!",
                    Title = "Prague tour",
                    Price = (decimal) 139.99,
                    IsHot = true,
                    Rating = 10
                },
                new Tour
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14),
                    ShortDescription = "The best trip ever!",
                    Title = "Prague tour",
                    Price = (decimal) 139.99,
                    IsHot = true,
                    Rating = 10
                },
            };
        }

        private List<TourProgram> GetPrograms()
        {
            return new List<TourProgram>
            {
                new TourProgram
                {
                    Title = "Berlin, Warshaw, Krakov",
                    TourId =  2,
                    Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
                    EndingDay = 3,
                    StartingDay = 1
                },
                new TourProgram
                {
                    Title = "Berlin, Warshaw, Krakov",
                    TourId =  1,
                    Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
                    EndingDay = 3,
                    StartingDay = 1
                },
                new TourProgram
                {
                    Title = "Berlin, Warshaw, Krakov",
                    TourId =  4,
                    Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
                    EndingDay = 3,
                    StartingDay = 1
                },
                new TourProgram
                {
                    Title = "Berlin, Warshaw, Krakov",
                    TourId =  3,
                    Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
                    EndingDay = 3,
                    StartingDay = 1
                },
                new TourProgram
                {
                    Title = "Berlin, Warshaw, Krakov",
                    TourId =  2,
                    Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
                    EndingDay = 3,
                    StartingDay = 1
                },
                new TourProgram
                {
                    Title = "Berlin, Warshaw, Krakov",
                    TourId =  2,
                    Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
                    EndingDay = 3,
                    StartingDay = 1
                },
                new TourProgram
                {
                    Title = "Berlin, Warshaw, Krakov",
                    TourId =  1,
                    Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
                    EndingDay = 3,
                    StartingDay = 1
                },
                new TourProgram
                {
                    Title = "Berlin, Warshaw, Krakov",
                    TourId =  2,
                    Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
                    EndingDay = 3,
                    StartingDay = 1
                },
                new TourProgram
                {
                    Title = "Berlin, Warshaw, Krakov",
                    TourId =  1,
                    Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
                    EndingDay = 3,
                    StartingDay = 1
                },
                new TourProgram
                {
                    Title = "Berlin, Warshaw, Krakov",
                    TourId =  3,
                    Description = "Start your eastern Europe trip from Berlin - one of the most attractive European cities. Head out to Warsaw - the capital of Poland, where you’ll be able to take a guided tour through the city’s places of interests and museums.",
                    EndingDay = 3,
                    StartingDay = 1
                },
            };
        }
    }
}