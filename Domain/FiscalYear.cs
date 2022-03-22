using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FiscalYear
    {
        [Key]
        public int FiscalYear_ID { get; set; }
        [Required]
        [Display(Name = "Fiscal Year")]
        public string Year { get; set; }
    }
}
