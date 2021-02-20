using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleRentalSystem.Models;
using VehicleRentalSystem.ViewModels;

namespace VehicleRentalSystem.Controllers
{
    public class DashboardController : Controller
    {       
        public ActionResult Index()
        {
            return View();
        }


        // works out number of cars to be picked up today
        [ChildActionOnly]
        public ActionResult DailyPickUps()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var pickups = db.Rentals.Where(r => (DbFunctions.TruncateTime(r.StartDate) == DbFunctions.TruncateTime(DateTime.Now)) && !r.Returned).Count(); // count number of pickups today
                DashboardStatViewModel viewModel = new DashboardStatViewModel
                {
                    StatName = "Daily Pickups",
                    StatValue = pickups
                };
                return PartialView("_DashboardStat", viewModel);
            }
        }


        // works out number of cars to be returned today
        [ChildActionOnly]
        public ActionResult DailyReturns()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var returns = db.Rentals.Where(r => (DbFunctions.TruncateTime(r.EndDate) == DbFunctions.TruncateTime(DateTime.Now)) && !r.Returned).Count(); // count all rentals to be returned today
                DashboardStatViewModel viewModel = new DashboardStatViewModel // dashboard state viewmodel object to store required data
                {
                    StatName = "Daily Returns",
                    StatValue = returns
                };
                return PartialView("_DashboardStat", viewModel); // return partial view for dashboard item
            }
        }

        // works out number of cars that became over due today
        [ChildActionOnly]
        public ActionResult OverDueRentalsCount()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               // var overdue = db.Rentals.Where(r => r.Status == RentalStatus.Overdue).Count(); // count all overdue rentals
                var overdue = db.Rentals.Where(r => (DbFunctions.TruncateTime(r.EndDate) < DbFunctions.TruncateTime(DateTime.Now)) && !r.Returned).Count(); // count all rentals to be returned today
                DashboardStatViewModel viewModel = new DashboardStatViewModel
                {
                    StatName = "Overdue Rentals",
                    StatValue = overdue

                };
                return PartialView("_DashboardStat", viewModel);
            }
        }

        // GET Car Availability data by car class
        [HttpGet]
        public ActionResult CarClassAvailability()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // gets available cars
                var availableCars = db.Vehicles.Where(c => c.IsAvailable).Include("VehicleModel.VehicleType").ToList();

                //groups available cars by car class
                var carClassGroups = from vehicle in availableCars
                                        group vehicle by vehicle.VehicleModel.Name;



                List<string> category = new List<string>();
                List<int> count = new List<int>();

                // store car categories and amounts or cars per categories in lists
                foreach (var group in carClassGroups)
                {
                    category.Add(group.Key);
                    count.Add(group.Count());
                }


                return Json(new { data = new { category, count } }, JsonRequestBehavior.AllowGet);

            }
        }


        // get revenue data for last 7 days for line graph
        [HttpGet]
        public ActionResult LastSevenDaysRevenue()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // gets rentals for last 7 days and group by date
                var rentals = db.Rentals.Include(r => r.Customer).Include("VehicleType").ToList().Where(r => r.StartDate.Date > DateTime.Now.AddDays(-7).Date
                                                && (r.StartDate.Date <= DateTime.Now.Date)).OrderBy(r => r.StartDate).GroupBy(r => r.StartDate);

                decimal[] revenueValues = new decimal[7];
                string[] dates = new string[7];
                int i = 0;

           

                // calculate revenue for each day
                foreach (var group in rentals)
                {
                    dates[i] = group.Key.Date.ToString();
                    revenueValues[i] = group.Sum(r => r.CalculateRentalCost());
                    i++;
                }


                return Json(new { data = new { dates, revenueValues } }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}

