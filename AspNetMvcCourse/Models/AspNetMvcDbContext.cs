using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetMvcCourse.Models
{
    public class AspNetMvcDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}