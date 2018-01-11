using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PersonalPortfolio.Models
{
    public class PersonalInfo
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Primary Phone No.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Must be a Valid Phone Number.")]
        public string PrimaryPhone { get; set; }

        [Display(Name = "Primary Email.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must be a Valid Email Address.")]
        public string PrimaryEmail { get; set; }
    }
}