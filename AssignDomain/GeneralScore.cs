using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AssignDomain
{
   public class GeneralScore
    {
        public string ApplicantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherNames { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int Height { get; set; }
        public string Weight { get; set; }
        public string ExamNo { get; set; }
        public string NationalityID { get; set; }
        public string StateOfOriginID { get; set; }
        public string HomeTown { get; set; }
        public string ClassAdmittedID { get; set; }
        public string ExamBatchNo { get; set; }
        public string photo { get; set; }
        public string ExamScore { get; set; }
        public IList<SelectListItem> classlist { get; set; }
    }
}
