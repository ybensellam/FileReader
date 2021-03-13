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

        public XMLFileReader(string filePath)
        {
            FilePath = filePath;
        }

        public Company ReadXMlFile()
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Company));

            StreamReader reader = new StreamReader(FilePath);
            var company = (Company)serializer.Deserialize(reader);

            reader.Close();

            return company;
        }
    }
}

