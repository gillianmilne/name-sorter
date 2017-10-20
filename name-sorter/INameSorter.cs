using System;
using System.Collections.Generic;
using System.Text;

namespace name_sorter
{
    public interface INameSorter
    {
        IEnumerable<Person> SortNames(IEnumerable<Person> persons);
    }
}
