using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Domain;

namespace Nortify.StudentsInformation.Controllers
{
    public class AcademicTermController : Controller
    {
        private IRecordsRepository<AcademicTerm> termrepository = null;
        private IRecordsRepository<AcademicSession> sessionrepository = null;
        public AcademicTermController()
        {
            this.termrepository = new AcademicTermRepo<AcademicTerm>();
            this.sessionrepository = new AcademicSessionRepo<AcademicSession>();
        }

        
        // GET: /AcademicSession/
        public ActionResult ViewTerms()
        {
            var viewall = termrepository.SelectAll().ToList();
            return View(viewall);
        }

        public ActionResult Details(int id)
        {
            var employee = termrepository.SelectByID(id);
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult CreateTerm()
        {
            ViewBag.SessionID = new SelectList(sessionrepository.SelectAll(), "SessionID", "Description");
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult CreateTerm(AcademicTerm term)
        {
            if (ModelState.IsValid)
            {
                termrepository.Insert(term);
                termrepository.Save();

                return RedirectToAction("ViewTerm");
            }
            return View(term);
        }

        // GET: Employee/Edit/5
        public ActionResult EditTerm(int id)
        {
            ViewBag.SessionID = new SelectList(sessionrepository.SelectAll(), "SessionID", "Description");
            var employee = termrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult EditTerm(AcademicTerm term)
        {
            ViewBag.SessionID = new SelectList(sessionrepository.SelectAll(), "SessionID", "Description");
            try
            {
                termrepository.Update(term);
                termrepository.Save();
                return RedirectToAction("ViewTerms");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult DeleteTerm(int id)
        {
            var employee = termrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult DeleteTerm(int id, FormCollection collection)
        {
            try
            {
                termrepository.Delete(id);
                termrepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
	}
}