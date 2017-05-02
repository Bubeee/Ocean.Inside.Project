using System;
using FluentValidation;
using Ocean.Inside.Project.ViewModels;

namespace Ocean.Inside.Project.Validators
{
    public class TourValidator : AbstractValidator<TourViewModel>
    {
        public TourValidator()
        {
            RuleFor(model => model.Title).NotEmpty();
            RuleFor(model => model.Hotel).NotEmpty();
            RuleFor(model => model.Location).NotEmpty();
            RuleFor(model => model.ImageRaw).NotNull();
            RuleFor(model => model.Price).GreaterThan(0);
            RuleFor(model => model.StartDate).NotEmpty().GreaterThan(DateTime.Now);
            RuleFor(model => model.DurationDays).GreaterThan(0);
        }
    }
}