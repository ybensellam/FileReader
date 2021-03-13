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
        public static string _basePath = ConfigurationManager.AppSettings["basePath"];
        public static string _adminFiles = ConfigurationManager.AppSettings["admin"];
        public static string _userFiles = ConfigurationManager.AppSettings["user"];
        public static bool _encryptedFile =Convert.ToBoolean(ConfigurationManager.AppSettings["encryptedFile"]);
        static void Main(string[] args)
        {
            //Version1();
            //Version2();
            //Version3();
            //Version4();
            Version5();
        }

        private static void Version1()
        {
            var textFileReader = new TextFileReader(_filePathV1);

            Console.WriteLine(textFileReader.ReadTextFile(_encryptedFile));
            Console.ReadLine();
        }
        private static void Version2()
        {
            var xmlFileReader = new XMLFileReader(_filePathV2, _basePath);

            var company = xmlFileReader.ReadXMlFile();

            Console.WriteLine($"Name : {company.Name}");
            Console.WriteLine($"Location : {company.Location}");

            Console.ReadLine();
        }
        private static void Version3()
        {
            var textFileReader = new TextFileReader(_filePathV1);

            Console.WriteLine(textFileReader.ReadTextFile(_encryptedFile));
            Console.ReadLine();
        }
        private static void Version4()
        {
            string roleInput = string.Empty;
            do
            {
                Console.WriteLine("Type your role : ");
                roleInput = Console.ReadLine();
            } while (!IsExistingRole(roleInput));

            var files = ConfigurationManager.AppSettings[roleInput.ToLower()];

            var xmlFileReader = new XMLFileReader(_filePathV2, _basePath);

            foreach (var item in xmlFileReader.ReadXMlFiles(files, _encryptedFile))
            {
                Console.WriteLine($"----------- FileName : {item.Key} ---------------");
                Console.WriteLine($"Name : {item.Value.Name}");
                Console.WriteLine($"Location : {item.Value.Location}");
            }
            Console.ReadLine();
        }
        private static void Version5()
        {
            string roleInput = string.Empty;
            do
            {
                Console.WriteLine("Type your role : ");
                roleInput = Console.ReadLine();
            } while (!IsExistingRole(roleInput));

            var files = ConfigurationManager.AppSettings[roleInput.ToLower()];

            var xmlFileReader = new XMLFileReader(_filePathV2, _basePath);

            foreach (var item in xmlFileReader.ReadXMlFiles(files, _encryptedFile))
            {
                Console.WriteLine($"----------- FileName : {item.Key} ---------------");
                Console.WriteLine($"Name : {item.Value.Name}");
                Console.WriteLine($"Location : {item.Value.Location}");
            }
            Console.ReadLine();
        }
        private static bool IsExistingRole(string roleInput)
        {
            bool correctRole = false;

            switch (roleInput?.ToLower())
            {
                case "admin":
                case "user":
                    correctRole = true;
                    break;
                default:
                    correctRole = false;
                    Console.WriteLine("Unknown role");
                    break;
            }

            return correctRole;
        }
    }
}

