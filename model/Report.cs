using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Xaml.Schema;

namespace ReportesDane.model
{
    class DataAdministrator
    {
        public DataAdministrator() { 

        }

        public DataTable GetDataTable(String path) {

            List<List<String>> data = ReadData(path);
            DataTable dt = new DataTable();

            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Region";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Codigo Departamento";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Departamento";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Codigo Municipio";
            dt.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Municipio";
            dt.Columns.Add(column);

            for (int i = 0; i < data.Count; i++) {

                row = dt.NewRow();

                row["Region"] = data[i][0];
                row["Codigo Departamento"] = data[i][1];
                row["Departamento"] = data[i][2];
                row["Codigo Municipio"] = data[i][3];
                row["Municipio"] = data[i][4];

                dt.Rows.Add(row);

            }


            return dt;
        }

        private List<List<String>> ReadData(String path) {

            StreamReader reader = new StreamReader(path);

            List<List<String>> temp = new List<List<string>>();



            while (!reader.EndOfStream) {

                String line = reader.ReadLine();
                
                String[] dataItem = line.Split(",");
                if (!dataItem[0].Equals("REGION")) {
                    List<String> item = new List<string>();
                    for (int i = 0; i < dataItem.Length; i++)
                    {
                        item.Add(dataItem[i]);
                    }
                    temp.Add(item);
                }               
            }
            return temp;
        }
    }
}
