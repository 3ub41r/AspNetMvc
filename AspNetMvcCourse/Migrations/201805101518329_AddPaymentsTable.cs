namespace AspNetMvcCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Student_Id", "dbo.Students");
            DropIndex("dbo.Payments", new[] { "Student_Id" });
            DropTable("dbo.Payments");
        }
    }
}
