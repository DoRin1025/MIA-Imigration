using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MIA_Immigration.Models
{
    public class Request
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Full Name")]
        public string Full_Name { get; set; }

        [Required]
        [DisplayName("Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Marital Status")]
        public string Marital_Status { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public string Birthday { get; set; }

        //[Required]
        //[DisplayName("Current Country of Residence")]
        //public string Country_of_Residence { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [Required]
        [DisplayName("Number of Children and Ages")]
        public string Children_and_Ages { get; set; }

        [Required]
        [DisplayName("Current Occupation/ Position Title")]
        public string Profesional1 { get; set; }

        [Required]
        [DisplayName("French Proficiency")]
        public string Profesional3 { get; set; }

        [Required]
        [DisplayName("How long have you been in this occupation and how many hours per week do you work?")]
        public string Profesional4 { get; set; }

        [Required]
        [DisplayName("English Proficiency")]
        public string Profesional5 { get; set; }

        [Required]
        [DisplayName("Do you have a job offer from a Canadian employer?")]
        public string Profesional6 { get; set; }

        [Required]
        [DisplayName("What would you like to do in Canada?")]
        public string ToDo1 { get; set; }

        [Required]
        [DisplayName("Have you ever visited Canada in the past? If yes, which cities and when?")]
        public string ToDo2 { get; set; }

        [Required]
        [DisplayName("Do you have any family in Canada (Citizens or Permanent Residents)? If yes, where do they live and what is your relationship with them?")]
        public string ToDo3 { get; set; }

        [Required]
        [DisplayName("How did you hear about us?")]
        public string ToDo4 { get; set; }

        //[Required]
        //[DisplayName("Which province do you plan to settle in?")]
        //public string ToDo5 { get; set; }

        //[Required]
        //[DisplayName("What is the approximate amount of money you have available for your objective of immigrating, studying or travelling to Canada?")]
        //public string ToDo6 { get; set; }

        [Required]
        [DisplayName("Do you have any existing medical condition or criminal history? If yes, please describe.")]
        public string ToDo7 { get; set; }


        [Required]
        [DisplayName("Upload your CV")]
        [NotMapped]
        
        public HttpPostedFileBase File { get; set; }

        [NotMapped]
        public String ImageUrl
        {
            get { return ID.ToString() + ".pdf"; }

        }


        public int CountryID { get; set; }

        public virtual Country Countries { get; set; }

        [Required]
        [DisplayName("Current Country of Residence")]
        public int CountryRID { get; set; }
        
        public virtual CountryResidence CountryResidence { get; set; }

        [Required]
        [DisplayName("Which province do you plan to settle in?")]
        public int ProvinceID { get; set; }

        public virtual Province Provinces { get; set; }

        [Required]
        [DisplayName("What is the approximate amount of money you have available for your objective of immigrating, studying or travelling to Canada?")]
        public int MoneyID { get; set; }

        public virtual Money Moneys { get; set; }


        public int EducationID { get; set; }

        public virtual Education Educations { get; set; }

    }
}