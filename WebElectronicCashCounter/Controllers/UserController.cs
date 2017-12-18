using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebElectronicCashCounter.Models;

namespace WebElectronicCashCounter.Controllers
{
    public class UserController : Controller
    {
        Control_UserAccountModel dbl=new Control_UserAccountModel();
        private OurDbContext db = new OurDbContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserAccountModel account)
        {
            if (ModelState.IsValid)
            {
                //UserAccountModel account = new UserAccountModel();
                //account.FirstName = formCollection["FirstName"];
                //account.LastName = formCollection["LastName"];
                //account.email = formCollection["email"];
                //account.Password = formCollection["password"];

                Control_UserAccountModel control_UserAccountModel = new Control_UserAccountModel();
                control_UserAccountModel.AddUserAccount(account);

                return RedirectToAction("Login");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                //var model = (from m in db.UserAccountModel where m.email == login.email && m.Password == login.Password select m).Any();
                // if (model)
                // { var loginInfo = db.UserAccountModel.Where(x => x.FirstName == login.FirstName && x.LastName == login.LastName && x.email == login.email && x.Password == login.Password);

                //Session["email"] = loginInfo.email;

                //     return RedirectToAction("Index", "Home");}

                UserAccountModel account = new UserAccountModel();

                account.FirstName = formCollection["FirstName"];
                account.LastName = formCollection["LastName"];


                account.email = formCollection["email"];
                account.Password = formCollection["password"];

                Control_UserAccountModel control_UserAccountModel = new Control_UserAccountModel();
                //int x=control_UserAccountModel.ExecuteQuery(account);
                if (control_UserAccountModel.ExecuteQuery(account) == 1)
                {
                    Session["FirstName"] = account.FirstName;
                    Session["LastName"] = account.LastName;

                    //return RedirectToAction("Index", "Home");
                }
                Session["email"] = account.email;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Credentials");
            }


            return View();
        }



        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
            //Session.Clear();
            //return RedirectToAction("Login");
        }
    }
}