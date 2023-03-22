using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Configuration;

namespace PR
{
    public partial class FirstPasswordReset : Page
    {
        private string connectionstr = ConfigurationManager.ConnectionStrings["SQLaspnetdb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Newpassword.Text == Re_Enterpassword.Text)
            //{
            //    SubmitButton.Enabled = true;
            //}
            //else
            //{
            //    SubmitButton.Enabled = false;
            //}
        }

        public MembershipUser VerifyUsername(string username)
        {

            MembershipUserCollection uCol = Membership.GetAllUsers();


            MembershipUser Returnuser = null;
            foreach (MembershipUser membershipuser in uCol)
            {
              
                if (membershipuser.UserName == username)
                {
                    Returnuser = membershipuser;
                }
            }
            return Returnuser;
             
        }
        protected void ResetP_Onclick(object sender, EventArgs args)
        {
            string user = Request.QueryString["username"];
           
            MembershipUser u = VerifyUsername(user);

            try
            {

                if (u.ChangePassword(Oldpassoword.Text, Newpassword.Text))
                {
                    
                    string query = "update  [aspnetdb].[dbo].[aspnet_Membership] set FirstLogin=0 where UserId=(select [UserId] from [aspnetdb].[dbo].[aspnet_Users] where UserName=@UserName)";

                    using (SqlConnection con = new SqlConnection(connectionstr))
                    {
                        try
                        {
                            con.Open();
                            SqlCommand command = new SqlCommand(query, con);

                            command.CommandType = CommandType.Text;
                            command.Parameters.AddWithValue("@UserName", user);

                            command.ExecuteNonQuery();
                            command.Dispose();
                        }
                        catch (Exception ex)
                        {
                            failuretext.InnerHtml = "Inccorect Password entred or Please raise a ticket in https://hd.sar.com.sa through your business contact/personnel. ";
                            Page.Response.Write("<script>console.log('" + "This is error while updating db for first login user password change==>" + ex + "');</script>");
                        }
                        con.Close();

                    }
                    Response.Redirect("/_layouts/15/PR/Login.aspx");
                }
                else
                {
                    failuretext.InnerHtml = "Unknown error occurred ! Please raise a ticket in https://hd.sar.com.sa through your business contact/personnel.";
                }

            }
            catch (Exception e)
            {
                failuretext.InnerHtml = "Inccorect Password entred or Please raise a ticket in https://hd.sar.com.sa through your business contact/personnel. ";
      
            }

        }
    }
}
