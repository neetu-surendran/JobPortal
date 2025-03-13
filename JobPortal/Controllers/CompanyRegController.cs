using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class CompanyRegController : Controller
    {
        JobPortalDBEntities dbobj = new JobPortalDBEntities();
        // GET: CompanyReg
        public ActionResult CompanyInsert_PageLoad()
        {
            return View();
        }
        public ActionResult CompanyInsert_Click(CompanyInsert clsobj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Images");
                    string p = Path.Combine(s, fname);
                    file.SaveAs(p);

                    var fullpath = Path.Combine("~\\Images", fname);
                    clsobj.photo = fullpath;
                }
                var getMaxId = dbobj.sp_MaxRegId().FirstOrDefault();
                int regId;
                if(Convert.ToInt32(getMaxId) == 0)
                {
                    regId = 1;
                }
                else
                {
                    regId = Convert.ToInt32(getMaxId) + 1;
                }
                dbobj.sp_InsertCompany(regId, clsobj.name, clsobj.address, clsobj.phone, clsobj.email, clsobj.website, clsobj.photo);
                dbobj.sp_InsertLogin(regId, clsobj.username, clsobj.password, "admin");
                clsobj.adminmsg = "Successfully Inserted";
                return View("CompanyInsert_PageLoad", clsobj);
            }
            return View("CompanyInsert_PageLoad", clsobj);
        }
    }
}