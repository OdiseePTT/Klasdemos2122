using System.Data.Entity;

namespace TodoApp
{
    internal class TodoDbContext : DbContext
    {
        public TodoDbContext() : base("TodoApp")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoList>()
                .HasMany(list => list.TodoItems)
                .WithRequired(x => x.TodoList)
                .WillCascadeOnDelete();
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
    }
}
