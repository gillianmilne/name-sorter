using System;
using System.IO;

namespace name_sorter
{
    class FileHandler
    {
        // Reads newline delimited lines from a textfile and stores
        // them in array Names
        public String[] ReadLinesFromFile(String path)
        {
            String[] lines = null;
            try
            {
                lines = File.ReadAllLines(path);
                return lines;
            }
            catch (Exception e)
            {
                Console.WriteLine("Read file " + path + " failed: ");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // Prints full names to a file
        // Prints full names to file "path", each on a new line in a 
        // "FirstNames LastNames" format
        public bool WriteLinesToFile(String path, String[] lines)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (String line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Write to file " + path + " failed: ");
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

