using System;

namespace Guesser
{
    public interface IRandom
    {
        int Next(int number);
    }

    public class RandomWrapper : IRandom
    {
        Random random = new Random();
        public RandomWrapper()
        {

        }

        public int Next(int number)
        {
            return random.Next(number);
        }
    }
}
