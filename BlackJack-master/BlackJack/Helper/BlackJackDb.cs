using System.Data.Entity;

namespace BlackJack
{
    public class BlackJackDb : DbContext
    {
        public BlackJackDb() : base("BlackJack")
        {

        }

        public virtual DbSet<User> Users { get; set; }
    }
}
