using System.Collections.Generic;
using System.Globalization;

namespace Homework2
{
    public class DataModel
    {
        public List<Employee> Employees { get; set; }
        public Dictionary<int, ICollection<Payment>> Payments { get; set; }
    }
}