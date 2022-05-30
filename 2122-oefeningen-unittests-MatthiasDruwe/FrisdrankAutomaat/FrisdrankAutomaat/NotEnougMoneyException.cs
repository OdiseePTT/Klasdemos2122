using System;

namespace FrisdrankAutomaat
{
    public class NotEnougMoneyException : Exception
    {
        private double budget;

        public NotEnougMoneyException(double budget)
        {
            this.budget = budget;
        }

        public double Budget { get => budget; }
    }
}
