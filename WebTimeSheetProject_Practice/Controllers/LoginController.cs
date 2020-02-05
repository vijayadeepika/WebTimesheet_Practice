using CaptchaMvc.HtmlHelpers;
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
    public class LoginController : Controller
    {
        // GET: Login
        private ILogin _ILogin;
        //private IAssignRoles _IAssignRoles;
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            try
            {
                if (!this.IsCaptchaValid("Captcha is not valid"))
                {
                    ViewBag.errormessage = "Error: captcha entered is not valid.";

                    return View(loginViewModel);
                }

                if (!string.IsNullOrEmpty(loginViewModel.Username) && !string.IsNullOrEmpty(loginViewModel.Password))
                {
                    var Username = loginViewModel.Username;
                    var password = EncryptionLibrery.EncryptText(loginViewModel.Password);

                    var result = _ILogin.ValidateUser(Username, password);

                    if (result != null)
                    {
                        if (result.RegistrationID == 0 || result.RegistrationID < 0)
                        {
                            ViewBag.errormessage = "Entered Invalid Username and Password";
                        }
                        else
                        {
                            var RoleID = result.RoleID;
                            remove_Anonymous_Cookies(); //Remove Anonymous_Cookies

                            Session["RoleID"] = Convert.ToString(result.RoleID);
                            Session["Username"] = Convert.ToString(result.Username);
                            if (RoleID == 1)
                            {
                                Session["AdminUser"] = Convert.ToString(result.RegistrationID);

                                if (result.ForceChangePassword == 1)
                                {
                                    return RedirectToAction("ChangePassword", "UserProfile");
                                }

                                return RedirectToAction("Dashboard", "Admin");
                            }
                            else if (RoleID == 2)
                            {
                               // if (!_IAssignRoles.CheckIsUserAssignedRole(result.RegistrationID))
                                {
                                    ViewBag.errormessage = "Approval Pending";
                                    return View(loginViewModel);
                                }

                                Session["UserID"] = Convert.ToString(result.RegistrationID);

                                if (result.ForceChangePassword == 1)
                                {
                                    return RedirectToAction("ChangePassword", "UserProfile");
                                }

                                return RedirectToAction("Dashboard", "User");
                            }
                            else if (RoleID == 3)
                            {
                                Session["SuperAdmin"] = Convert.ToString(result.RegistrationID);
                                return RedirectToAction("Dashboard", "SuperAdmin");
                            }
                        }
                    }
                    else
                    {
                        ViewBag.errormessage = "Entered Invalid Username and Password";
                        return View(loginViewModel);
                    }
                }
                return View(loginViewModel);
            }
            catch (Exception)
            {
                throw;
            }
            // return View();
        }
        [NonAction]
        public void remove_Anonymous_Cookies()
        {
            try
            {

                if (Request.Cookies["WebTime"] != null)
                {
                    var option = new HttpCookie("WebTime");
                    option.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(option);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}