<%@ Page Language="C#" Title="Biểu đồ băng thông" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="BieuDo.aspx.cs" Inherits="baocao.BaoCao_BieuDo" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script>
        $(function () {
            $('#txtTuNgay').datepicker(
            {
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                yearRange: '1950:2100',
                onSelect: function () {
                    var date = $.datepicker.formatDate('yymmdd', $(this).datepicker('getDate'));
                    $("#strTuNgay").val(date);

                }
            });
            $('#txtDenNgay').datepicker(
           {
               dateFormat: 'dd/mm/yy',
               changeMonth: true,
               changeYear: true,
               yearRange: '1950:2100',
               onSelect: function () {
                   var date = $.datepicker.formatDate('yymmdd', $(this).datepicker('getDate'));
                   $("#strDenNgay").val(date);
               }
           });

        })
        function xembieudo(tungay, denngay) {
            var txttungay = tungay.toString();
            var txtdenngay = denngay.toString();
            var strdate = txttungay.substring(6, 8) + "/" + txttungay.substring(4, 6) + "/" + txttungay.substring(0, 4);
            var strdate1 = txtdenngay.substring(6, 8) + "/" + txtdenngay.substring(4, 6) + "/" + txtdenngay.substring(0, 4);
            $("#txtTuNgay").val(strdate);
            $("#txtDenNgay").val(strdate1);
            $("#strTuNgay").val(tungay);
            $("#strDenNgay").val(denngay);
        }
    </script>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-xl-3 col-sm-6 mb-3">
                <label>
                    Chọn đơn vị:         
            <asp:DropDownList runat="server" ID="cmdSelectDonVi" CssClass="form-control" DataTextField="TEN" DataValueField="DON_VI_ID" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="cmdSelectDonVi_SelectedIndexChanged">
            </asp:DropDownList>
                </label>
            </div>
            <div class="col-xl-2 col-sm-6 mb-3">
                <label>
                    UPE: 
        <asp:DropDownList runat="server" ID="cmdSelectUPE" CssClass="form-control" DataTextField="UPE" DataValueField="UPE" AutoPostBack="True" OnSelectedIndexChanged="cmdSelectUPE_SelectedIndexChanged">
        </asp:DropDownList>
                </label>
            </div>
            <div class="col-xl-2 col-sm-6 mb-3">
                <label>
                    Cổng: 
        <asp:DropDownList runat="server" ID="cmdSelectPort" CssClass="form-control" DataTextField="PORT" DataValueField="PORT" AutoPostBack="True" OnSelectedIndexChanged="cmdSelectPort_SelectedIndexChanged" >
        </asp:DropDownList>
                </label>
            </div>
        </div>
        <div class="row">            
            <div class="col-xl-12 col-sm-6 mb-3">
               <p> Diễn Giải:<asp:Label ID="txtDienGiai" runat="server" ForeColor="#FF3300"></asp:Label></p>

            </div>
        </div>

        <div class="row">
            <div class="col-xl-3 col-sm-6 mb-3">
                <label>
                    Từ Ngày:
            <input type="text" id="txtTuNgay">
                    <input type="hidden" id="strTuNgay" name="strTuNgay" value="-1" />
                </label>
            </div>
            <div class="col-xl-3 col-sm-6 mb-3">
                <label>
                    Đến Ngày:
            <input type="text" id="txtDenNgay">
                    <input type="hidden" id="strDenNgay" name="strDenNgay" value="-1" />

                </label>
            </div>
        </div>
        <asp:Button ID="btnCompare" runat="server" Text="Xem Biểu Đồ" OnClick="XemBieuDo" CssClass="btn btn-primary" />
        <div class="form-group" style="clear: both;">
            <asp:Label ID="txtErr" runat="server" ForeColor="#FF3300"></asp:Label>
        </div>
        <hr />
        <asp:Chart ID="Chart1" runat="server" Width="950px" Height="500px"></asp:Chart>
    </div>
</asp:Content>
