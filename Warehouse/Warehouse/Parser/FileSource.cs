using System;
using System.Collections.Generic;
using System.IO;

namespace Warehouse.Parser
{

    public class FileSource : ISource
    {
        private readonly string _fileName;
        public FileSource(string fileName)
        {
            if(string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException(nameof(fileName));
            if (!File.Exists(fileName)) throw new FileNotFoundException(nameof(fileName));

            _fileName = fileName;
        }

        public IEnumerable<string> GetData()
        {
            using var reader = new StreamReader(_fileName);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
