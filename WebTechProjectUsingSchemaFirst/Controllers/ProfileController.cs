using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTechProjectUsingSchemaFirst.Controllers
{
    public class ProfileController : Controller
    {
        static string loggedInUser;
        // GET: Profile
        [HttpGet]
        public ActionResult ProfileView()
        {
            if (Session["loggedInUser"] == null)
            {
                return RedirectToAction("LoginView", "Login");
            }else
            {
                loggedInUser = Session["loggedInUser"].ToString();
                //user logged = LoginController.context.users.SingleOrDefault(x => x.id == Session["loggedInUser"].ToString());
                user logged = LoginController.context.users.SingleOrDefault(x => x.id == loggedInUser);
                return View(logged);
            }
            
        }

        public ActionResult ContactView()
        {

            return View();
        }


    }
}