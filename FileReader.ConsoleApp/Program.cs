using FileReader.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = ConfigurationManager.AppSettings["pathV1"];
            var textFileReader = new TextFileReader(filePath);

            Console.WriteLine(textFileReader.ReadTextFile());
            Console.ReadLine();
        }
    }
}
