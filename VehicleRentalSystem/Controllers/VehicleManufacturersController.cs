using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.Controllers
{
    public class VehicleManufacturersController : Controller
    {
        [Route("VehicleManufacturers")]
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
                    VehicleManufacturer maker = db.VehicleManufacturers.Find(id);
                    return View(maker);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(VehicleManufacturer maker)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // Update vehicle manufacturer
                if (db.VehicleManufacturers.Any(x => x.VehicleManufacturerId == maker.VehicleManufacturerId))
                {
                    VehicleManufacturer current = db.VehicleManufacturers.Find(maker.VehicleManufacturerId);
                    current.Name = maker.Name;
                
                    db.SaveChanges();

                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    // Add Manufacturer
                    db.VehicleManufacturers.Add(maker);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult GetData()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<VehicleManufacturer> makerList = db.VehicleManufacturers.ToList();
                return Json(new { data = makerList }, JsonRequestBehavior.AllowGet);
            }
        }

  
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                VehicleManufacturer maker = db.VehicleManufacturers.Find(id);
                db.VehicleManufacturers.Remove(maker);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}