using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class Return
    {
        public int ReturnId { get; set; }
        [Display(Name = "Return Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReturnDate { get; set; }
        public Rental Rental { get; set; }
    }
}