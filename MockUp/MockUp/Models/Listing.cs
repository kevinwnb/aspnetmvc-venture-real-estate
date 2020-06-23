using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MockUp.Models
{
    public class Listing
    {
        [Key]
        public int ListingId { get; set; }

        [NotMapped]
        public string ImgPath { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        
        [Required]
        public string Municipality { get; set; }
        
        [Required]
        public string Province { get; set; }

        [RegularExpression("^[A-Za-z]\\d[A-Za-z][ -]?\\d[A-Za-z]\\d$", ErrorMessage = "Postal Code is not in the correct format")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        
        [Required]
        [Display(Name = "Square Feet")]
        public int SquareFeet { get; set; }

        [Required]
        public int Beds { get; set; }
        
        [Required]
        public int Baths { get; set; }

        [Display(Name = "Area of City")]
        [Required]
        public string CityArea { get; set; }

        [Required]
        public string Summary { get; set; }

        [Display(Name = "Type of Heating")]
        [Required]
        public string HeatingType { get; set; }

        [Display(Name = "Has Fireplace")]
        public bool HasFireplace { get; set; }

        [Display(Name = "Has Garage")]
        public bool HasGarage { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Agent")]
        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; }
        
        [Display(Name = "Contract Signed")]
        public bool ContractSigned { get; set; }


        public ICollection<Image> Images { get; set; }
    }
}