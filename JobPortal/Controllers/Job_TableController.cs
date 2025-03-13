using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobPortal;

namespace JobPortal.Controllers
{
    public class Job_TableController : Controller
    {
        private JobPortalDBEntities db = new JobPortalDBEntities();

        // GET: Job_Table
        public ActionResult Index()
        {
            return View(db.Job_Table.ToList());
        }

        // GET: Job_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job_Table job_Table = db.Job_Table.Find(id);
            if (job_Table == null)
            {
                return HttpNotFound();
            }
            return View(job_Table);
        }

        // GET: Job_Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Job_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Job_Id,Company_Id,Job_Title,Description,Salary,Location,Experience_years,Skills,Job_Type,Vacancies,Job_Status,Start_Date,End_Date")] Job_Table job_Table)
        {
            if (ModelState.IsValid)
            {
                db.Job_Table.Add(job_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(job_Table);
        }

        // GET: Job_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job_Table job_Table = db.Job_Table.Find(id);
            if (job_Table == null)
            {
                return HttpNotFound();
            }
            return View(job_Table);
        }

        // POST: Job_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Job_Id,Company_Id,Job_Title,Description,Salary,Location,Experience_years,Skills,Job_Type,Vacancies,Job_Status,Start_Date,End_Date")] Job_Table job_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job_Table);
        }

        // GET: Job_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job_Table job_Table = db.Job_Table.Find(id);
            if (job_Table == null)
            {
                return HttpNotFound();
            }
            return View(job_Table);
        }

        // POST: Job_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job_Table job_Table = db.Job_Table.Find(id);
            db.Job_Table.Remove(job_Table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
