using System;

namespace Ocean.Inside.Project.Models
{
    using FluentValidation.Attributes;

    using Ocean.Inside.Project.Validators;

    [Validator(typeof(CheckInValidator))]
    public class CheckInViewModel
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public DateTime Date { get; set; }
    }
}