using System.Collections.Generic;
using System.Globalization;

namespace Homework2
{
    public class DataModel
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public Dictionary<int, ICollection<Payment>> Payments { get; set; } = new Dictionary<int, ICollection<Payment>>();
    }
}