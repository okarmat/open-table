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
    public class CreateReservationViewModel
    {

        public int RestaurantId { get; set; }

        public string RestaurantName { get; set; }

        [Required]        
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Contact email")]
        public string ReservingPersonEmail { get; set; }

        [Required]
        [DateTimeNextSevenDaysRangeAttributeValidation]
        [DisplayName("Reservation date")]
        public DateTime ReservationDate { get; set; }

        [Required]
        public int TableId { get; set; }

        public string Tables { get; set; }        
    }
}