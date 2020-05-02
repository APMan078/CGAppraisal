﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userDetails.aspx.cs" Inherits="SampleApp.settings.userDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 
        <div class="form-horizontal">
    <div class="form-group">
    <h3 class="col-md-5">PAYMENT DETAILS</h3>  
    </div>
    <hr />
     <div class="form-group">
        <h4><asp:Label ID="Label1" runat="server" Text="First name:" CssClass="control-label col-md-2"></asp:Label></h4> 
            <div class="col-md-10">
                <asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please input firstname" ControlToValidate="txtFirstname"></asp:RequiredFieldValidator>
            </div>
    </div> 

    <div class="form-group">
        <h4><asp:Label ID="Label2" runat="server" Text="Middle name:" CssClass="control-label col-md-2"></asp:Label></h4> 
            <div class="col-md-10">
                <asp:TextBox ID="txtMiddlename" runat="server" CssClass="form-control"></asp:TextBox> 
            </div>
    </div> 

    <div class="form-group">
        <h4><asp:Label ID="Label3" runat="server" Text="Last name:" CssClass="control-label col-md-2"></asp:Label></h4> 
            <div class="col-md-10">
                <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Please input lastname" ControlToValidate="txtLastname"></asp:RequiredFieldValidator>
            </div>
    </div> 
         <%-- for  if checker and approer --%>
    <hr /> 
            
    <div class="form-group">
        <h4><asp:Label ID="Label4" runat="server" Text="SHOW IN SELECTION" CssClass="control-label col-md-2"></asp:Label></h4> 
            <div class="col-md-10">
                <asp:CheckBox ID="chkPreparedBy" runat="server" Checked="true" CssClass="form-check col-md-2" Text="Prepared by"></asp:CheckBox>
                <asp:CheckBox ID="chkNotedBy" runat="server" Checked="true" CssClass="form-check col-md-2" Text="Noted By"></asp:CheckBox>
            </div>
    </div> 
    <hr />

            
     <%-- for  user access --%>
    <hr /> 
    <div class="form-group">
        <h3 class="col-md-5">USER ACCESS</h3>  
    </div>  
    <hr />



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
            <asp:Button ID="btnBackToList" runat="server" Text="Back to List" CssClass="btn btn-danger"  OnClientClick="return confirm('Back to list?');" OnClick="btnBackToList_Click"  /> 
        </div>
    </div>
</div>
</asp:Content>