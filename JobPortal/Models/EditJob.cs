using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class EditJob
    {
        public int jobId { set; get; }
        [Display(Name = "Vacancies")]
        [Required(ErrorMessage = "Enter Job vacancies")]
        public int jobVac { set; get; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Enter Job status")]
        public string status { set; get; }
    }
}