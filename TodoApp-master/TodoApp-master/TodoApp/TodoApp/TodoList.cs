using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoApp
{
    internal class TodoList
    {
        public TodoList(string name)
        {
            Name = name;
        }
        public TodoList()
        {

        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<TodoItem> TodoItems { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}