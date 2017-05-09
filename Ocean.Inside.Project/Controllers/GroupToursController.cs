using System.Web.Mvc;

namespace Ocean.Inside.Project.Controllers
{
    using System.Collections.Generic;

    using AutoMapper;

    using Ocean.Inside.BLL;
    using Ocean.Inside.Domain.Entities;
    using Ocean.Inside.Project.ViewModels;

    public class GroupToursController : Controller
    {
        private readonly IGroupTourService groupTourService;

        public GroupToursController(IGroupTourService groupTourService)
        {
            this.groupTourService = groupTourService;
        }

        public ActionResult AllTours()
        {
            var model =
                Mapper.Map<IEnumerable<GroupTour>, IEnumerable<GroupTourViewModel>>(
                    this.groupTourService.GetGroupTours());

            return this.View(model);
        }
    }
}