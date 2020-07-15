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
                <asp:TextBox ID="txtBatchReference" runat="server" CssClass="form-control"></asp:TextBox> 
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
        <asp:GridView ID="grdItems" runat="server" DataKeyNames="Items" AutoGenerateColumns="false" class="table">
        <Columns>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:LinkButton ID="btnupdt" runat="server" Text="Edit" CssClass="btn btn-delete" tooltip="Delete" 
                                CommandName="EmpEdit"  >
                        <i class="glyphicon glyphicon-delete" aria-hidden="true"></i>
                            </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Period">
            <ItemTemplate>
                <asp:TextBox ID="txtItems" runat="server" Text='<%# Eval("Items") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>

        </Columns>
        </asp:GridView>
        <asp:Button ID="btnAddRow" runat="server" OnClick="btnAddRow_Click" Text="Add Items" />
    </div>

    <hr /> 
     <h3>Payment Details</h3>  
    

    <div class="container">
        <div class="form-group row">
            <div class="col-md-12">
                <div class="col-md-4">
                     <label for="txtTimeTable" class="control-label">Time table:</label> 
                     <asp:TextBox ID="txtTimeTable" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>  
                </div>
                <div class="col-md-1">
                     <label for="CheckBox1" class="control-label"></label> 
                    <asp:CheckBox ID="CheckBox1" runat="server" CssClass="checkbox" Text="Vat"/>
                    
                </div>
            </div>  
        </div>

        <asp:GridView ID="GridView1" runat="server" DataKeyNames="PayScale" AutoGenerateColumns="false" class="table">
        <Columns>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:LinkButton ID="btnupdt" runat="server" Text="Edit" CssClass="btn btn-delete" tooltip="Delete" 
                                CommandName="EmpEdit"  >
                        <i class="glyphicon glyphicon-delete" aria-hidden="true"></i>
                            </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Description">
            <ItemTemplate>
                <asp:TextBox ID="txtItems" runat="server" Text='<%# Eval("items") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
         
        </Columns>
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" OnClick="btnAddRow_Click" Text="Add Row" />
    </div>


    <div class="container"> 
        <div class="form-group">  
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClientClick="return confirm('Are you sure you want to save this record?');"  OnClick="btnSave_Click" />
            <asp:Button ID="btnBackToList" runat="server" Text="Back to List" CssClass="btn btn-danger"/>  
        </div>
    </div> 
</asp:Content>
