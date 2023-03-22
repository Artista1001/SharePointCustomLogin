using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.Web.Hosting.Administration;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Configuration;
using Microsoft.SharePoint.Mobile.WebControls;
using static Microsoft.SharePoint.Administration.Claims.SPSecurityTokenServiceConstants;
using System.Configuration.Provider;
using System.Web;
using System.Web.Mail;
using MailMessage = System.Net.Mail.MailMessage;
using System.Security.Authentication;

namespace PR
{
    public partial class ForgetPasswordReset : Page
    {
        //private string smtpuser = ConfigurationManager.AppSettings["SMTPUSERNAME"];
        //private string smtppassword = ConfigurationManager.AppSettings["SMTPPASSWORD"];
        private string smtpuser;
        private string smtppassword;
        private int eto;
        private int pfrom;
        private int pto;
        private string connectionstr = ConfigurationManager.ConnectionStrings["SQLaspnetdb"].ConnectionString;
        private string Mailconnectionstr = ConfigurationManager.ConnectionStrings["smtpEmail"].ConnectionString;
        private string smtpclient = ConfigurationManager.AppSettings["SmtpClient"];
        private string smtpname = ConfigurationManager.AppSettings["SMTPName"];
        private int PORT = Int32.Parse(ConfigurationManager.AppSettings["SMTPClientPort"]);

       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            eto = Mailconnectionstr.IndexOf(";Password=");
            pfrom = Mailconnectionstr.IndexOf(";Password=") + ";Password=".Length;
            pto = Mailconnectionstr.Length;
            smtpuser = Mailconnectionstr.Substring("email=".Length, eto-"email=".Length);
            smtppassword = Mailconnectionstr.Substring(pfrom, pto - pfrom);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write("button just clicked");
            //System.Diagnostics.Debug.WriteLine("This will be displayed in output window");

        }

        public MembershipUser VerifyUsername(string username)
        {

            MembershipUserCollection uCol = Membership.GetAllUsers();

            MembershipUser Returnuser = null;
            foreach (MembershipUser membershipuser in uCol)
            {
                Console.WriteLine(membershipuser.UserName);
                if(membershipuser.UserName == username)
                {
                   Returnuser = membershipuser;
                }
            }
            return Returnuser;
        }

