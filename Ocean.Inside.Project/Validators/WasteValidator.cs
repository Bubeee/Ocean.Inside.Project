using System;

namespace Ocean.Inside.Project.Validators
{
    using FluentValidation;

    using Ocean.Inside.Project.Models;

    public class WasteValidator : AbstractValidator<WasteViewModel>
    {
        public WasteValidator()
        {

        }
    }
}