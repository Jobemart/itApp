using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Web.Security;
using System.Security.Principal;

namespace itApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String adPath = "LDAP://bcn.pidcgroup.com";

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
                    String groups = adAuth.GetGroups();

                    //Create the ticket, and add the groups.
                    //bool isCookiePersistent = chkPersist.Checked;
                    bool isCookiePersistent = true;
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, username,
                  DateTime.Now, DateTime.Now.AddMinutes(60), isCookiePersistent, groups);

                    //Encrypt the ticket.
                    String encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    //Create a cookie, and then add the encrypted ticket to the cookie as data.
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                    if (true == isCookiePersistent)
                        authCookie.Expires = authTicket.Expiration;

                    //Add the cookie to the outgoing cookies collection.
                    Response.Cookies.Add(authCookie);

                    //You can redirect now.
                    Response.Redirect("CaseQuestionnaire.aspx");
                }
                else
                {
                    Debug.WriteLine("Authentication did not succeed. Check user name and password.");
                }
            
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
    }
}