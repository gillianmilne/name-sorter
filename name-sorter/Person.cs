using System;
using System.Collections.Generic;
using System.Text;

namespace name_sorter
{
    // Person class which contains a String FirstNames
    // and a string LastNames
    public class Person
    {
        public Person()
        { }
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

        public override bool Equals(Object obj)
        {
            Person person = obj as Person;
            if (person == null)
            {
                return false;
            }
            if (person.FirstNames == this.FirstNames && person.LastName == this.LastName)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.FirstLastNameString().GetHashCode();
        }
    }
}
