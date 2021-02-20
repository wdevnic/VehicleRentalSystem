using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VehicleRentalSystem.Models
{
    

    public class Rental
    {
        public Rental()
        {

        }

        [Display(Name = "Id")]
        public int RentalId { get; set; }
        [Display(Name = "Rental Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DefaultValue(typeof(DateTime), "")]
        public DateTime RentalDate { get; set; } 
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }



        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int VehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public int VehicleTypeId { get; set; }
        public bool  Returned { get; set; }
        public VehicleType VehicleType { get; set; }       
        [ForeignKey("PickUpLocation")]
        public int PickUpLocationId { get; set; }
        [Display(Name = "Pick Up Location")]
        public Branch PickUpLocation { get; set; }
        [ForeignKey("DropOffLocation")]
        public int DropOffLocationId { get; set; }
        [Display(Name = "Drop Off Location")]
        public Branch DropOffLocation { get; set; }

        public decimal CalculateNumberDaysRented()
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

        public decimal CalculateRentalCost()
        {
            return CalculateNumberDaysRented() * VehicleType.Rate;
        }

    }
}