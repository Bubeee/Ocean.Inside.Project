namespace Ocean.Inside.Project.Models
{
    using FluentValidation.Attributes;

    using Ocean.Inside.Project.Validators;

    [Validator(typeof(WasteValidator))]
    public class WasteViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsIncluded { get; set; }

        public int TourId { get; set; }
    }
}