﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using FluentValidation.Attributes;
using Ocean.Inside.Domain.Entities;
using Ocean.Inside.Project.Validators;

namespace Ocean.Inside.Project.ViewModels
{
    [Validator(typeof(TourValidator))]
    public class TourViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Hotel { get; set; }
        public string Location { get; set; }
        public string DepartFrom { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public Currencies CurrencyCode { get; set; }
        public int DurationDays { get; set; }
        public int DurationNights { get; set; }

        public DateTime StartDate { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public IList<Image> Images { get; set; }
        public string Description { get; set; }

        public HttpPostedFileBase ImageRaw { get; set; }
    }
}