using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        public string Password { get; set; }

        public double Budget { get; set; }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public User()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj is User)
            {
                User user = obj as User;
                return user.UserName == UserName && user.Password == Password && user.Budget == Budget
;
            }
            return base.Equals(obj);
        }

    }
}
