using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class UserRegController : Controller
    {
        JobPortalDBEntities dbobj = new JobPortalDBEntities();
        // GET: UserReg
        public ActionResult UserInsert_PageLoad()
        {
            List<LocationDDL> location = new List<LocationDDL>()
                { new LocationDDL{ locId = 1, locName = "Ahmedabad" },
                  new LocationDDL{ locId = 2, locName = "Bangalore" },
                  new LocationDDL{ locId = 3, locName = "Chennai" },
                  new LocationDDL{ locId = 4, locName = "Coimbatore" },
                  new LocationDDL{ locId = 5, locName = "Delhi" },
                  new LocationDDL{ locId = 6, locName = "Kochi" },
                  new LocationDDL{ locId = 7, locName = "Vishakhapatnam" },
                  new LocationDDL{ locId = 8, locName = "Thiruvananthapuram" },
                  new LocationDDL{ locId = 9, locName = "Same as Address" }
                };
            ViewBag.selectedLocation = new SelectList(location, "locId", "locName");

            UserInsert user = new UserInsert();
            user.qualification = bindQualificationData();

            return View(user);
        }
        public List<CheckBoxListHelper> bindQualificationData()
        {
            List<CheckBoxListHelper> qual = new List<CheckBoxListHelper>
            {
                new CheckBoxListHelper{Value="X", Text="X", IsChecked=false },
            new CheckBoxListHelper { Value = "XII", Text = "XII", IsChecked = false },
            new CheckBoxListHelper { Value = "Bachelors", Text = "Bachelors", IsChecked = false },
            new CheckBoxListHelper { Value = "Masters", Text = "Masters", IsChecked = false },
            new CheckBoxListHelper { Value = "Doctorate", Text = "Doctorate", IsChecked = false }
            };
            return qual;
        }
        public ActionResult UserInsert_Click(UserInsert clsobj, HttpPostedFileBase file, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Images");
                    string p = Path.Combine(s, fname);
                    file.SaveAs(p);

                    string dbPath = Path.Combine("~\\Images", fname);
                    clsobj.photo = dbPath;
                }

                List<LocationDDL> location = new List<LocationDDL>()
                { new LocationDDL{ locId = 1, locName = "Ahmedabad" },
                  new LocationDDL{ locId = 2, locName = "Bangalore" },
                  new LocationDDL{ locId = 3, locName = "Chennai" },
                  new LocationDDL{ locId = 4, locName = "Coimbatore" },
                  new LocationDDL{ locId = 5, locName = "Delhi" },
                  new LocationDDL{ locId = 6, locName = "Kochi" },
                  new LocationDDL{ locId = 7, locName = "Vishakhapatnam" },
                  new LocationDDL{ locId = 8, locName = "Thiruvananthapuram" },
                  new LocationDDL{ locId = 9, locName = "Same as Address" },
                };
                ViewBag.selectedLocation = new SelectList(location, "locId", "locName");

                int selectedId = Convert.ToInt32(form["ddlLocation"]);
                LocationDDL selectedItem = location.FirstOrDefault(c => c.locId == selectedId);
                clsobj.locId = selectedItem.locId;
                clsobj.locName = selectedItem.locName;

                var quid = string.Join(",", clsobj.selectedQual);
                clsobj.qual = quid;
                clsobj.qualification = bindQualificationData();

                var getMaxId = dbobj.sp_MaxRegId().FirstOrDefault();
                int regId;
                if (Convert.ToInt32(getMaxId) == 0)
                {
                    regId = 1;
                }
                else
                {
                    regId = Convert.ToInt32(getMaxId) + 1;
                }
                dbobj.sp_InsertUser(regId, clsobj.name, clsobj.age, clsobj.address, 
                                    clsobj.phone, clsobj.email, clsobj.gender, clsobj.qual, clsobj.experience, 
                                    clsobj.skills, clsobj.locName, clsobj.photo );
                dbobj.sp_InsertLogin(regId, clsobj.username, clsobj.password, "user");
                clsobj.msg = "Successfully Inserted";
                return View("UserInsert_PageLoad", clsobj);
            }
            else
            {
                List<LocationDDL> location = new List<LocationDDL>()
                { new LocationDDL{ locId = 1, locName = "Ahmedabad" },
                  new LocationDDL{ locId = 2, locName = "Bangalore" },
                  new LocationDDL{ locId = 3, locName = "Chennai" },
                  new LocationDDL{ locId = 4, locName = "Coimbatore" },
                  new LocationDDL{ locId = 5, locName = "Delhi" },
                  new LocationDDL{ locId = 6, locName = "Kochi" },
                  new LocationDDL{ locId = 7, locName = "Vishakhapatnam" },
                  new LocationDDL{ locId = 8, locName = "Thiruvananthapuram" },
                  new LocationDDL{ locId = 9, locName = "Same as Address" },
                };
                ViewBag.selectedLocation = new SelectList(location, "locId", "locName");

                clsobj.qualification = bindQualificationData();
                return View("UserInsert_PageLoad", clsobj);
            }            
        }
    }
}