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

            string queryString = "select * from [Case]";
            OleDbConnection connection = new OleDbConnection(strDSN);

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(queryString, connection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TableRow tRow = new TableRow();
                    TableCase.Rows.Add(tRow);

                    for (int i = 0; i<11; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                TableCell tCell = new TableCell();
                                tCell.Text = reader.GetValue(i).ToString();
                                tRow.Cells.Add(tCell);
                                break;
                                /*
                            case 4:
                                tCell = new TableCell();
                                tCell.Text = reader.GetDateTime(i).ToString();
                                break;
                            case 8:
                                tCell = new TableCell();
                                tCell.Text = reader.GetDateTime(i).ToString();
                                break;
                            case 11:
                                tCell = new TableCell();
                                tCell.Text = reader.GetDateTime(i).ToString();
                                break;
                                */
                            default:
                                tCell = new TableCell();
                                tCell.Text = reader.GetString(i);
                                tRow.Cells.Add(tCell);
                                break;

                        }
                    }
                }
                reader.Close();            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}