using System;
using System.Linq;

namespace Homework2
{
    public class People
    {
        private int _iD;
        private string _firstName;
        private string _lastName;

        public int ID
        {
            get { return _iD; }
            set { if (_iD > 0) _iD = value;
                    else throw new Exception("The value of ID should be any positive integer number.") ; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { if (_firstName.All(Char.IsLetter)) _firstName = value;
                else throw new Exception("First Name should contain only letters (uppercase or lowercase), no numbers or special characters.");
            }
        }
        public string LastName
        {
            get { return _firstName; }
            set
            {
                if (_firstName.All(Char.IsLetter)) _firstName = value;
                else throw new Exception("First Name should contain only letters (uppercase or lowercase), no numbers or special characters.");
            }
        }
    }
}
