using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class AdminDashController : Controller
    {
        JobPortalDBEntities dbobj = new JobPortalDBEntities();
        // GET: AdminDash
        public ActionResult Admin_PageLoad()
        {
            var jobEntry = dbobj.sp_selectJobs(Convert.ToInt32(Session["uid"])).ToList();
            ViewBag.Job = jobEntry;
            return View();
        }
        //GET: Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult ShowArchived()
        {
            var job = dbobj.sp_selectArchivedJobs(Convert.ToInt32(Session["uid"])).ToList();
            ViewBag.Archived = job;
            return View();
        }
        //POST
        public ActionResult Create_Click(AdminDash clsobj)
        {
            if (ModelState.IsValid)
            {
                dbobj.sp_createJob(Convert.ToInt32(Session["uid"]), clsobj.jobTitle, clsobj.jobDesc, clsobj.jobSal, clsobj.jobLoc,
                                            clsobj.jobExp, clsobj.jobSkills, clsobj.jobType, clsobj.jobVac, clsobj.status,
                                            clsobj.startDate, clsobj.endDate);
                return RedirectToAction("Admin_PageLoad");
            }
            return View("Create");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var job = dbobj.sp_getJob(id).FirstOrDefault();
            EditJob model = new EditJob
            {
                jobId = (int)id,
                jobVac = job.Vacancies,
                status = job.Job_Status
            };
            return View(model);
        }

        public ActionResult Edit_Save(EditJob editObj)
        {
            if (ModelState.IsValid)
            {
                dbobj.sp_updateJob(editObj.jobId, Convert.ToInt32(Session["uid"]), editObj.jobVac, editObj.status);
                return RedirectToAction("Admin_PageLoad");
            }
            return View("Edit");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jobDetails = dbobj.sp_getJobDetails(id).Single();
            ViewBag.JobDetails = jobDetails;
            return View(new AdminDash { 
                jobId = jobDetails.Job_Id,
                cId = jobDetails.Company_Id,
                jobTitle = jobDetails.Job_Title,
                jobDesc = jobDetails.Description,
                jobSal = jobDetails.Salary,
                jobLoc = jobDetails.Location,
                jobExp = jobDetails.Experience_years,
                jobSkills = jobDetails.Skills,
                jobType = jobDetails.Job_Type,
                jobVac = jobDetails.Vacancies,
                status = jobDetails.Job_Status,
                startDate = jobDetails.Start_Date.Date,
                endDate = jobDetails.End_Date.Date
            });
        }

        public ActionResult Archive(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dbobj.sp_archiveJob(id, Convert.ToInt32(Session["uid"]), "archived");
            return RedirectToAction("Admin_PageLoad");
        }
    }
}