using OpenTable.Models;
using OpenTable.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenTable.ViewModels
{
    public class CreateReservationViewModel : IValidatableObject
    {

        public int RestaurantId { get; set; }

        public string RestaurantName { get; set; }

        [Required(ErrorMessage = "Please enter contact email")]        
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Contact email")]
        public string ReservingPersonEmail { get; set; }

        [Required(ErrorMessage = "Please enter reservation start date")]
        [DateTimeNextSevenDaysRangeAttributeValidation]
        [DisplayName("Reservation start")]
        public DateTime ReservationStart { get; set; }

        [Required(ErrorMessage = "Please enter reservation end date")]
        [DateTimeNextSevenDaysRangeAttributeValidation]
        [DisplayName("Reservation end")]
        public DateTime ReservationEnd { get; set; }

        [Required]
        public int TableId { get; set; }

        public string Tables { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ReservationEnd <= ReservationStart)
                yield return new ValidationResult("Reservation end date have to be greater then reservation start");
        }
    }
}