using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class AdminDash
    {
        public int jobId { set; get; }
        [Display(Name = "Company ID")]
        public int cId { set; get; }
        [Required (ErrorMessage = "Enter Job title")]
        [Display(Name = "Title")]
        public string jobTitle { set; get; }
        [Required(ErrorMessage = "Enter Job description")]
        [Display(Name = "Description")]
        public string jobDesc { set; get; }
        [Required(ErrorMessage = "Enter Job salary")]
        [Display(Name = "Salary")]
        public int jobSal { set; get; }
        [Display(Name = "Location")]
        public string jobLoc { set; get; }
        [Display(Name = "Experience (yrs)")]
        public int jobExp { set; get; }
        [Display(Name = "Skills")]
        public string jobSkills { set; get; }
        [Display(Name = "Type")]
        public string jobType { set; get; }
        [Display(Name = "Vacancies")]
        [Required(ErrorMessage = "Enter Job vacancies")]
        public int jobVac { set; get; }
        [Display(Name = "Status")]
        public string status { set; get; }
        [Display(Name = "Start Date")]
        public System.DateTime startDate { set; get; }
        [Display(Name = "End Date")]
        public System.DateTime endDate { set; get; }
    }
}