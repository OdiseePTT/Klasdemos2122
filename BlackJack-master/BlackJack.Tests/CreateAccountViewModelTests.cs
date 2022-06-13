using NSubstitute;
using NUnit.Framework;
using System.Windows.Media;

namespace BlackJack.Tests
{
    internal class CreateAccountViewModelTests
    {
        [Test]
        public void Ctor_OnCleanStart_CreateAccountButtonDisabled()
        {

        }

        [Test]
        public void CancelCommand_OpensLoginScreen()
        {
            ICoordinator coordinator = Substitute.For<ICoordinator>();
            CreateAccountViewModel sut = new CreateAccountViewModel(coordinator, null);

            sut.CancelCommand.Execute(null);

            coordinator.Received(1).OpenLogin();
        }

        [Test]
        public void Username_WithValidUsername_ClearsUsernameColor()
        {
            IUserDataRepository userDataRepository = Substitute.For<IUserDataRepository>();
            userDataRepository.UsernameExists("Test").Returns(false);

            CreateAccountViewModel sut = new CreateAccountViewModel(null, userDataRepository);

            sut.Username = "Test";

            Assert.AreEqual(null, sut.UserBackgroundColor);
        }

        [Test]
        public void Username_WithEmptyUsername_MakesUserNameColorRed()
        {

        }

        [Test]
        public void Username_WithExistingUsername_MakesUserNameColorRed()
        {
            IUserDataRepository userDataRepository = Substitute.For<IUserDataRepository>();
            userDataRepository.UsernameExists(Arg.Any<string>()).Returns(true);

            CreateAccountViewModel sut = new CreateAccountViewModel(null, userDataRepository);

            sut.Username = "Test1";

            Assert.AreEqual(Brushes.Red, sut.UserBackgroundColor);
        }

        [Test]
        public void Password_WithValidPassword_ClearsPasswordColor()
        {

        }

        [Test]
        public void Password_WithInvalidPassword_MakesPasswordColorRed()
        {

        }

        [Test]
        public void CheckPassword_WithSameValueAsPassword_ClearsCheckPasswordColor()
        {

        }

        [Test]
        public void CheckPassword_WithDifferentValueAsPassword_MakesCheckPasswordColorRed()
        {

        }

        [Test]
        public void UsernamePasswordCheckPassword_WithValidData_EnablesCreateAccountButton()
        {

        }

        // Gebruik hierbij testcases om meerdere invalid states te checken.
        [Test]
        public void UsernamePasswordCheckPassword_WithInValidData_DisablesCreateAccountButton()
        {

        }

        [Test]
        public void CreateAccountCommand_WithValidData_CreatesUserAndOpensBlackJackScreen()
        {
            ICoordinator coordinator = Substitute.For<ICoordinator>();
            IUserDataRepository userDataRepository = Substitute.For<IUserDataRepository>();
            userDataRepository.UsernameExists("Test").Returns(false);
            userDataRepository.CreateUser("Test", "Ab1Ab1Ab1").Returns(2);
            CreateAccountViewModel sut = new CreateAccountViewModel(coordinator, userDataRepository);
            sut.Username = "Test";
            sut.Password = "Ab1Ab1Ab1";
            sut.CheckPassword = "Ab1Ab1Ab1";

            // act

            sut.CreateAccountCommand.Execute(null);

            // Assert
            userDataRepository.Received(1).CreateUser("Test", "Ab1Ab1Ab1");
            coordinator.Received(1).OpenBlackJack(2);
        }


    }
}
