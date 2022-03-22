using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AssignDomain;
using System.Data;
using System.Data.SqlClient;


namespace Nortify.StudentsInformation.Controllers
{
    public class AssignClassController : Controller
    {

        private StudentsinfoEntities db = new StudentsinfoEntities();
        
        public ActionResult AssignClass()
        {

            List<SelectListItem> cname = new List<SelectListItem>();
            StudentsinfoEntities asm = new StudentsinfoEntities();


            ViewBag.classid = new SelectList(db.SchoolClasses, "code", "Name");
            var rc = new StudentsinfoEntities();
            var res = (from p in rc.PreAdmissionLists
                       join f in rc.StudentScores
                       on p.ApplicantNo equals f.ApplicantID

                       select new GeneralScore
                       {


                          
                           OtherNames = p.OtherNames,
                           FirstName = p.Firstname,
                           LastName = p.Lastname,

                           DateOfBirth = p.DateOfBirth,
                           Gender = p.Gender,
                           
                           Weight = p.Weight,
                           ExamNo = p.ExamNo,
                           NationalityID = p.NationalityID,
                           StateOfOriginID = p.StateOfOriginID,
                           HomeTown = p.HomeTown,
                          
                          

                       });

            return View(res.ToList());
        }

        [HttpPost]
        public ActionResult AssignClass(List<Student> cl)
        {
            StudentsinfoEntities co = new StudentsinfoEntities();
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var myper in cl)
                    {
                        co.Students.Add(myper);

                    }

                    co.SaveChanges();
                    return RedirectToAction("diplayscore");

                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return View();

        }

        public ActionResult ClassCapacity()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult ClassCapacity(FormCollection fc)
        {
            Session["capacity"] = fc["classcapacity"];
            return RedirectToAction("AssignByScore");
            
        }

        public ActionResult AssignByScore(FormCollection f, int page = 1)
        {
            var rc = new StudentsinfoEntities();
            //int Size;
            int Size = (from r in rc.SchoolClasses
                        select r.Capacity).SingleOrDefault();


            ViewBag.classid = new SelectList(db.SchoolClasses, "code", "Name");
                
                var res = (from p in rc.PreAdmissionLists
                           join c in rc.StudentScores
                           on p.ApplicantNo equals c.ApplicantID orderby c.ExamScore descending

                           select new GeneralScore
                           {
                               OtherNames = p.OtherNames,
                               FirstName = p.Firstname,
                               LastName = p.Lastname,

                               DateOfBirth = p.DateOfBirth,
                               Gender = p.Gender,

                               Weight = p.Weight,
                               ExamNo = p.ExamNo,
                               NationalityID = p.NationalityID,
                               StateOfOriginID = p.StateOfOriginID,
                               HomeTown = p.HomeTown,
                             ExamScore = c.ExamScore
                           }).ToList();

                var pro = res.Skip((page - 1) * Size).Take(Size).ToList();
                //var pro = res.ToPagedList(page ?? 1, Size);
                ViewBag.CurrentPage = page;
                ViewBag.PageSize = Size;
                ViewBag.TotalPages = Math.Ceiling((double)res.Count() / Size);


                return View(pro);
            
        }

        [HttpPost]
        public ActionResult AssignByScore(FormCollection f, List<Student> cl, int page=1)
        {
            var co = new StudentsinfoEntities();
            //int Size;
            int Size = (from r in co.SchoolClasses
                        select r.Capacity).SingleOrDefault();


            ViewBag.classid = new SelectList(db.SchoolClasses, "code", "Name");
           
            if (ModelState.IsValid)
            {
                foreach (var myper in cl)
                {
                    co.Students.Add(myper);

                }

                co.SaveChanges();
                //return RedirectToAction("auto");

            }
            var res = (from p in co.PreAdmissionLists
                       join c in co.StudentScores
                       on p.ApplicantNo equals c.ApplicantID
                       orderby c.ExamScore descending

                       select new GeneralScore
                       {
                           OtherNames = p.OtherNames,
                           FirstName = p.Firstname,
                           LastName = p.Lastname,

                           DateOfBirth = p.DateOfBirth,
                           Gender = p.Gender,

                           Weight = p.Weight,
                           ExamNo = p.ExamNo,
                           NationalityID = p.NationalityID,
                           StateOfOriginID = p.StateOfOriginID,
                           HomeTown = p.HomeTown,
                           ExamScore = c.ExamScore
                       }).ToList();

            var pro = res.Skip((page - 1) * Size).Take(Size).ToList();
            //var pro = res.ToPagedList(page ?? 1, Size);
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = Size;
            ViewBag.TotalPages = Math.Ceiling((double)res.Count() / Size);


            return View(pro);
        }

        public ActionResult AssignByRandom(int page = 1)
        {
            var rc = new StudentsinfoEntities();
            //int Size;
            int PageSize = (from r in rc.SchoolClasses
                        select r.Capacity).SingleOrDefault();
            ViewBag.classid = new SelectList(db.SchoolClasses, "code", "Name");

            var res = (from p in rc.PreAdmissionLists
                       join c in rc.StudentScores
                       on p.ApplicantNo equals c.ApplicantID
                       orderby Guid.NewGuid()
                       select new GeneralScore
                       {
                           OtherNames = p.OtherNames,
                           FirstName = p.Firstname,
                           LastName = p.Lastname,

                           DateOfBirth = p.DateOfBirth,
                           Gender = p.Gender,

                           Weight = p.Weight,
                           ExamNo = p.ExamNo,
                           NationalityID = p.NationalityID,
                           StateOfOriginID = p.StateOfOriginID,
                           HomeTown = p.HomeTown,
                           ExamScore = c.ExamScore
                       }).ToList();
            var pro = res.Skip((page - 1) * PageSize).Take(PageSize).ToList();
            // var pro = res.ToPagedList(page ?? 1, Size);
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = PageSize;
            ViewBag.TotalPages = Math.Ceiling((double)res.Count() / PageSize);


            return View(pro);
        }

        [HttpPost]
        public ActionResult AssignByRandom(List<Student> cl, int page = 1)
        {
            var co = new StudentsinfoEntities();
            //int Size;
            int Size = (from r in co.SchoolClasses
                        select r.Capacity).SingleOrDefault();


            ViewBag.classid = new SelectList(db.SchoolClasses, "code", "Name");

            if (ModelState.IsValid)
            {
                foreach (var myper in cl)
                {
                    co.Students.Add(myper);

                }

                co.SaveChanges();
                //return RedirectToAction("auto");

            }
            var res = (from p in co.PreAdmissionLists
                       join c in co.StudentScores
                       on p.ApplicantNo equals c.ApplicantID
                       orderby c.ExamScore descending

                       select new GeneralScore
                       {
                           OtherNames = p.OtherNames,
                           FirstName = p.Firstname,
                           LastName = p.Lastname,

                           DateOfBirth = p.DateOfBirth,
                           Gender = p.Gender,

                           Weight = p.Weight,
                           ExamNo = p.ExamNo,
                           NationalityID = p.NationalityID,
                           StateOfOriginID = p.StateOfOriginID,
                           HomeTown = p.HomeTown,
                           ExamScore = c.ExamScore
                       }).ToList();

            var pro = res.Skip((page - 1) * Size).Take(Size).ToList();
            //var pro = res.ToPagedList(page ?? 1, Size);
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = Size;
            ViewBag.TotalPages = Math.Ceiling((double)res.Count() / Size);


            return View(pro);
        }

        
        
	}
}