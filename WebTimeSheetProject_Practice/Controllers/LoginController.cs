﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtimesheet_Practice.models;
    
namespace WebTimeSheetProject_Practice.Controllers
{
    public class LoginController : Controller
    {
        //private Ilogin _ilogin;

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(LoginViewModel lm)
        {
            var username = lm.Username;
            var password = lm.Password;

            return View();
        }
    }
}