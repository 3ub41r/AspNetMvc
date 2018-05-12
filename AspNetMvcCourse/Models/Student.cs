using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetMvcCourse.Models
{
    public class Student
    {
        public int Id { get; set; }

        [DisplayName("IC Number")]
        public string IcNumber { get; set; }

        [DisplayName("Matric Number")]
        public string MatricNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public string Name { get; set; }

        // Virtual properties are lazy loaded
        public virtual ICollection<Payment> Payments { get; set; }
    }
}