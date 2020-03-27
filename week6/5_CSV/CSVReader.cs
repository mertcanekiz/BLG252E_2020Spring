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
            // A variable to store the final result that is of type
            // List<Dictionary<string, string>> meaning this is a
            // list of dictionaries that hold string-to-string pairs.
            var result = new List<Dictionary<string, string>>();

            // Read all lines and separate them into a string array.
            string[] lines = File.ReadAllLines(@filename);
            // The first line of the file describes the names of the fields.
            // Split this line and store these names in an array called 'headers'
            var headers = lines[0].Split(',');

            // We already parsed the first line, start from the second line
            for (int i = 1; i < lines.Length; i++)
            {
                // Create a dictionary that will hold the data for the current line
                Dictionary<string,string> current = new Dictionary<string, string>();

                // Split the line on a comma character (,) and store these inside tokens array
                var tokens = lines[i].Split(',');

                // For each of the tokens, set the current item's header and data
                // for example, if headers is ["name", "id"], then the following loop produces:
                //
                // current["name"] = tokens[0]
                // current["id"] = tokens[1]
                // ...
                // and so on.
                for (int j = 0; j < tokens.Length; j++)
                {
                    current[headers[j]] = tokens[j];
                }

                // Add the dictionary (which holds the data for current line) to the result list
                result.Add(current);
            }

            // Finally, return the result List.
            return result;
        }
    }
}