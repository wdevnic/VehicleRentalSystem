using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleRentalSystem.DTOs;
using VehicleRentalSystem.Models;
using VehicleRentalSystem.ViewModels;

namespace VehicleRentalSystem.Controllers
{
    public class RentalsController : Controller
    {
        [Route("Rentals")]
        public ActionResult Manage()
        {
            return View();
        }

      
        public ActionResult AddRental()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                
                //Build get new view model data
                    var viewModel = new RentalViewModel
                    {
                        Customers = db.Customers.Include("Person").Include("Branch").OrderBy(b => b.Person.LastName).ToList(),
                        Vehicles = db.Vehicles.OrderBy(p => p.VehicleModel.Name).ToList(),
                        VehicleTypes = db.VehicleTypes.OrderBy(p => p.Name).ToList(),
                        VehicleModels = db.VehicleModels.OrderBy(p => p.Name).ToList(),
                        Branches = db.Branches.OrderBy(b => b.Name).ToList()
                    };
                    return View(viewModel);               
            }

        }
        public ActionResult AddReturn(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //Build view modal with exisiting cusotmer data
                RentalViewModel viewModel = new RentalViewModel
                {
                    Rental = db.Rentals.Include("Customer.Person").Include("Customer.Branch").Include("VehicleType").SingleOrDefault(c => c.RentalId == id),
                    Customers = db.Customers.OrderBy(b => b.Person.LastName).ToList(),
                    Vehicles = db.Vehicles.OrderBy(p => p.VehicleModel.Name).ToList(),
                    VehicleTypes = db.VehicleTypes.OrderBy(p => p.Name).ToList(),
                    VehicleModels = db.VehicleModels.OrderBy(p => p.Name).ToList(),
                    Branches = db.Branches.OrderBy(b => b.Name).ToList()
                };

                return View(viewModel);
            }
        }


        [HttpPost]
        public ActionResult AddRental(RentalViewModel newRental)
        {
           // Update new customer rental
            using (ApplicationDbContext db = new ApplicationDbContext())
            {                
                newRental.Rental.Customer = db.Customers.Find(newRental.Rental.Customer.CustomerId);
                newRental.Rental.DropOffLocation = db.Branches.Find(newRental.Rental.DropOffLocation.BusinessEntityId);
                newRental.Rental.PickUpLocation = db.Branches.Find(newRental.Rental.PickUpLocation.BusinessEntityId);

                newRental.Rental.Vehicle = db.Vehicles.Find(newRental.Rental.Vehicle.VehicleId);
                newRental.Rental.Vehicle.IsAvailable = false;
                newRental.Rental.VehicleType = db.VehicleTypes.Find(newRental.Rental.VehicleType.VehicleTypeId);
                newRental.Rental.VehicleModel = db.VehicleModels.Find(newRental.Rental.VehicleModel.VehicleModelId);

                db.Rentals.Add(newRental.Rental);

                db.SaveChanges();

                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult AddReturn(RentalViewModel newReturn)
        {
            // Add return date to rental
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                int rentalId = newReturn.Rental.RentalId;

                newReturn.Return.ReturnId = rentalId;

                Rental rental = db.Rentals.Find(rentalId);
                rental.Returned = true;

                db.Returns.Add(newReturn.Return);                   
                 db.SaveChanges();

                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

        // this filters are used when vehicle type and model are selected
        public ActionResult FilterByVehicleModelsByType(int vehicleTypeId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {             
                    List<VehicleModel> vehicleModels = db.VehicleModels.Where(p => p.VehicleTypeId == vehicleTypeId).OrderBy(p => p.Name).ToList();
                    return Json(vehicleModels, JsonRequestBehavior.AllowGet);  
            }
        }


        public ActionResult FilterByVehiclesByModel(int vehicleModelId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Vehicle> vehicles = db.Vehicles.Where(p => p.VehicleModelId == vehicleModelId && p.IsAvailable).OrderBy(p => p.LicensePlate).ToList();
                return Json(vehicles , JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult RentalCostPreview(int vehicleModelId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Vehicle> vehicles = db.Vehicles.Where(p => p.VehicleModelId == vehicleModelId && p.IsAvailable).OrderBy(p => p.LicensePlate).ToList();
                return Json(vehicles, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetData()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // create rental DTO for data table
                List<RentalDTO> rentalList = db.Rentals.Include("Customer.Person").Include("VehicleModel").Include("DropOffLocation").Include("PickUpLocation").ToList().Select(r => new RentalDTO
                {

                    Id = r.RentalId,
                    RentalDate = r.RentalDate.ToString(),
                    CustomerName = r.Customer.Person.FullName,
                    StartDate = r.StartDate.ToString(),
                    EndDate = r.EndDate.ToString(),
                    PickUpLocation = r.PickUpLocation.Name,
                    DropOffLocation = r.DropOffLocation.Name,
                    Returned = r.Returned
                }).ToList();
                return Json(new { data = rentalList }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(int id)
        {
            // Build model for DTO
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Rental rental = db.Rentals.Include("Customer.Person").Include("VehicleModel").Include("VehicleType").Include("Vehicle").Include("DropOffLocation").Include("PickUpLocation").SingleOrDefault(c => c.RentalId == id);
                Return returnRental = db.Returns.Find(id);

                // calculate overdue
                int overdueDays= 0 ;
                decimal overdueCost = 0;


                if (returnRental != null)
                {
                    if (((int)(returnRental.ReturnDate - rental.EndDate).TotalDays) > 0)
                    {
                        overdueDays = (int)(returnRental.ReturnDate - rental.EndDate).TotalDays;
                    }
                    
                    overdueCost = overdueDays * rental.VehicleType.Rate;
                }


                RentalViewModel viewModel = new RentalViewModel
                {
                    Rental = rental,
                    Return = returnRental,
                    DaysRented = rental.CalculateNumberDaysRented(),
                    RentalCost = rental.CalculateRentalCost(),
                    DaysOverdue = overdueDays,
                    OverdueCost = overdueCost
                };

                return View(viewModel);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Rental rental = db.Rentals.Find(id);
                Return returned = db.Returns.Find(id);
                db.Returns.Remove(returned);
                db.Rentals.Remove(rental);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}