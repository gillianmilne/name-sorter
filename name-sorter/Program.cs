using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace name_sorter
{
    class Person
    {
        public String FirstNames
        { get; set; }

        public String LastName
        { get; set; }

        public String FirstLastNameString()
        {
            return FirstNames +" "+ LastName;
        }
    }

    class NameSorter
    {
        public List<Person> UnorderedPersons
        {private set;  get; }
        public IEnumerable<Person> OrderedPersons
        { private set; get; }
        private String[] Names
        { set; get; }

        public NameSorter(String path)
        {
            UnorderedPersons = new List<Person>();
            OrderedPersons = new List<Person>();
            ReadNamesFromFile(path);
            SetNames();
            SortNames();
        }
        private void ReadNamesFromFile(String path)
        {
            if(File.Exists(path))
            {
                Names = File.ReadAllLines(path);
            }
        }

        private void SetNames()
        {
            for (int i = 0; i < Names.Length; i++)
            {
                int lastWhiteSpace = Names[i].LastIndexOf(' ');

                UnorderedPersons.Add(new Person
                {
                    FirstNames = Names[i].Substring(0, lastWhiteSpace),
                    LastName = Names[i].Substring(lastWhiteSpace + 1)
                });
            }
        }

        public void SortNames()
        {
            OrderedPersons =
                from person in UnorderedPersons
                orderby person.LastName, person.FirstNames
                select person;
        }

        public void WriteNamesToFile(String path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach(Person person in OrderedPersons)
                {
                    writer.WriteLine(person.FirstLastNameString());
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NameSorter sorter = new NameSorter("testnames.txt");


            foreach (Person p in sorter.UnorderedPersons)
            {
                Console.WriteLine(p.FirstLastNameString());
            }
            Console.WriteLine("---------------------------");
            foreach (Person p in sorter.OrderedPersons)
            {
                Console.WriteLine(p.FirstLastNameString());
            }

            sorter.WriteNamesToFile("orderedlist.txt");

            Console.ReadKey();
        }
    }
}
