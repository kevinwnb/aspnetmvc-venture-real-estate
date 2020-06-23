using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MockUp.Models
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }
        [Required]
        [Display(Name = "Social Insurance Number")]
        public string SIN { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "First Name cannot be longer than 20 characters")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }

        [Required]
        [Display(Name = "Logged In User Name")]
        [StringLength(20, ErrorMessage = "LoggedInUserName cannot be longer than 20 characters")]
        public string LoggedInUserName { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        [StringLength(30, ErrorMessage = "Street Address cannot be longer than 30 characters")]
        public string StreetAddress { get; set; }

        [Required]
        [Display(Name = "Municipality")]
        [StringLength(30, ErrorMessage = "Municipality cannot be longer than 30 characters")]
        public string Municipality { get; set; }

        [Required]
        [Display(Name = "Province")]
        [StringLength(30, ErrorMessage = "Province cannot be longer than 30 characters")]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [StringLength(10, ErrorMessage = "Postal Code cannot be longer than 10 characters")]
        [RegularExpression(@"^[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]{1}\d{1}[A-Za-z]{1} *\d{1}[A-Za-z]{1}\d{1}$", ErrorMessage = "Please enter a valid Postal Code")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Home Phone Number")]
        [StringLength(10, ErrorMessage = "Home Phone Number cannot be longer than 10 characters")]
        [DataType(DataType.PhoneNumber)]
        public string HomePhoneNumber { get; set; }

        [Required]
        [Display(Name = "Cell Phone Number")]
        [StringLength(10, ErrorMessage = "Cell Phone Number cannot be longer than 10 characters")]
        [DataType(DataType.PhoneNumber)]
        public string CellPhoneNumber { get; set; }

        [Required]
        [Display(Name = "Office Email")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Email must be between 5 and 150 characters")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email address")]
        [DataType(DataType.EmailAddress)]
        public string OfficeEmail { get; set; }

        [Required]
        [Display(Name = "Office Phone Number")]
        [StringLength(10, ErrorMessage = "Office Phone Number cannot be longer than 10 characters")]
        [DataType(DataType.PhoneNumber)]
        public string OfficePhoneNumber { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public ICollection<Listing> Listings { get; set; }
    }
}