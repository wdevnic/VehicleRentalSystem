using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.Controllers
{
    public class VehicleTypeController : Controller
    {
        [Route("VehicleTypes")]
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
                    return View();
                }
                else
                {
                    VehicleType vehicleType = db.VehicleTypes.Find(id);
                    return View(vehicleType);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(VehicleType newVehicleType)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // Update vehicle type
                if (db.VehicleTypes.Any(x => x.VehicleTypeId == newVehicleType.VehicleTypeId))
                {
                    VehicleType currentVehicleType = db.VehicleTypes.Find(newVehicleType.VehicleTypeId);
                    currentVehicleType.Name = newVehicleType.Name;
                    currentVehicleType.Rate = newVehicleType.Rate;

                    db.SaveChanges();

                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    // Add new vehicle type
                    db.VehicleTypes.Add(newVehicleType);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult GetData()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<VehicleType> vehicleTypes = db.VehicleTypes.ToList();
                return Json(new { data = vehicleTypes }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                VehicleType vehicleType = db.VehicleTypes.Find(id);
                db.VehicleTypes.Remove(vehicleType);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}