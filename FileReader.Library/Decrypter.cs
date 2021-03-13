using FileReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader.Library
{
    public static class Decrypter
    {
        public static string DecryptText(string text) => new string(text.Reverse().ToArray());
        public static Company DecryptCompany(Company company)
        {
            return new Company
            {
                Location = new string(company.Location.Reverse().ToArray()),
                Name = new string(company.Name.Reverse().ToArray())
            };
        }
    }
}
