using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoGorillas2.Repository;
using MongoGorillas2.Types;

namespace MongoGorillas2.Web.Controllers
{
    public class ServiceController : Controller
    {
        [HttpGet]
        public JsonResult Gorillas()
        {
            IEnumerable<Gorilla> gorillas = GorillaRepository.ToList();

            return Json(gorillas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Spawn()
        {
            // Commented out for demo.
            // Gorilla gorilla = GorillaRepository.Spawn();
            Gorilla gorilla = new Gorilla() { Name = "Test", Age = 10, Gold = 100 };

            return Json(gorilla);
        }

        [HttpPost]
        public JsonResult Remove(Gorilla gorilla)
        {
            // Commented out for demo.
            // bool result = GorillaRepository.Remove(gorilla);
            bool result = true;

            return Json(result);
        }
    }
}