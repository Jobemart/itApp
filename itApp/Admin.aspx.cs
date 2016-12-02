using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;

namespace itApp
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Table TableCase = (Table)FindControl("TableCase");
            string strDSN = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                    "Data Source =|DataDirectory|CaseList.accdb;" +
                    "Persist Security Info = False";

            string queryString = "SELECT * FROM [Case]";
            try
            {
                using (OleDbConnection connection = new OleDbConnection(strDSN))
                {
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TableRow tRow = new TableRow();
                        TableCase.Rows.Add(tRow);

                        for (int i = 0; i<10; i++)
                        {
                            if (i == 0)
                            {
                                TableCell tCell = new TableCell();
                                tCell.Text = reader.GetValue(i).ToString();
                                tRow.Cells.Add(tCell);
                            }
                            else
                            {
                                TableCell tCell = new TableCell();
                                tCell.Text = reader.GetString(i);
                                tRow.Cells.Add(tCell);
                            }
                        }
                
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source");
            }
        }
    }
}