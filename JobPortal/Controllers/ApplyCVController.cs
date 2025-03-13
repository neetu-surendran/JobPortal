using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class ApplyCVController : Controller
    {
        // GET: ApplyCV
        JobPortalDBEntities dbobj = new JobPortalDBEntities();
        public ActionResult ApplyCV_Load(int cid, int jid)
        {
            TempData["cid"] = cid;
            TempData["jid"] = jid;
            var count = dbobj.sp_alreadyApplied(cid, jid, Convert.ToInt32(Session["uid"])).Single();
            if (count == 1)
            {
                TempData["applied"] = true;
            }
            else
            {
                TempData["applied"] = false;
            }
            TempData.Keep("applied");
            return View();
        }

        public ActionResult ApplyCV_click(CVInsert clsobj, HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0)
            {
                ModelState.AddModelError("resume", "Please upload a valid file.");
            }
            else
            {
                string[] allowedExtensions = { ".pdf", ".doc", ".docx" };
                string extension = Path.GetExtension(file.FileName);
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("resume", "Only .pdf, .doc and .docx files are allowed.");
                }
                if (file.ContentLength > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("resume", "File size must be less than 2MB.");
                }
            }
            if (ModelState.IsValid)
            {
                string fname = Path.GetFileName(file.FileName);
                var path = Server.MapPath("~/Files");
                string p = Path.Combine(path, fname);
                file.SaveAs(p);

                var dbPath = Path.Combine("~\\Files", fname);
                clsobj.resume = dbPath;

                var count = dbobj.sp_alreadyApplied(Convert.ToInt32(TempData["cid"]), Convert.ToInt32(TempData["jid"]), Convert.ToInt32(Session["uid"])).Single();
                if (count == 1)
                {                   
                    dbobj.sp_updateCv(Convert.ToInt32(Session["uid"]), Convert.ToInt32(TempData["cid"]),
                        Convert.ToInt32(TempData["jid"]), clsobj.resume, DateTime.Now.ToString("yyyy-MM-dd"));
                    clsobj.msg = "Application updated successfully";
                }
                else
                {
                    TempData["applied"] = false;
                    dbobj.sp_applycv(Convert.ToInt32(Session["uid"]), Convert.ToInt32(TempData["cid"]),
                        Convert.ToInt32(TempData["jid"]), clsobj.resume, DateTime.Now.ToString("yyyy-MM-dd"), "Applied");
                    clsobj.msg = "Application uploaded successfully";
                }
                return View("ApplyCV_Load", clsobj);
                
            }
            return View("ApplyCV_Load", clsobj);
        }
    }
}