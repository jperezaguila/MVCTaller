using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTaller.Models;

namespace MVCTaller.Controllers
{
    public class VehiculosController : Controller
    {
        taller02Entities db = new taller02Entities();
        
        // GET: Vehiculos
        public ActionResult Index()
        {
            return View(db.Vehiculos);

        }

        [HttpPost]
        public ActionResult Alta(Vehiculos model)
        {
            db.Vehiculos.Add(model);
            db.SaveChanges();
            return Json(model);
        }
        

    }
}