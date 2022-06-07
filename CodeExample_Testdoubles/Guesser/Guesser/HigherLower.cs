namespace Guesser
{
    public class HigherLower
    {
        int number;
        IRandom random;
        public HigherLower()
        {
            random = new RandomWrapper();
            GetRandomNumber();
        }


        public HigherLower(IRandom random)
        {
            this.random = random;
            GetRandomNumber();
        }

        public string MakeAGuess(int guess)
        {
            if (number == guess)
            {
                return "Correct";
            }
            else if (number < guess)
            {
                return "Lower";
            }
            else
            {
                return "Higher";
            }
        }

        private void GetRandomNumber()
        {
            number = random.Next(100);
        }

    }
}
