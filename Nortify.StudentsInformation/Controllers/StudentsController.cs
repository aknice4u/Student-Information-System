using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using DataAccess;
using System.EnterpriseServices;

namespace Nortify.StudentsInformation.Controllers
{

    public class StudentsController : Controller
    {
         private IRecordsRepository<Students> studentsrepository = null;
         private IRecordsRepository<SchoolClass> classrepository = null;
         private IRecordsRepository<AcademicTerm> termrepository = null;
         private IRecordsRepository<Guardian> guardianrepository = null;

        // private IRecordsRepository<FiscalYear> Fiscalrepository = null;
         public StudentsController()
        {
            this.studentsrepository = new StudentsRepo<Students>();
            this.classrepository = new SchoolClassRepo<SchoolClass>();
            this.termrepository = new AcademicTermRepo<AcademicTerm>();
            this.guardianrepository = new GuardianRepo<Guardian>();
           // this.Fiscalrepository = new FiscalYearRepo<FiscalYear>();
        }

        public ActionResult ViewStudents()
        {
            var viewall = studentsrepository.SelectAll().ToList();
            return View(viewall);
        }

        public ActionResult ViewProfile(int id)
        {
            var profile = studentsrepository.SelectByID(id);
            return View(profile);
        }

        public ActionResult Details(int id)
        {
            var employee = studentsrepository.SelectByID(id);
            return View(employee);
        }

        public ActionResult Create()
        {
            ViewBag.roleid = new SelectList(studentsrepository.SelectAll(), "roleid", "rolename");
            ViewBag.CurrentTermID = new SelectList(termrepository.SelectAll(), "ID", "TermID");
            ViewBag.CurrentClassID = new SelectList(classrepository.SelectAll(), "ID", "Name");
            ViewBag.GuardianID = new SelectList(guardianrepository.SelectAll(), "ID", "FirstName");
            return View();
        }

        // GET: Employee/Create
        public ActionResult CreateStudents()
        {
            ViewBag.roleid = new SelectList(studentsrepository.SelectAll(), "roleid", "rolename");
            ViewBag.CurrentTermID = new SelectList(termrepository.SelectAll(), "ID", "TermID");
            ViewBag.CurrentClassID = new SelectList(classrepository.SelectAll(), "ID", "Name");
            ViewBag.GuardianID = new SelectList(guardianrepository.SelectAll(), "ID", "FirstName");
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult CreateStudents(Students s)
        {
            ViewBag.roleid = new SelectList(studentsrepository.SelectAll(), "roleid", "rolename");
            ViewBag.CurrentTermID = new SelectList(termrepository.SelectAll(), "ID", "TermID");
            ViewBag.CurrentClassID = new SelectList(classrepository.SelectAll(), "ID", "Name");
            ViewBag.GuardianID = new SelectList(guardianrepository.SelectAll(), "ID", "FirstName");

           
              //if (ModelState.IsValid)
            try
                {

                    //ViewBag.FiscalYear_ID = new SelectList(Fiscalrepository.SelectAll(), "FiscalYear_ID", "Year");
                    studentsrepository.Insert(s);
                    studentsrepository.Save();

                    return RedirectToAction("ViewStudents");
                }
                catch(Exception ex)
                {
                    ViewBag.error = ex.Message;
                 // ViewBag.error = "Not inserted";
                }
            
             
            return View(s);
        }

        // GET: Employee/Edit/5
        [HttpGet]
        public ActionResult EditStudents(int id)
        {
   
            ViewBag.CurrentTermID = new SelectList(termrepository.SelectAll(), "ID", "TermID");
            ViewBag.ClassAdmittedID = new SelectList(classrepository.SelectAll(), "ID", "Name");
            ViewBag.GuardianID = new SelectList(guardianrepository.SelectAll(), "ID", "FirstName");
            var employee = studentsrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult EditStudents(Students s)
        {
            
               
                ViewBag.CurrentTermID = new SelectList(termrepository.SelectAll(), "ID", "TermID");
                ViewBag.ClassAdmittedID = new SelectList(classrepository.SelectAll(), "ID", "Name");
                ViewBag.GuardianID = new SelectList(guardianrepository.SelectAll(), "ID", "FirstName");
                studentsrepository.Update(s);
                studentsrepository.Save();
                //return RedirectToAction("ViewStudents");
          
                return View();
         }

        // GET: Employee/Delete/5
        public ActionResult DeleteStudent(int id)
        {
            var employee = studentsrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult DeleteStudent(int id, FormCollection collection)
        {
            try
            {
                studentsrepository.Delete(id);
                studentsrepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


       
        public ActionResult SearchStudents(FormCollection collection)
        {
          ViewBag.CurrentClassID = new SelectList(classrepository.SelectAll(), "ID", "Name");
         return View();
        }
        public ActionResult Search(FormCollection collection)
        {
            var studentclass = collection["CurrentClassId"];
            var fname = collection["FirstName"];
            var lname = collection["Lastname"];
            var onames = collection["OtherNames"];
            var gender = collection["Gender"];
            var stat = collection["Status"];
            StudentsContext ct = new StudentsContext();
            var search = from p in ct.students
                         where p.FirstName == fname || p.LastName == lname || p.OtherNames == onames || p.Gender == gender || p.Status == stat
                         select p;
            ViewBag.CurrentClassID = new SelectList(classrepository.SelectAll(), "ID", "Name");
            return View(search.ToList());
        }
	}
}