using System;
using FluentValidation;
using Ocean.Inside.Project.Models;

namespace Ocean.Inside.Project.Validators
{
    using System.Linq;

    public class TourValidator : AbstractValidator<TourViewModel>
    {
        public TourValidator()
        {
            this.RuleFor(model => model.Title).NotEmpty();
            this.RuleFor(model => model.Hotel).NotEmpty();
            this.RuleFor(model => model.Place).NotEmpty();
            this.RuleFor(model => model.Price).GreaterThan(0);
            //this.RuleFor(model => model.StartDate).NotEmpty();
            this.RuleFor(model => model.Duration).GreaterThan(0);
        }
    }
}