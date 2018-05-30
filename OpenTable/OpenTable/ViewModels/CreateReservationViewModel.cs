using OpenTable.Models;
using System;
using System.Collections.Generic;
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
        public string ReservingPersonEmail { get; set; }

        [Required]
        [Display(Name = "Reservation date")]
        public DateTime ReservationDate { get; set; }

        [Required]
        public int TableId { get; set; }

        public string Tables { get; set; }        
    }
}