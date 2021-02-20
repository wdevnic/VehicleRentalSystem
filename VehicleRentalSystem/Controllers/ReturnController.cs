using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleRentalSystem.Controllers
{
    public class ReturnController : Controller
    {
        //[Route("Returns")]
        public ActionResult Index()
        {
            return View();
        }
    }
}