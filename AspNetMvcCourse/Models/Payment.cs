using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetMvcCourse.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [DisplayName("Payment Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        public string Description { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}