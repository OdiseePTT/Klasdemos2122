using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace TodoApp
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        #region fields
        private string listName;
        private Visibility showDetail;
        private TodoList selectedTodoList;
        private List<TodoList> todoLists;
        private List<TodoItem> todoItems;
        private string newListName;
        private TodoItem selectedTodoItem;
        private string newTodoItem;

        private TodoItemDataRepository todoItemDataRepository = new TodoItemDataRepository();
        private TodoListDataRepository todoListDataRepository = new TodoListDataRepository();
        #endregion
        #region properties
        public event PropertyChangedEventHandler PropertyChanged;

        public string ListName
        {
            get => listName;
            set
            {
                listName = value;
                OnPropertyChanged();
            }
        }

        public List<TodoList> TodoLists
        {
            get => todoLists;
            set
            {
                todoLists = value;
                OnPropertyChanged();
            }
        }
        public List<TodoItem> TodoItems
        {
            get => todoItems;
            set
            {
                todoItems = value;
                OnPropertyChanged();
            }
        }

        private void Todoitem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            TodoItem todoItem = (TodoItem)sender;
            todoItem.PropertyChanged -= Todoitem_PropertyChanged;
            todoItemDataRepository.CheckItem(todoItem);

            TodoItems = todoItemDataRepository.GetAllItemsForList(SelectedTodoList.Id);
        }

        public TodoItem SelectedTodoItem
        {
            get => selectedTodoItem;
            set
            {
                selectedTodoItem = value;
            }
        }
        public TodoList SelectedTodoList
        {
            get => selectedTodoList;
            set
            {
                selectedTodoList = value;
                if (value != null)
                {
                    ShowDetail = Visibility.Visible;
                    TodoItems = todoItemDataRepository.GetAllItemsForList(SelectedTodoList.Id);
                    ListName = SelectedTodoList.Name;
                }
                else
                {
                    ShowDetail = Visibility.Collapsed;
                }
                OnPropertyChanged();
            }
        }

        public string NewListName
        {
            get => newListName;
            set
            {
                newListName = value;
                OnPropertyChanged();
            }
        }
        public Visibility ShowDetail
        {
            get => showDetail;
            set
            {
                showDetail = value;
                OnPropertyChanged();
            }
        }

        public string NewTodoItem
        {
            get => newTodoItem;
            set
            {
                newTodoItem = value;
                OnPropertyChanged();
            }
        }

        #endregion
        #region commands
        public ActionCommand AddListCommand { get; set; }
        public ActionCommand AddItemToListCommand { get; set; }
        public ActionCommand CheckItemCommand { get; set; }
        public ActionCommand DeleteItemCommand { get; set; }
        public ActionCommand DeleteListCommand { get; set; }
        public ActionCommand ChangeNameCommand { get; set; }
        #endregion

        public MainViewModel()
        {
            AddListCommand = new ActionCommand(AddListCommandAction);
            AddItemToListCommand = new ActionCommand(AddItemToListCommandAction);
            CheckItemCommand = new ActionCommand(CheckItemCommandAction);
            DeleteItemCommand = new ActionCommand(DeleteItemCommandAction);
            DeleteListCommand = new ActionCommand(DeleteListCommandAction);
            ChangeNameCommand = new ActionCommand(ChangeNameCommandAction);
            SelectedTodoList = null;
            TodoLists = todoListDataRepository.GetAllLists();
        }

        private void ChangeNameCommandAction()
        {
            todoListDataRepository.ChangeNameForList(SelectedTodoList, ListName);
            int selectedIndex = TodoLists.IndexOf(SelectedTodoList);
            TodoLists = todoListDataRepository.GetAllLists();
            SelectedTodoList = TodoLists[selectedIndex];
        }

        private void DeleteListCommandAction()
        {
            if (SelectedTodoList != null)
            {
                todoListDataRepository.RemoveList(SelectedTodoList);
                TodoLists = todoListDataRepository.GetAllLists();
            }
        }

        private void DeleteItemCommandAction()
        {
            if (SelectedTodoItem != null)
            {
                todoItemDataRepository.RemoveItem(SelectedTodoItem);
                TodoItems = todoItemDataRepository.GetAllItemsForList(SelectedTodoList.Id);
            }
        }

        private void CheckItemCommandAction()
        {
            if (SelectedTodoItem != null)
            {
                todoItemDataRepository.CheckItem(SelectedTodoItem);
                TodoItems = todoItemDataRepository.GetAllItemsForList(SelectedTodoList.Id);
            }
        }

        private void AddItemToListCommandAction()
        {
            todoItemDataRepository.CreateItem(SelectedTodoList, NewTodoItem);
            TodoItems = todoItemDataRepository.GetAllItemsForList(SelectedTodoList.Id);
        }

        private void AddListCommandAction()
        {
            todoListDataRepository.CreateList(NewListName);
            TodoLists = todoListDataRepository.GetAllLists();
        }

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
