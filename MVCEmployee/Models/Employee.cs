using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEmployee.Models
{
    public class Employee
    {

        public int PK_EMP_ID { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Name")]
        [Display(Name = "Employee Name")]
        public string EMP_NAME { get; set; }

        [Required(ErrorMessage = "Please Enter User ID")]
        [Display(Name = "User ID")]
        public string USER_ID { get; set; }

        [Required(ErrorMessage = "Please Select Location")]
        [Display(Name = "Location")]
        public string LOCATION { get; set; }

        [Required(ErrorMessage = "Please Enter Age")]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please Select MARTIAL STATUS")]
        [Display(Name = "Martial Status")]
        public string MARTIAL_STATUS { get; set; }

        [Required(ErrorMessage = "Please Enter Salary")]
        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

        public string CREATEDBY { get; set; }
        public string CREATEDDATE { get; set; }
        public int ISACTIVE { get; set; }
        public string PASSWORD { get; set; }

        [Required(ErrorMessage = "Please Select Location")]
        [Display(Name = "Location ID")]
        public int LOCATIONID { get; set; }

        public List<SelectListItem> LocList { get; set; }
       
       
        public Employee()
        {
            LocList = getLocList();
           
        }

        public List<SelectListItem> getLocList()
        {
            TESTDataContext sa = new TESTDataContext();

            var list = sa.TBLLOCATIONs.Where(u => u.ISACTIVE == 1).OrderBy(u => u.LOCATION).ToList().Select(u => new LocDetails
            {
                locID = u.PK_LOC_ID,
                locName = u.LOCATION
            }).ToList();
            list.Insert(0, new LocDetails { locName = "---Select One---", locID = 0 });

            var LocationList = list.Select(u => new SelectListItem
            {
                Text = u.locName,
                Value = u.locID.ToString()
            }).ToList();
            return LocationList;

        }

        [Required(ErrorMessage = "Please Select Skill")]
        [Display(Name = "Skill")]
        public string Skill { get; set; }

        [Required(ErrorMessage = "Please Select Skill")]
        [Display(Name = "Skill")]
        public int Skillid { get; set; }

        [Required(ErrorMessage = "Please Enter Relevant Exprience")]
        [Display(Name = "Relevant Exprience")]
        public string RelevantExprience { get; set; }

    }

    public class LocDetails
    {
        public int locID { get; set; }
        public String locName { get; set; }
    }

    public class SkillDetails
    {
        public int id { get; set; }
        public String label { get; set; }
    }


}