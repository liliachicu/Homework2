using System;

namespace Homework2
{
    class Payment
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public Payment(decimal amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }
    }
}
