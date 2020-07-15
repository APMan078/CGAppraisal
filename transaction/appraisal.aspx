<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="appraisal.aspx.cs" Inherits="SampleApp.transaction.appraisal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
        <div class="form-horizontal">
             <div class="form-group">
                <h3 class="col-md-5">Appraisal</h3>
            </div>
            
            <hr />
            <div class="form-group">
                <span class=" col-md-2">
                <asp:LinkButton ID="createItem" runat="server" OnClick="createItem_Click"  >Create Appraisal Details</asp:LinkButton>
                </span>
            </div>
            <br />

             <div class="form-group">
                <span class="control-label col-md-2">
                    Date From:
                </span>

                <div class="col-md-2">
                    <asp:TextBox ID="txtfrom" runat="server" CssClass="form-control" ReadOnly></asp:TextBox>
                    <asp:LinkButton ID="lbfrom" runat="server" onclick="lbfrom_Click">PickDate...</asp:LinkButton>
                   <asp:Calendar ID="clndrfrom" runat="server" Visible="False" OnSelectionChanged="clndrfrom_SelectionChanged"></asp:Calendar>
                </div>

                 <span class="control-label col-md-2">
                    Date To:
                </span>
                 <div class="col-md-2">
                    <asp:TextBox ID="txtto" runat="server" CssClass="form-control" ReadOnly></asp:TextBox>
                    <asp:LinkButton ID="LinkButton2" runat="server" onclick="lbto_Click">PickDate...</asp:LinkButton>
                   <asp:Calendar ID="clndrto" runat="server" Visible="False" OnSelectionChanged="clndrto_SelectionChanged"></asp:Calendar>
                </div>
                 
            </div>

          
            <div class="form-group">      
                <span class="control-label col-md-2">Keyword:</span>
                <span class="col-md-2"> 
                    <asp:TextBox ID="txtKeyword" runat="server" class="form-control"></asp:TextBox> 
                </span> 
                 <span class="col-md-2">
                     <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btnsearch_Click"/>
                 </span>
                 
            </div>
        </div>

        <asp:ListView ID="lvItems" runat="server" GroupPlaceholderID="groupPlaceHolder1"
            ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="lvItems_PagePropertiesChanging" >
            <LayoutTemplate>
            <div class="table-responsive-sm">
            <table class="table">
                <caption>List of Bank</caption>
                <thead class="table-primary">
                    <tr>
                        <th class="col-1" scope="col">

                        </th>  
                        <th scope="col">#</th>
                        <th scope="col">DATE ENCODED</th> 
                        <th scope="col">NAME</th>
                        <th scope="col">STATUS</th>
                    </tr>
               </thead>
                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                    <tr>
                        <td colspan = "6">
                            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvItems" PageSize="50" Visible ="true">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                        ShowNextPageButton="false" />
                                    <asp:NumericPagerField ButtonType="Link" />
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" 
                                        ShowLastPageButton="false" ShowPreviousPageButton = "false" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </div>
            </LayoutTemplate>
            <GroupTemplate>
                <tr>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <tr>
                    <th class="row">  
                         <asp:LinkButton ID="btnupdt" runat="server" Text="Edit" CssClass="btn btn-primary" tooltip="Edit and View" 
                             CommandName="EmpEdit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' >
                        <i class="glyphicon glyphicon-edit" aria-hidden="true"></i>
                         </asp:LinkButton>

                         <asp:LinkButton ID="LinkButton1" runat="server" Text="Edit" CssClass="btn btn-primary" tooltip="Print" 
                             CommandName="EmpEdit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' >
                        <i class="glyphicon glyphicon-print" aria-hidden="true"></i>
                         </asp:LinkButton>
                    </th>  
                    <th scope="row">
                        <%# Eval("RowNo").ToString() %>
                    </th> 
                    <td> 
                        <%# Convert.ToDateTime(Eval("DateEncoded")).ToString("MM/dd/yyyy hh:mm tt") %>
                    </td>
                    <td>
                        <%-- barch reference --%> 
                    </td> 
                    <td>
                        <%# Eval("IsActive").ToString().ToLower() == "false" ? "INACTIVE" : "ACTIVE" %>
                    </td> 
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
               <table class="emptyTable" cellpadding="5" cellspacing="5">
                <tr>
                  <td> 
                  </td>
                  <td>
                    No record(s) Found.
                  </td>
                </tr>
              </table>
            </EmptyDataTemplate>
        </asp:ListView>
         

        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>
