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

        public string BasePath { get; set; }
        public JsonFileReader(string filePath,string basePath)
        {
            FilePath = filePath;
            BasePath = basePath;
        }
        public Company ReadJsonFile(bool isEncrypted)
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string json = reader.ReadToEnd();
                return isEncrypted ? Decrypter.DecryptCompany(JsonConvert.DeserializeObject<Company>(json)) : JsonConvert.DeserializeObject<Company>(json);
            }
        }
        public Dictionary<string, Company> ReadJsonFiles(string fileNames, bool isEncrypted)
        {
            Dictionary<string, Company> filesCompany = new Dictionary<string, Company>();
            var files = fileNames.Split(',').Where(x => x.Contains(".json"));

            foreach (var file in files)
            {
                using (StreamReader reader = new StreamReader(string.Format(BasePath, file)))
                {
                    string json = reader.ReadToEnd();
                    filesCompany.Add(file, isEncrypted ? Decrypter.DecryptCompany(JsonConvert.DeserializeObject<Company>(json)) : JsonConvert.DeserializeObject<Company>(json));
                    reader.Close();
                }
            }
            return filesCompany;
        }
    }
}
