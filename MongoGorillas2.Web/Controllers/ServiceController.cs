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
            IEnumerable<Gorilla> Gorillas = GorillaRepository.ToList();

            return Json(Gorillas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Spawn()
        {
            // Commented out for demo.
            // Gorilla Gorilla = GorillaRepository.Spawn();
            Gorilla Gorilla = new Gorilla() { Name = "Test", Age = 10, Gold = 100 };

            return Json(Gorilla);
        }

        [HttpPost]
        public JsonResult Remove(Gorilla Gorilla)
        {
            // Commented out for demo.
            // bool result = GorillaRepository.Remove(Gorilla);
            bool result = true;

            return Json(result);
        }
    }
}