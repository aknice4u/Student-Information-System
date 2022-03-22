using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Guardian
    {
        [Key]
        public int ID { get; set; }       
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LaststName { get; set; }
        [Required]
        [Display(Name = "Other Names")]
        public string OtherNames { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Religion")]
        public string Religion { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Marital Status")]
        public string MaritalStatusID { get; set; }
        [Required]
        [Display(Name = "Wedding Aniversary")]
        public DateTime WeddingAniversary { get; set; }
        [Required]
        [Display(Name = "Home Address 1")]
        public string HomeAddressLine1 { get; set; }
        [Required]
        [Display(Name = "Home Address 2")]
        public string HomeAddressLine2 { get; set; }
          [Display(Name = "Country of Residence")]
        public int CountryOfResidenceID { get; set; }
          [Display(Name = "State Of Residence")]
        public int StateOfResidenceID { get; set; }
          [Display(Name = "LGA Of Residence")]
        public int LGAOfResidenceID { get; set; }
          [Display(Name = "City Of Residence")]
        public string cityOfResidence { get; set; }
          [Display(Name = "Occupation")]
        public string Occupation { get; set; }
          [Display(Name = "Education")]
        public string Eduction { get; set; }
        [Required]
        [Display(Name = "Relationship")]
        public string Relationship { get; set; }
          [Display(Name = "Office Address 1")]
        public string OfficeAddressLine1 { get; set; }
          [Display(Name = "Office Address 2")]
        public string OfficeAddressLine2 { get; set; }
          [Display(Name = "Office City")]
        public string OfficeCity { get; set; }
        [Required]
        [Display(Name = "Office LGA")]
        public int OfficeLGAID { get; set; }
        [Required]
        [Display(Name = "Office State")]
        public int OfficeStateID { get; set; }
        [Required]
        [Display(Name = "Office Country")]
        public string OfficeCountryID { get; set; }
        [Required]
        [Display(Name = "User Identity")]
        public int UserID { get; set; }
          [Display(Name = "Office Phone Number 1")]
        public string OfficePhone1 { get; set; }
          [Display(Name = "Office Phone Number 2")]
        public string OfficePhone2 { get; set; }


        
    }
}
