using Microsoft.Win32;
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
using ReportesDane.model;
using System.Data;
using LiveCharts;
using LiveCharts.Definitions.Series;
using LiveCharts.Wpf;
using System.Collections;

namespace ReportesDane
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Develop
        OpenFileDialog ofd = new OpenFileDialog();
        Report rep = new Report();
        DataTable dt;
        String selectedPath;

        public MainWindow()
            
        {
            InitializeComponent();
            letters.ItemsSource =  "-ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        }

        private void Open_file_Click(object sender, RoutedEventArgs e)
        {
            ofd.Filter = "CSV (*.cvs)|*.csv";

            Nullable<bool> result = ofd.ShowDialog();

            if (result == true)
            {
                label.Content = ofd.FileName;
                selectedPath = ofd.FileName;

                dt = rep.GetDataTable(ofd.FileName);

                DataView view = new DataView(dt);

                dataDANE.ItemsSource = view;

                initChart();
            }
            
            
        }

        private DataTable Filter(string comboBoxValue)
        {
            DataTable dv = dt.Copy();
            for (int i = dv.Rows.Count - 1; i >= 0; i--)
            {
                string cellValue = dv.Rows[i].Field<string>(2);
                if (!cellValue[0].Equals(char.Parse(comboBoxValue)))
                {
                    dv.Rows[i].Delete();
                }
                dv.AcceptChanges();
            }
            return dv;
        }

        private void letters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (label.Content.ToString().Length != 0)
            {

                if (letters.SelectedItem.ToString().Equals("-"))
                {
                    DataView view = new DataView(dt);
                    dataDANE.ItemsSource = view;

                    updateChart(dt);
                }
                else
                {

                    DataTable tempTable = Filter(letters.SelectedItem.ToString());
                    Console.WriteLine(letters.SelectedItem.ToString());
                    DataView view = new DataView(tempTable);
                    dataDANE.ItemsSource = view;

                    updateChart(tempTable);

                }
            }
            else
            {
                MessageBox.Show("Master, primero rotate la data. Todo bn.");

            }

        }

        public void piechartData_Loaded(Object sender, RoutedEventArgs e) {

        }

        public void initChart() {

            Hashtable cityCount = new Hashtable();
            
            for (int i = 1; i<dt.Rows.Count; i++) 
            {
                String region = dt.Rows[i].ItemArray[0].ToString();
                if (cityCount.ContainsKey(region))
                {
                    cityCount[region] = (int)cityCount[region] + 1;
                }
                else
                {
                    cityCount.Add(region, 1);
                }
            }
            
            /*
            foreach (DataRow dep in dt.Rows)
            {

                String region = dep.ItemArray[0].ToString();

                if (cityCount.ContainsKey(region))
                {

                    cityCount[region] = (int)cityCount[region] + 1;
                }
                else
                {
                    cityCount.Add(region, 1);
                }
            }
            */

            piechartData.Series.Clear();

            foreach (String key in cityCount.Keys)
            {
                IChartValues values = new ChartValues<int> { (int)cityCount[key] };
                ISeriesView series = new PieSeries { Title = key, DataLabels = true, Values = values };
                piechartData.Series.Add(series);
            }

        }

        public void updateChart(DataTable newData) {

            Hashtable cityCount = new Hashtable();

            for (int i = 1; i < newData.Rows.Count; i++)
            {
                String region = newData.Rows[i].ItemArray[0].ToString();
                if (cityCount.ContainsKey(region))
                {
                    cityCount[region] = (int)cityCount[region] + 1;
                }
                else
                {
                    cityCount.Add(region, 1);
                }
            }

            /*
            foreach (DataRow dep in newData.Rows)
            {

                String region = dep.ItemArray[0].ToString();

                if (cityCount.ContainsKey(region))
                {

                    cityCount[region] = (int)cityCount[region] + 1;
                }
                else
                {
                    cityCount.Add(region, 1);
                }
            }
            */

            piechartData.Series.Clear();

            foreach (String key in cityCount.Keys)
            {
                IChartValues values = new ChartValues<int> { (int)cityCount[key] };
                ISeriesView series = new PieSeries { Title = key, DataLabels = true, Values = values};
                piechartData.Series.Add(series);
            }
        }
    }
}
