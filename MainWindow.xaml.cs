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

        public MainWindow()
            
        {
            InitializeComponent();

        }

        private void Open_file_Click(object sender, RoutedEventArgs e)
        {
            ofd.Filter = "CSV (*.cvs)|*.csv";

            Nullable<bool> result = ofd.ShowDialog();

            if (result == true)
            {
                label.Content = ofd.FileName;

                dt = rep.GetDataTable(ofd.FileName);

                DataView view = new DataView(dt);

                dataDANE.ItemsSource = view;

            }
            
        }
    }
}
