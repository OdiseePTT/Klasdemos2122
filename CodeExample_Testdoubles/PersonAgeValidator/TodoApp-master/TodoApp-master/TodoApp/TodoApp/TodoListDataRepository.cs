using System.Collections.Generic;
using System.Linq;

namespace TodoApp
{
    internal class TodoListDataRepository
    {
        TodoDbContext db = new TodoDbContext();

        internal void CreateList(string listName)
        {
            TodoList list = new TodoList(listName);
            db.TodoLists.Add(list);
            db.SaveChanges();
        }

        internal List<TodoList> GetAllLists()
        {
            return db.TodoLists.ToList();
        }

        internal void RemoveList(TodoList selectedTodoList)
        {
            TodoList list = db.TodoLists.First(t => t.Id == selectedTodoList.Id);
            db.TodoLists.Remove(list);
            db.SaveChanges();
        }

        internal void ChangeNameForList(TodoList selectedTodoList, string listName)
        {
            TodoList list = db.TodoLists.First(t => t.Id == selectedTodoList.Id);
            list.Name = listName;
            db.SaveChanges();
        }
    }
}
