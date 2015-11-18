using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTaller.Models;

namespace MVCTaller.Controllers
{
    public class TiposController : Controller
    {
        private taller02Entities db = new taller02Entities();
        // GET: Tipos
        public ActionResult Index()
        {
            var data = db.Tipo;
            return View(data);
        }

        public ActionResult Detalle(string nombre)
        {
            var nom = nombre.Replace("_", " ");
            var data = db.Tipo.FirstOrDefault(o => o.nombre == nom);
            if (data == null)

                return RedirectToAction("Index");
            return View(data);
        }

        public ActionResult Alta()
        {
            return View(new Tipo());
        }

        [HttpPost]
        public ActionResult Alta(Tipo model)
        {
            if (ModelState.IsValid)
            {
                db.Tipo.Add(model);
                db.SaveChanges();
                return View(new Tipo());
            }
            return View(model);

        }
    }

}