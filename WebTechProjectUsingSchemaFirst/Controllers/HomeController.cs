using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTechProjectUsingSchemaFirst.Controllers
{
    public class HomeController : Controller
    {
        static string loggedInUser;
        
        [HttpGet]
        public ActionResult HomeView()
        {
            if (Session["loggedInUser"] == null)
            {
                return RedirectToAction("LoginView", "Login");
            }else
            {
                loggedInUser = (Session["loggedInUser"]).ToString();
                //List <appointment> appointment  = LoginController.context.appointments.Include(x=>x.user).Where(x => x.userId == loggedInUser).ToList();
                List<appointment> appointment = LoginController.context.appointments.Where(x => x.userId == loggedInUser).ToList();
                user logged = LoginController.context.users.SingleOrDefault(x => x.id == loggedInUser);
                ViewBag.note = (logged.note).ToString();
                ViewBag.today = DateTime.Now.ToShortDateString();
                return View(appointment);
            }

            
        }
        
    }
}