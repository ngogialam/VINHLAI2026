<%@ Page Language="C#" Title="Chỉ số công tơ tổng" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ChiSoCongToTong.aspx.cs" Inherits="ChiSoCongToTong" %>

<asp:Content runat="server" ID="head" ContentPlaceHolderID="head">
    <script type="text/javascript">
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
                        console.log("sfdsfdsfasfsdfasd");
                        var date = $.datepicker.formatDate('yymmdd', $(this).datepicker('getDate'));
                        console.log(date);
                        $("#strDenNgay").val(date);
                    }
                });
            $('#txtKyHD').datepicker(
                {
                    format: "mm/yyyy",
                    viewMode: "months",
                    minViewMode: "months",
                    //yearRange: '1950:2100',
                    onSelect: function () {
                        var date = $.datepicker.formatDate('mm/yyyy', $(this).datepicker('getDate'));
                        $("#strKyHD").val(date);
                    }
                });

        })
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
                    <asp:DropDownList runat="server" ID="drpKy" DataValueField="id" DataTextField="ky" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-sm-6 mb-1">
                    <asp:Button ID="btnLaySL" runat="server" Text="Lấy số liệu" CssClass="btn btn-primary" OnClick="btnLaySL_Click" />
                    <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật số liệu" CssClass="btn btn-success" OnClick="btnCapNhat_Click" />
                    <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#addKyModal">Thêm Kỳ HĐ</button>
                    <asp:Button ID="btnXuatExcel" runat="server" Text="Xuất Excel" CssClass="btn btn-success" OnClick="btnXuatExcel_Click" />

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
                                <asp:Label ID="lblCSCu" runat="server" Text='<%# Eval("cs_cu") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CS mới">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCSMoi" type="number" CssClass="form-control" runat="server" Text='<%# Eval("cs_moi") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kỳ">
                            <ItemTemplate>
                                <asp:Label ID="lblKy" runat="server" Text='<%# Eval("ky") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sản lượng bán">
                            <ItemTemplate>
                                <asp:Label ID="lblSoBan" runat="server" Text='<%# Eval("so_ban") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sản lượng mua">
                            <ItemTemplate>
                                <asp:Label ID="lblSoMua" runat="server" Text='<%# Eval("so_mua") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày cập nhật" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblNgayCapNhat" runat="server" Text='<%# Eval("ngay_cap_nhat") %>'></asp:Label>
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
                        <input type="text" class="form-control input-lg" id="txtKyHD" autocomplete="off" />
                        <input type="hidden" id="strKyHD" name="strKyHD" value="-1" />
                    </div>
                    <div class="row mx5">
                        <label>Từ ngày</label>
                        <input type="text" class="form-control input-lg" id="txtTuNgay" autocomplete="off" />
                        <input type="hidden" id="strTuNgay" name="strTuNgay" value="-1" />
                    </div>
                    <div class="row mx5">
                        <label>Đến ngày</label>
                        <input type="text" class="form-control input-lg" id="txtDenNgay" autocomplete="off" />
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
</asp:Content>
