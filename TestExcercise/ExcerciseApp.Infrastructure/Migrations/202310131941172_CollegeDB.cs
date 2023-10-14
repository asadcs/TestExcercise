namespace ExcerciseApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollegeDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TeacherId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        RegistrationNumber = c.String(),
                        Subject_SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId)
                .Index(t => t.Subject_SubjectId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Subjects", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Students", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Students");
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "Subject_SubjectId" });
            DropIndex("dbo.Subjects", new[] { "CourseId" });
            DropIndex("dbo.Subjects", new[] { "TeacherId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Grades");
            DropTable("dbo.Students");
            DropTable("dbo.Subjects");
            DropTable("dbo.Courses");
        }
    }
}
