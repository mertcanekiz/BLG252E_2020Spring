using System;
using System.IO;
using System.Collections.Generic;

namespace _5_CSV
{
    class CSVReader
    {
        private string filename;
        public CSVReader(string filename)
        {
            this.filename = filename;
        }

        public List<Dictionary<string, string>> read()
        {
            var result = new List<Dictionary<string, string>>();
            string[] lines = File.ReadAllLines(@filename);
            var headers = lines[0].Split(',');
            for (int i = 1; i < lines.Length; i++)
            {
                Dictionary<string,string> current = new Dictionary<string, string>();
                var tokens = lines[i].Split(',');
                for (int j = 0; j < tokens.Length; j++)
                {
                    current[headers[j]] = tokens[j];
                }
                result.Add(current);
            }
            return result;
        }
    }
}