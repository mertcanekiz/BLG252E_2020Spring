using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;

namespace Quiz3
{
    class CSVReader
    {
        public static Type getType(string value)
        {
            // Try converting to int, double and DateTime types
            // Return a compatible type, or string if none succeeds
            if (int.TryParse(value, out int intValue)) return typeof(int);
            if (double.TryParse(value, out double floatValue)) return typeof(double);
            if (DateTime.TryParse(value, out DateTime dateTimeResult)) return typeof(DateTime);
            return typeof(string);
        }

        public static DataTable ReadFile(string filename)
        {
            DataTable result = new DataTable();
            
            // Read the file and store the lines into a string array
            // string[] lines = File.ReadLines(filename).Take(10).ToArray();
            string[] lines = File.ReadLines(filename).ToArray();

            // Get the column titles from the first line
            string[] columnTitles = lines[0].Split(',');

            for (int i = 0; i < columnTitles.Length; i++)
            {
                string title = columnTitles[i];

                // Get the type of the current column from the second line
                Type type = getType(lines[1].Split(',')[i]);
                // Add a new column to the table with this title and type
                result.Columns.Add(title, type);
            }

            for (int i = 1; i < lines.Length; i++)
            {
                // Replace empty fields with 0
                // (Otherwise this results in an error
                string input = lines[i].Replace(",,", ",0,");

                // Delete the commas inside quotes
                var regex = new Regex("\\\"(.*?)\\\"");
                var output = regex.Replace(input, m => m.Value.Replace(',', ' '));
                
                // Split the line and add it to the table as a new row
                string[] tokens = output.Split(',');
                result.Rows.Add(tokens);
            }

            return result;
        }
    }
}