using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTaller.Models;

namespace MVCTaller.Controllers
{
    [Authorize]
    public class TiposController : Controller
    {

       
        private taller01Entities db = new taller01Entities();
        // GET: Tipos
        public ActionResult Index()
        {
            

            // Codigo Luis: return View(db.Tipo.ToList());
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
        [ValidateAntiForgeryToken]
        public ActionResult Alta(Tipo model)
        {
            if (ModelState.IsValid)
            {
                db.Tipo.Add(model);
                db.SaveChanges();
                // codigo Luis: return RedirectToAction("Index");
                return View(new Tipo());
            }
            return View(model);

        }
    }

}