<%@ Page Language="C#" Title="Nhập chỉ số" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="NhapChiSo.aspx.cs" Inherits="NhapChiSo" %>

<%@ Register Assembly="DevExpress.Web.v12.1, Version=12.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>

<asp:Content runat="server" ID="head" ContentPlaceHolderID="head">
    <script type="text/javascript">
        $(function () {
            $("#GirdViewNoPaGE tbody tr td input").keydown(function (e) {
                if (e.keyCode == 13) {
                    e.preventDefault();
                    // Báo chỉ số mới không thỏa mãn
                    let chiSoCu = $(this).parent().parent().find("input[id='lblCSCu']").val();
                    let chiSoMoi = $(this).val();
                    let heSo = $(this).parent().parent().find("span[id='lblheso']").text();
                    if (parseInt(chiSoMoi, 10) < parseInt(chiSoCu, 10)) {
                        alert('Chỉ số mới nhỏ hơn chỉ số cũ');
                    }
                    else {
                        let maCto = $(this).parent().parent().find("span[id='lblMaCT']").text();
                        var data = maCto + "|" + chiSoMoi+"|"+chiSoCu;
                        cbCapNhat.PerformCallback(data);
                        $(this).parent().parent().find("span[id='lblDienNangTT']").text((chiSoMoi - chiSoCu) * heSo);
                        $(this).parent().parent().next("tr").find("input").focus().select();
                    }
                }
                if (e.keyCode == 40) {
                    e.preventDefault();
                    // Báo chỉ số mới không thỏa mãn
                    //let chiSoCu = $(this).parent().parent().find("span[id='lblCSCu']").text();
                    let chiSoCu = $(this).parent().parent().find("input[id='lblCSCu']").val();
                    let chiSoMoi = $(this).val();
                    if (parseInt(chiSoMoi, 10) < parseInt(chiSoCu, 10)) {
                        alert('Chỉ số mới nhỏ hơn chỉ số cũ');
                    }
                    else {
                        $(this).parent().parent().next("tr").find("input").focus();
                    }
                }
                if (e.keyCode == 38) {
                    e.preventDefault();
                    let chiSoCu = $(this).parent().parent().find("input[id='lblCSCu']").val();
                    
                    let chiSoMoi = $(this).val();
                    if (parseInt(chiSoMoi, 10) < parseInt(chiSoCu, 10)) {
                        alert('Chỉ số mới nhỏ hơn chỉ số cũ');
                    }
                    else {
                        $(this).parent().parent().prev("tr").find("input").focus();
                    }
                }
                if (e.keyCode == 9) {
                    e.preventDefault();
                    if (parseInt(chiSoMoi, 10) < parseInt(chiSoCu, 10)) {
                        alert('Chỉ số mới nhỏ hơn chỉ số cũ');
                    }
                    else {
                        $(this).parent().parent().next("tr").find("input").focus();
                    }
                }
            })
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
            $('#txtKyHD').datepicker(
                {
                    dateFormat: 'mm/yy',
                    changeMonth: true,
                    changeYear: true,
                    yearRange: '1950:2100',
                    onSelect: function () {
                        var date = $.datepicker.formatDate('mm/yy', $(this).datepicker('getDate'));
                        $("#strKyHD").val(date);
                    }
                });

        })

        //Stop Form Submission of Enter Key Press
        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) { return false; }
        }
    </script>
