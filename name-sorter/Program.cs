using System;
using System.Collections.Generic;
using System.Linq;

namespace name_sorter
{
    class Program
    {
        // Brief: Processes full name strings to a List<Person>.
        // Iterates over the array Names, splitting strings based on the 
        // last index of the input delimiter. Creates a new Person Object and
        // adds it to the List UnorderedPersons
        private static List<Person> ProcessNames(String delimiter, String[] Names)
        {
            List<Person> unorderedPersons = new List<Person>();
            for (int i = 0; i < Names.Length; i++)
            {
                int lastDelimIndex = Names[i].LastIndexOf(delimiter);

                unorderedPersons.Add(new Person
                {
                    FirstNames = Names[i].Substring(0, lastDelimIndex),
                    LastName = Names[i].Substring(lastDelimIndex + 1)
                });
            }

            return unorderedPersons;
        }

        // Brief: Outputs fullname strings of Persons to array.
        // Takes an IEnumerable list of Person, converts it to
        // an array, iterates over it and adds the full name in 
        // the format "FirstName Lastname" to an array and returns 
        // it. 
        // TODO: Receive a function to determine format?
        private static String[] NamesToArray(IEnumerable<Person> n)
        {
            String[] names = new String[n.Count()];
            Person[] persons = n.ToArray();

            for (int i = 0; i < n.Count(); i++)
            {
                names[i] = persons[i].FirstLastNameString();
            }

            return names;
        }

        static void Main(string[] args)
        {
            //Filepaths
            String readPath = "unsorted-names-list.txt";
            String writePath = "sorted-names-list.txt";
            
            //Initialise
            NameSorter sorter = new NameSorter();
            FileHandler file = new FileHandler();
           
            List<Person> unorderedPersons = new List<Person>();
            List<Person> orderedPersons = new List<Person>();

            //Get names from file and process them
            unorderedPersons = ProcessNames(" ", file.ReadLinesFromFile(readPath));
            //Sort names
            orderedPersons = sorter.SortLastThenFirst(unorderedPersons);

            //Print to screen
            Console.WriteLine("Original list: ");
            foreach (Person p in unorderedPersons)
            { 
                Console.WriteLine(p.FirstLastNameString());
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine("Ordered list: ");
            foreach (Person p in orderedPersons)
            {
                Console.WriteLine(p.FirstLastNameString());
            }
            
            //Write names to file
            file.WriteLinesToFile(writePath, NamesToArray(orderedPersons));

            Console.ReadKey();

        }
    }
}
