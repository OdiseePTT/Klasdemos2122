using System.Windows;

namespace Coordinator_example
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            Coordinator c = new Coordinator();
            c.OpenNewWindow();
        }
    }
}