</asp:Content>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-12">
        </div>
    </div>
    <div class="card mb-3">
        <div class="card-header">
            <div class="row">
                <div class="col-sm-3 mb-1">
                    <asp:DropDownList runat="server" ID="drpTram" DataValueField="id_tram_bien_ap" DataTextField="ten_tram_bien_ap" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-sm-3 mb-1">
                    <asp:DropDownList runat="server" ID="drpKy" DataValueField="id" DataTextField="ky" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-sm-6 mb-1">
                    <asp:Button ID="btnLaySL" runat="server" Text="Lấy số liệu" CssClass="btn btn-primary" OnClick="btnLaySL_Click" />
                    <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật số liệu" CssClass="btn btn-success" OnClick="btnCapNhat_Click" />
                    <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#addKyModal">Thêm Kỳ HĐ</button>
                </div>
            </div>
            <div class="row">
                <asp:Label runat="server" ID="lblErr"></asp:Label>
            </div>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GirdViewNoPaGE" ClientIDMode="Static" runat="server" CssClass="table table-striped table-bordered table-hover dataTable no-footer dtr-inline" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Mã">
                            <ItemTemplate>
                                <asp:Label ID="lblMaKH" runat="server" Text='<%# Eval("ma_kh") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên khách hàng" ControlStyle-Width="180px">
                            <ItemTemplate>
                                <asp:Label ID="lblTenKH" runat="server" Text='<%# Eval("ten_kh") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hệ số">
                            <ItemTemplate>
                                <asp:Label ID="lblheso" runat="server" Text='<%# Eval("he_so_ti") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Số hộ">
                            <ItemTemplate>
                                <asp:Label ID="lblSoHo" runat="server" Text='<%# Eval("so_ho") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã CT">
                            <ItemTemplate>
                                <asp:Label ID="lblMaCT" runat="server" Text='<%# Eval("ma_cong_to") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạm">
                            <ItemTemplate>
                                <asp:Label ID="lblMaTram" runat="server" Text='<%# Eval("ten_tram_bien_ap") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CS cũ">
                            <ItemTemplate>
                               <%-- <asp:Label ID="lblCSCu" runat="server" Text='<%# Eval("cs_cu") %>'></asp:Label>--%>
                                <asp:TextBox ID="lblCSCu" CssClass="form-control" runat="server" Text='<%# Eval("cs_cu") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CS mới">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCSMoi" CssClass="form-control" runat="server" Text='<%# Eval("cs_moi") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Điện năng TT">
                            <ItemTemplate>
                                <asp:Label ID="lblDienNangTT" runat="server" Text='<%# dienNangTieuThu(Eval("cs_cu"), Eval("cs_moi"), Eval("he_so_ti")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng thái">
                            <ItemTemplate>
                                <asp:Label ID="lblTenTT" runat="server" Text='<%# Eval("ten_trang_thai") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="idTrangThai" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblTrangThaiID" runat="server" Text='<%# Eval("trang_thai") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="idkhu" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblidKhu" runat="server" Text='<%# Eval("id_khu") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="idTram" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblidTram" runat="server" Text='<%# Eval("id_tram_bien_ap") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <!-- Modal -->

    <div class="modal fade" id="addKyModal" tabindex="-1" role="dialog" aria-labelledby="addKyModal" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="huyModalLable">Thêm kỳ hóa đơn mới</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body m-xl-3">
                    <div class="row mx5">
                        <label>Kỳ trước</label>
                        <asp:DropDownList runat="server" ID="ddlKyCu" DataValueField="id" DataTextField="ky" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="row mx5">
                        <label>Kỳ</label>
                        <input type="text" class="form-control input-lg" id="txtKyHD" autocomplete="off">
                        <input type="hidden" id="strKyHD" name="strKyHD" value="-1" />
                    </div>
                    <div class="row mx5">
                        <label>Từ ngày</label>
                        <input type="text" class="form-control input-lg" id="txtTuNgay" autocomplete="off">
                        <input type="hidden" id="strTuNgay" name="strTuNgay" value="-1" />
                    </div>
                    <div class="row mx5">
                        <label>Đến ngày</label>
                        <input type="text" class="form-control input-lg" id="txtDenNgay" autocomplete="off">
                        <input type="hidden" id="strDenNgay" name="strDenNgay" value="-1" />
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Quay lại</button>
                        <asp:Button ID="btnAdd" runat="server" OnClick="ThemKyHD" CssClass="btn btn-success" Text="Thêm mới" />
                        <asp:Label runat="server" ID="txtErr"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <dx:aspxcallback id="cbCapNhat" clientinstancename="cbCapNhat" clientidmode="Static" runat="server" oncallback="btnCapNhat_Callback" />

</asp:Content>
