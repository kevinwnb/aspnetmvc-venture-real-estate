using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MockUp.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool Approved { get; set; }

        public int? ListingId { get; set; }
        public virtual Listing Listing { get; set; }
    }
}