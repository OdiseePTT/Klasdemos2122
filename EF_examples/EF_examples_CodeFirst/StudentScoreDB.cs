using EF_examples_CodeFirst.Migrations;
using System.Data.Entity;

namespace EF_examples_CodeFirst
{
    internal class StudentScoreDB : DbContext
    {
        public StudentScoreDB() : base("studentScoreDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentScoreDB, Configuration>());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

    }
}
