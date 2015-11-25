using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTaller.Models;

namespace MVCTaller.Controllers
{
    [Authorize]
    public class VehiculosController : Controller
    {
        taller01Entities db = new taller01Entities();

        //Codigo Luis
        public ActionResult Index(int id)
        {
            //aqui almacenamos el id del tipo del vehiculo
            ViewBag.idTipo = id;

            var data = db.Vehiculos.Where(o => o.idtipo == id);
            return View(data);
         }
        //Cod. Buscar Luis
        public ActionResult Buscar(int idTipo, int campo, String contenido)
        {
            //Preparar una busqueda de vehiculos que pueda buscar por matricula o marca
            var data = db.Vehiculos.Where(o => o.idtipo == idTipo);
            //si la busqueda por matricula
            if (campo ==1)
            {
                data = data.Where(o => o.matricula.Contains(contenido));

            }
            else
            {
                data = data.Where(o => o.marca.Contains(contenido));
            }
            //Aqui devolvemos el Partial View
            return PartialView("_ListadoVehiculoLuis", data.ToList());
        }
         


        //public ActionResult Index()
        //{
        //    return View(db.Vehiculos);

        //}

        [HttpPost]
        public ActionResult Alta(Vehiculos model)
        {
            db.Vehiculos.Add(model);
            db.SaveChanges();
            //aqui tambien devolvemos a Json permite por Get( JsonRequestBehavior.AllowGet),
            //lo normal es que realice por POST
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        

    }
}