using System;

namespace Ocean.Inside.Project.Validators
{
    using FluentValidation;

    using Ocean.Inside.Project.Models;

    public class GroupTourValidator : AbstractValidator<GroupTourViewModel>
    {
        public GroupTourValidator()
        {
            this.RuleFor(model => model.Description).NotNull();
            this.RuleFor(model => model.Title).NotNull();
            this.RuleFor(model => model.Duration).NotNull();
            this.RuleFor(model => model.Price).NotNull();
        }
    }
}