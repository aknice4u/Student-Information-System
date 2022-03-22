using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using DataAccess;

namespace Nortify.StudentsInformation.Controllers
{
    public class SchoolClassController : Controller
    {
        private IRecordsRepository<SchoolClass> classrepository = null;
        public SchoolClassController()
        {
            this.classrepository = new SchoolClassRepo<SchoolClass>();
        }
        public ActionResult ViewClass()
        {
            var viewall = classrepository.SelectAll().ToList();
            return View(viewall);
        }

        public ActionResult Details(int id)
        {
            var employee = classrepository.SelectByID(id);
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult CreateClass()
        {
          
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult CreateClass(SchoolClass clas)
        {
            if (ModelState.IsValid)
            {
                classrepository.Insert(clas);
                classrepository.Save();

                return RedirectToAction("ViewClass");
            }
            return View(clas);
        }

        // GET: Employee/Edit/5
        public ActionResult EditClass(int id)
        {
            var employee = classrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult EditClass(SchoolClass clas)
        {
            try
            {
                classrepository.Update(clas);
                classrepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult DeleteClass(int id)
        {
            var employee = classrepository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult DeleteClass(int id, FormCollection collection)
        {
            try
            {
                classrepository.Delete(id);
                classrepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
	}
}