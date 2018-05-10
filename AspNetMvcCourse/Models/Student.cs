using System;

namespace AspNetMvcCourse.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string IcNumber { get; set; }
        public string MatricNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}