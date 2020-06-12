using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace Quiz3
{

    class Program
    {
        private static State[] states;
        private static Dictionary<string, string> pollsters = new Dictionary<string, string>();
        static string[] grades = new string[]
        {
            "D",
            "D+",
            "C-",
            "C",
            "C+",
            "B-",
            "B",
            "B+",
            "A-",
            "A",
            "A+"
        };

        static DataRow[] ResultsByState(DataTable table, string state)
        {
            // Get the rows that have their state column equal to the given state and order them by their date
            return table.Select($"state = '{state}'").OrderBy(u => u["startdate"]).ToArray();
        }

        static string[] GetStateNames(DataTable table)
        {
            // Get unique state names from the data table into a string array
            List<string> result = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                string state = row.Field<string>("state");
                if (!result.Contains(state))
                {
                    result.Add(state);
                }
            }
            result.Sort();
            return result.ToArray();
        }
        
        static void Main(string[] args)
        {
            // Read the csv file into a data table
            DataTable table = CSVReader.ReadFile("2016election.csv");

            // Get the state names into an array
            string[] stateNames = GetStateNames(table);

            // Create an array of State objects
            states = new State[stateNames.Length];

            for (int i = 0; i < states.Length; i++)
            {
                // For every state, instantiate it with a name
                states[i] = new State(stateNames[i]);
                // and evaluate the poll results
                states[i].Evaluate(ResultsByState(table, stateNames[i]));

                // Get the swing results and print them
                var swingMonths = states[i].GetSwingMonths();
                if (swingMonths.Count > 0)
                {
                    Console.WriteLine("{0}: {1} swinging months", states[i].GetName(), swingMonths.Count);
                    foreach (var swing in swingMonths)
                    {
                        Console.WriteLine("{0}, {1}", swing.Key, swing.Value);
                    }
                    Console.WriteLine();
                }
            }

            Console.Write("Press any key to print pollster grades");
            Console.ReadLine();
            
            foreach (DataRow row in table.Rows)
            {
                // For each row, get the pollster and calculate the winner from adjpoll columns
                string pollster = row.Field<string>("pollster");
                string grade = row.Field<string>("grade");
                int numGrade = Array.IndexOf(grades, grade);
                double adjpoll_clinton = row.Field<double>("adjpoll_clinton");
                double adjpoll_trump = row.Field<double>("adjpoll_trump");
                double adjpoll_johnson = row.Field<double>("adjpoll_johnson");
                double winner = Math.Max(adjpoll_clinton, Math.Max(adjpoll_trump, adjpoll_johnson));

                // Increase their score if they guessed correctly, decrease otherwise
                if (winner == adjpoll_trump)
                {
                    numGrade += 1;
                }
                else
                {
                    numGrade -= 1;
                }

                // Adjust the grades so they don't go out of bounds
                if (numGrade >= grades.Length) numGrade = grades.Length - 1;
                if (numGrade < 0) numGrade = 0;

                // Set the current pollster and their score in the dictionary
                pollsters[pollster] = grades[numGrade];

            }

            // Order the pollsters in descending order and print them
            var orderedPollsters = pollsters.OrderBy(x => -Array.IndexOf(grades, x.Value));
            foreach (var pollsters in orderedPollsters)
            {
                Console.WriteLine("{0}: {1}", pollsters.Key, pollsters.Value);
            }

            Console.Write("\nPress any key to quit");
            Console.ReadLine();
        }
    }
}
