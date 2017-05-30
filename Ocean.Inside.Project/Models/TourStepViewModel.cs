using FluentValidation.Attributes;
using Ocean.Inside.Project.Validators;

namespace Ocean.Inside.Project.Models
{
    [Validator(typeof(TourStepValidator))]
    public class TourStepViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Day { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public int TourId { get; set; }
    }
}