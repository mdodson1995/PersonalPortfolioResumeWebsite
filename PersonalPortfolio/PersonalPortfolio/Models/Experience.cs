using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace PersonalPortfolio.Models
{
    public class Experience
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Job/Internship")]
        public string ExperienceName { get; set; }

        [Display(Name = "City")]
        public string CityHeld { get; set; }

        [Display(Name = "State")]
        public string StateHeld { get; set; }

        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public string ZipHeld { get; set; }

        [Display(Name = "Duration of Job")]
        public string MonthsHeld { get; set; }

        [Display(Name = "Description of Job")]
        public string descriptionOfJob { get; set; }
    }
}