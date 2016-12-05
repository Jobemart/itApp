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

            int row = 0;

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

                    TableCell tCell = new TableCell();
                    System.Web.UI.WebControls.CheckBox chk = new System.Web.UI.WebControls.CheckBox();
                    chk.ID = "row_"+row.ToString();
                    tCell.Controls.Add(chk);
                    tRow.Cells.Add(tCell);

                    for (int i = 0; i<12; i++)
                    {
                        if( i == 0)
                        {
                            tCell = new TableCell();
                            tCell.Text = reader.GetValue(i).ToString();
                            tRow.Cells.Add(tCell);
                        }
                        else
                        {
                            tCell = new TableCell();
                            tCell.Text = reader.GetString(i);
                            tRow.Cells.Add(tCell);
                        }
                    }
                    row++;
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


        protected void btnAssign_Click(object sender, EventArgs e)
        {
            string strDSN = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                    "Data Source =|DataDirectory|CaseList.accdb;" +
                    "Persist Security Info = False";

            OleDbConnection newConn = new OleDbConnection(strDSN);


            Table TableCase = (Table)FindControl("TableCase");
            TableRowCollection Rows = TableCase.Rows;

            for ( int i = 0; i < Rows.Count; i++)
            {
                System.Web.UI.WebControls.CheckBox CheckBox = (System.Web.UI.WebControls.CheckBox) Rows[i].FindControl("row_" + i);
                if (CheckBox.Checked)
                {
                    try
                    {
                        newConn.Open();
                        OleDbCommand newCmd = newConn.CreateCommand();
                        newCmd.CommandText = "INSERT INTO [Case] ([Responsable])"
                            + "VALUES (@responsable)";
                        newCmd.Parameters.Add(new OleDbParameter("@responsable", Context.User.Identity.Name));
                        newCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error interno, por favor vuelve a probar más tarde");
                        Debug.WriteLine(ex.Message);
                    }
                    finally
                    {
                        newConn.Close();
                    }
                }
            }
        }


        protected void btnDone_Click(object sender, EventArgs e)
        {

        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}