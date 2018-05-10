namespace AspNetMvcCourse.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNetMvcCourse.Models.AspNetMvcDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AspNetMvcCourse.Models.AspNetMvcDbContext";
        }

        protected override void Seed(AspNetMvcCourse.Models.AspNetMvcDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
