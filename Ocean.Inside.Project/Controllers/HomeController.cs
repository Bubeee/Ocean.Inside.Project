using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;

using Ocean.Inside.Domain.Entities;
using Ocean.Inside.Project.Models;

namespace Ocean.Inside.Project.Controllers
{
    using System;
    using System.Linq;
    using System.Net.Mime;
    using System.Text;

    using Ocean.Inside.BLL.Services.Interfaces;
    using Ocean.Inside.Project.Utils;

    using VkNet;
    using VkNet.Model.RequestParams;

    public class HomeController : Controller
    {
        private readonly ITourService tourService;
        private readonly ITestimonialService testimonialService;
        private readonly SiteMapBuilder siteMapBuilder;

        public HomeController(ITourService tourService, ITestimonialService testimonialService, SiteMapBuilder siteMapBuilder)
        {
            this.tourService = tourService;
            this.testimonialService = testimonialService;
            this.siteMapBuilder = siteMapBuilder;
        }

        [OutputCache(Duration = 36000, VaryByParam = "none")]
        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                TourViewModels = new List<TourViewModel>(),
            };

            var testimonials = this.testimonialService.GetTestimonials();
            var countedTestimonials = testimonials as Testimonial[] ?? testimonials.ToArray();
            model.Testimonials =
                Mapper.Map<IEnumerable<Testimonial>, IEnumerable<TestimonialViewModel>>(
                    countedTestimonials.Skip(DateTime.Now.Millisecond % countedTestimonials.Count())
                        .Take(7)).ToList();

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

            if (testimonials.Any())
            {
                this.testimonialService.DeleteAll();
            }

            foreach (var testimonial in testimonials)
            {
                this.testimonialService.AddTestimonial(Mapper.Map<TestimonialViewModel, Testimonial>(testimonial));
            }

            this.testimonialService.CommitChanges();
        }
        public ActionResult About()
        {
            this.ViewBag.Message = "О компании Океан внутри";

            return View();
        }

        [OutputCache(Duration = 86400)]
        public ContentResult Robots()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("user-agent: *");
            stringBuilder.AppendLine("disallow: /error/");
            stringBuilder.AppendLine("disallow: /account/");
            stringBuilder.Append("sitemap: ");
            var requestUrl = this.Request.Url;
            if (requestUrl != null)
            {
                var routeUrl = this.Url.RouteUrl("Sitemap", null, requestUrl.Scheme);
                if (routeUrl != null) stringBuilder.AppendLine(routeUrl.TrimEnd('/'));
            }

            return this.Content(stringBuilder.ToString(), "text/plain", Encoding.UTF8);
        }

        [OutputCache(Duration = 86400)]
        public ContentResult Sitemap()
        {
            var sitemapNodes = this.siteMapBuilder.GetSitemapNodes(this.Url);
            var xml = this.siteMapBuilder.GetSitemapDocument(sitemapNodes);
            return this.Content(xml, MediaTypeNames.Text.Xml, Encoding.UTF8);
        }
    }
}