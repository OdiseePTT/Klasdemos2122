using System.Windows;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Coordinator coordinator = new Coordinator();
            coordinator.OpenLogin();
        }
    }
}
