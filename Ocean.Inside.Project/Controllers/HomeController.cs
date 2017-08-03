using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Ocean.Inside.BLL;
using Ocean.Inside.Domain.Entities;
using Ocean.Inside.Project.Models;

namespace Ocean.Inside.Project.Controllers
{
    using System.Linq;

    using Ocean.Inside.BLL.Services.Interfaces;

    using VkNet;
    using VkNet.Model.RequestParams;

    public class HomeController : Controller
    {
        private readonly ITourService tourService;
        private readonly ITestimonialService testimonialService;

        public HomeController(ITourService tourService, ITestimonialService testimonialService)
        {
            this.tourService = tourService;
            this.testimonialService = testimonialService;
        }

        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                TourViewModels = new List<TourViewModel>(),
            };

            var testimonials = this.testimonialService.GetTestimonials();
            model.Testimonials =
                Mapper.Map<IEnumerable<Testimonial>, IEnumerable<TestimonialViewModel>>(
                    testimonials.OrderByDescending(testimonial => testimonial.Text.Length)).ToList();

            foreach (var tour in this.tourService.GetManyTours(tour => tour.Wastes.Any() == false))
            {
                model.TourViewModels.Add(Mapper.Map<Tour, TourViewModel>(tour));
            }

            return View(model);
        }

        [Authorize]
        public void GetTestimonials()
        {
            var api = new VkApi();
            var comments = api.Board.GetComments(
                new BoardGetCommentsParams { GroupId = 56790707, TopicId = 29636087, Count = 100, StartCommentId = 1, Extended = true }, true);

            var items = comments.Items.Where(comment => comment.FromId > 0);
            var testimonials = (from item in items
                                join user in comments.Profiles on item.FromId equals user.Id
                                where item.FromId > 0
                                select
                                new TestimonialViewModel
                                {
                                    Id = item.Id,
                                    Text = item.Text,
                                    PhotoUrl = user.Photo50.AbsoluteUri,
                                    Name = user.FirstName
                                }).ToList();

            foreach (var testimonial in testimonials)
            {
                this.testimonialService.AddTestimonial(Mapper.Map<TestimonialViewModel, Testimonial>(testimonial));
            }

            this.testimonialService.Save();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}