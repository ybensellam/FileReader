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
        public TextFileReader(string filePath)
        {
            FilePath = filePath;
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
            return isEncrypted ? EncryptText(stringBuilder.ToString()) : stringBuilder.ToString();
        }
        private string EncryptText(string text) =>  new string(text.Reverse().ToArray());


    }
}
