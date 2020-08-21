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
            if (letters.SelectedItem.Equals("-"))
            {
                DataView view = new DataView(dt);
                dataDANE.ItemsSource = view;
            }
            else {

                DataTable tempTable = Filter(letters.SelectedItem.ToString());
                Console.WriteLine(letters.SelectedItem.ToString());
                DataView view = new DataView(tempTable);
                dataDANE.ItemsSource = view;

            }

        }
    }
}
