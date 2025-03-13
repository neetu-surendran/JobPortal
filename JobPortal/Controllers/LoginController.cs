using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class LoginController : Controller
    {
        JobPortalDBEntities dbobj = new JobPortalDBEntities();
        // GET: Login
        public ActionResult Login_PageLoad()
        {
            return View();
        }
        public ActionResult Login_Click(LoginClass clsobj)
        {
            if (ModelState.IsValid)
            {
                var count = dbobj.sp_CountLogId(clsobj.username, clsobj.password).Single();
                if (count == 1)
                {
                    var id = dbobj.sp_GetRegId(clsobj.username, clsobj.password).FirstOrDefault();
                    Session["uid"] = id;

                    var type = dbobj.sp_GetType(clsobj.username, clsobj.password).FirstOrDefault();
                    if (type == "user")
                    {
                        return RedirectToAction("User_PageLoad", "UserDash");
                    }
                    else if (type == "admin")
                    {
                        return RedirectToAction("Admin_PageLoad", "AdminDash");
                    }
                }               
            }
            else
            {
                ModelState.Clear();
                clsobj.msg = "Invalid login credentials";
                return View("Login_PageLoad", clsobj);
            }
            return View("Login_PageLoad", clsobj);
        }
    }
}