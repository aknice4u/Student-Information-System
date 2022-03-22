using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using DataAccess;

namespace Nortify.StudentsInformation.Controllers
{
    public class GuardianController : Controller
    {
        private IRecordsRepository<Guardian> guardianrepository = null;
        private IRecordsRepository<Students> studentsrepository = null;
        public GuardianController()
        {
            this.guardianrepository = new GuardianRepo<Guardian>();
            this.studentsrepository = new StudentsRepo<Students>();
        }
        public ActionResult ViewGuardians()
        {
            var viewall = guardianrepository.SelectAll().ToList();
            return View(viewall);
        }

        public ActionResult ViewDetails(int id)
        {
            var employee = guardianrepository.SelectByID(id);
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult CreateGuardian()
        {
            ViewBag.StudentNo = new SelectList(studentsrepository.SelectAll(), "StudentNo", "LastName"); 
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult CreateGuardian(Guardian g)
        {
            if (ModelState.IsValid)
            {
                guardianrepository.Insert(g);
                guardianrepository.Save();

                return RedirectToAction("ViewGuardians");
            }
            return View(g);
        }

        // GET: Employee/Edit/5
        public ActionResult EditGuardian(int id)
        {
            var employee = guardianrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult EditGuardian(Guardian g)
        {
            try
            {
                guardianrepository.Update(g);
                guardianrepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult DeleteGuardian(int id)
        {
            var employee = guardianrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult DeleteGuardian(int id, FormCollection collection)
        {
            try
            {
                guardianrepository.Delete(id);
                guardianrepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
	}
}