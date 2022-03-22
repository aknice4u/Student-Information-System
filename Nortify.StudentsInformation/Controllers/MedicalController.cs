using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using DataAccess;

namespace Nortify.StudentsInformation.Controllers
{
    public class MedicalController : Controller
    {
         private IRecordsRepository<StudentMedical> medicalrepository = null;
        private IRecordsRepository<Students> studentsrepository = null;
         public MedicalController()
        {
            this.medicalrepository = new StudentsMedicalRepo<StudentMedical>();
           this.studentsrepository = new StudentsRepo<Students>();
        }

         public ActionResult ViewMedical()
        {
            var viewall = medicalrepository.SelectAll().ToList();
            return View(viewall);
        }

        public ActionResult Details(int id)
        {
            var employee = medicalrepository.SelectByID(id);
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult CreateMedical()
        {
            ViewBag.StudentNo = new SelectList(studentsrepository.SelectAll(), "StudentNo", "FirstName");
            //ViewBag.FiscalYear_ID = new SelectList(medicalrepository.SelectAll(), "FiscalYear_ID", "Year");
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult CreateMedical(StudentMedical sm)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.FiscalYear_ID = new SelectList(Fiscalrepository.SelectAll(), "FiscalYear_ID", "Year");
                medicalrepository.Insert(sm);
                medicalrepository.Save();

                return RedirectToAction("ViewMedical");
            }
            return View(sm);
        }

        // GET: Employee/Edit/5
        public ActionResult EditMedical(int id)
        {
            var stu = new Students();
           
            ViewBag.StudentNo = new SelectList(studentsrepository.SelectAll(), "StudentNo", "FirstName",id);
            var employee = medicalrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult EditMedical(StudentMedical sm)
        {
            ViewBag.StudentNo = new SelectList(studentsrepository.SelectAll(), "StudentNo", "FirstName");
            try
            {
                medicalrepository.Update(sm);
                medicalrepository.Save();
                return RedirectToAction("ViewMedical");
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult DeleteMedical(int id)
        {
            var employee = medicalrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult DeleteMedical(int id, FormCollection collection)
        {
            try
            {
                medicalrepository.Delete(id);
                medicalrepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
	}
}