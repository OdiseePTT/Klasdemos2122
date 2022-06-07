namespace Coordinator_example
{
    public class MainViewModel
    {

        public ActionCommand OpenNewScreenCommand { get; set; }
        public ActionCommand ShowMessageBoxCommand { get; set; }

        ICoordinator coordinator = new Coordinator();

        public MainViewModel(ICoordinator coordinator)
        {
            this.coordinator = coordinator;
            LoadCommand();
        }

        private void LoadCommand()
        {
            OpenNewScreenCommand = new ActionCommand(OpenNewScreenCommandAction);
            ShowMessageBoxCommand = new ActionCommand(ShowMessageBoxCommandAction);
        }

        private void ShowMessageBoxCommandAction()
        {
            coordinator.ShowMessageBox("Test");
        }

        private void OpenNewScreenCommandAction()
        {
            coordinator.OpenNewWindow();
        }
    }
}
