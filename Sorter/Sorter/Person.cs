using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorter
{
    class Person

    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool hasLastName { get; set; }

        public string printFullName()
        {
            if (lastName == "}")
            {
                return firstName;
            }
            else
            {
                return firstName + " " + lastName;
            }
        }
    }
}
