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
using System.Data;

namespace ReportesDane
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Develop
        public MainWindow()
            
        {
            InitializeComponent();
        }


        private void buttonTest_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("REGION");
            dt.Columns.Add("CODIGO DANE");
            dt.Columns.Add("DEPARTAMENTO");
            dt.Columns.Add("CODIGO DANE EXACTO");
            dt.Columns.Add("MUNICIPIO");

            dt.Rows.Add("Region eje cafetero", "5", "Antioquia", "5.0001", "Metrellin");
            dt.Rows.Add("Region eje cafetero", "5", "Valle", "5.0002", "Carrera");
            dt.Rows.Add("Region eje cafetero", "5", "Cauca", "5.0003", "Sucia");
            dt.Rows.Add("Region eje cafetero", "5", "Amazonia", "5.0004", "Grande");
            dt.Rows.Add("Region eje cafetero", "5", "Antioquia", "5.0005", "Incasa");
            dt.Rows.Add("Region eje cafetero", "5", "Antioquia", "5.0006", "Luzo");
            
            /*
            DataTable dt2 = Filter(dt,"A");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.WriteLine(dt.Rows[i][j]);
                }
            }
            */

        }
        private DataTable Filter(DataTable dt, string comboBoxValue)
        {
            DataTable dv = dt;
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
    }
}
