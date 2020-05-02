﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="appraisal.aspx.cs" Inherits="SampleApp.transaction.appraisal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
        <div class="form-horizontal">
             <div class="form-group">
                <h3 class="col-md-5">PAYMENT</h3>
            </div>
            
            <hr />

            <div class="form-group">
                <span class=" col-md-2">
                <asp:LinkButton ID="createPayment" runat="server"  >Create Payment Details</asp:LinkButton>
                </span>
            </div>
            <br />
            <div class="form-group">                
                <span class="col-md-4">
                   Keyword:
                    <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control"></asp:TextBox> 
                </span> 
                 <div class="col-md-2">
                     <br />
                     <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-success"  />
                 </div>
            </div>
        </div>

        <asp:ListView ID="lvItems" runat="server" GroupPlaceholderID="groupPlaceHolder1"
            ItemPlaceholderID="itemPlaceHolder1" >
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
                         <asp:LinkButton ID="btnupdt" runat="server" Text="Edit" CssClass="btn btn-primary" tooltip="Update a record" 
                             CommandName="EmpEdit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' >
                        <i class="glyphicon glyphicon-edit" aria-hidden="true"></i>
                         </asp:LinkButton>
                    </th>  
                    <th scope="row">
                        <%# Eval("RowNo").ToString() %>
                    </th> 
                    <td> 
                        <%# Convert.ToDateTime(Eval("DateEncoded")).ToString("MM/dd/yyyy hh:mm tt") %>
                    </td>
                    <td>
                        <%# Eval("Name").ToString() %>
                    </td> 
                    <td>
                        <%# Eval("IsActive").ToString().ToLower() == "false" ? "INACTIVE" : "ACTIVE" %>
                    </td> 
                </tr>
            </ItemTemplate>
        </asp:ListView>
         

        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>