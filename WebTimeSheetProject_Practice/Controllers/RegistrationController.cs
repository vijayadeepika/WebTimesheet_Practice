using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtimesheet_Practice.models;
namespace WebTimeSheetProject_Practice.Controllers
{
    public class RegistrationController : Controller
    {
        
        // GET: Registration
        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult Registration(Registration rs)
        {
            return View();
          
        }
    }
}