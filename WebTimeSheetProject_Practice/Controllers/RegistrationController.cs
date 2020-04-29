using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtimesheet_Practice.models;
using webTimeSheetProject_Practice.Interface;
using WebTimeSheetProject_Practice.Librery;

namespace WebTimeSheetProject_Practice.Controllers
{
    public class RegistrationController : Controller
    {
        private IRegistration _iregistration;
        private IRole _irole;
        // GET: Registration
        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult Registration(Registration rs)
        {
         try
            {
                var isuserexisting = _iregistration.CheckUserNameExist(rs.Username);
                if(isuserexisting)
                {
                    ModelState.AddModelError("", errorMessage: "user name alredy used try unique one!");
                }
                else
                {
                    rs.CreatedOn = DateTime.Now;
                    rs.RoleID = _irole.rolesofuserbyusername("users");
                    rs.Password = EncryptionLibrery.EncryptText(rs.Password);
                    rs.ConfirmPassword = EncryptionLibrery.EncryptText(rs.ConfirmPassword);
                    if(_iregistration.addUser(rs)>0)
                    {
                        TempData["messageregistration"] = "Registred Successfully!!";
                        return RedirectToAction("Registration");
                    }
                    else
                    {
                        return View();
                    }
                   
                }
                return RedirectToAction("Registration");
            }
            catch
            {
                return View();
            }
          
        }
        public JsonResult checkusernameexist(string username)
        {
            try
            {
                var usernameexist = false;
                if(username !=null)
                {
                    usernameexist = _iregistration.CheckUserNameExist(username);
                }
                if(usernameexist)
                {
                    return Json(data: true);
                }
                else
                {
                    return Json(data:false);
                }
                
            }
            catch
            {
                throw;
            }
        }
    }
}