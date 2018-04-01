using System;

namespace Ocean.Inside.Project.Models
{
    using FluentValidation.Attributes;

    using Ocean.Inside.Project.Validators;

    [Validator(typeof(CheckInValidator))]
    public class CheckInViewModel : IComparable<CheckInViewModel>
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public DateTime Date { get; set; }

        public override bool Equals(object obj)
        {
            return (obj is CheckInViewModel && (this.Date == ((CheckInViewModel)obj).Date));
        }

        public int CompareTo(CheckInViewModel other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return this.Date.CompareTo(other.Date);
        }
    }
}