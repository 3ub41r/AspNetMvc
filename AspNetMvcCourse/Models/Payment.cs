using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcCourse.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}