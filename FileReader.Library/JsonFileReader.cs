using FileReader.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader.Library
{
    public class JsonFileReader
    {
        public string FilePath { get; set; }
        public JsonFileReader(string filePath)
        {
            FilePath = filePath;
        }
        public Company ReadJsonFile(bool isEncrypted)
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string json = reader.ReadToEnd();
                return isEncrypted? Decrypter.DecryptCompany(JsonConvert.DeserializeObject<Company>(json)) : JsonConvert.DeserializeObject<Company>(json);
            }
        }
    }
}
