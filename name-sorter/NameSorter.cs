using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Contains functions to process and sort names
// Operates on lists of persons
namespace name_sorter
{
    // Contains functions to process and sort names
    class NameSorter
    {
        // Sorts UnorderedPersons into OrderedPersons
        // Takes UnorderedPersons and sorts alphabetically based on LastNames
        // and then FirstNames and stores it in the Enumerable list OrderedPersons
        public IEnumerable<Person> SortLastThenFirst(List<Person> unorderedPersons)
        {
            IEnumerable<Person> orderedPersons =
                from person in unorderedPersons
                orderby person.LastName, person.FirstNames
                select person;
            return orderedPersons;
        }
    }
}