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
    public class VehicleController : Controller
    {
        [Route("Vehicles")]
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
                    VehicleViewModel viewModel = new VehicleViewModel
                    {
                        VehicleModels = db.VehicleModels.ToList(),
                        Branches = db.Branches.ToList()
                    };
                    return View(viewModel);
                }
                else
                {
                    // Populate view model with current vehicle data
                     VehicleViewModel viewModel = new VehicleViewModel
                    {
                        Vehicle = db.Vehicles.Include("Branch").Include("VehicleModel").SingleOrDefault(v => v.VehicleId == id),
                        VehicleModels = db.VehicleModels.ToList(),
                        Branches = db.Branches.ToList()
                    };

                    return View(viewModel);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(VehicleViewModel newVehicle)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               
                // Update Vehicle data
                if (db.Vehicles.Any(x => x.VehicleId == newVehicle.Vehicle.VehicleId))
                {
                    Vehicle currentVehicle = db.Vehicles.Find(newVehicle.Vehicle.VehicleId);

                    currentVehicle.LicensePlate = newVehicle.Vehicle.LicensePlate;
                    currentVehicle.IsAvailable = newVehicle.Vehicle.IsAvailable;
                    currentVehicle.Branch = db.Branches.Find(newVehicle.Vehicle.Branch.BusinessEntityId);
                    currentVehicle.VehicleModel = db.VehicleModels.Find(newVehicle.Vehicle.VehicleModel.VehicleModelId);

                    db.SaveChanges();

                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                   //Add new vehicle
                    Vehicle vehicle = new Vehicle
                    {
                        LicensePlate = newVehicle.Vehicle.LicensePlate,
                        IsAvailable = newVehicle.Vehicle.IsAvailable,
                        Branch = db.Branches.Find(newVehicle.Vehicle.Branch.BusinessEntityId),
                        VehicleModel = db.VehicleModels.Find(newVehicle.Vehicle.VehicleModel.VehicleModelId)
                    };

                    db.Vehicles.Add(vehicle);

                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult GetData()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //Build vehicle DTO
                List<VehicleDTO> vehicles = db.Vehicles.Select(v => new VehicleDTO { 
                    Id = v.VehicleId,
                    LicensePlate = v.LicensePlate,
                    IsAvailable = v.IsAvailable,
                    Branch = v.Branch.Name,
                    VehicleModel = v.VehicleModel.Name
                               
                }).ToList();
                return Json(new { data = vehicles }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Vehicle vehicle = db.Vehicles.Find(id);
                db.Vehicles.Remove(vehicle);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}