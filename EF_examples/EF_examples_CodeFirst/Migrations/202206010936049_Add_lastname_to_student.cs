namespace EF_examples_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_lastname_to_student : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Scores", "Student_Id", "dbo.Students");
            DropIndex("dbo.Scores", new[] { "Student_Id" });
            AddColumn("dbo.Students", "Lastname", c => c.String());
            AddColumn("dbo.Scores", "Student_Id1", c => c.Int());
            AlterColumn("dbo.Scores", "Student_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Scores", "Student_Id");
            CreateIndex("dbo.Scores", "Student_Id1");
            AddForeignKey("dbo.Scores", "Student_Id", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Scores", "Student_Id1", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "Student_Id1", "dbo.Students");
            DropForeignKey("dbo.Scores", "Student_Id", "dbo.Students");
            DropIndex("dbo.Scores", new[] { "Student_Id1" });
            DropIndex("dbo.Scores", new[] { "Student_Id" });
            AlterColumn("dbo.Scores", "Student_Id", c => c.Int());
            DropColumn("dbo.Scores", "Student_Id1");
            DropColumn("dbo.Students", "Lastname");
            CreateIndex("dbo.Scores", "Student_Id");
            AddForeignKey("dbo.Scores", "Student_Id", "dbo.Students", "Id");
        }
    }
}
