using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlackJack
{

    public interface IUserDataRepository
    {
        int CreateUser(string username, string password);
        User GetUser(int id);
        bool UsernameExists(string username);
        User Login(string username, string password);
        void UpdateBudget(int userId, double change);
    }
    public class UserDataRepository : IUserDataRepository
    {
        readonly BlackJackDb db = new BlackJackDb();

        public UserDataRepository(BlackJackDb db)
        {
            this.db = db;
        }

        public UserDataRepository()
        {
            // Little hack to prevent UI freeze 
            _ = db.Users.ToList();
        }



        public int CreateUser(string username, string password)
        {

            User user = new User(username, GetHash(password))
            {
                Budget = 1000
            };

            db.Users.Add(user);
            db.SaveChanges();

            return user.Id;

        }

        public User GetUser(int id)
        {
            return db.Users.First(user => user.Id == id);
        }

        public bool UsernameExists(string username)
        {
            return db.Users.Where(user => user.UserName == username).Count() > 0;
        }
        public User Login(string username, string password)
        {
            string hashedPassword = GetHash(password);
            User user = db.Users.FirstOrDefault(u => u.UserName == username && u.Password == hashedPassword);

            return user;

        }

        private string GetHash(string text)
        {
            // SHA512 is disposable by inheritance.  
            using (var sha256 = new SHA256Managed())
            {

                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public void UpdateBudget(int userId, double change)
        {
            User user = db.Users.First(u => u.Id == userId);

            user.Budget += change;

            db.SaveChanges();
        }
    }
}
