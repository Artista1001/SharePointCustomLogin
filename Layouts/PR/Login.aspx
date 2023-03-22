<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PR.Login" MasterPageFile="~/_layouts/15/errorv15.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
	 <link rel="stylesheet" href="/_layouts/15/PR/Css/custom.css" />
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
	<div class="container">
    <form  id="signInControl"  >
					<layouttemplate>
					
				<asp:label id="failuretext" class="ms-error" runat="server" />
					<div class="Color"  align="left" >
					
					
					<div height="100px">
						
						<div height="50px" nowrap="nowrap"><sharepoint:encodedliteral runat="server" text="User name" encodemethod='htmlencode'/></div>

						<div height="80px" width="100%"><asp:textbox id="username" placeholder="Enter User Name" autocomplete="off" runat="server" class="ms-inputuserfield"/></div>
						
					</div>
					<div height="100px">
						
				
						<div height="50px" nowrap="nowrap"><sharepoint:encodedliteral runat="server" text="Password" encodemethod='htmlencode'/></div>
						
						<div height="50px" width="100%"><asp:textbox id="password" placeholder="Enter Password" textmode="password" autocomplete="off" runat="server" class="ms-inputuserfield" /></div>
					</div>
					<div>
						<div colspan="2" align="left"><asp:button OnClick="Login_Onclick" CssClass="btn" id="login" text="Sign In" commandname="login" runat="server" /></div>

					</div>
					<div>
						<div colspan="2" class="sign-me-auto"><asp:checkbox id="rememberme" text="<%$sphtmlencodedresources:wss,login_pagerememberme%>" runat="server" /></div>
					</div>
						
                    
					<div>
                        <div colspan="2" align="center" 
                        class="sign-in-bottom">If you are a windows user click 
						<a href="/_windows/default.aspx?ReturnUrl=%2f_layouts%2f15%2fAuthenticate.aspx%3fSource%3d%252F&Source=%2F">here</a> to sign in.
                        </div>
                    </div>
						<div colspan="2" align="center" 
                        class="sign-in-bottom"> 
						<a href="/_layouts/15/PR/ForgetPasswordReset.aspx">Forgot Password?</a>
                        </div>
					</div>
				
				
				</layouttemplate>
			  </form>
</div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Sign In
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
	

</asp:Content>
