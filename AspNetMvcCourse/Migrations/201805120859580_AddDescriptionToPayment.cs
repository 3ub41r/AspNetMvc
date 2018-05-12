namespace AspNetMvcCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "Description");
        }
    }
}
