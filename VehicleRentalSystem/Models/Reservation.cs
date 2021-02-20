using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    public class Reservation
    {
        [Display(Name = "Id")]
        public int ReservationId { get; set; }
        [Display(Name = "Reservation Date")]
        public DateTime ReservationDate { get; set; } = DateTime.Now;
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [ForeignKey("PickUpLocation")]
        public int PickUpLocationId { get; set; }
        [Display(Name = "Pick Up Location")]
        public Branch PickUpLocation { get; set; }
        [ForeignKey("DropOffLocation")]
        public int DropOffLocationId { get; set; }
        [Display(Name = "Drop Off Location")]
        public Branch DropOffLocation { get; set; }
        [Display(Name = "Days Reserved")]
        public int DaysReserved
        {
            get
            {
                if (((int)(EndDate - StartDate).TotalDays) == 0)
                {
                    return 1;
                }
                else
                {
                    return (int)(EndDate - StartDate).TotalDays;
                }
            }
        }

        public int CustomerId { get; set; }
        public  Customer Customer { get; set; }

        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}