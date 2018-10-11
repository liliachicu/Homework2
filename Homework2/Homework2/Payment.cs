using System;

namespace Homework2
{
    class Payment
    {
        public int IDEmployee { get;}
        public decimal Amount { get; }
        public DateTime Date { get; }
        public Payment(int id,  decimal amount, DateTime date)
        {
            IDEmployee = id;
            Amount = amount;
            Date = date;
        }
    }
}
