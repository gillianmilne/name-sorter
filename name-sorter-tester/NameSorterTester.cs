using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter;
using System;
using System.Collections.Generic;

namespace name_sorter_tester
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void FirstLastNameString_Concatenates_FirstName_and_LastName()
        {
            Person pers = new Person { FirstNames = "Luisa Helene", LastName = "Smith" };

            String expected = "Luisa Helene Smith";
            String actual = pers.FirstLastNameString();

            Assert.AreEqual(expected, actual, "FirstLastName should return the FirstName " +
                "and LastName porperty concatenated in the format \"FirstName LastName");
        }
    }

    [TestClass]
    public class NameSorterTests
    {
        [TestMethod]
        public void SortLastThenFirst_()
        {
            NameSorter namesorter = new NameSorter();
            List<Person> unsorted = new List<Person>();
            List<Person> sorted = new List<Person>();
            List<Person> expected = new List<Person>();
            unsorted.Add(new Person { FirstNames = "Berry Mint", LastName = "Kelvin" });
            unsorted.Add(new Person { FirstNames = "Barry Mint", LastName = "Kelvin" });
            unsorted.Add(new Person { FirstNames = "Barry Mont", LastName = "Kelvin" });
            unsorted.Add(new Person { FirstNames = "Barry Mont", LastName = "Kalvin" });

            expected.Add(new Person { FirstNames = "Barry Mont", LastName = "Kalvin" });
            expected.Add(new Person { FirstNames = "Barry Mint", LastName = "Kelvin" });
            expected.Add(new Person { FirstNames = "Barry Mont", LastName = "Kelvin" });
            expected.Add(new Person { FirstNames = "Berry Mint", LastName = "Kelvin" });

            sorted = namesorter.SortLastThenFirst(unsorted);

            CollectionAssert.AreEqual(expected, sorted, "SortLastThenFirst should return a " +
                "List<Person> sorted in order by LastName and then FirstName");
        }
    }
}
