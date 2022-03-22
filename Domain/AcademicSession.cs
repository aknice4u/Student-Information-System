using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AcademicSession
    {
        [Key]
        public int SessionID { get; set; }
        public string Code { get; set; }
        [Required]
        [Display(Name="Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Status")]
        public int status { get; set; }
        [Required]
        [Display(Name = "Fiscal Year")]
        public int FiscalYear_ID { get; set; }
        [ForeignKey("FiscalYear_ID")]
        public virtual FiscalYear FYear { get; set; }
       
    }
}
