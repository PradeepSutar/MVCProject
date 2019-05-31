using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.Data;
using WebMatrix.WebData;
using MVCEmployee.Models;

namespace MVCEmployee.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            Session.Clear();
            Session.Abandon();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            TESTDataContext sa = new TESTDataContext();
            var user = (from v in sa.TBLEMPLOYEEs where v.USER_ID == model.UserName && v.PASSWORD == model.Password && v.ISACTIVE == 1 select v).SingleOrDefault();
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    Session["AD_ID"] = Convert.ToString(user.USER_ID);
                    Session["EMP_NAME"] = Convert.ToString(user.EMP_NAME);
                    return RedirectToAction("List", "Employee");
                }
                else
                {
                    //ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    TempData["Response_Message"] = "The user name or password provided is incorrect.";
                }
            }
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}