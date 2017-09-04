namespace Ocean.Inside.Project.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Xml.Linq;

    using Ocean.Inside.BLL.Services.Interfaces;
    using Ocean.Inside.Project.Models;

    public class SiteMapBuilder
    {
        private readonly ITourService tourService;
        private readonly IGalleryService galleryService;
        private readonly IImageService imageService;

        public SiteMapBuilder(ITourService tourService, IImageService imageService, IGalleryService galleryService)
        {
            this.tourService = tourService;
            this.imageService = imageService;
            this.galleryService = galleryService;
        }

        public IReadOnlyCollection<SitemapNode> GetSitemapNodes(UrlHelper urlHelper)
        {
            List<SitemapNode> nodes = new List<SitemapNode>
                                          {
                                              new SitemapNode {
                                                      Url =
                                                          urlHelper.AbsoluteRouteUrl(
                                                              "Default"),
                                                      Priority = 1
                                                  }
                                          };

            foreach (var tour in this.tourService.GetManyTours(tour => !string.IsNullOrEmpty(tour.Hotel)))
            {
                nodes.Add(
                   new SitemapNode
                   {
                       Url = urlHelper.AbsoluteRouteUrl("Tour", new { id = tour.Id }),
                       Frequency = SitemapFrequency.Weekly,
                       Priority = 1
                   });
            }

            foreach (var tour in this.tourService.GetManyTours(tour => string.IsNullOrEmpty(tour.Hotel)))
            {
                nodes.Add(
                   new SitemapNode
                   {
                       Url = urlHelper.AbsoluteRouteUrl("GroupTour", new { id = tour.Id }),
                       Frequency = SitemapFrequency.Weekly,
                       Priority = 1
                   });
            }

            nodes.Add(new SitemapNode
            {
                Url = urlHelper.AbsoluteRouteUrl("Default", new { action = "About" }),
                Frequency = SitemapFrequency.Monthly,
                Priority = 1
            });

            return nodes;
        }

        public string GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            var root = new XElement(xmlns + "urlset");
            foreach (var sitemapNode in sitemapNodes)
            {
                var urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            var document = new XDocument(root);
            return document.ToString();
        }
    }
}