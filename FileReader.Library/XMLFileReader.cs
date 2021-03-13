using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using FileReader.Models;

namespace FileReader.Library
{
    public class XMLFileReader
    {
        public string FilePath { get; set; }
        public string BasePath { get; set; }

        public XMLFileReader(string filePath, string basePath)
        {
            FilePath = filePath;
            BasePath = basePath;
        }

        public Company ReadXMlFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Company));

            StreamReader reader = new StreamReader(FilePath);
            var company = (Company)serializer.Deserialize(reader);

            reader.Close();

            return company;
        }
        public Dictionary<string, Company> ReadXMlFiles(string fileNames, bool isEncrypted)
        {
            Dictionary<string, Company> filesCompany = new Dictionary<string, Company>();
            var files = fileNames.Split(',');

            XmlSerializer serializer = new XmlSerializer(typeof(Company));

            StreamReader reader = new StreamReader(FilePath);
            var company = (Company)serializer.Deserialize(reader);

            foreach (var file in files)
            {
                reader = new StreamReader(string.Format(BasePath, file));
                company = (Company)serializer.Deserialize(reader);
                filesCompany.Add(file, isEncrypted ? Decrypter.DecryptCompany(company) : company);
                reader.Close();
            }
            return filesCompany;
        }
    }
}

