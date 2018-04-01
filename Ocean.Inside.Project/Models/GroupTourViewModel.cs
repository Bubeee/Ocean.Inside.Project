using System.Collections.Generic;

namespace Ocean.Inside.Project.Models
{
    using System;

    using FluentValidation.Attributes;

    using JetBrains.Annotations;

    using Validators;

    [Validator(typeof(GroupTourValidator))]
    public class GroupTourViewModel : TourViewModel
    {
        public string Description { get; set; }

        public List<WasteViewModel> Wastes { get; set; }

        public List<TourStepViewModel> TourSteps { get; set; }
    }

    public class GroupTourClosestStartDateAscendingComparer : IComparer<DateTime>
    {
        public int Compare(DateTime x, DateTime y)
        {
            if (x > DateTime.Now && y < DateTime.Now)
            {
                return 1;
            }

            if (x < DateTime.Now && y > DateTime.Now)
            {
                return -1;
            }

            return DateTime.Compare(x, y);
        }
    }
}