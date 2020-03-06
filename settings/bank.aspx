<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bank.aspx.cs" Inherits="SampleApp.settings.bank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
        <div class="form-horizontal">
             <div class="form-group">
                <h3 class="col-md-5">BANK</h3>
            </div>
            
            <hr />

            <div class="form-group">
                <span class=" col-md-2">
                <asp:LinkButton ID="createBank" runat="server" OnClick="createBank_Click" >Create Bank</asp:LinkButton>
                </span>
            </div>
            <br />
            <div class="form-group">
                <span class=" col-md-2">
                    Date From:
                     <asp:TextBox ID="txtfrom" runat="server" CssClass="form-control" ReadOnly></asp:TextBox>
                    <asp:LinkButton ID="lbfrom" runat="server" OnClick="lbfrom_Click" >PickDate...</asp:LinkButton>
                   <asp:Calendar ID="clndrfrom" runat="server" Visible="False" OnSelectionChanged="clndrfrom_SelectionChanged"  ></asp:Calendar>
                </span>

                

                 <span class="col-md-2">
                    Date To:
                    <asp:TextBox ID="txtto" runat="server" CssClass="form-control" ReadOnly></asp:TextBox>
                    <asp:LinkButton ID="lbTo" runat="server"  onClick="lbTo_Click" >PickDate...</asp:LinkButton>
                   <asp:Calendar ID="clndrto" runat="server" Visible="False" OnSelectionChanged="clndrto_SelectionChanged" ></asp:Calendar>
                </span> 

                <span class="col-md-4">
                   Keyword:
                    <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control"></asp:TextBox> 
                </span> 
                 <div class="col-md-2">
                     <br />
                     <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-success"/>
                 </div>
            </div>
        </div>

        <asp:ListView ID="lvItems" runat="server" GroupPlaceholderID="groupPlaceHolder1"
            ItemPlaceholderID="itemPlaceHolder1"  >
            <LayoutTemplate>
            <table  class="table">
                <thead class="thead-dark">
                    <tr>
                        <th scope="col">

                        </th> 
                        <th scope="col">#</th>
                        <th scope="col">DATE ENCODED</th> 
                        <th scope="col">NAME</th>
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
            </LayoutTemplate>
            <GroupTemplate>
                <tr>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td>
                     <asp:Button ID="btndel" runat="server" Text="Delete" tooltip="Delete a record" 
                         onclientclick="javascript:return confirm('Are you sure to delete record?')" CommandName="EmpDelete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EmpID") %>' />  
                     <asp:Button ID="btnupdt" runat="server" Text="Edit" tooltip="Update a record" 
                         CommandName="EmpEdit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EmpID") %>' /> 
                </td> 
                <td>
                    <%# Eval("RowNo").ToString() %>
                </td> 
                <td>
                    <%# Convert.ToDateTime(Eval("DateEncoded")).ToString("MM/dd/yyyy hh:mm tt") %>
                </td>
                <td>
                    <%# Eval("Name").ToString() %>
                </td> 
            </ItemTemplate>
        </asp:ListView>
         

        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>
