using dbdocs.lib.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbdocs.lib.Utilities
{
    public class FileSystem : IFileSystem
    {
        public string ReadTextFile(string filePath)
        {
            var sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }

        public void SaveTextFile(string fileText, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine(fileText);
            }
        }
    }
}
