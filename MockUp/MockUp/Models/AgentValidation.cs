using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VentureRealEstateMockUp.Models
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        public DateGreaterThanAttribute(DateTime birthDate, params string[] propertyNames)
        {
            
        }
    }
}