<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstPasswordReset.aspx.cs" Inherits="PR.FirstPasswordReset" MasterPageFile="~/_layouts/15/errorv15.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
	<link rel="stylesheet" href="/_layouts/15/PR/Css/FirstPasswordReset.css" />
 
   <style>
  #ms-error-content {
    background-color: rgba(245,245,245, 0.8);
    width: 600px;
    height: 500px;
    padding-left: 30px;
    padding-top: 20px;
    border-radius: 10px;
}
   </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    
<div class="container">
  <form>
  <div id="failuretext" runat="server" ></div>
    <div class="row">
      <div class="col-25">
        <sharepoint:encodedliteral runat="server" text="Old Password" encodemethod='htmlencode'/>
      </div>
      <div class="col-75">
        <asp:textbox id="Oldpassoword" placeholder="Enter Email Password" autocomplete="off" runat="server" class="ms-inputuserfield"/>
      </div>
    </div>
    <div class="row">
      <div class="col-25">
        <sharepoint:encodedliteral  runat="server" text="New Password" encodemethod='htmlencode'/>
      </div>
      <div class="col-75">
        <asp:textbox  id="Newpassword" placeholder="Enter New Password" textmode="password" autocomplete="off" runat="server" class="ms-inputuserfield" />
      </div>
    </div>
       <div class="row">
      <div class="col-25">
        <sharepoint:encodedliteral  runat="server" text="Re-Enter Password" encodemethod='htmlencode'/>
      </div>
      <div class="col-75">
        <asp:textbox id="Re_Enterpassword" placeholder="Enter New Password" textmode="password" autocomplete="off" runat="server" class="ms-inputuserfield" />
          <div class="col-25">
          <asp:CompareValidator runat="server" ControlToCompare="Newpassword" ControlToValidate="Re_Enterpassword" ErrorMessage="Passwords do not match." ForeColor="Red" Display="Dynamic">
          </asp:CompareValidator>
          </div>
      </div>
           
    </div>
    <div >
      <asp:button id="SubmitButton" Text="Submit" OnClick="ResetP_Onclick" CssClass="btn" runat="server" />
    </div>
  </form>
</div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
First Reset Password
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >	
    
</asp:Content>