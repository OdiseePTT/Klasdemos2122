using System.Windows;

namespace Coordinator_example
{

    public interface ICoordinator
    {
        void OpenNewWindow();
        void ShowMessageBox(string message);
    }

    public class Coordinator : ICoordinator
    {
        public void OpenNewWindow()
        {
            newScreen newScreen = new newScreen();
            NewScreenViewModel newScreenViewModel = new NewScreenViewModel(this);
            newScreen.DataContext = newScreenViewModel;
            newScreenViewModel.closeAction = newScreen.Close;
            newScreen.ShowDialog();
        }


        public void OpenMainScreen()
        {
            MainWindow mainWindow = new MainWindow();
            MainViewModel mainViewModel = new MainViewModel(this);
            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();
        }
        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
    }
}