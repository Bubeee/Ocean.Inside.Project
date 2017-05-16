using System;

namespace Ocean.Inside.Project.Validators
{
    using FluentValidation;

    using Ocean.Inside.Project.Models;

    public class CheckInValidator : AbstractValidator<CheckInViewModel>
    {
        public CheckInValidator()
        {
            RuleFor(model => model.Date).NotNull().GreaterThan(DateTime.Now);
            RuleFor(model => model.TourId).NotNull();
        }
    }
}