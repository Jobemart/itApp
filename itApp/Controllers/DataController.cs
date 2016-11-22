using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.Common;
using System.Data.OleDb;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace itApp.Controllers
{
    public class DataController : Controller
    {
        private static DbConnect conn;

        public DataController(){
            
        }

        public void DataBaseConnection()
        {
            int id = 123;
            String title = "aa";

            try
            {
                conn = new DbConnect();
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;"
                    +"Data source= C:/Users/j.benito.DPIDC/Documents/Visual Studio 2015/Projects/BBDD.accdb";

                DbCommand cmd = conn.CreateCommand();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO Prueba ([ID],[Title]) VALUES(@ID, @Title)";    
                
                DbParam idParam = new DbParam();
                idParam.ParameterName = "@ID";
                idParam.Value = id;

                DbParam titleParam = new DbParam();
                idParam.ParameterName = "@Title";
                idParam.Value = title;

                cmd.Parameters.Add(idParam);
                cmd.Parameters.Add(titleParam);

                cmd.Connection = conn;

                conn.Open();
                // Insert code to process data.
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to connect to data source");
            }
            finally
            {
                conn.Close();
            }
        }


    }

}
