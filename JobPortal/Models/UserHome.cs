using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class UserHome
    {
        [Display(Name = "Company ID")]
        public int companyId { set; get; }
        [Display(Name = "Title")]
        public string jobTitle { set; get; }
        public string Description { set; get; }
        public string Salary { set; get; }
        public string Location { set; get; }
        public string Experience { set; get; }
        public string Skills { set; get; }
        [Display(Name = "Type")]
        public string jobType { set; get; }
        public int Vacancies { set; get; }
        public int Status { set; get; }
        [Display(Name = "Last Date")]
        public System.DateTime endDate { set; get; }
    }
}