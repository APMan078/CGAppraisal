<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="appraisalDetailsPayment.aspx.cs" Inherits="SampleApp.transaction.appraisalDetailsPayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Payment Details</h3>
    <hr />
    <h4>Add Items</h4>

    <div class="container">  
        <ajaxToolkit:ComboBox ID="cbItem"  ItemInsertLocation="OrdinalValue" AutoPostBack="False" DropDownStyle="Simple" runat="server" Width="700"  CssClass="WindowsStyle"
                                        AppendDataBoundItems="True"  AutoCompleteMode="SuggestAppend"></ajaxToolkit:ComboBox>  

        <asp:Button ID="btnAddRowItems" runat="server" Text="Add Item" CssClass="btn btn-primary" OnClick="btnAddRowItems_Click"/> 
    </div>
    <br />
    <div class="container">
        <asp:GridView ID="grdPaymentDetails" runat="server" DataKeyNames="RowNo" AutoGenerateColumns="false" CssClass="table table-striped" OnRowDeleting="grdPaymentDetails_RowDeleting">
        <Columns> 
        
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="#">
            <ItemTemplate>
                <asp:Label ID="lblRowNo" runat="server" Text='<%# Eval("RowNo") %>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField>
        
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Payment Details">
            <ItemTemplate>
                <asp:TextBox ID="txtPaymentDetails" runat="server" Text='<%# Eval("PaymentDetails") %>' CssClass="form-control" autocomplete-="false"></asp:TextBox> 
            </ItemTemplate> 
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Amount">
            <ItemTemplate>
                <asp:TextBox ID="txtAmount" runat="server" Text='<%# Eval("Amount") %>' CssClass="form-control" TextMode="Number"></asp:TextBox>
            </ItemTemplate> 
        </asp:TemplateField>
        <asp:CommandField ShowDeleteButton="True" />

        </Columns>
        </asp:GridView>
    </div>

     <div class="container"> 
        <div class="form-group">  
            <asp:Button ID="btnNext" runat="server" Text="Save" CssClass="btn btn-success" OnClientClick="return confirm('Are you sure you want to save this record?');"   />
            <asp:Button ID="btnBackToList" runat="server" Text="Back to List" CssClass="btn btn-danger"/>  
        </div>
    </div> 
</asp:Content>
