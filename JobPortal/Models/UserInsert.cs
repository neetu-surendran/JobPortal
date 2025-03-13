using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class LocationDDL
    {
        public int locId { set; get; }
        public string locName { set; get; }
    }
    public class CheckBoxListHelper
    {
        public string Value { set; get; }
        public string Text { set; get; }
        public bool IsChecked { set; get; }
    }
    public class UserInsert
    {
        public int locId { set; get; }
        public string locName { set; get; }

        public List<CheckBoxListHelper> qualification { set; get; }
        public string[] selectedQual { set; get; }

        public int uid { set; get; }
        [Required (ErrorMessage = "Enter Name")]
        public string name { set; get; }
        [Range (22, 60, ErrorMessage = "Enter age between 22 and 60")]
        public int age { set; get; }
        [Required (ErrorMessage = "Enter address")]
        public string address { set; get; }
        [RegularExpression (@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string phone { set; get; }
        [EmailAddress (ErrorMessage = "Enter valid e-mail id")]
        public string email { set; get; }
        public string gender { set; get; }
        public string qual { set; get; }
        [Required(ErrorMessage = "Enter experience in years")]
        public int experience { set; get; }
        [Required(ErrorMessage = "Enter skills")]
        public string skills { set; get; }
        public string photo { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        [Compare ("password", ErrorMessage ="Password mismatch")]
        public string cpwd { set; get; }
        public string msg { set; get; }
    }
}