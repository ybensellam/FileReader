using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader.Library
{
    public class TextFileReader
    {
        public string FilePath { get; set; }

        public string BasePath { get; set; }
        public TextFileReader(string filePath, string basePath)
        {
            FilePath = filePath;
            BasePath = basePath;
        }

        public string ReadTextFile(bool isEncrypted)
        {
            var stringBuilder = new StringBuilder();

            using (var reader = new StreamReader(FilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    stringBuilder.AppendLine(line);
                }
            }
            return isEncrypted ? Decrypter.DecryptText(stringBuilder.ToString()) : stringBuilder.ToString();
        }
        public Dictionary<string, string> ReadTextFiles(string fileNames,bool isEncrypted)
        {

            Dictionary<string, string> filesText = new Dictionary<string, string>();
            var files = fileNames.Split(',').Where(x => x.Contains(".txt"));
            StringBuilder stringBuilder = null;

            
            foreach (var file  in files)
            {
                stringBuilder = new StringBuilder();
                using ( var reader = new StreamReader(string.Format(BasePath, file)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        stringBuilder.AppendLine(line);
                    }
                   filesText.Add(file, isEncrypted? Decrypter.DecryptText(stringBuilder.ToString()) : stringBuilder.ToString());
                    
                }
            }

            return filesText;
        }

    }
}
