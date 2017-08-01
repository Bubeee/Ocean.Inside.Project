using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Ocean.Inside.BLL;
using Ocean.Inside.Domain.Entities;
using Ocean.Inside.Project.Models;

namespace Ocean.Inside.Project.Controllers
{
    using System.Linq;

    using VkNet;
    using VkNet.Model.RequestParams;

    public class HomeController : Controller
    {
        private readonly ITourService tourService;
        
        public HomeController(ITourService tourService)
        {
            this.tourService = tourService;
        }

        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                TourViewModels = new List<TourViewModel>()
            };

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
                new BoardGetCommentsParams { GroupId = 56790707, TopicId = 29636087, Count = 50, StartCommentId = 100, Extended = true }, true);

            var items = comments.Items.Where(comment => comment.FromId > 0);
            var testimonials = (from item in items
                                  join user in comments.Profiles on item.FromId equals user.Id
                                  select
                                  new CommentViewModel
                                  {
                                      Id = item.Id,
                                      Text = item.Text,
                                      PhotoUrl = user.Photo50.AbsoluteUri
                                  }).ToList();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}