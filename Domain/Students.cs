using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Students
    {
       [Key]
        public int StudentNo { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
       
        [Display(Name = "Other Name")]
        public string OtherNames { get; set; }
        
        [Display(Name = "Gender")]
        public string Gender { get; set; }
       
        [Display(Name = "Photo ID")]
        public string PhotoID { get; set; }
        
        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }
        
        [Display(Name = "Birth Place")]
        public string BirthPace { get; set; }
      
        [Display(Name = "Religion")]
        public string Religion { get; set; }
        
        [Display(Name = "Nationality")]
        public string NationalityID { get; set; }
        
        [Display(Name = "State Of Origin")]
        public string StateOfOriginID { get; set; }
        
        [Display(Name = "LGA Of Origin")]
        public string LGAOfOriginID { get; set; }
        
        [Display(Name = "Home Town")]
        public string HomeTown{ get; set; }
       
        [Display(Name = "Entry Mode")]
        public string EntryModeID { get; set; }
      
        [Display(Name = "Admission Number")]
        public string AdmissionNo { get; set; }
        
        [Display(Name = "Date Admitted")]
        public String dateAdmitted{ get; set; }
       
        [Display(Name = "Class Admitted")]
        public string ClassAdmittedID { get; set; }
        
              
       [Display(Name= "Current Class")]
        public string CurrentClassID { get; set; }

       [Display(Name = "Current Term")]
        public string CurrentTermID { get; set; }
       
       [Display(Name = "Student Category")]
        public string StudentCategoryID { get; set; }
       
        [Display(Name = "Address Line 1")]
        public string AddressLine1{ get; set; }
       
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }
        
        [Display(Name = "Country of Residence")]
        public string CountryOfResidenceID { get; set; }
       
        [Display(Name = "State Of Residence")]
        public string StateOfResidenceID { get; set; }
        
        [Display(Name = "LGA Of Residence")]
        public string LGAOfResidenceID { get; set; }
       [Display(Name = "City Of Residence")]
        public string CityOfResidence { get; set; }
        
        [Display(Name = "Guardian")]
        public string GuardianID { get; set; }
        
        
       [Display(Name = "Status")]
        public string Status { get; set; }
       
       [Display(Name = "ID")]
        public string ID { set; get; }
       
    }
}
