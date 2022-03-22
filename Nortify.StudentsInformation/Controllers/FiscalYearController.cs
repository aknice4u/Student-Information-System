using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using DataAccess;

namespace Nortify.StudentsInformation.Controllers
{
    public class FiscalYearController : Controller
    {
        private IRecordsRepository<FiscalYear> Fiscalrepository = null;
        public FiscalYearController()
        {
            this.Fiscalrepository = new FiscalYearRepo<FiscalYear>();
        }

        public ActionResult ViewFiscalYear()
        {
            var viewall = Fiscalrepository.SelectAll().ToList();
            return View(viewall);
        }

        public ActionResult Details(int id)
        {
            var employee = Fiscalrepository.SelectByID(id);
            return View(employee);
           
        }

        // GET: Employee/Create
        public ActionResult CreateFiscalYear()
        {
             return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult CreateFiscalYear(FiscalYear year)
        {
            if (ModelState.IsValid)
            {
                Fiscalrepository.Insert(year);
                Fiscalrepository.Save();

                return RedirectToAction("ViewFiscalYear");
            }
            ViewBag.error = "cannot insert";
            return View();
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = Fiscalrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(FiscalYear year)
        {
            try
            {
                Fiscalrepository.Update(year);
                Fiscalrepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = Fiscalrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Fiscalrepository.Delete(id);
                Fiscalrepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
	}
}