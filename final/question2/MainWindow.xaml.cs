// defaults namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// used namespaces
using System.Globalization;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data;
using System.IO;

// for livecharts library
using LiveCharts;
using LiveCharts.Wpf;

// BLG252E Final Exam Question 2 by Batuhan Ozer | 040180615

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        // Variables for graphs
        public SeriesCollection SeriesCollection_total { get; set; }
        public SeriesCollection SeriesCollection_new { get; set; }
        public string[] Labels_total { get; set; }
        public string[] Labels_new { get; set; }
        public Func<double, string> Formatter { get; set; }

        // Class for storing covid data item
        class covidData
        {
            public string country;
            public int confirmed;
            public int deaths;
            public int recovered;
            public int active;
            public int newCases;
            public int newDeaths;
            public int newRecovered;
            public float deathPercent;
            public float recoverPercent;
            public float deaths100recovered;
            public int confirmedLast;
            public int weekChange;
            public float weekIncrease;
            public string region;

            public covidData()
            {
            }

            public void setVariables(ref string line)
            {
                string[] data = line.Split(',');

                country = data[0];
                confirmed = int.Parse(data[1]);
                deaths = int.Parse(data[2]);
                recovered = int.Parse(data[3]);
                active = int.Parse(data[4]);
                newCases = int.Parse(data[5]);
                newDeaths = int.Parse(data[6]);
                newRecovered = int.Parse(data[7]);
                deathPercent = float.Parse(data[8]);
                recoverPercent = float.Parse(data[9]);
                if (data[10] == "inf")
                {
                    //deaths100recovered = 99999999.99f;
                    deaths100recovered = float.PositiveInfinity;
                }
                else
                {
                    deaths100recovered = float.Parse(data[10]);
                }
                confirmedLast = int.Parse(data[11]);
                weekChange = int.Parse(data[12]);
                weekIncrease = float.Parse(data[13]);
                region = data[14];
            }

        };

        // Global variables
        private List<covidData> covidDataList;
        private DataTable dt;
        private SolidColorBrush activeBrush;
        private SolidColorBrush inactiveBrush;
        private bool isFiltering;

        // Save Load System
        void SaveAllData()
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            string outPath = appPath + @"/CustomSaveData.txt";

            string exportString = "";

            exportString += SearchBar.Text + "\n";

            exportString += (isFiltering ? "1" : "0") + "\n";

            exportString += comboBox.SelectedIndex.ToString() + "\n";

            exportString += compareComboBox.SelectedIndex.ToString() + "\n";

            exportString += compareValue.Text + "\n";

            exportString += filterNresults.Text + "\n";

            System.IO.File.WriteAllText(outPath, exportString);

        }
        void LoadOldData()
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            string outPath = appPath + @"/CustomSaveData.txt";
            if (!File.Exists(outPath)) return;

            string[] lines = File.ReadAllLines(outPath);

            SearchBar.Text = lines[0];

            isFiltering = lines[1] == "1" ? true : false;

            comboBox.SelectedIndex = int.Parse(lines[2]);

            compareComboBox.SelectedIndex = int.Parse(lines[3]);

            compareValue.Text = lines[4];

            filterNresults.Text = lines[5];

            filterButton.Background = isFiltering ? activeBrush : inactiveBrush;
            filterButton.BorderBrush = isFiltering ? activeBrush : inactiveBrush;
        }

        // Initializer
        public MainWindow()
        {
            InitializeComponent();
            FillingDataGrid();

            inactiveBrush = new SolidColorBrush(Color.FromRgb(103, 58, 183));
            activeBrush = Brushes.DarkGreen;

            SeriesCollection_total = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Total",
                    Values = new ChartValues<int> { 0, 0, 0 }
                }
            };
            SeriesCollection_new = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "New",
                    Values = new ChartValues<int> { 0, 0, 0 },
                    Fill = Brushes.DarkOrange
                }
            };

            Labels_total = new[] { "Confirmed", "Deaths", "Recovered"};
            Labels_new = new[] { "Cases", "Deaths", "Recovered" };

            Formatter = value => value.ToString();

            isFiltering = false;

            DataContext = this;

            LoadOldData();

            this.Closing += MainWindow_Closing;
        }

        // To save data when closing app
        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveAllData();
        }

        // Fill the datagrid using csv file
        void FillingDataGrid()
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            string covidCsvPath = appPath + @"/covid19.csv";
            if (!File.Exists(covidCsvPath)) { 
                MessageBox.Show("Error. covid19.csv file should be near the .exe file");
                // shutdown the app
                Environment.Exit(0);
                return; 
            }
            string[] lines = File.ReadAllLines(appPath + @"/covid19.csv");

            int lineCount = lines.Length;
            covidDataList = new List<covidData>(lineCount-1);

            for(int i = 1; i < lineCount; i++)
            {
                covidData cdata = new covidData();
                cdata.setVariables(ref lines[i]);
                covidDataList.Add(cdata);
            }

            dt = new DataTable();

            DataColumn county = new DataColumn("Country", typeof(string));
            DataColumn confirmed = new DataColumn("Confirmed", typeof(int));
            DataColumn deaths = new DataColumn("Deaths", typeof(int));
            DataColumn recovered = new DataColumn("Recovered", typeof(int));
            DataColumn active = new DataColumn("Active", typeof(int));
            DataColumn newcases = new DataColumn("NewCases", typeof(int));
            DataColumn newdeaths = new DataColumn("NewDeaths", typeof(int));
            DataColumn newrecovered = new DataColumn("NewRecovered", typeof(int));
            DataColumn deathPercent = new DataColumn("DeathOverHundredCases", typeof(float));
            DataColumn recoverPercent = new DataColumn("RecoveredOverHundredCases", typeof(float));
            DataColumn death100recovered = new DataColumn("DeathsOverHundredRecovered", typeof(float));
            DataColumn confirmedLast = new DataColumn("ConfirmedLastWeek", typeof(int));
            DataColumn weekchange = new DataColumn("OneWeekChange", typeof(int));
            DataColumn weekincrease = new DataColumn("OneWeekIncreasePercent", typeof(float));
            DataColumn region = new DataColumn("WHORegion", typeof(string));

            dt.Columns.Add(county);
            dt.Columns.Add(confirmed);
            dt.Columns.Add(deaths);
            dt.Columns.Add(recovered);
            dt.Columns.Add(active);
            dt.Columns.Add(newcases);
            dt.Columns.Add(newdeaths);
            dt.Columns.Add(newrecovered);
            dt.Columns.Add(deathPercent);
            dt.Columns.Add(death100recovered);
            dt.Columns.Add(confirmedLast);
            dt.Columns.Add(weekchange);
            dt.Columns.Add(weekincrease);
            dt.Columns.Add(region);

            for (int i = 0; i < covidDataList.Count; i++)
            {
                DataRow row = dt.NewRow();
                row[0] = covidDataList[i].country;
                row[1] = covidDataList[i].confirmed;
                row[2] = covidDataList[i].deaths;
                row[3] = covidDataList[i].recovered;
                row[4] = covidDataList[i].active;
                row[5] = covidDataList[i].newCases;
                row[6] = covidDataList[i].newDeaths;
                row[7] = covidDataList[i].newRecovered;
                row[8] = covidDataList[i].deathPercent;
                row[9] = covidDataList[i].deaths100recovered;
                row[10] = covidDataList[i].confirmedLast;
                row[11] = covidDataList[i].weekChange;
                row[12] = covidDataList[i].weekIncrease;
                row[13] = covidDataList[i].region;

                dt.Rows.Add(row);
            }

            CovidDataGrid.ItemsSource = dt.DefaultView;
           
        }

        // Windows first load
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.FillingDataGrid();
            CovidDataGrid.SelectedIndex = 0;
            FilterTheItemsInTheDataGrid();
        }

        // Country search bar changed
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dt != null)
            {
                FilterTheItemsInTheDataGrid();
            }
        }

        // To display charts based on selected row of datagrid
        private void CovidDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // if nothing is selected return
            int idx = CovidDataGrid.SelectedIndex;
            if ((idx) == -1) return;

            // get selected rows
            var rows = CovidDataGrid.SelectedItems;
            int rowCount = rows.Count;

            // data for graphs
            int confirmed = 0;
            int deaths = 0;
            int recovered = 0;
            int newconfirmed = 0;
            int newdeaths = 0;
            int newrecovered = 0;

            for (int i = 0; i < rowCount; i++)
            {
                DataRow row = ((DataRowView)rows[i]).Row;

                confirmed += (int)row[1];
                deaths += (int)row[2];
                recovered += (int)row[3];

                newconfirmed += (int)row[5];
                newdeaths += (int)row[6];
                newrecovered += (int)row[7];
            }

            // For country name part at the top
            if (rowCount == 1){ CountryNameLabel.Content = ((DataRowView)rows[0]).Row[0]; }
            else{ CountryNameLabel.Content = "Multiple Countries"; }

            // Finally assign the data to charts
            SeriesCollection_total[0].Values = new ChartValues<int> { confirmed, deaths, recovered };
            SeriesCollection_new[0].Values = new ChartValues<int> { newconfirmed, newdeaths, newrecovered };

        }

        // For the textbox to get only numerical values.
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // Filter the values in datagrid based on filter options
        private void FilterTheItemsInTheDataGrid()
        {

            // expression to be used as rowfilter.
            string theExpression = "";

            if (SearchBar.Text.Length > 0)
            {
                theExpression += string.Format("Country LIKE '{0}%'", SearchBar.Text);
            }

            if (isFiltering)
            {
                if (theExpression.Length > 0){ theExpression += " AND "; }

                string valueString = compareValue.Text.Length > 0 ? compareValue.Text : 0.ToString();
                int compType = compareComboBox.SelectedIndex;
                string elementName = (string)((ComboBoxItem)comboBox.SelectedItem).Content;

                theExpression += "(" + elementName + ")";
                switch (compType)
                {
                    case 0:
                        theExpression += ">";
                        break;
                    case 1:
                        theExpression += "=";
                        break;
                    case 2:
                        theExpression += "<";
                        break;
                    default:
                        break;
                }
                theExpression += valueString;
            }

            dt.DefaultView.RowFilter = theExpression;

            if (filterNresults.Text.Length > 0 && int.Parse(filterNresults.Text) > 0)
            {
                CovidDataGrid.ItemsSource = dt.DefaultView.Cast<DataRowView>().Take(int.Parse(filterNresults.Text));
            }
            else
            {
                CovidDataGrid.ItemsSource = dt.DefaultView;
            }

            // always select first item of list instead of nothing.
            CovidDataGrid.SelectedIndex = 0;
        }

        // Filter button activate and deactivate button. Button works like a checkbox.
        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            isFiltering = !isFiltering;

            if (isFiltering)
            {
                filterButton.Background = activeBrush;
                filterButton.BorderBrush = activeBrush;
            }
            else
            {
                //#FF673AB7
                filterButton.Background = inactiveBrush;
                filterButton.BorderBrush = inactiveBrush;
            }

            FilterTheItemsInTheDataGrid();
        }

        // the type of column for filtering
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isFiltering)
            {
                FilterTheItemsInTheDataGrid();
            }
        }

        // compare type of filtering ( > < = )
        private void compareComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isFiltering)
            {
                FilterTheItemsInTheDataGrid();
            }
        }

        // compare value of filtering
        private void compareValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isFiltering)
            {
                FilterTheItemsInTheDataGrid();
            }
        }

        // Show first n results
        private void filterNresults_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterTheItemsInTheDataGrid();
        }
    }
}
