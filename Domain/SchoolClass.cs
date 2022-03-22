using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SchoolClass
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Class Capacity")]
        public int Capacity { get; set; }
        [Display(Name = "Class Arm")]
        public string Arms { get; set; }
        [Required]
        [Display(Name = "Status")]
        public int Status { get; set; }
    }
}
