using System;
using System.Collections.Generic;
using System.Text;

namespace name_sorter
{
    // Person class which contains a String FirstNames
    // and a string LastNames
    class Person
    {
        public String FirstNames
        { get; set; }

        public String LastName
        { get; set; }

        // Returns name string in "FirstName Lastname"
        // format
        public String FirstLastNameString()
        {
            return FirstNames + " " + LastName;
        }
    }
}
