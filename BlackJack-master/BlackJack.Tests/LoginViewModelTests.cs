using NSubstitute;
using NUnit.Framework;

namespace BlackJack.Tests
{
    internal class LoginViewModelTests
    {
        [Test]
        public void Ctor_OnCleanStart_LoginButtonIsDisabled()
        {
            // Arrange + Act
            LoginViewModel sut = new LoginViewModel(null, null);


            // Assert 
            Assert.IsFalse(sut.LoginButtonEnabled);
        }

        [Test]
        public void UsernameAndPassword_FilledWithText_LoginButtonIsEnabled()
        {
            // Arrange
            LoginViewModel sut = new LoginViewModel(null, null);

            // Act
            sut.Password = "Demo";
            sut.Username = "Demo";

            Assert.IsTrue(sut.LoginButtonEnabled);
        }

        [Test]
        public void CreateAccountCommand_OpenCreateAccountScreen()
        {
            // Arrange
            ICoordinator coordinator = Substitute.For<ICoordinator>();
            LoginViewModel sut = new LoginViewModel(coordinator, null);

            sut.CreateAccountCommand.Execute(null);

            coordinator.Received(1).OpenCreateAccount();
        }

        [Test]
        public void LoginCommand_WithFalseCredentials_OpensErrorMessage()
        {
            // Arrange
            ICoordinator coordinator = Substitute.For<ICoordinator>();
            IUserDataRepository userDataRepository = Substitute.For<IUserDataRepository>();
            LoginViewModel sut = new LoginViewModel(coordinator, userDataRepository);

            User u = null;
            userDataRepository.Login(Arg.Any<string>(), Arg.Any<string>()).Returns(u);

            // Act
            sut.LoginCommand.Execute(null);

            // Assert
            coordinator.Received(1).ShowMessageBox("Invalid Password");

        }

        [Test]
        public void LoginCommand_WithCorrectCredentials_OpensBlackJackWindow()
        {
            // Arrange
            ICoordinator coordinator = Substitute.For<ICoordinator>();
            IUserDataRepository userDataRepository = Substitute.For<IUserDataRepository>();
            LoginViewModel sut = new LoginViewModel(coordinator, userDataRepository);

            User u = new User("Demo", "Demo") { Id = 2 };
            userDataRepository.Login(Arg.Any<string>(), Arg.Any<string>()).Returns(u);

            // Act
            sut.LoginCommand.Execute(null);

            // Assert
            coordinator.Received(1).OpenBlackJack(2);
        }
    }
}
