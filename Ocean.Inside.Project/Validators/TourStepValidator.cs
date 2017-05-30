namespace Ocean.Inside.Project.Validators
{
    using FluentValidation;

    using Ocean.Inside.Project.Models;
    public class TourStepValidator : AbstractValidator<TourStepViewModel>
    {
        public TourStepValidator()
        {
            RuleFor(model => model.Description).NotNull();
            RuleFor(model => model.TourId).NotNull();
            RuleFor(model => model.Title).NotNull();
            RuleFor(model => model.Day).NotNull();
            RuleFor(model => model.Duration).NotNull();
        }
    }
}