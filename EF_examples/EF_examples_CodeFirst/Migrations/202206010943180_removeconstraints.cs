namespace EF_examples_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeconstraints : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Scores", "Student_Id", "dbo.Students");
            DropIndex("dbo.Scores", new[] { "Student_Id" });
            DropIndex("dbo.Scores", new[] { "Student_Id1" });
            DropColumn("dbo.Scores", "Student_Id");
            RenameColumn(table: "dbo.Scores", name: "Student_Id1", newName: "Student_Id");
            AlterColumn("dbo.Scores", "Student_Id", c => c.Int());
            CreateIndex("dbo.Scores", "Student_Id");
            AddForeignKey("dbo.Scores", "Student_Id", "dbo.Students", "Id");
            DropColumn("dbo.Students", "Lastname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Lastname", c => c.String());
            DropForeignKey("dbo.Scores", "Student_Id", "dbo.Students");
            DropIndex("dbo.Scores", new[] { "Student_Id" });
            AlterColumn("dbo.Scores", "Student_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Scores", name: "Student_Id", newName: "Student_Id1");
            AddColumn("dbo.Scores", "Student_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Scores", "Student_Id1");
            CreateIndex("dbo.Scores", "Student_Id");
            AddForeignKey("dbo.Scores", "Student_Id", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
