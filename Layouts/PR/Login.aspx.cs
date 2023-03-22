using Microsoft.SharePoint;
using Microsoft.SharePoint.IdentityModel;
using Microsoft.SharePoint.WebControls;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IdentityModel.Tokens;
using System.Web.Security;
using System.Web.UI;

namespace PR
{
    public partial class Login : Page
    {
        private string connectionstr = ConfigurationManager.ConnectionStrings["SQLaspnetdb"].ConnectionString;
        //private string connectionstring = ConfigurationManager.ConnectionStrings["SQLaspnetdb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected bool Checkfirsttimelogon(string user)
        {
            
            try
            {

                string query = "SELECT FirstLogin from [aspnetdb].[dbo].[aspnet_Membership]  where UserId=(select [UserId] from [aspnetdb].[dbo].[aspnet_Users] where UserName=@UserName)";
                
                using (SqlConnection con = new SqlConnection(connectionstr))

                {
                    //Page.Response.Write("<script>console.log('" + "This is SQL Hello World! ==>" + user + "');</script>");
                    try
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand(query, con);
                        command.Parameters.AddWithValue("@UserName", user);
                        SqlDataReader sdr = command.ExecuteReader();
                        
                        while (sdr.Read())
                        {
                            bool FirstLogin = (bool)sdr["FirstLogin"];
                            
                            if (FirstLogin == true)
                            {
                                sdr.Close();
                                command.Dispose();
                                return true;

                            }

                        }

                    }

                    catch (Exception ex)
                    {
                        Page.Response.Write("<script>console.log('" + "This is SQL Email ==>" + ex + "');</script>");

                    }

                    con.Close();

                }


            }
            catch (Exception e)
            {
                Console.WriteLine("SQL update error");
            }
            return false;

        }

        [Obsolete]
        protected void Login_Onclick(object sender, EventArgs args)
        {
            //string membershipProviderName = "FBAMembershipProvider";
            //string roleProviderName = "FBARoleProvider";
            string user = username.Text;
            bool firstloginistrue = Checkfirsttimelogon(user);
            if (firstloginistrue)
            {
                Response.Redirect("/_layouts/15/PR/FirstPasswordReset.aspx?username=" + user);
            }
            else
            {
                Page.Response.Write("<script>console.log('" + "This is redirect home ==>" + user + "');</script>");

                if (Membership.ValidateUser(username.Text, password.Text))

                {
                    //SecurityToken token = SPSecurityContext.SecurityTokenForFormsAuthentication(
                    //new Uri(SPContext.Current.Web.Url),
                    //membershipProviderName,
                    //roleProviderName,
                    //username.Text,
                    //password.Text);
                    //SPFederationAuthenticationModule.Current.SetPrincipalAndWriteSessionToken(token);

                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        bool status = SPClaimsUtility.AuthenticateFormsUser(Context.Request.UrlReferrer, username.Text, password.Text);
                        if (status)
                        {
                            
                            Response.Redirect("/SitePages/Home.aspx");
                        }
                    });

                }
            }


        }
    }
}
