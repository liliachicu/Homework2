using System;

namespace Homework2
{
    public class Payments
    {
        private decimal _salary;
        private DateTime _dayOfPayment;
        private string _salaryFormat;
        private string _dayOfPaymentFormat;
        public string Salary
        { get { return _salaryFormat = string.Format("{0:0.000}", _salary); }
            set { _salaryFormat = value; } 
        }
        public string DayOfPayment
        {
            get { return _dayOfPaymentFormat= string.Format("{0:MM/dd/yyyy}", _dayOfPayment); }
            set { _dayOfPaymentFormat = value; }
        }

                
    }
}
