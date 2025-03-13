using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class CompanyInsert
    {
        [Required (ErrorMessage ="Enter Company Name")]
        public string name { set; get; }
        [Required (ErrorMessage = "Enter Company address")]
        public string address { set; get; }
        [Required (ErrorMessage ="Enter Phone number")]
        [RegularExpression (@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string phone { set; get; }
        [EmailAddress (ErrorMessage = "Enter valid e-mail id")]
        public string email { set; get; }
        [Url (ErrorMessage ="Enter valid website address")]
        public string website { set; get; }
        public string photo { set; get; }
        [Required (ErrorMessage = "Enter a username")]
        public string username { set; get; }
        public string password { set; get; }
        [Compare ("password", ErrorMessage = "Password mismatch")]
        public string cpass { set; get; }
        public string adminmsg { set; get; }



    }
}