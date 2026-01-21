<%@ Page Language="C#" Title="Bảng kê tiền điện" AutoEventWireup="true" CodeFile="BangKeTienDienDetail.aspx.cs" Inherits="BangKeTienDienDetail" %>
<%@ Register Assembly="DevExpress.XtraReports.v12.1.Web, Version=12.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sổ</title>
</head>
<body>
    <span id="hello" runat="server"></span>
    <form id="form1" runat="server">
        <div style="padding: 10px 5px 5px 10%">
            <dx:ReportToolbar Theme="Glass" ID="ReportToolbar1" runat='server' ShowDefaultButtons='False'
                Width="60%" ReportViewer="<%# reportSo %>">
                <Items>
                    <dx:ReportToolbarButton ItemKind='PrintReport' />
                    <dx:ReportToolbarButton ItemKind='PrintPage' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton Enabled='False' ItemKind='FirstPage' />
                    <dx:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' />
                    <dx:ReportToolbarLabel ItemKind='PageLabel' />
                    <dx:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'>
                    </dx:ReportToolbarComboBox>
                    <dx:ReportToolbarLabel ItemKind='OfLabel' />
                    <dx:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' />
                    <dx:ReportToolbarButton ItemKind='NextPage' />
                    <dx:ReportToolbarButton ItemKind='LastPage' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind='SaveToDisk' />
                    <dx:ReportToolbarButton ItemKind='SaveToWindow' />
                    <dx:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'>
                        <Elements>
                            <dx:ListElement Value='pdf' />
                            <dx:ListElement Value='xls' />
                            <dx:ListElement Value='xlsx' />
                            <dx:ListElement Value='png' />
                        </Elements>
                    </dx:ReportToolbarComboBox>
                </Items>
                <Styles>
                    <LabelStyle>
                        <Margins MarginLeft='3px' MarginRight='3px' />
                    </LabelStyle>
                </Styles>
            </dx:ReportToolbar>
            <br />
            <dx:ReportViewer Theme="Glass" ID="reportSo" runat="server" ClientInstanceName="reportSo" Width="100%">
            </dx:ReportViewer>
        </div>
    </form>
</body>
</html>
