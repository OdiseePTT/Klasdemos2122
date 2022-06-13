using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlackJack.Tests
{
    internal class UserDataRepositoryTests
    {
        [Test]
        public void CreateUser_WithUsernameAndPassword_CreatesUserWithBudgetOf1000()
        {
            BlackJackDb dbContext = Substitute.For<BlackJackDb>();
            UserDataRepository sut = new UserDataRepository(dbContext);
            User u = new User("test", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8");
            u.Budget = 1000;
            DbSet<User> mockUsers = NSubstituteUtils.GenerateMockDbSet(new List<User>());
            dbContext.Users.Returns(mockUsers);

            // Act
            int id = sut.CreateUser("test", "password");


            dbContext.Users.Received(1).Add(u);
            dbContext.Received(1).SaveChanges();
            Assert.Equals(0, id);
        }

        [Test]
        public void GetUser_WithId_ReturnsCorrectUser()
        {
            List<User> userList = new List<User>()
            {
                new User("Matthias", "password1"){ Id=1},// met behulp van de accolades kunnen we direct properties instellen, die we niet in de constructor gebruiken.
                new User("Ella", "password2"){Id=2}
            };

            // BlackJackDB Mocken
            BlackJackDb blackJackDb = Substitute.For<BlackJackDb>();
            // DbSet voor User maken met behulp van GenerateMockDbSet
            DbSet<User> mockUsers = NSubstituteUtils.GenerateMockDbSet(userList);

            // Instellen dat wanneer Users aangeroepen wordt, we gebruik maken van de mockUsers.
            blackJackDb.Users.Returns(mockUsers);
        }

        [Test]
        public void UserNameExists_WithNonExistingUsername_ReturnsFalse()
        {

        }

        [Test]
        public void UserNameExists_WithExistingUsername_ReturnsTrue()
        {

        }

        [Test]
        public void Login_WithExistingCredentials_ReturnsUser()
        {

        }

        [Test]
        public void Login_WithFakeCredentials_ReturnsNull()
        {

        }

        [Test]
        public void UpdateBudget_WithuserIdAndBudget_UpdatesBudgetForUser()
        {

        }
    }
}
