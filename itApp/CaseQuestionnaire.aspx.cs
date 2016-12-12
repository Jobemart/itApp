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
using System.Net.Mail;
using System.Net;

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
            RadioButtonList Department = (RadioButtonList)FindControl("DepartmentRadioButton");


            if (TitleBox != null || DescriptionBox != null || Department != null
                || Deadline != null || Category != null || Priority != null)
            {

                string TitleCase = TitleBox.Text;
                string DescriptionCase = DescriptionBox.Text;
                string ApplicantCase = Context.User.Identity.Name;
                string DeadlineCase = Deadline.SelectedDate.ToShortDateString();
                string CategoryCase = Category.Text;
                string PriorityCase = Priority.Text;
                string DepartmentCase = Department.SelectedItem.Text;

                addCaseToBD(TitleCase,DescriptionCase,ApplicantCase,DeadlineCase,CategoryCase,PriorityCase, DepartmentCase);

            }
            else
            {
                Debug.WriteLine("No ha encontrado alguno de los componentes");
                MessageBox.Show("Por favor, rellena todo los campos");
            }
        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }



        protected void addCaseToBD(string TitleCase, string DescriptionCase, string ApplicantCase,
            string DeadlineCase, string CategoryCase, string PriorityCase, string DepartmentCase)
        {

            DateTime CreationDate = DateTime.Now;
            string StatusCase = "Pending";
            string ResolvedDate = "null";
            string Responsable = "null";
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
                newCmd.CommandText = "INSERT INTO [Case] ([ID],[Title],[Description],[Applicant],[DeadlineDate],[Category],[Priority],[Department],[CreationDate],[Status],[ResolvedDate],[Responsable])"+
                    "VALUES (@id, @title, @description, @applicant, @deadline, @category, @priority, @department, @creationdate, @status, @resolved, @responsable)";
                newCmd.Parameters.AddRange(new OleDbParameter[]
                {
                        new OleDbParameter("@id", ID),
                        new OleDbParameter("@title", TitleCase),
                        new OleDbParameter("@description", DescriptionCase),
                        new OleDbParameter("@applicant", ApplicantCase),
                        new OleDbParameter("@deadline", DeadlineCase),
                        new OleDbParameter("@category", CategoryCase),
                        new OleDbParameter("@priority", PriorityCase),
                        new OleDbParameter("@department", DepartmentCase),
                        new OleDbParameter("@creationdate", CreationDate.ToString()),
                        new OleDbParameter("@status", StatusCase),
                        new OleDbParameter("@resolved", ResolvedDate),
                        new OleDbParameter("@responsable", Responsable),

                });
                newCmd.ExecuteNonQuery();
                MessageBox.Show("Incidencia registrada con exito, anota esta ID: "+ID);

                /* Desactivar protección de acceso */
                
                MailAddress fromAddress = new MailAddress("j.benito@winsystemsintl.com", "Joan");

                MailMessage message = new MailMessage();

                message.From = fromAddress;
                message.To.Add(new MailAddress("j.benito@winsystemsintl.com"));
                message.Subject = "Información de tu incidencia";
                message.Body = "Esta es la ID de tu incidencia "+TitleCase+":"+ID+"Creada el "+CreationDate.ToString();
                message.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.Host = "VSEX01.bcn.pidcgroup.com";
                client.Port = 25;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("j.benito@winsystemsintl.com", "cacafutilol1*");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = false;

                try
                {
                    client.Send(message);
                }
                catch (Exception exc)
                {
                    Debug.WriteLine(exc.Message + " " + exc.Data);
                }
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