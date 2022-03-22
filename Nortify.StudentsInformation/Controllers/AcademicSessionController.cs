using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using DataAccess;

namespace Nortify.StudentsInformation.Controllers
{
    public class AcademicSessionController : Controller
    {
         private IRecordsRepository<AcademicSession> Sessionrepository = null;
         private IRecordsRepository<FiscalYear> Fiscalrepository = null;
        public AcademicSessionController()
        {
            this.Sessionrepository = new AcademicSessionRepo<AcademicSession>();
            this.Fiscalrepository = new FiscalYearRepo<FiscalYear>();
        }

        
        // GET: /AcademicSession/
        public ActionResult ViewSessions()
        {
            var viewall = Sessionrepository.SelectAll().ToList();
            return View(viewall);
        }

        public ActionResult Details(int id)
        {
            var employee = Sessionrepository.SelectByID(id);
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult CreateSession()
        {
            ViewBag.roleid = new SelectList(Sessionrepository.SelectAll(), "roleid", "rolename");
            ViewBag.FiscalYear_ID = new SelectList(Fiscalrepository.SelectAll(), "FiscalYear_ID", "Year");
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult CreateSession(AcademicSession role)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FiscalYear_ID = new SelectList(Fiscalrepository.SelectAll(), "FiscalYear_ID", "Year");
                Sessionrepository.Insert(role);
                Sessionrepository.Save();

                return RedirectToAction("ViewSessions");
            }
            return View(role);
        }

        // GET: Employee/Edit/5
        public ActionResult EditSession(int id)
        {
            ViewBag.FiscalYear_ID = new SelectList(Fiscalrepository.SelectAll(), "FiscalYear_ID", "Year");

            var employee = Sessionrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult EditSession(AcademicSession role)
        {
            ViewBag.FiscalYear_ID = new SelectList(Fiscalrepository.SelectAll(), "FiscalYear_ID", "Year",role.FiscalYear_ID);
            
                Sessionrepository.Update(role);
                Sessionrepository.Save();
               // return RedirectToAction("Index");
           
                
                return View();
           
        }

        // GET: Employee/Delete/5
        public ActionResult DeleteSession(int id)
        {
            var employee = Sessionrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult DeleteSession(int id, FormCollection collection)
        {
            try
            {
                Sessionrepository.Delete(id);
                Sessionrepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
	}
}