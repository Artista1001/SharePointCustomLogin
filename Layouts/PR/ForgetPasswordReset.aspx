<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPasswordReset.aspx.cs" Inherits="PR.ForgetPasswordReset" MasterPageFile="~/_layouts/15/errorv15.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
	 <link rel="stylesheet" href="/_layouts/15/PR/Css/ForgetPasswordReset.css" />
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
	<div class="container">
				<form  id="signInControl">
					<layouttemplate>
						<asp:label id="failuretext" class="ms-error" runat="server" />
							<div class="Color"  align="left" >
							<%--<div class="logintitle" >
								Forget Password
							</div>--%>
								 <asp:Label id="Msg" runat="server" ForeColor="maroon" />
							<div height="100px">
								<%--<div height="50px" nowrap="nowrap"><input type="text" placeholder="Enter Username" name="username" value=""/><br></div--%>
								<div height="50px" nowrap="nowrap"><sharepoint:encodedliteral runat="server" text="Forgot Password" encodemethod='htmlencode'/></div>
								<div height="50px" nowrap="nowrap"><asp:TextBox ID="TextBox1" placeholder="Enter Username" runat="server"></asp:TextBox></div>
							</div>
								<div> <asp:Button ID="Button2" runat="server" class="btn" Text="Submit" OnClick="ResetPassword_OnClick" />
								<%--<asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button1_Click" />--%>
							</div>
							
					</layouttemplate>
			  </form>
	</div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Forgot Password
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">

</asp:Content>
