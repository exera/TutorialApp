using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad zorunludur.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad zorunludur.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Yaş zorunludur.")]
        [Range(20, double.PositiveInfinity,ErrorMessage ="Yaş en az 20 olmalıdır.")]
        public int Age { get; set; }
        public double? GPA { get; set; }
    }
}