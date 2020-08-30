<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="appraisalDetailsItem.aspx.cs" Inherits="SampleApp.transaction.appraisalDetailsItem" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Item</h3>
    <hr />
    <h4>Add Items</h4>

    <div class="container">  
      <%--  <div class="col-md-7">             
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" ></asp:DropDownList> 
             
            <ajaxToolkit:ComboBox ID="ComboBox1" AppendDataBoundItems="True" runat="server" CssClass="form-control"  MaxLength="0" >
            </ajaxToolkit:ComboBox> 
        </div> --%> 
         <ajaxToolkit:ComboBox ID="cbItem"  ItemInsertLocation="OrdinalValue" AutoPostBack="False" DropDownStyle="Simple" runat="server" Width="700"  CssClass="WindowsStyle"
                                        AppendDataBoundItems="True"  AutoCompleteMode="SuggestAppend"></ajaxToolkit:ComboBox>  

        <asp:Button ID="btnAddRowItems" runat="server" Text="Add Item" CssClass="btn btn-primary" OnClick="btnAddRowItems_Click"/> 
    </div>
    <br />
     <div class="container"> 
        <asp:GridView ID="grdItems" runat="server" DataKeyNames="RowNo" AutoGenerateColumns="false" CssClass="table table-striped" OnRowDeleting="grdItems_RowDeleting" >
        <Columns>         
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="#">
            <ItemTemplate>
                <asp:Label ID="lblRowNoItem" runat="server" Text='<%# Eval("RowNo") %>' Width="50" ></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField> 


         <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Item">
            <ItemTemplate>
                <asp:TextBox ID="txtItem" runat="server" Text='<%# Eval("Item") %>' CssClass="form-control" AutoCompleteType="None"></asp:TextBox>
            </ItemTemplate> 
        </asp:TemplateField>


        <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        </asp:GridView>        
     </div>

    <hr />
    <div class="container"> 
        <div class="form-group">  
            <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn btn-success" OnClientClick="return confirm('Are you sure you want to save this record?');" OnClick="btnNext_Click"   />
            <asp:Button ID="btnBackToList" runat="server" Text="Back to List" CssClass="btn btn-danger" OnClick="btnBackToList_Click"/>  
        </div>
    </div> 
</asp:Content>
