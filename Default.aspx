<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="form-horizontal">
        <div class="form-group">
        <h2 class="control-label col-md-2">Login</h2>
        </div>
        <hr />
        <div class="form-group">
            <h4><asp:Label ID="Label1" runat="server" Text="Username:" CssClass="control-label col-md-2"></asp:Label></h4> 
             <div class="col-md-10">
                 <asp:TextBox ID="txtusername" runat="server" CssClass="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="validateUsername" runat="server" CssClass="text-danger" ErrorMessage="Please input username" ControlToValidate="txtusername"></asp:RequiredFieldValidator>
             </div>
        </div>

         
        <div class="form-group">
            <h4><asp:Label ID="Label2" runat="server" Text="Password:" CssClass="control-label col-md-2"></asp:Label></h4> 
             <div class="col-md-10">
                 <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="validateLastname" runat="server" CssClass="text-danger" ErrorMessage="Please input password" ControlToValidate="txtpassword"></asp:RequiredFieldValidator>
             </div>
        </div>

        <div class="form-group">
             <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="btnlogin" runat="server" Text="Login" CssClass="btn btn-success" OnClick="btnlogin_Click" />
                 <br />
                  <h4><asp:Label ID="lblmsg" runat="server" Text="" CssClass="text-danger"></asp:Label></h4> 
             </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
