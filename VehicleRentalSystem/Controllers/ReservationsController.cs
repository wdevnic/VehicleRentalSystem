using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleRentalSystem.DTOs;
using VehicleRentalSystem.Models;
using VehicleRentalSystem.ViewModels;

namespace VehicleRentalSystem.Controllers
{
    public class ReservationsController : Controller
    {
        [Route("Reservations")]
        public ActionResult Manage()
        {
            return View();
        }


        public ActionResult AddOrEdit(int id = 0)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (id == 0)
                {
                    var viewModel = new ReservationViewModel
                    {
                        Customers = db.Customers.Include("Person").Include("Branch").OrderBy(b => b.Person.LastName).ToList(),
                        VehicleTypes = db.VehicleTypes.OrderBy(p => p.Name).ToList(),
                        Branches = db.Branches.OrderBy(b => b.Name).ToList()
                    };
                    return View(viewModel);

                }
                else
                {

                    ReservationViewModel viewModel = new ReservationViewModel
                    {
                        Reservation = db.Reservations.Include("Customer.Person").Include("Customer.Branch").SingleOrDefault(c => c.ReservationId == id),
                        Customers = db.Customers.OrderBy(b => b.Person.LastName).ToList(),
                        VehicleTypes = db.VehicleTypes.OrderBy(p => p.Name).ToList(),
                        Branches = db.Branches.OrderBy(b => b.Name).ToList()
                    };

                    return View(viewModel);
                }
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(ReservationViewModel newReservation)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (db.Reservations.Any(x => x.ReservationId == newReservation.Reservation.ReservationId))
                {
                    // Update existing Reservation
                    Reservation currentReservation = db.Reservations.Find(newReservation.Reservation.ReservationId);

                    currentReservation.Customer = db.Customers.Find(newReservation.Reservation.Customer.CustomerId);
                    currentReservation.StartDate = newReservation.Reservation.StartDate;
                    currentReservation.EndDate = newReservation.Reservation.EndDate;
                    currentReservation.PickUpLocation = db.Branches.Find(newReservation.Reservation.PickUpLocation.BusinessEntityId);
                    currentReservation.DropOffLocation = db.Branches.Find(newReservation.Reservation.DropOffLocation.BusinessEntityId);

                    db.SaveChanges();

                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    // Create new Reservation
                    Customer customer = db.Customers.Find(newReservation.Reservation.Customer.CustomerId);
                    Branch pickUpLocation = db.Branches.Find(newReservation.Reservation.PickUpLocation.BusinessEntityId);
                    Branch dropOffLocation = db.Branches.Find(newReservation.Reservation.DropOffLocation.BusinessEntityId);
                    VehicleType type = db.VehicleTypes.Find(newReservation.Reservation.VehicleType.VehicleTypeId);
                    Reservation reservation = new Reservation
                    {
                        Customer = customer,
                        StartDate = newReservation.Reservation.StartDate,
                        EndDate = newReservation.Reservation.EndDate,
                        PickUpLocation = pickUpLocation,
                        DropOffLocation = dropOffLocation,
                        VehicleType = type
                    };

                    
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult GetData()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // Create Reservations DTO's to display in Datatables
                List<ReservationDTO> reservationList = db.Reservations.Include("Customer.Person").Include("VehicleType").Include("DropOffLocation").Include("PickUpLocation").ToList().Select(r => new ReservationDTO {

                    Id = r.ReservationId,
                    ReservationDate = r.ReservationDate.ToString(), 
                    CustomerName = r.Customer.Person.FullName,
                    StartDate = r.StartDate.ToString(),
                    EndDate = r.EndDate.ToString(),
                    NumberOfDaysReserved = r.DaysReserved,
                    PickUpLocation = r.PickUpLocation.Name,
                    DropOffLocation = r.DropOffLocation.Name
                }).ToList();
                return Json(new { data = reservationList }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Reservation reservation = db.Reservations.Find(id);
                db.Reservations.Remove(reservation);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

       
    }
}