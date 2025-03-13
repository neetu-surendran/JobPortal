using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class LoginClass
    {
        [Required (ErrorMessage = "Enter username")]
        public string username { set; get; }
        [Required(ErrorMessage = "Enter password")]
        public string password { set; get; }
        public string msg { set; get; }
        public string logType { set; get; }
    }
}