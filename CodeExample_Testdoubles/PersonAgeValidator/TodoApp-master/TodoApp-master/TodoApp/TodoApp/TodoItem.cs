using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApp
{
    internal class TodoItem : INotifyPropertyChanged
    {
        private bool isChecked;


        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }

        public TodoList TodoList { get; set; }

        public TodoItem()
        {

        }

        public TodoItem(string content, bool isChecked, TodoList todoList)
        {
            Content = content;
            IsChecked = isChecked;
            TodoList = todoList;
        }
    }
}