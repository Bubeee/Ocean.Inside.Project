namespace Ocean.Inside.DAL.DataGeneration
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Domain.Entities;

    public class OceanInsideSeedData : DropCreateDatabaseIfModelChanges<OceanInsideDbContext>
    {
        protected override void Seed(OceanInsideDbContext context)
        {
            this.GetTours().ForEach(t => context.Tours.Add(t));
            this.GetGroupTours().ForEach(t => context.Tours.Add(t));

            context.Commit();
        }

        private List<Tour> GetTours()
        {
            return new List<Tour>
            {
                new Tour
                {
                    Title = "Турция",
                    Duration = 7,
                    DurationNights = 8,
                    Price = 258,
                    CurrencyCode = CurrencyCode.USD,
                    Place = "Анталия, Сиде",
                    FlyFrom = "Киев",
                    CheckIns = new List<CheckIn>
                                   {
                                       new CheckIn
                                           {
                                               Date = DateTime.Now.AddDays(15),
                                           }
                                   },
                    Hotel = "HANE SUN 5*",
                    GalleryImages = new List<Image>
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
                    Duration = 7,
                    DurationNights = 8,
                    Price = 220,
                    CurrencyCode = CurrencyCode.USD,
                    Place = "Хургада",
                    FlyFrom = "Киев",
                    CheckIns = new List<CheckIn>
                                   {
                                       new CheckIn
                                           {
                                               Date = DateTime.Now.AddDays(15),
                                           }
                                   },
                    Hotel = "HANE SUN 5*",
                    GalleryImages = new List<Image>
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
                    Duration = 7,
                    DurationNights = 8,
                    Price = 280,
                    CurrencyCode = CurrencyCode.EUR,
                    Place = "Солнечный берег",
                    FlyFrom = "Минск",
                    CheckIns = new List<CheckIn>
                                   {
                                       new CheckIn
                                           {
                                               Date = DateTime.Now.AddDays(15),
                                           }
                                   },
                    Hotel = "HANE SUN 5*",
                    GalleryImages = new List<Image>
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
                    Duration = 7,
                    DurationNights = 8,
                    Price = 220,
                    CurrencyCode = CurrencyCode.USD,
                    Place = "Хургада",
                    FlyFrom = "Киев",
                    CheckIns = new List<CheckIn>
                                   {
                                       new CheckIn
                                           {
                                               Date = DateTime.Now.AddDays(15),
                                           }
                                   },
                    Hotel = "HANE SUN 5*"
                },
                new Tour
                {
                    Title = "Болгария",
                    Duration = 7,
                    DurationNights = 8,
                    Price = 280,
                    CurrencyCode = CurrencyCode.EUR,
                    Place = "Солнечный берег",
                    FlyFrom = "Минск",
                    CheckIns = new List<CheckIn>
                                   {
                                       new CheckIn
                                           {
                                               Date = DateTime.Now.AddDays(15),
                                           }
                                   },
                    Hotel = "HANE SUN 5*"
                },
                new Tour
                {
                    Title = "Египет",
                    Duration = 7,
                    DurationNights = 8,
                    Price = 220,
                    CurrencyCode = CurrencyCode.USD,
                    Place = "Хургада",
                    FlyFrom = "Киев",
                    CheckIns = new List<CheckIn>
                                   {
                                       new CheckIn
                                           {
                                               Date = DateTime.Now.AddDays(15),
                                           }
                                   },
                    Hotel = "HANE SUN 5*"
                },
                new Tour
                {
                    Title = "Болгария",
                    Duration = 7,
                    DurationNights = 8,
                    Price = 280,
                    CurrencyCode = CurrencyCode.EUR,
                    Place = "Солнечный берег",
                    FlyFrom = "Минск",
                    CheckIns = new List<CheckIn>
                                   {
                                       new CheckIn
                                           {
                                               Date = DateTime.Now.AddDays(15),
                                           }
                                   },
                    Hotel = "HANE SUN 5*"
                },
            };
        }

        private List<Tour> GetGroupTours()
        {
            return new List<Tour>
                       {
                           new Tour
                               {
                                   Title = "Лето в Испании",
                                   Duration = 11,
                                   Price = 400,
                                   CurrencyCode = CurrencyCode.EUR,
                                   Place = "Испания",
                                   FlyFrom = "Минск, Москва или Вильнюс",
                                   Description = "27 мая стартует первый заезд в солнечную Испанию! Вас ждет комфортная "
                                                 + "вилла и отличная компания! Обещаем, ни дня без впечатлений! И конечно же, "
                                                 + "только приятных и позитивных! :) Красивейшая и разнообразная природа "
                                                 + "Испании не оставит вас равнодушными и вы надолго влюбитесь в этот "
                                                 + "прекрасный уголок нашей планеты.",
                                   Wastes = new List<Waste>
                                                {
                                                    new Waste
                                                        {
                                                            IsIncluded = true,
                                                            Description = "Встреча и трансфер: аэропорт-вилла-аэропорт"
                                                        },
                                                    new Waste
                                                        {
                                                            IsIncluded = true,
                                                            Description = "Проживание в вилле, расселение два человека в комнате"
                                                        },
                                                    new Waste
                                                        {
                                                            IsIncluded = true,
                                                            Description = "Ваш личный гид, на протяжении всего вашего отдыха"
                                                        },
                                                    new Waste
                                                        {
                                                            IsIncluded = true,
                                                            Description = "Море фотографий и внимания :)"
                                                        },
                                                    new Waste
                                                        {
                                                            IsIncluded = false,
                                                            Description = "Авиа перелет (вылеты могут быть из Москвы, Минска и Вильнюса) – 250-350 евро "
                                                        },
                                                    new Waste
                                                        {
                                                            IsIncluded = false,
                                                            Description = "Шенген виза + страховка (если нет в наличии) – 80 евро виза + 6 евро страховка"
                                                        },
                                                    new Waste
                                                        {
                                                            IsIncluded = false,
                                                            Description = "Аренда велосипеда, мотобайка, авто (по желанию) – от 10 евро в день "
                                                        },
                                                    new Waste
                                                        {
                                                            IsIncluded = false,
                                                            Description = "Питание на курорте (мы покажем вам самые вкусные и недорогие места) "
                                                        },
                                                    new Waste
                                                        {
                                                            IsIncluded = false,
                                                            Description = "Экскурсии на курорте (будут платные и бесплатные) "
                                                        },
                                                    new Waste
                                                        {
                                                            IsIncluded = false,
                                                            Description = "Тренировки у моря и во дворике нашей виллы с фитнес-тренером Яной Котовой – 50 евро."
                                                        },
                                                },
                                   CheckIns =
                                       new List<CheckIn>
                                           {
                                               new CheckIn
                                                   {
                                                       Date =
                                                           DateTime.Now.AddDays(
                                                               15).AddDays(11)
                                                   },
                                               new CheckIn
                                                   {
                                                       Date =
                                                           DateTime.Now.AddDays(
                                                               30).AddDays(11)
                                                   },
                                               new CheckIn
                                                   {
                                                       Date =
                                                           DateTime.Now.AddDays(
                                                               45).AddDays(11)
                                                   },
                                               new CheckIn
                                                   {
                                                       Date =
                                                           DateTime.Now.AddDays(
                                                               60).AddDays(11)
                                                   },
                                           },
                                   GalleryImages =
                                       new List<Image>
                                           {
                                               new Image
                                                   {
                                                       Path =
                                                           "/images/Tours/Испания/2.jpg",
                                                   },
                                               new Image
                                                   {
                                                       Path =
                                                           "/images/Tours/Испания/3.jpg",
                                                   },
                                               new Image
                                                   {
                                                       Path =
                                                           "/images/Tours/Испания/4.jpg",
                                                   },
                                               new Image
                                                   {
                                                       Path =
                                                           "/images/Tours/Испания/5.jpg",
                                                   },
                                               new Image
                                                   {
                                                       Path =
                                                           "/images/Tours/Испания/6.jpg",
                                                   },
                                               new Image
                                                   {
                                                       Path =
                                                           "/images/Tours/Испания/7.jpg",
                                                   }
                                           },
                                   TourSteps =
                                       new List<TourStep>
                                           {
                                               new TourStep
                                                   {
                                                       Title = "Барселона",
                                                       Description =
                                                           "Мы посетим Барселону, которая не оставит равнодушным никого: красивейшие парки и впечатляющая архитектура, пикник в порту на лужайке, квартал Гауди, шоу танцующих фонтанов.",
                                                       Day = 2,
                                                       Duration = 1,
                                                   },
                                               new TourStep
                                                   {
                                                       Title = "Port Aventura",
                                                       Description =
                                                           "Мы прокатимся на самых высоких горках в Европе - Port Aventura - где выплеснем эмоции и получим море адреналина! ",
                                                       Day = 3,
                                                       Duration = 1,
                                                   },
                                               new TourStep
                                                   {
                                                       Title = "Испанские города",
                                                       Description =
                                                           "Мы пройдёмся по улочкам небольших Испанских городков, каждый из которых является настоящей историей!",
                                                       Day = 5,
                                                       Duration = 1,
                                                   },
                                               new TourStep
                                                   {
                                                       Title =
                                                           "Частная винодельня",
                                                       Description =
                                                           "Мы посетим частную винодельню и виноградники, научимся различать самые известные сорта вин.",
                                                       Day = 7,
                                                       Duration = 1,
                                                   }
                                           }
                               },
                       };
        }
    }
}