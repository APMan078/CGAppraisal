<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="appraisalDetails.aspx.cs" Inherits="SampleApp.transaction.appraisalDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="appraisalItem" runat="server">
        <%--Form control --%>
        <ContentTemplate>

            <div class="form-group">
                <h3 class="col-md-5">APPRAISAL (<asp:Label ID="lblIsEdit" runat="server" CssClass="control-label"></asp:Label>)</h3>
            </div>

            <hr />
            <asp:Label ID="lblHidden" runat="server" Text=""></asp:Label>
            <ajaxToolkit:ModalPopupExtender ID="mpePopUp" runat="server" TargetControlID="lblHidden" PopupControlID="divPopUp" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
            <div id="divPopUp" class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">

                        <h5 class="modal-title" id="exampleModalLongTitle">Error Message</h5>

                        <div id="main" class="modal-body">


                            <asp:Label ID="lblText" runat="server" CssClass="text-danger" Text=""></asp:Label>

                        </div>

                        <div id="modal-footer">
                            <div id="DivbtnOK" class="buttonOK">
                                <asp:Button ID="btnOk" runat="server" Text="Ok" CssClass="btn btn-default" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>



            <div class="container">
                <div class="form-group">
                    <div class="col-md-4">
                        <h3>Basic Information</h3>
                        <p>(*) Required Field</p>
                    </div>
                </div>
            </div>

            <div id="mainContainer" class="container">
                <div class="form-group">
                    <div class="col-md-4">
                        <label for="inputdefault">Batch Reference:</label>
                        <asp:TextBox ID="txtBatchReference" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row">
                    <div class="col-md-6">
                        <label for="txtAccountName" class="control-label">*Account Name:</label>
                        <asp:TextBox ID="txtAccountName" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>

                    </div>
                    <div class="col-md-6">
                        <label for="txtCompanyName">Company Name:</label>
                        <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>

                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-12">
                        <label for="txtPropertyLocation" class="control-label">*Property Location:</label>
                        <asp:TextBox ID="txtPropertyLocation" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>

                    </div>
                </div>

                <div class="form-group row">
                    <div class="col-md-6">
                        <label for="txtTCTNo" class="control-label">TCT No.:</label>
                        <asp:TextBox ID="txtTCTNo" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>

                    </div>
                    <div class="col-md-6">
                        <label for="txtTotalArea">*Total Area:</label>
                        <asp:TextBox ID="txtTotalArea" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>

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
                    <asp:Button ID="btnAddRowItems" runat="server" Text="Add Item" CssClass="btn btn-primary" OnClick="btnAddRowItems_Click" />
                </div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cbAppraisalItem" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="container">
                <asp:GridView ID="grdItems" runat="server" DataKeyNames="RowNo" AutoGenerateColumns="false" CssClass="table table-striped" OnRowDeleting="grdItems_RowDeleting">
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
            <h3>Payment Details</h3>
            <div class="container">
                <div class="col-md-2">
                    <asp:Button ID="btnAddRow" runat="server" OnClick="btnAddRow_Click" Text="Add Payment Details" CssClass="btn btn-primary" />
                </div>
                <div class="col-md-5">
                    <asp:CheckBox ID="chkWithVat" runat="server" CssClass="form-check-input" AutoPostBack="True" OnCheckedChanged="chkWithVat_CheckedChanged" />
                    <label class="form-check-label" for="chkWithVat">With Vat</label>
                </div>
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
                <div class="container">
                    <div class="col-md-9">
                        
                    </div>
                    <div class="col-md-3"> 
                        <asp:Label ID="lblWithVat" runat="server" Text=""></asp:Label>
                    </div>
                </div>

            </div>
            <br />
            <div class="container">
                <div class="form-group">
                    <%--<asp:Button ID="btnNext" runat="server" Text="Save" CssClass="btn btn-success" OnClientClick="return confirm('Are you sure you want to save this record?');"  OnClick="btnSave_Click" />--%>
                    <asp:Button ID="btnNext" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
                    <asp:Button ID="btnBackToList" runat="server" Text="Back to List" CssClass="btn btn-danger" OnClick="btnBackToList_Click" />
                </div>
            </div>


        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddRowItems" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnNext" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnBackToList" EventName="Click" />


            <asp:AsyncPostBackTrigger ControlID="btnAddRow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnOk" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
