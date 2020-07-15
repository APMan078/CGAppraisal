<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="paymentDetails.aspx.cs" Inherits="SampleApp.settings.paymentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
    <div class="form-group">
    <h3 class="col-md-5">PAYMENT DETAILS</h3>  
    </div>
    <hr />
     <div class="form-group">
        <h4><asp:Label ID="Label1" runat="server" Text="Name:" CssClass="control-label col-md-2"></asp:Label></h4> 
            <div class="col-md-10">
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateUsername" runat="server" CssClass="text-danger" ErrorMessage="Please input name" ControlToValidate="txtName"></asp:RequiredFieldValidator>
            </div>
    </div> 
    <div class="form-group">
        <h4><asp:Label ID="Label2" runat="server" Text="Default Amount:" CssClass="control-label col-md-2"></asp:Label></h4> 
            <div class="col-md-10">
                <asp:TextBox ID="txtDefaultAmount" runat="server" CssClass="form-control" TextMode="Number" Text="0.00"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please input currency" ControlToValidate="txtDefaultAmount"></asp:RequiredFieldValidator> 
            </div>
    </div> 

    <div class="form-group">
        <div class="col-md-2"></div>
            <div class="col-md-10">
                <asp:CheckBox ID="isActive" runat="server" Checked="true" CssClass="form-check col-md-2" Text="Active"></asp:CheckBox>
            </div>
    </div> 
    <div class="container">
    <div class="col-md-2"></div>
        <div class="col-md-10">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success"  OnClientClick="return confirm('Do you want to save this item?');" OnClick="btnSave_Click"  />
            <asp:Button ID="btnBackToList" runat="server" Text="Back to List" CssClass="btn btn-danger"  OnClientClick="return confirm('Are you sure you want to save this record?');"  OnClick="btnBackToList_Click"  /> 
        </div>
    </div>
</div>
</asp:Content>
