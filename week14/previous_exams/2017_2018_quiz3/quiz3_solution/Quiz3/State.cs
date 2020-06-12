using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Quiz3
{
    class State
    {
        private string name;
        private Dictionary<DateTime, string> results = new Dictionary<DateTime, string>();
        private Dictionary<DateTime, string> swingMonths = new Dictionary<DateTime, string>();

        public State(string name)
        {
            this.name = name;
        }

        public void Evaluate(DataRow[] rows)
        {
            foreach (DataRow row in rows)
            {
                // Get the date of the poll
                DateTime date = row.Field<DateTime>("startdate");
                // We only care about the month, so subtract the day
                date = date.AddDays(-date.Day + 1);

                // Determine who won that month
                double rawpoll_clinton = row.Field<double>("rawpoll_clinton");
                double rawpoll_trump = row.Field<double>("rawpoll_trump");
                double rawpoll_johnson = row.Field<double>("rawpoll_johnson");
                double winner = Math.Max(rawpoll_clinton, Math.Max(rawpoll_trump, rawpoll_johnson));
                string name = "";
                if (winner == rawpoll_clinton)
                    name = "clinton";
                else if (winner == rawpoll_trump)
                    name = "trump";
                else
                    name = "johnson";

                // Add the result to the dictionary
                results[date] = name;
                
            }

            // Set the previousMonth to the first result
            var previousMonth = results.First();
            foreach (var month in results)
            {
                // Check if we're comparing two consecutive months
                if (month.Key == previousMonth.Key.AddMonths(1))
                {
                    // If the winner has changed
                    if (month.Value != previousMonth.Value)
                    {
                        // Add it to the swinging months
                        swingMonths.Add(month.Key, month.Value);
                    }
                }
                // Set the previous month to current month and continue
                previousMonth = month;
            }
        }

        public string GetName()
        {
            return name;
        }

        public Dictionary<DateTime, string> GetSwingMonths()
        {
            return swingMonths;
        }
    }
}
