using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Diagnostics;

namespace itApp
{
    public partial class CaseQuestionnaire : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            TextBox TitleBox = (TextBox) FindControl("TitleBox");
            if (TitleBox != null)
            {
                string TitleCase = TitleBox.Text;
                Debug.WriteLine(TitleCase);

                string strDSN = "Provider=Microsoft.ACE.OLEDB.12.0;"+
                    "Data Source =|DataDirectory|CaseList.accdb;"+
                    "Persist Security Info = False";

                OleDbConnection newConn = new OleDbConnection(strDSN);
                try
                {
                    newConn.Open();
                    OleDbCommand newCmd = newConn.CreateCommand();
                    newCmd.CommandText = "INSERT INTO [Case]([Title]) VALUES(@title)";
                    newCmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@title", TitleCase)
                    });
                    //OleDbCommand newCmd = new OleDbCommand("insert into Case(Title) values('" + TitleCase + "')");
                    newCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
 
                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    newConn.Close();
                }
            }
            else
            {
                Debug.WriteLine("No ha encontrado el textbox");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}