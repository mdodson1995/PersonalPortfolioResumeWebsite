using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace PersonalPortfolio.Models
{
    public class Education
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "School Name")]
        public string SchoolName { get; set; }

        [Display(Name = "City")]
        public string SchoolCity { get; set; }

        [Display(Name = "State")]
        public string SchoolState { get; set; }

        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode, ErrorMessage = "Must be a Valid Zip Code.")]
        public string SchoolZip { get; set; }
    }
}