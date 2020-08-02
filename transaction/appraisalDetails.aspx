<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="appraisalDetails.aspx.cs" Inherits="SampleApp.transaction.appraisalDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
    <div class="form-group">
    <h3 class="col-md-5">APPRAISAL (<asp:Label ID="lblIsEdit" runat="server" CssClass="control-label"></asp:Label>)</h3>   
    </div> 
    <hr /> 
    <h3>Basic Information</h3>  
    <div id= "mainContainer" class="container">  
        <div class="form-group">  
            <div class="col-md-4">
                <label for="inputdefault">Batch Reference:</label>
                <asp:TextBox ID="txtBatchReference" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox> 
            </div> 
        </div> 
        
        <div class="form-group row">
            <div class="col-md-6">
            <label for="txtAccountName" class="control-label">Account Name:</label> 
                <asp:TextBox ID="txtAccountName" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                
            </div>
             <div class="col-md-6">
                <label for="txtCompanyName">Company Name:</label>
                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" AutoCompleteType="Disabled" ></asp:TextBox> 
            </div>
        </div>

        <div class="form-group">
           <div class="col-md-12">
               <label for="txtPropertyLocation" class="control-label">Property Location:</label> 
               <asp:TextBox ID="txtPropertyLocation" runat="server" CssClass="form-control" AutoCompleteType="Disabled" ></asp:TextBox> 
            </div>
        </div>

         <div class="form-group row">
            <div class="col-md-6">
            <label for="txtTCTNo" class="control-label">TCT No.:</label> 
                <asp:TextBox ID="txtTCTNo" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                
            </div>
             <div class="col-md-6">
                <label for="txtTotalArea">Total Area:</label>
                    <asp:TextBox ID="txtTotalArea" runat="server" CssClass="form-control" AutoCompleteType="Disabled" ></asp:TextBox> 
            </div>

        </div>
          <div class="form-group row">
            <div class="col-md-6">
            <label for="txtTCTNo" class="control-label">Prepared By:</label> 
                <asp:DropDownList ID="ddPreparedBy" runat="server" CssClass="form-control"></asp:DropDownList> 
            </div>
             <div class="col-md-6">
                <label for="txtTotalArea">Noted By</label>
                 <asp:DropDownList ID="ddNotedBy" runat="server" CssClass="form-control"></asp:DropDownList> 
            </div>
        </div>
    </div>

     <%--payment details  --%>

     <hr /> 
    <h3>Items</h3>
    <div class="container">
        <div class="col-md-2">
            <asp:Button ID="btnAddRowItems" runat="server" Text="Add Item" CssClass="btn btn-primary" OnClick="btnAddRowItems_Click"/>
        </div>
        <div class="col-md-7"> 
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" ></asp:DropDownList> 
        </div> 
    </div>


    <br />
     <div class="container"> 
        <asp:GridView ID="grdItems" runat="server" DataKeyNames="RowNo" AutoGenerateColumns="false" CssClass="table table-striped" OnRowDeleting="grdItems_RowDeleting" >
        <Columns>         
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="#">
            <ItemTemplate>
                <asp:Label ID="lblRowNoItem" runat="server" Text='<%# Eval("RowNo") %>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField>
        
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Items">
            <ItemTemplate>
                <asp:TextBox ID="txtItem" runat="server" Text='<%# Eval("Item") %>' CssClass="form-control" autocomplete-="false"></asp:TextBox> 
            </ItemTemplate> 
        </asp:TemplateField> 

        <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        </asp:GridView>        
     </div>

     <hr /> 
     <h3>PaymentDetails</h3>  
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

        <asp:Button ID="btnAddRow" runat="server" OnClick="btnAddRow_Click" Text="Add Payment Details" CssClass="btn btn-primary"/>
     </div> 
    <br />
    <hr /> 
    <div class="container"> 
        <div class="form-group">  
            <%--<asp:Button ID="btnNext" runat="server" Text="Save" CssClass="btn btn-success" OnClientClick="return confirm('Are you sure you want to save this record?');"  OnClick="btnSave_Click" />--%>
            <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn btn-success"   OnClick="btnSave_Click" />
            <asp:Button ID="btnBackToList" runat="server" Text="Back to List" CssClass="btn btn-danger"/>  
        </div>
    </div> 
</asp:Content>
