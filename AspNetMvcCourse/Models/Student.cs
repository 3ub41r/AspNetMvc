using System;
using System.Collections.Generic;

namespace AspNetMvcCourse.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string IcNumber { get; set; }
        public string MatricNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public List<Payment> Payments { get; set; }
    }
}