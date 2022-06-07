using System;

namespace Coordinator_example
{
    internal class NewScreenViewModel
    {
        private ICoordinator coordinator;

        public ActionCommand CloseCommand { get; set; }

        public Action closeAction { get; set; }

        public NewScreenViewModel(ICoordinator coordinator)
        {
            this.coordinator = coordinator;
            CloseCommand = new ActionCommand(CloseCommandAction);
        }

        private void CloseCommandAction()
        {
            closeAction();
        }
    }
}
