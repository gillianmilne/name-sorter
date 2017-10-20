using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace name_sorter
{
    public class DescendingLastnameSorter : INameSorter
    {
        public IEnumerable<Person> SortNames(IEnumerable<Person> persons)
        {
            IEnumerable<Person> orderedPersons =
            from person in persons
            orderby person.LastName descending, person.FirstNames
            select person;

            return orderedPersons;
        }
    }
}
