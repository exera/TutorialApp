namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExamModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentExams",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Exam_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Exam_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.Exam_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Exam_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentExams", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.StudentExams", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentExams", new[] { "Exam_Id" });
            DropIndex("dbo.StudentExams", new[] { "Student_Id" });
            DropTable("dbo.StudentExams");
            DropTable("dbo.Exams");
        }
    }
}
