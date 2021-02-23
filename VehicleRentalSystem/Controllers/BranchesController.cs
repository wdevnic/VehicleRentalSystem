using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicleRentalSystem.DTOs;
using VehicleRentalSystem.Models;
using VehicleRentalSystem.ViewModels;

namespace VehicleRentalSystem.Controllers
{
    public class BranchesController : Controller
    {
        [Route("Branches")]
        public ActionResult Manage()
        {
            return View();
        }

       
        public ActionResult AddOrEdit(int id = 0)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                if (id == 0)
                {
                    return View();                  
                }
                else
                {
                    BranchViewModel viewModel = new BranchViewModel
                    {
                        Branch = db.Branches.Find(id),
                        Address = db.Addresses.Find(db.BusinessEntityAddresses.Where(b => b.BusinessEntityId == id && b.AddressTypeId == 2).Single().AddressId)
                    };

                    return View(viewModel);                   
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(BranchViewModel newBranch)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {              
                if (db.Branches.Any(x => x.BusinessEntityId == newBranch.Branch.BusinessEntityId))
                {
                    db.Branches.Attach(newBranch.Branch);
                    db.Entry(newBranch.Branch).State = EntityState.Modified;


                    db.Addresses.Attach(newBranch.Address);
                    db.Entry(newBranch.Address).State = EntityState.Modified;

                    db.SaveChanges();

                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    BusinessEntity be = new BusinessEntity();
                    db.BusinessEntities.Add(be);
                    newBranch.Branch.BusinessEntity = be;

                    db.Branches.Add(newBranch.Branch);
                    db.Addresses.Add(newBranch.Address);


                    BusinessEntityAddress bea = new BusinessEntityAddress {
                        BusinessEntity = be,
                        AddressType = db.AddressesTypes.Find(2),
                        Address = newBranch.Address
                    };

                    db.BusinessEntityAddresses.Add(bea);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpGet]
        public ActionResult GetData()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // create DTO with Branch and Branch Address data
                var data2 = db.Branches
                    .Join(
                        db.BusinessEntityAddresses,
                        branch => branch.BusinessEntityId,
                        bea => bea.BusinessEntityId,
                        (branch, bea) => new BranchDTO
                        {
                            Id = branch.BusinessEntityId,
                            Name = branch.Name,
                            AddressLine1 = bea.Address.AddressLine1,
                            AddressLine2 = bea.Address.AddressLine2,
                            City = bea.Address.City,
                            PostalCode = bea.Address.PostalCode
                        }

                    ).ToList();

                return Json(new { data = data2 }, JsonRequestBehavior.AllowGet); // sent json of rentals to page
            }
        }

        public ActionResult Details(int? id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                BranchViewModel viewModel = new BranchViewModel
                {
                    Branch = db.Branches.Find(id),
                    Address = db.Addresses.Find(db.BusinessEntityAddresses.Where(b => b.BusinessEntityId == id && b.AddressTypeId == 2).Single().AddressId)
                };

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                BusinessEntity be = db.BusinessEntities.Find(id);
                var addresses = db.BusinessEntityAddresses.Where(b => b.BusinessEntityId == id).Select(b => b.Address);

                db.BusinessEntities.Remove(be);                
                db.Addresses.RemoveRange(addresses);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}