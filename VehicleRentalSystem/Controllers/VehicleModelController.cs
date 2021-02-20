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
    public class VehicleModelController : Controller
    {
        [Route("VehicleModels")]
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
                    VehicleModelViewModel viewModel = new VehicleModelViewModel
                    {
                        VehicleManufacturers = db.VehicleManufacturers.OrderBy(v => v.Name).ToList(),
                        VehicleTypes = db.VehicleTypes.OrderBy(v => v.Name).ToList()
                    };
                    
                    return View(viewModel);
                }
                else
                {
                    VehicleModelViewModel viewModel = new VehicleModelViewModel
                    {
                        VehicleModel = db.VehicleModels.Find(id),
                        VehicleManufacturers = db.VehicleManufacturers.OrderBy(v => v.Name).ToList(),
                        VehicleTypes = db.VehicleTypes.OrderBy(v => v.Name).ToList()
                    };

                    return View(viewModel);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(VehicleModelViewModel newVehicleModel)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // Update Vehicle Model
                if (db.VehicleModels.Any(x => x.VehicleModelId == newVehicleModel.VehicleModel.VehicleModelId))
                {
                    VehicleModel currentVehicleModel = db.VehicleModels.Include("VehicleType").Include("VehicleManufacturer").SingleOrDefault(c => c.VehicleModelId == newVehicleModel.VehicleModel.VehicleModelId);
                    currentVehicleModel.Name = newVehicleModel.VehicleModel.Name;
                    currentVehicleModel.BagCapacity = newVehicleModel.VehicleModel.BagCapacity;
                    currentVehicleModel.SeatingCapacity = newVehicleModel.VehicleModel.SeatingCapacity;
                    currentVehicleModel.VehicleManufacturer = db.VehicleManufacturers.Find(newVehicleModel.VehicleModel.VehicleManufacturer.VehicleManufacturerId);
                    currentVehicleModel.VehicleType = db.VehicleTypes.Find(newVehicleModel.VehicleModel.VehicleType.VehicleTypeId);
                    currentVehicleModel.Automatic = newVehicleModel.VehicleModel.Automatic;

                    db.SaveChanges();

                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);

                }

                else
                {
                    // Add Vehicle Model
                    VehicleType vehicleType = db.VehicleTypes.Find(newVehicleModel.VehicleModel.VehicleType.VehicleTypeId);
                    newVehicleModel.VehicleModel.VehicleType = vehicleType;

                    VehicleManufacturer vehicleManufacturer = db.VehicleManufacturers.Find(newVehicleModel.VehicleModel.VehicleManufacturer.VehicleManufacturerId);
                    newVehicleModel.VehicleModel.VehicleManufacturer = vehicleManufacturer;

                    db.VehicleModels.Add(newVehicleModel.VehicleModel);                    
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
    

        public ActionResult GetData()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // Create list of vehicle model DTO for display in data table
                List<VehicleModelDTO> vehicleModels = db.VehicleModels.Include("VehicleType").Include("VehicleManufacturer").Select(v => new VehicleModelDTO
                {
                    Id = v.VehicleModelId,
                    Name = v.Name,
                    SeatingCapacity = v.SeatingCapacity,
                    BaggageCapacity = v.BagCapacity,
                    VehicleManufacturer = v.VehicleManufacturer.Name,
                    VehicleType = v.VehicleType.Name,
                    Automatic = v.Automatic

                }).ToList();
                return Json(new { data = vehicleModels }, JsonRequestBehavior.AllowGet);
            }
        }




        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                VehicleModel model = db.VehicleModels.Find(id);
                db.VehicleModels.Remove(model);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}