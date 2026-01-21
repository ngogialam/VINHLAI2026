<%@ Page Language="C#" Title="Lập hóa đơn" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="LapHoaDonDienTangGia.aspx.cs" Inherits="LapHoaDon" %>

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
                    <asp:Button ID="btnLaySL" runat="server" Text="Lấy số liệu điện tăng giá" CssClass="btn btn-primary" OnClick="btnLaySL_Click" />
                    <asp:Button ID="btnCapNhat" runat="server" Text="Lập hóa đơn điện tăng giá" CssClass="btn btn-success" OnClick="btnChotSL_Click" OnClientClick="return confirm('Sau khi lập hóa đơn sẽ không thể thay đổi dữ liệu. Bạn có chắc chắn thực hiện?')" />
                    <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#addKyModal">Thêm Kỳ HĐ</button>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12 mb-1">
                    Từ ngày                 
                    <b>
                        <asp:Label ID="lblTuNgay" runat="server"></asp:Label></b>
                    đến ngày                
                    <b>
                        <asp:Label ID="lblDenNgay" runat="server"></asp:Label></b>
                </div>
            </div>
            <div class="row">
                <asp:Label runat="server" ID="lblErr"></asp:Label>
            </div>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridViewEman" ClientIDMode="Static" runat="server" CssClass="table table-striped table-bordered table-hover dataTable no-footer dtr-inline" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Mã">
                            <ItemTemplate>
                                <asp:Label ID="lblMaKH" runat="server" Text='<%# Eval("ma_kh") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên khách hàng">
                            <ItemTemplate>
                                <asp:Label ID="lblTenKH" runat="server" Text='<%# Eval("ten_kh") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hệ số">
                            <ItemTemplate>
                                <asp:Label ID="lblDB" runat="server" Text='<%# Eval("he_so_ti") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạm">
                            <ItemTemplate>
                                <asp:Label ID="lblMaTram" runat="server" Text='<%# Eval("ten_tram_bien_ap") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bảng giá">
                            <ItemTemplate>
                                <asp:Label ID="lblBangGia" runat="server" Text='<%# Eval("ten_bang_gia") %>'></asp:Label>
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
                        <asp:TemplateField HeaderText="CS cũ">
                            <ItemTemplate>
                                <asp:Label ID="lblCSCu" runat="server" Text='<%# Eval("cs_cu") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CS mới">
                            <ItemTemplate>
                                <asp:Label ID="lblCSMoi" runat="server" Text='<%# Eval("cs_moi") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ĐNTT">
                            <ItemTemplate>
                                <asp:Label ID="lblDNTT" runat="server" Text='<%# Eval("san_luong") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thành tiền" ItemStyle-CssClass="text-right">
                            <ItemTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text='<%# string.Format("{0:#,0}",Eval("total") ) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tiền thuế" ItemStyle-CssClass="text-right">
                            <ItemTemplate>
                                <asp:Label ID="lblVatAmount" runat="server" Text='<%# string.Format("{0:#,0}",Eval("vatamount") ) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tổng tiền" ItemStyle-Font-Bold="true" ItemStyle-CssClass="text-right">
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" runat="server"  Text='<%# string.Format("{0:#,0}",Eval("amount") )%>'></asp:Label>
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
                        <asp:TemplateField HeaderText="idBG" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblidBangGia" runat="server" Text='<%# Eval("id_bang_gia") %>'></asp:Label>
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
</asp:Content>
