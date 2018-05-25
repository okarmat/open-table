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
        public string RestaurantName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string ReservingPersonEmail { get; set; }

        [Required]
        [Display(Name = "Reservation date")]
        public string ReservationDate { get; set; }

        public string Tables { get; set; }                
    }
}