        private void sendemail(MembershipUser user, string newPassword)
        {

            try
            {
                MailMessage newMail = new MailMessage();
                // use the Gmail SMTP Host
                SmtpClient client = new SmtpClient(smtpclient);
                
                // Follow the RFS 5321 Email Standard
                newMail.From = new MailAddress(smtpuser, smtpname);

                Attechemtn Oattachment = client.Add

                newMail.To.Add(user.Email);// declare the email subject

                newMail.Subject = "Hi, there your newly generated password for Sharepoint "; // use HTML for the email body

                newMail.IsBodyHtml = true;
                //newMail.Body = "<h4>Hi, there</h4></br><p>Your newly generated first time password is as per below</p></br></br><h1 text-align:center>"+newPassword+"</h1>";
                newMail.Body = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">

<head>
 	<style>
    
    .es-content{border-radius: 10px; border: 2px Solid #00778b; padding: 20px;}

</style>
    <meta charset=""UTF-8"">
    <meta content=""width=device-width, initial-scale=1"" name=""viewport"">
    <meta name=""x-apple-disable-message-reformatting"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta content=""telephone=no"" name=""format-detection"">
    <title></title>
    <!--[if (mso 16)]>
    <style type=""text/css"">
    a {text-decoration: none;}
    </style>
    <![endif]-->
    <!--[if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]-->
    <!--[if gte mso 9]>
<xml>
    <o:OfficeDocumentSettings>
    <o:AllowPNG></o:AllowPNG>
    <o:PixelsPerInch>96</o:PixelsPerInch>
    </o:OfficeDocumentSettings>
</xml>
  
</head>

<body>

    <div class=""es-wrapper-color"">
        <!--[if gte mso 9]>
			<v:background xmlns:v=""urn:schemas-microsoft-com:vml"" fill=""t"">
				<v:fill type=""tile"" color=""#f0f0f0""></v:fill>
			</v:background>
		<![endif]-->
        <table class=""es-wrapper"" width=""100%"" cellspacing=""0"" cellpadding=""0"">
            <tbody>
                <tr>
                    <td class=""esd-email-paddings"" valign=""top"">
                        <table cellpadding=""0"" cellspacing=""0"" class=""es-content esd-header-popover"" align=""center"">
                            <tbody>
                                <tr>
                                    <td class=""esd-stripe"" align=""center"" esd-custom-block-id=""147867"">
                                        <table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" width=""600"">
                                            <tbody>
                                                <tr>
                                                    <td class=""esd-structure es-p15t es-p15b es-p30r es-p30l"" align=""left"">
                                                        <!--[if mso]><table width=""540"" cellpadding=""0"" cellspacing=""0""><tr><td width=""257"" valign=""top""><![endif]-->
                                                        <table cellpadding=""0"" cellspacing=""0"" align=""left"" class=""es-left"">
                                                            <tbody>
                                                                <tr>
                                                                    <td width=""257"" class=""esd-container-frame"" align=""center"" valign=""top"">
                                                                        <table cellpadding=""0"" cellspacing=""0"" width=""100%"">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align=""left"" class=""esd-block-text es-infoblock es-m-txt-c"">
                                                                                        <img src=""https://www.eyeofriyadh.com/includes/image.php?image=/directory/images/2021/03/23b0a6a6d31fb.jpg&width=230&height=160"">
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <!--[if mso]></td><td width=""20""></td><td width=""263"" valign=""top""><![endif]-->
                                                        <table cellpadding=""0"" cellspacing=""0"" class=""es-right"" align=""right"">
                                                            <tbody>
                                                                <tr>
                                                                    <td width=""263"" align=""left"" class=""esd-container-frame"">
                                                                        <table cellpadding=""0"" cellspacing=""0"" width=""100%"">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align=""right"" class=""esd-block-text es-infoblock es-m-txt-c"">
                                                                                        <p><a target=""_blank"" class=""view"" href=" + HttpContext.Current.Request.Url.Authority + "/_layouts/15/PR/Login.aspx" + @"> Sign in</a></p>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <!--[if mso]></td></tr></table><![endif]-->
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"">
                            <tbody>
                                <tr>
                                    <td class=""esd-stripe"" align=""center"">
                                        <table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" width=""600"">
                                            <tbody>
                                                <tr>
                                                    <td class=""esd-structure es-p30"" align=""left"">
                                                        <table cellpadding=""0"" cellspacing=""0"" width=""100%"">
                                                            <tbody>
                                                                <tr>
                                                                    <td width=""540"" class=""esd-container-frame"" align=""center"" valign=""top"">
                                                                        <table cellpadding=""0"" cellspacing=""0"" width=""100%"">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align=""center"" class=""esd-block-image es-m-p30r es-m-p30l"" style=""font-size: 0px;""><a target=""_blank"">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align=""center"" class=""esd-block-text es-m-txt-c es-p20t"">
                                                                                        <h1>Welcome to SAR World</h1>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align=""center"" class=""esd-block-text es-p10t es-p20b es-m-txt-c"">
                                                                                        <p>&nbsp;Use the below password to sign in.</p>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width=""540"" class=""esd-container-frame"" align=""center"" valign=""top"">
                                                                        <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""border-left:2px dashed #0081ff;border-right:2px dashed #0081ff;border-top:2px dashed #0081ff;border-bottom:2px dashed #0081ff;border-radius: 12px; border-collapse: separate;"">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align=""center"" class=""esd-block-text es-p20t es-p20b es-m-txt-c"">
                                                                                        <h2 style=""font-family: -apple-system, blinkmacsystemfont, 'segoe ui', roboto, helvetica, arial, sans-serif, 'apple color emoji', 'segoe ui emoji', 'segoe ui symbol';"">" + newPassword + @"</h2>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </body>
            </html>";
                // enable SSL for encryption across channels
                

                client.EnableSsl = true;
                // Port 465 for SSL communication
                client.Port = PORT;
                // Provide authentication information with Gmail SMTP server to authenticate your sender account
                client.Credentials = new System.Net.NetworkCredential(smtpuser, smtppassword);

                client.Send(newMail); // Send the constructed mail
                Response.Redirect("success.html");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -" + ex);
                Msg.Text = "There is techical issue occur Please try again or Please raise a ticket in https://hd.sar.com.sa through your business contact/personnel.";
            }
        }

        private void Firsttimelog(string user)
        {
            

            try
            {
               
                string query = "update  [aspnetdb].[dbo].[aspnet_Membership] set FirstLogin=1 where UserId=(select [UserId] from [aspnetdb].[dbo].[aspnet_Users] where UserName=@UserName)";

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
                    catch(Exception ex)
                    {
                        Msg.Text = "There is techical issue occur Please try again or Please raise a ticket in https://hd.sar.com.sa through your business contact/personnel.";

                    }

                    con.Close();

                }
            }
            catch(Exception e)
            {
                Console.WriteLine("SQL update error");
            }
        }
        public void ResetPassword_OnClick(object sender, EventArgs args)
        {
            MembershipUser Founduser = VerifyUsername(TextBox1.Text);
          
            string user = TextBox1.Text;
            string newPassword;
            
            if (Founduser == null)
            {
                Msg.Text = "There is no account registered with username " + Server.HtmlEncode(user) + " Please try again or Please raise a ticket in https://hd.sar.com.sa through your business contact/personnel.";

                return;
            }

            try
            {
                newPassword = Founduser.ResetPassword();
            }
            catch (Exception e)
            {
                Msg.Text = e.Message;
                return;
            }

            if (newPassword != null)
            {
                Msg.Text = "Password sent to your registred mail.";
                Firsttimelog(user);
                sendemail(Founduser, newPassword);
            }
            else
            {
                Msg.Text = "Password reset failed or Please raise a ticket in https://hd.sar.com.sa through your business contact/personnel.";
            }
        }

    }
}
