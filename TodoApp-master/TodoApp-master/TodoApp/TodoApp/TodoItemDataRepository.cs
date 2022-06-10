using System.Collections.Generic;
using System.Linq;

namespace TodoApp
{
    internal class TodoItemDataRepository
    {
        TodoDbContext db = new TodoDbContext();

        internal void CreateItem(TodoList selectedTodoList, string newTodoItem)
        {
            TodoList todoList = db.TodoLists.First(t => t.Id == selectedTodoList.Id);
            TodoItem item = new TodoItem(newTodoItem, false, todoList);

            db.TodoItems.Add(item);
            db.SaveChanges();
        }

        internal List<TodoItem> GetAllItemsForList(int id)
        {
            return db.TodoItems.Where(t => t.TodoList.Id == id).ToList();
        }

        internal void CheckItem(TodoItem selectedTodoItem)
        {
            TodoItem todoItem = db.TodoItems.FirstOrDefault(t => t.Id == selectedTodoItem.Id);
                todoItem.IsChecked = true;
                db.SaveChanges();
        }

        internal void RemoveItem(TodoItem selectedTodoItem)
        {
            TodoItem todoItem = db.TodoItems.FirstOrDefault(t => t.Id == selectedTodoItem.Id);
            db.TodoItems.Remove(todoItem);
            db.SaveChanges();
        }
    }
}
