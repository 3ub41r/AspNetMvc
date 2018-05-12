namespace AspNetMvcCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "Student_Id", "dbo.Students");
            DropIndex("dbo.Payments", new[] { "Student_Id" });
            RenameColumn(table: "dbo.Payments", name: "Student_Id", newName: "StudentId");
            AlterColumn("dbo.Payments", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "StudentId");
            AddForeignKey("dbo.Payments", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "StudentId", "dbo.Students");
            DropIndex("dbo.Payments", new[] { "StudentId" });
            AlterColumn("dbo.Payments", "StudentId", c => c.Int());
            RenameColumn(table: "dbo.Payments", name: "StudentId", newName: "Student_Id");
            CreateIndex("dbo.Payments", "Student_Id");
            AddForeignKey("dbo.Payments", "Student_Id", "dbo.Students", "Id");
        }
    }
}
