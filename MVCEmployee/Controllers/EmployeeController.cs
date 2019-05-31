using MVCEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult List()
        {
            TESTDataContext sa = new TESTDataContext();
            var list = (from v in sa.TBLEMPLOYEEs
                        join l in sa.TBLLOCATIONs on v.LOCATION equals l.PK_LOC_ID
                        select new { v.ISACTIVE, v.PK_EMP_ID, v.EMP_NAME, v.AGE, v.USER_ID, v.MARTIAL_STATUS, v.SALARY, v.LOCATION, locname = l.LOCATION }
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
                lst.Add(obj);
            }

            return View(lst);
        }

        public ActionResult Create()
        {
            Employee model = new Employee();
            model.CREATEDBY = Convert.ToString(Session["AD_ID"]);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Employee model, string Command)
        {
            TESTDataContext sa = new TESTDataContext();
            string create_val = "=";
            try
            {
                sa.Connection.Open();
                sa.Transaction = sa.Connection.BeginTransaction();
                if (Command == "Save")
                {

                    if (model.EMP_NAME == "" || model.EMP_NAME == null)
                    {
                        create_val = "false=Please Enter Employee Name";
                    }
                    else if (model.USER_ID == "" || model.EMP_NAME == null)
                    {
                        create_val = "false=Please Enter User ID";
                    }
                    else if (model.LOCATIONID == 0 || model.LOCATIONID == null)
                    {
                        create_val = "false=Please Select Location";
                    }
                    else if (model.Age == 0 || model.Age == null)
                    {
                        create_val = "false=Please Enter age";
                    }
                    else if (model.MARTIAL_STATUS == "---Select One---" || model.MARTIAL_STATUS == null)
                    {
                        create_val = "false=Please Select Martial Status";
                    }
                    else if (model.Salary == 0 || model.Salary == null)
                    {
                        create_val = "false=Please Enter Salary";
                    }
                    else if (model.Skillid == 0 || model.Skillid == null)
                    {
                        create_val = "false=Please Select Skill";
                    }
                    else if (model.RelevantExprience == "" || model.RelevantExprience == null)
                    {
                        create_val = "false=Please Enter Relevant Exprience";
                    }
                    else
                    {
                        var rec_count = 0;

                        rec_count = (from v in sa.TBLEMPLOYEEs
                                     where v.USER_ID == model.USER_ID
                                     select v).Count();

                        if (rec_count == 0)
                        {
                            TBLEMPLOYEE te = new TBLEMPLOYEE();
                            te.EMP_NAME = model.EMP_NAME;
                            te.USER_ID = model.USER_ID;
                            te.LOCATION = model.LOCATIONID;
                            te.AGE = model.Age;
                            te.SALARY = model.Salary;
                            te.MARTIAL_STATUS = model.MARTIAL_STATUS;
                            te.CREATED_BY = Convert.ToString(Session["AD_ID"]);
                            te.CREATED_DATE = DateTime.Now;
                            te.ISACTIVE = 1;
                            te.PASSWORD = "123";
                            te.SKILL_ID = model.Skillid;
                            te.RELEVANT_EXPR = model.RelevantExprience;
                            sa.TBLEMPLOYEEs.InsertOnSubmit(te);
                            sa.SubmitChanges();
                            create_val = "true=Data Saved Successfully.User Name:-" + model.USER_ID + "";
                            sa.Transaction.Commit();
                        }
                        else
                        {
                            create_val = "false=Record Does Not Exist";
                        }

                    }

                }
                else
                {
                    if (model.EMP_NAME == "" || model.EMP_NAME == null)
                    {
                        create_val = "false=Please Enter Employee Name";
                    }
                    else if (model.USER_ID == "" || model.EMP_NAME == null)
                    {
                        create_val = "false=Please Enter User ID";
                    }
                    else if (model.LOCATIONID == 0 || model.LOCATIONID == null)
                    {
                        create_val = "false=Please Select Location";
                    }
                    else if (model.Age == 0 || model.Age == null)
                    {
                        create_val = "false=Please Enter age";
                    }
                    else if (model.MARTIAL_STATUS == "---Select One---" || model.MARTIAL_STATUS == null)
                    {
                        create_val = "false=Please Select Martial Status";
                    }
                    else if (model.Salary == 0 || model.Salary == null)
                    {
                        create_val = "false=Please Enter Salary";
                    }

                    else
                    {
                        var rec_count = 0;

                        rec_count = (from v in sa.TBLEMPLOYEEs
                                     where v.USER_ID == model.USER_ID
                                     select v).Count();

                        if (rec_count == 0)
                        {
                            TBLEMPLOYEE te = new TBLEMPLOYEE();
                            te.EMP_NAME = model.EMP_NAME;
                            te.USER_ID = model.USER_ID;
                            te.LOCATION = model.LOCATIONID;
                            te.AGE = model.Age;
                            te.SALARY = model.Salary;
                            te.MARTIAL_STATUS = model.MARTIAL_STATUS;
                            te.CREATED_BY = Convert.ToString(Session["AD_ID"]);
                            te.CREATED_DATE = DateTime.Now;
                            te.ISACTIVE = 1;
                            te.PASSWORD = "123";
                            // te.SKILL_ID = model.Skillid;
                            // te.RELEVANT_EXPR = model.RelevantExprience;
                            sa.TBLEMPLOYEEs.InsertOnSubmit(te);
                            sa.SubmitChanges();
                            create_val = "true=Data Saved Successfully.User Name:-" + model.USER_ID + "";
                            sa.Transaction.Commit();
                        }
                        else
                        {
                            create_val = "false=Record Does Not Exist";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                sa.Transaction.Rollback();

            }

            string[] return_data = create_val.Split('=');
            TempData["Response_Message"] = Convert.ToString(return_data[1]);
            if (Convert.ToString(return_data[0]) == "true")
            {
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }

        }

        public ActionResult Edit(int id)
        {
            TESTDataContext sa = new TESTDataContext();
            var temp = (from v in sa.TBLEMPLOYEEs
                        join l in sa.TBLLOCATIONs on v.LOCATION equals l.PK_LOC_ID
                        from s in sa.TBLSKILLs.Where(p => v.SKILL_ID == p.PK_SKILL_ID).DefaultIfEmpty()
                        where v.PK_EMP_ID == id
                        select new
                        {
                            v.PK_EMP_ID,
                            v.EMP_NAME,
                            v.AGE,
                            v.USER_ID,
                            v.MARTIAL_STATUS,
                            v.SALARY,
                            v.LOCATION,
                            locname = l.LOCATION,
                            v.CREATED_BY,
                            v.CREATED_DATE,
                            v.SKILL_ID,
                            v.RELEVANT_EXPR,
                            s.SKILL_NAME
                        }
                        ).SingleOrDefault();

            Employee obj = new Employee();
            if (temp != null)
            {

                obj.PK_EMP_ID = temp.PK_EMP_ID;
                obj.EMP_NAME = temp.EMP_NAME;
                obj.USER_ID = temp.USER_ID;
                obj.Age = Convert.ToInt32(temp.AGE);
                obj.Salary = Convert.ToDecimal(temp.SALARY);
                obj.LOCATIONID = Convert.ToInt32(temp.LOCATION);
                obj.MARTIAL_STATUS = temp.MARTIAL_STATUS;
                obj.LOCATION = temp.locname;
                obj.CREATEDBY = temp.CREATED_BY;
                obj.CREATEDDATE = Convert.ToString(temp.CREATED_DATE);
                obj.Skillid = Convert.ToInt32(temp.SKILL_ID);
                obj.Skill = temp.SKILL_NAME;
                obj.RelevantExprience = temp.RELEVANT_EXPR;

            }

            return View(obj);

        }

        [HttpPost]
        public ActionResult Edit(Employee model, string Command)
        {
            TESTDataContext sa = new TESTDataContext();
            string create_val = "=";

            try
            {
                sa.Connection.Open();
                sa.Transaction = sa.Connection.BeginTransaction();
                if (Command == "Save")
                {
                    if (model.EMP_NAME == "")
                    {
                        create_val = "false=Please Enter Employee Name";
                    }
                    else if (model.USER_ID == "")
                    {
                        create_val = "false=Please Enter User ID";
                    }
                    else if (model.LOCATIONID == 0)
                    {
                        create_val = "false=Please Select Location";
                    }
                    else if (model.Age == 0)
                    {
                        create_val = "false=Please Enter age";
                    }
                    else if (model.MARTIAL_STATUS == "---Select One---")
                    {
                        create_val = "false=Please Select Martial Status";
                    }
                    else if (model.Salary == 0)
                    {
                        create_val = "false=Please Enter Salary";
                    }
                    else if (model.Skillid == 0 || model.Skillid == null)
                    {
                        create_val = "false=Please Select Skill";
                    }
                    else if (model.RelevantExprience == "" || model.RelevantExprience == null)
                    {
                        create_val = "false=Please Enter Relevant Exprience";
                    }
                    else
                    {
                        var rec_count = 0;

                        rec_count = (from v in sa.TBLEMPLOYEEs
                                     where v.USER_ID == model.USER_ID
                                     select v).Count();

                        if (rec_count > 0)
                        {
                            TBLEMPLOYEE te = (from v in sa.TBLEMPLOYEEs where v.PK_EMP_ID == model.PK_EMP_ID select v).SingleOrDefault();
                            if (te != null)
                            {
                                te.EMP_NAME = model.EMP_NAME;
                                te.USER_ID = model.USER_ID;
                                te.LOCATION = model.LOCATIONID;
                                te.AGE = model.Age;
                                te.SALARY = model.Salary;
                                te.MARTIAL_STATUS = model.MARTIAL_STATUS;
                                te.CREATED_BY = Convert.ToString(Session["AD_ID"]);
                                te.CREATED_DATE = DateTime.Now;
                                te.ISACTIVE = 1;
                                te.SKILL_ID = model.Skillid;
                                te.RELEVANT_EXPR = model.RelevantExprience;
                                sa.SubmitChanges();
                                create_val = "true=Record Updated Successfully";
                                sa.Transaction.Commit();
                            }
                            else
                            {
                                create_val = "false=Record Does Not Exist";
                            }
                        }
                        else
                        {
                            create_val = "false=Record Does Not Exist";
                        }

                    }
                }
                else
                {
                    if (model.EMP_NAME == "")
                    {
                        create_val = "false=Please Enter Employee Name";
                    }
                    else if (model.USER_ID == "")
                    {
                        create_val = "false=Please Enter User ID";
                    }
                    else if (model.LOCATIONID == 0)
                    {
                        create_val = "false=Please Select Location";
                    }
                    else if (model.Age == 0)
                    {
                        create_val = "false=Please Enter age";
                    }
                    else if (model.MARTIAL_STATUS == "---Select One---")
                    {
                        create_val = "false=Please Select Martial Status";
                    }
                    else if (model.Salary == 0)
                    {
                        create_val = "false=Please Enter Salary";
                    }

                    else
                    {
                        var rec_count = 0;

                        rec_count = (from v in sa.TBLEMPLOYEEs
                                     where v.USER_ID == model.USER_ID
                                     select v).Count();

                        if (rec_count > 0)
                        {
                            TBLEMPLOYEE te = (from v in sa.TBLEMPLOYEEs where v.PK_EMP_ID == model.PK_EMP_ID select v).SingleOrDefault();
                            if (te != null)
                            {
                                te.EMP_NAME = model.EMP_NAME;
                                te.USER_ID = model.USER_ID;
                                te.LOCATION = model.LOCATIONID;
                                te.AGE = model.Age;
                                te.SALARY = model.Salary;
                                te.MARTIAL_STATUS = model.MARTIAL_STATUS;
                                te.CREATED_BY = Convert.ToString(Session["AD_ID"]);
                                te.CREATED_DATE = DateTime.Now;
                                te.ISACTIVE = 1;
                                // te.SKILL_ID = model.Skillid;
                                //  te.RELEVANT_EXPR = model.RelevantExprience;
                                sa.SubmitChanges();
                                create_val = "true=Record Updated Successfully";
                                sa.Transaction.Commit();
                            }
                            else
                            {
                                create_val = "false=Record Does Not Exist";
                            }
                        }
                        else
                        {
                            create_val = "false=Record Does Not Exist";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                sa.Transaction.Rollback();
            }
            string[] return_data = create_val.Split('=');
            TempData["Response_Message"] = Convert.ToString(return_data[1]);
            if (Convert.ToString(return_data[0]) == "true")
            {
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            TESTDataContext sa = new TESTDataContext();
            var temp = (from v in sa.TBLEMPLOYEEs
                        join l in sa.TBLLOCATIONs on v.LOCATION equals l.PK_LOC_ID
                        where v.ISACTIVE == 1 && v.PK_EMP_ID == id
                        select new { v.PK_EMP_ID, v.EMP_NAME, v.AGE, v.USER_ID, v.MARTIAL_STATUS, v.SALARY, v.LOCATION, locname = l.LOCATION, v.CREATED_BY, v.CREATED_DATE }
                        ).SingleOrDefault();

            Employee obj = new Employee();
            if (temp != null)
            {

                obj.PK_EMP_ID = temp.PK_EMP_ID;
                obj.EMP_NAME = temp.EMP_NAME;
                obj.USER_ID = temp.USER_ID;
                obj.Age = Convert.ToInt32(temp.AGE);
                obj.Salary = Convert.ToDecimal(temp.SALARY);
                obj.LOCATIONID = Convert.ToInt32(temp.LOCATION);
                obj.MARTIAL_STATUS = temp.MARTIAL_STATUS;
                obj.LOCATION = temp.locname;
                obj.CREATEDBY = temp.CREATED_BY;
                obj.CREATEDDATE = Convert.ToString(temp.CREATED_DATE);

            }

            return View(obj);

        }

        [HttpPost]
        public ActionResult Delete(Employee model)
        {
            TESTDataContext sa = new TESTDataContext();
            string create_val = "=";
            try
            {
                sa.Connection.Open();
                sa.Transaction = sa.Connection.BeginTransaction();
                if (model.PK_EMP_ID != 0)
                {
                    TBLEMPLOYEE te = (from v in sa.TBLEMPLOYEEs where v.PK_EMP_ID == model.PK_EMP_ID select v).SingleOrDefault();
                    if (te != null)
                    {
                        te.ISACTIVE = 0;
                        te.CREATED_BY = Convert.ToString(Session["AD_ID"]);
                        te.CREATED_DATE = DateTime.Now;
                        sa.SubmitChanges();
                        create_val = "true=Record Deleted Successfully";
                        sa.Transaction.Commit();
                    }
                    else
                    {
                        create_val = "false=Record Does Not Exist";
                    }
                }
            }
            catch (Exception ex)
            {
                sa.Transaction.Rollback();
            }
            string[] return_data = create_val.Split('=');
            TempData["Response_Message"] = Convert.ToString(return_data[1]);
            if (Convert.ToString(return_data[0]) == "true")
            {
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult SkilList()
        {
            TESTDataContext sa = new TESTDataContext();
            var list = (from v in sa.TBLSKILLs
                        where v.ISACTIVE == 1
                        select new { v.PK_SKILL_ID, v.SKILL_NAME }
                        ).ToList();
            List<SkillDetails> ObjList = new List<SkillDetails>();
            foreach (var temp in list)
            {
                SkillDetails obj = new SkillDetails();
                obj.id = temp.PK_SKILL_ID;
                obj.label = temp.SKILL_NAME;
                ObjList.Add(obj);
            }

            return Json(ObjList, JsonRequestBehavior.AllowGet);
        }
    }
}


