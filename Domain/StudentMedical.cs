using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StudentMedical
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Student ID")]
        public int StudentNo { get; set; }
        [ForeignKey("StudentNo")]
        public virtual Students student { get; set; }
        [Required]
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
        [Required]
        [Display(Name = "Genotype")]
        public String Genotype { get; set; }
        [Required]
        [Display(Name = "Allergies")]
        public string Allergies { get; set; }
        [Required]
        [Display(Name = "Height")]
        public decimal Height { get; set; }
        [Required]
        [Display(Name = "Weight")]
        public decimal Weight { get; set; }
        [Required]
        [Display(Name = "Immunization Card ID")]
        public int ImunizationCardID { get; set; }
        [Required]
        [Display(Name = "Birth Certificate ID")]
        public int BirthCertificateID { get; set; }

    }
}
