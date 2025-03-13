using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class UserDashController : Controller
    {
        JobPortalDBEntities dbobj = new JobPortalDBEntities();
        // GET: UserDash
        public ActionResult User_PageLoad()
        {            
            return View(getData());
        }
        private JobSearch getData()
        {
            var joblist = new JobSearch();
            var job = dbobj.Job_Table.Where(j => j.Job_Status.ToLower() == "open").ToList();
            foreach (var e in job)
            {
                var jobcls = new JobSearchTable();
                jobcls.jobId = e.Job_Id;
                jobcls.cId = e.Company_Id;
                jobcls.jobTitle = e.Job_Title;
                jobcls.jobDesc = e.Description;
                jobcls.jobSal = e.Salary;
                jobcls.jobLoc = e.Location;
                jobcls.jobExp = e.Experience_years;
                jobcls.jobSkills = e.Skills;
                jobcls.jobType = e.Job_Type;
                jobcls.jobVac = e.Vacancies;
                jobcls.status = e.Job_Status;
                jobcls.endDate = e.End_Date.ToString();
                joblist.jobFilterList.Add(jobcls);
            }
            return joblist;
        }
        public ActionResult searchJob_click(JobSearch jobSearch)
        {
            string query = "";
            if (jobSearch.selectJob.jobExp.HasValue)
            {
                query += " and Experience_years = " + jobSearch.selectJob.jobExp + "";
            }
            if (!string.IsNullOrWhiteSpace(jobSearch.selectJob.jobSkills))
            {
                query += " and Skills like '%" + jobSearch.selectJob.jobSkills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(jobSearch.selectJob.jobLoc))
            {
                query += " and Location like '%" + jobSearch.selectJob.jobLoc + "%'";
            }
            return View("User_PageLoad", getSearchData(jobSearch, query));
        }

        private JobSearch getSearchData(JobSearch jobSearch, string query)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_JobSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@query",query);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearch();
                while (dr.Read())
                {
                    string status = dr["Job_Status"].ToString();
                    if (status.ToLower() == "open")
                    {
                        var jobobj = new JobSearchTable();
                        jobobj.cId = Convert.ToInt32(dr["Company_Id"]);
                        jobobj.jobTitle = dr["Job_Title"].ToString();
                        jobobj.jobDesc = dr["Description"].ToString();
                        jobobj.jobSal = Convert.ToInt32(dr["Salary"]);
                        jobobj.jobLoc = dr["Location"].ToString();
                        jobobj.jobExp = Convert.ToInt32(dr["Experience_years"]);
                        jobobj.jobSkills = dr["Skills"].ToString();
                        jobobj.jobType = dr["Job_Type"].ToString();
                        jobobj.jobVac = Convert.ToInt32(dr["Vacancies"]);
                        jobobj.status = dr["Job_Status"].ToString();
                        jobobj.endDate = dr["End_Date"].ToString();
                        joblist.jobFilterList.Add(jobobj);
                    }
                }
                con.Close();
                return joblist;
            }
        }
    }
}