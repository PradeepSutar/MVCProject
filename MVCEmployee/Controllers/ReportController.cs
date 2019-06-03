using MVCEmployee.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace MVCEmployee.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult List()
        {
            TESTDataContext sa = new TESTDataContext();
            var list = (from v in sa.TBLEMPLOYEEs
                        join l in sa.TBLLOCATIONs on v.LOCATION equals l.PK_LOC_ID
                        join s in sa.TBLSKILLs on v.SKILL_ID equals s.PK_SKILL_ID
                        select new
                        {
                            v.ISACTIVE,
                            v.PK_EMP_ID,
                            v.EMP_NAME,
                            v.AGE,
                            v.USER_ID,
                            v.MARTIAL_STATUS,
                            v.SALARY,
                            v.LOCATION,
                            locname = l.LOCATION,
                            s.PK_SKILL_ID,
                            s.SKILL_NAME,
                            v.RELEVANT_EXPR,
                            v.CREATED_BY,
                            v.CREATED_DATE
                        }
                        ).ToList();

            List<Employee> lst = new List<Employee>();
            foreach (var temp in list)
            {
                Employee obj = new Employee();
                obj.PK_EMP_ID = temp.PK_EMP_ID;
                obj.EMP_NAME = temp.EMP_NAME;
                obj.USER_ID = temp.USER_ID;
                obj.Age = Convert.ToInt32(temp.AGE);
                obj.Salary = Convert.ToDecimal(temp.SALARY);
                obj.LOCATIONID = Convert.ToInt32(temp.LOCATION);
                obj.MARTIAL_STATUS = temp.MARTIAL_STATUS;
                obj.LOCATION = temp.locname;
                obj.ISACTIVE = Convert.ToInt32(temp.ISACTIVE);
                obj.RelevantExprience = temp.RELEVANT_EXPR;
                obj.Skill = temp.SKILL_NAME;
                obj.CREATEDBY = temp.CREATED_BY;
                obj.CREATEDDATE = Convert.ToString(temp.CREATED_DATE);
                lst.Add(obj);
            }

            return View(lst);
        }


        [HttpPost]
        public JsonResult EmployeeList()
        {
            TESTDataContext sa = new TESTDataContext();
            var list = (from v in sa.TBLEMPLOYEEs
                        select new { v.PK_EMP_ID, v.EMP_NAME }
                        ).ToList();
            List<SkillDetails> ObjList = new List<SkillDetails>();
            foreach (var temp in list)
            {
                SkillDetails obj = new SkillDetails();
                obj.id = temp.PK_EMP_ID;
                obj.label = temp.EMP_NAME;
                ObjList.Add(obj);
            }

            return Json(ObjList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult LocationList()
        {
            TESTDataContext sa = new TESTDataContext();
            var list = (from v in sa.TBLLOCATIONs
                        select new { v.PK_LOC_ID, v.LOCATION }
                        ).ToList();
            List<SkillDetails> ObjList = new List<SkillDetails>();
            foreach (var temp in list)
            {
                SkillDetails obj = new SkillDetails();
                obj.id = temp.PK_LOC_ID;
                obj.label = temp.LOCATION;
                ObjList.Add(obj);
            }

            return Json(ObjList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getReportData(string empid, string skillid, string locid)
        {
            string[] jsonArray = new string[1];
            //List<SkillDetails> ObjList = new List<SkillDetails>();
            List<Employee> lst = new List<Employee>();
            try
            {
                TESTDataContext sa = new TESTDataContext();


                var list = (from v in sa.TBLEMPLOYEEs
                            join l in sa.TBLLOCATIONs on v.LOCATION equals l.PK_LOC_ID
                            from s in sa.TBLSKILLs.Where(p => v.SKILL_ID == p.PK_SKILL_ID).DefaultIfEmpty()
                            select new
                            {
                                v.ISACTIVE,
                                v.PK_EMP_ID,
                                v.EMP_NAME,
                                v.AGE,
                                v.USER_ID,
                                v.MARTIAL_STATUS,
                                v.SALARY,
                                v.LOCATION,
                                locname = l.LOCATION,
                                s.PK_SKILL_ID,
                                s.SKILL_NAME,
                                v.RELEVANT_EXPR,
                                v.CREATED_BY,
                                v.CREATED_DATE,
                                l.PK_LOC_ID
                            }
                            ).ToList();
                if (empid != "" && skillid != "" && locid != "")
                {
                    list = list.Where(s => s.PK_EMP_ID == Convert.ToInt32(empid) && s.PK_SKILL_ID == Convert.ToInt32(skillid) && s.PK_LOC_ID == Convert.ToInt32(locid)).ToList();
                }
                else if (empid != "" && skillid != "" && locid == "")
                {
                    list = list.Where(s => s.PK_EMP_ID == Convert.ToInt32(empid) && s.PK_SKILL_ID == Convert.ToInt32(skillid)).ToList();
                }
                else if (empid != "" && skillid == "" && locid == "")
                {
                    list = list.Where(s => s.PK_EMP_ID == Convert.ToInt32(empid)).ToList();
                }
                else if (empid == "" && skillid != "" && locid == "")
                {
                    list = list.Where(s => s.PK_SKILL_ID == Convert.ToInt32(skillid)).ToList();
                }
                else if (empid == "" && skillid == "" && locid != "")
                {
                    list = list.Where(s => s.PK_LOC_ID == Convert.ToInt32(locid)).ToList();
                }
                else if (empid == "" && skillid != "" && locid != "")
                {
                    list = list.Where(s => s.PK_SKILL_ID == Convert.ToInt32(skillid) && s.PK_LOC_ID == Convert.ToInt32(locid)).ToList();
                }
                else if (empid != "" && skillid == "" && locid != "")
                {
                    list = list.Where(s => s.PK_EMP_ID == Convert.ToInt32(empid) && s.PK_LOC_ID == Convert.ToInt32(locid)).ToList();
                }


                foreach (var temp in list)
                {
                    Employee obj = new Employee();
                    obj.PK_EMP_ID = temp.PK_EMP_ID;
                    obj.EMP_NAME = temp.EMP_NAME;
                    obj.USER_ID = temp.USER_ID;
                    obj.Age = Convert.ToInt32(temp.AGE);
                    obj.Salary = Convert.ToDecimal(temp.SALARY);
                    obj.LOCATIONID = Convert.ToInt32(temp.LOCATION);
                    obj.MARTIAL_STATUS = temp.MARTIAL_STATUS;
                    obj.LOCATION = temp.locname;
                    obj.ISACTIVE = Convert.ToInt32(temp.ISACTIVE);
                    obj.RelevantExprience = temp.RELEVANT_EXPR;
                    obj.Skill = temp.SKILL_NAME;
                    obj.CREATEDBY = temp.CREATED_BY;
                    obj.CREATEDDATE = Convert.ToString(temp.CREATED_DATE);
                    lst.Add(obj);
                }
                // jsonArray[0] = JsonConvert.SerializeObject(lst, Formatting.Indented);

            }
            catch (Exception Ex)
            {

            }
            return Json(lst, JsonRequestBehavior.AllowGet);
            //return jsonArray;
        }

    }
}