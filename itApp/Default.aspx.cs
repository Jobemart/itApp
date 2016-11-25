using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace itApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String adPath = "LDAP://bcn.pidcgroup.com"; //Fully-qualified Domain Name
            //String adPath = "LDAP://vsdc01"; //Fully-qualified Domain Name
            TextBox UserNameBox = (TextBox)FindControl("UserBox");
            TextBox PasswordBox = (TextBox)FindControl("PasswordBox");
            string domain = "bcn.pidcgroup.com";
            string username = UserNameBox.Text;
            string password = PasswordBox.Text;
            LdapAuthentication adAuth = new LdapAuthentication(adPath);
            try
            {
                if (true == adAuth.IsAuthenticated(domain, username, password))
                {
                    Response.Redirect("CaseQuestionnaire.aspx");
                }
            }catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}