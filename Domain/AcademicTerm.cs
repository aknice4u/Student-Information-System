using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AcademicTerm
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Session")]
        public int SessionID { get; set; }
        [ForeignKey("SessionID")]
        public virtual AcademicSession academicsession { get; set; }

         [Display(Name = "Term")]
        public int TermID { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Tick if Current Term")]
        public bool IsCurrent { get; set; }
    }
}
