using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTechProjectUsingSchemaFirst.Controllers
{
    public class LoginController : Controller
    {
        public static webTechprojectDBEntities context = new webTechprojectDBEntities();
        [HttpGet]
        public ActionResult LoginView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginView(user unknown)
        {

            /*
             * //adding data to session
                //assuming the method below will return list of Products

                var products=Db.GetProducts();

                //Store the products to a session

                Session["products"]=products;

                //To get what you have stored to a session

                var products=Session["products"] as List<Product>;

                //to clear the session value

                Session["products"]=null;
             */

            user known = context.users.SingleOrDefault(x => x.id == unknown.id && x.password==unknown.password);
            if (known != null)
            {
                Session["loggedInUser"] = unknown.id;
                return RedirectToAction("HomeView", "Home");

            }
            else
            {
                ModelState.AddModelError("LoginError", "username or password is incorrect");
                return View(unknown);
            }
        }
    }
}