using FileReader.Library;
using FileReader.Models;
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
        public static string _filePathV1 = ConfigurationManager.AppSettings["pathV1"];
        public static string _filePathV2 = ConfigurationManager.AppSettings["pathV2"];
        static void Main(string[] args)
        {
            //Version1();
            //Version2();
            Version3();
        }

        private static void Version1()
        {
            var textFileReader = new TextFileReader(_filePathV1);

            Console.WriteLine(textFileReader.ReadTextFile(false));
            Console.ReadLine();
        }
        private static void Version2()
        {
            var xmlFileReader = new XMLFileReader(_filePathV2);

            var company = xmlFileReader.ReadXMlFile();

            Console.WriteLine($"Name : {company.Name}");
            Console.WriteLine($"Location : {company.Location}");

            Console.ReadLine();
        }
        private static void Version3()
        {
            var textFileReader = new TextFileReader(_filePathV1);

            Console.WriteLine(textFileReader.ReadTextFile(true));
            Console.ReadLine();
        }
    }
}

