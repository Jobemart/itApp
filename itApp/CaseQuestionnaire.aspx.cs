using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;
using System.Web.Security;
using System.Security.Principal;

namespace itApp
{
    public partial class CaseQuestionnaire : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            System.Web.UI.WebControls.TextBox TitleBox = (System.Web.UI.WebControls.TextBox)FindControl("TitleBox");
            System.Web.UI.WebControls.TextBox DescriptionBox = (System.Web.UI.WebControls.TextBox)FindControl("DescriptionBox");
            Calendar Deadline = (Calendar)FindControl("DeadlineCalendar");
            DropDownList Category = (DropDownList)FindControl("CategoryDropDownList");
            DropDownList Priority = (DropDownList)FindControl("PriorityDropDownList");


            if (TitleBox != null || DescriptionBox != null 
                || Deadline != null || Category != null || Priority != null)
            {

                string TitleCase = TitleBox.Text;
                string DescriptionCase = DescriptionBox.Text;
                string ApplicantCase = Context.User.Identity.Name;
                DateTime DeadlineCase = Deadline.SelectedDate;
                string CategoryCase = Category.Text;
                string PriorityCase = Priority.Text;

                if (TitleCase == "")
                { 
                    MessageBox.Show("Por favor, añade un título a la incidencia");
                }
                else
                {
                    addCaseToBD(TitleCase,DescriptionCase,ApplicantCase,DeadlineCase,CategoryCase,PriorityCase);
                }
            }
            else
            {
                Debug.WriteLine("No ha encontrado alguno de los componentes");
                MessageBox.Show("Error interno, por favor vuelve a probar más tarde");
            }
        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }



        protected void addCaseToBD(string TitleCase, string DescriptionCase, string ApplicantCase,
            DateTime DeadlineCase, string CategoryCase, string PriorityCase)
        {
            Debug.WriteLine(ApplicantCase);

            DateTime CreationDate = DateTime.Now;
            string StatusCase = "Pending";
            string ID = CreationDate.Month.ToString() + CreationDate.Day.ToString() +
                CreationDate.Minute + CreationDate.Second;

            string strDSN = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                    "Data Source =|DataDirectory|CaseList.accdb;" +
                    "Persist Security Info = False";

            OleDbConnection newConn = new OleDbConnection(strDSN);
            try
            {
                newConn.Open();
                OleDbCommand newCmd = newConn.CreateCommand();
                newCmd.CommandText = "INSERT INTO [Case] ([ID],[Title],[Description],[Applicant],[DeadlineDate],[Category],[Priority],[CreationDate],[Status]) "+
                    "VALUES (@id, @title, @description, @applicant, @deadline, @category, @priority, @creationdate, @status)";
                newCmd.Parameters.AddRange(new OleDbParameter[]
                {
                        new OleDbParameter("@id", ID),
                        new OleDbParameter("@title", TitleCase),
                        new OleDbParameter("@description", DescriptionCase),
                        new OleDbParameter("@applicant", ApplicantCase),
                        new OleDbParameter("@deadline", DeadlineCase.ToString()),
                        new OleDbParameter("@category", CategoryCase),
                        new OleDbParameter("@priority", PriorityCase),
                        new OleDbParameter("@creationdate", CreationDate.ToString()),
                        new OleDbParameter("@status", StatusCase),
                });
                newCmd.ExecuteNonQuery();
                MessageBox.Show("Incidencia registrada con exito, anota esta ID: "+ID);
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