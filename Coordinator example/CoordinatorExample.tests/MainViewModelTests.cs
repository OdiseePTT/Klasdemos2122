using Coordinator_example;
using NSubstitute;
using NUnit.Framework;

namespace CoordinatorExample.tests
{
    internal class MainViewModelTests
    {
        [Test]
        public void DemoTestOpenNewWindow()
        {
            ICoordinator coordinator = Substitute.For<ICoordinator>();
            MainViewModel sut = new MainViewModel(coordinator);

            sut.OpenNewScreenCommand.Execute(null);

            coordinator.Received().OpenNewWindow();
        }

    }
}
