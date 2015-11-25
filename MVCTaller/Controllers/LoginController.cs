using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCTaller.Models;
using MVCTaller.Utilidades;

namespace MVCTaller.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario model)
        {
           
            if (Membership.ValidateUser(model.login, model.password))
            {
                //Con Session se almacenara todos los datos querramos guardar.
                Session["horaLogin"] = DateTime.Now;

                FormsAuthentication.RedirectFromLoginPage(model.login,false);
                return RedirectToAction("Index","Tipos");

            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            //borra todos los datos
            Session.Clear();

            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");

        }

    }
}