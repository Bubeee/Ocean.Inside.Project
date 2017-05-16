using System;
using System.Collections.Generic;

namespace Ocean.Inside.Project.Models
{
    using Domain.Entities;
    using FluentValidation.Attributes;
    using Validators;

    [Validator(typeof(GroupTourValidator))]
    public class GroupTourViewModel : TourViewModel
    {
        public string Description { get; set; }

        public List<Waste> Wastes { get; set; }

        public List<TourStepViewModel> TourSteps { get; set; }
    }
}