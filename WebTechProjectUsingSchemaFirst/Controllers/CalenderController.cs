using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTechProjectUsingSchemaFirst.Controllers
{
    public class CalenderController : Controller
    {
        // GET: Calender
        public ActionResult CalenderView()
        {
            if (Session["loggedInUser"] == null)
            {
                return RedirectToAction("LoginView", "Login");
            }else
            {
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult SetEventView(string day, string month, string year)
        {
            ViewBag.day = day;
            ViewBag.month = month;
            ViewBag.year = year;
            ViewBag.date =Convert.ToDateTime(day+"-"+month+"-"+year);
            
            
            return View( new appointment() { date=ViewBag.date });
        }
        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            appointment appointmentToUpdate = LoginController.context.appointments.SingleOrDefault(d => d.Id == id);
            return View("SetEventView",appointmentToUpdate);
        }

        [HttpPost]
        public ActionResult EditEvent(appointment appointment)
        {
            appointment appointmentTooupdate = LoginController.context.appointments.SingleOrDefault(d => d.Id == appointment.Id);

            appointmentTooupdate.date = appointment.date;
            appointmentTooupdate.eventName = appointment.eventName;
            appointmentTooupdate.at = appointment.at;
            appointmentTooupdate.location = appointment.location;
            appointmentTooupdate.with = appointment.with;
            appointmentTooupdate.shortNote = appointment.shortNote;
            appointmentTooupdate.comment = appointment.comment;

            LoginController.context.SaveChanges();
            return RedirectToAction("HomeView","Home");
        }
        [HttpPost]
        public ActionResult SetEventView(appointment appointment)
        {
            //ViewBag.day = day;
            //ViewBag.month = month;
            //ViewBag.year = year;
            //ViewBag.date = day + "-" + month + "-" + year;
            appointment.userId = Session["loggedInUser"].ToString();
            LoginController.context.appointments.Add(appointment);
            LoginController.context.SaveChanges();
            return View("calenderView");
        }

    }
}