using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class JobSearch
    {
        public JobSearch()
        {
            jobFilterList = new List<JobSearchTable>();
            selectJob = new JobSearchTable();
        }
        public List<JobSearchTable> jobFilterList { set; get; }
        public JobSearchTable selectJob { set; get; }

    }

    public class JobSearchTable
    {
        public int jobId { set; get; }
        [Display(Name = "Company ID")]
        public int cId { set; get; }
        [Display(Name = "Title")]
        public string jobTitle { set; get; }
        [Display(Name = "Description")]
        public string jobDesc { set; get; }
        [Display(Name = "Salary")]
        public int jobSal { set; get; }
        [Display(Name = "Location")]
        public string jobLoc { set; get; }
        [Display(Name = "Experience (yrs)")]
        public int? jobExp { set; get; }
        [Display(Name = "Skills")]
        public string jobSkills { set; get; }
        [Display(Name = "Type")]
        public string jobType { set; get; }
        [Display(Name = "Vacancies")]
        public int jobVac { set; get; }
        [Display(Name = "Status")]
        public string status { set; get; }
        [Display(Name = "Start Date")]
        public string startDate { set; get; }
        [Display(Name = "Last Date")]
        public string endDate { set; get; }
        public string msg { set; get; }

    }

}