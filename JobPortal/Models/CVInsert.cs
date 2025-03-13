using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class CVInsert
    {
        public int userId { set; get; }
        public int cId { set; get; }
        [Display(Name = "Resume")]
        public string resume { set; get; }
        public string date { set; get; }
        public string msg { set; get; }

    }
}