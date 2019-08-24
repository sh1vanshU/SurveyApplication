using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyApplication.Models;
using System.Web.Security;
namespace SurveyApplication.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginView)
        {
            using (var context=new surveyEntities())
            {
                bool isValid = context.Registrations.Any(x => x.Name == loginView.Name && x.Email == loginView.Email && x.Password == loginView.Password);
                if(isValid)
                {
                    FormsAuthentication.SetAuthCookie(loginView.Name,false);
                    FormsAuthentication.SetAuthCookie(loginView.Email, false);
                    FormsAuthentication.SetAuthCookie(loginView.Password, false);
                    return RedirectToAction("SurveyQuestion", "Home");
                }
                ModelState.AddModelError("", "Invalid Name, Email and Contact -- Please Enter Again");
                return View();
            }
            
        }
        public ActionResult Signup()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Signup(Registration registrationModel)
        {
            using (var context = new surveyEntities())
            {
                context.Registrations.Add(registrationModel);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}