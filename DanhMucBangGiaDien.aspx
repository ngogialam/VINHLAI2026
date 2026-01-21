<%@ Page Language="C#" Title="Danh mục bảng giá điện" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DanhMucBangGiaDien.aspx.cs" Inherits="DanhMucBangGiaDien" %>

<%@ Register Assembly="DevExpress.Web.v12.1, Version=12.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script>
        //Thêm mới
        function ThemMoi() {
            $('#AddModal').modal('show');
        }
        function onClickThemMoi() {
            var re = /d+/;
            var txtTenBangGia = $('#txtTenBangGia_AddModal').val();
            var txtTenVietTat = $('#txtTenVietTat_AddModal').val();
            var txtDonGia = $('#txtDonGia_AddModal').val();
            var txtTienThue = $('#txtTienThue_AddModal').val();
            var txtPhanTramThue = $('#txtPhanTramThue_AddModal').val();
            var txtGiaBan = $('#txtGiaBan_AddModal').val();
            if (txtTenBangGia === "") {
                alert("Vui lòng nhập tên bảng giá!");
                $('#txtTenBangGia_AddModal').focus();
                return false
            }
            if (txtTenVietTat === "") {
                alert("Vui lòng nhập tên viết tắt!");
                $('#txtTenVietTat_AddModal').focus();
                return false
            }
            if (txtDonGia === "") {
                alert("Vui lòng nhập đơn giá!");
                $('#txtDonGia_AddModal').focus();
                return false;
            }
            var isDonGia = re.test(txtDonGia);
            if (isDonGia) {
                alert("Bạn chỉ được nhập số!");
                $('#txtDonGia_AddModal').focus();
                return false;
            }

            if (txtTienThue === "") {
                alert("Vui lòng nhập tiền thuế!");
                $('#txtTienThue_AddModal').focus();
                return false;
            }
            var isTienThue = re.test(txtTienThue);
            if (isTienThue) {
                alert("Bạn chỉ được nhập số!");
                $('#txtTienThue_AddModal').focus();
                return false;
            }

            if (txtPhanTramThue === "") {
                alert("Vui lòng nhập phần trăm thuế!");
                $('#txtPhanTramThue_AddModal').focus();
                return false;
            }
            var isPhanTramThue = re.test(txtPhanTramThue);
            if (isPhanTramThue) {
                alert("Bạn chỉ được nhập số!");
                $('#txtPhanTramThue_AddModal').focus();
                return false;
            }

            if (txtGiaBan === "") {
                alert("Vui lòng nhập giá bán!");
                $('#txtGiaBan_AddModal').focus();
                return false;
            }
            var isGiaBan = re.test(txtGiaBan);
            if (isGiaBan) {
                alert("Bạn chỉ được nhập số!");
                $('#txtGiaBan_AddModal').focus();
                return false;
            }
            cbThemMoi.PerformCallback()
        }
        function onClickThemMoiComplete(s, e) {
            if (e.result == "1") {
                alert("Thêm mới bảng giá điện thành công");
                location.href = "./DanhMucBangGiaDien.aspx";
            } else {
                alert("Thêm mới thất bại. Vui lòng thử lại!");
            }
        }
        //Sửa thông tin
        function onClickCapNhat() {
            var re = /d+/;
            var txtTenBangGia = $('#txtTenBangGia').val();
            var txtTenVietTat = $('#txtTenVietTat').val();
            var txtDonGia = $('#txtDonGia').val();
            var txtTienThue = $('#txtTienThue').val();
            var txtPhanTramThue = $('#txtPhanTramThue').val();
            var txtGiaBan = $('#txtGiaBan').val();

            if (txtTenBangGia === "") {
                alert("Vui lòng nhập tên bảng giá!");
                $('#txtTenBangGia').focus();
                return false
            }
            if (txtTenVietTat === "") {
                alert("Vui lòng nhập tên viết tắt!");
                $('#txtTenVietTat').focus();
                return false
            }
            var isDonGia = re.test(txtDonGia);
            if (isDonGia) {
                alert("Bạn chỉ được nhập số!");
                $('#txtDonGia').focus();
                return false;
            }
            var isTienThue = re.test(txtTienThue);
            if (isTienThue) {
                alert("Bạn chỉ được nhập số!");
                $('#txtTienThue').focus();
                return false;
            }
            var isPhanTramThue = re.test(txtPhanTramThue);
            if (isPhanTramThue) {
                alert("Bạn chỉ được nhập số!");
                $('#txtPhanTramThue').focus();
                return false;
            }
            var isGiaBan = re.test(txtGiaBan);
            if (isGiaBan) {
                alert("Bạn chỉ được nhập số!");
                $('#txtGiaBan').focus();
                return false;
            }
            cbCapNhat.PerformCallback()
        }
        function onClickCapNhatComplete(s, e) {
            if (e.result == "1") {
                alert("Cập nhật thành công");
                location.href = "./DanhMucBangGiaDien.aspx";
            } else {
                alert("Cập nhật thất bại. Vui lòng thử lại!");
            }
        }
    </script>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-12">
        </div>
    </div>
    <div class="card mb-3">
        <div class="card-header">
            <button id="btnThemMoiBGD" class="btn btn-primary" type="button" onclick="ThemMoi()">Thêm mới</button>
            <a href="DanhMucBangGiaDienChiTiet.aspx" class="btn btn-primary">Bảng giá chi tiết</a>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridViewEman" ClientIDMode="Static" runat="server" CssClass="table table-striped table-bordered table-hover dataTable no-footer dtr-inline" AutoGenerateColumns="False" OnRowCommand="GridView_OnRowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Eval("id_bang_gia") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên bảng giá">
                            <ItemTemplate>
                                <asp:Label ID="lblTenBangGia" runat="server" Text='<%# Eval("ten_bang_gia") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên viết tắt">
                            <ItemTemplate>
                                <asp:Label ID="lblTenVT" runat="server" Text='<%# Eval("ten_viet_tat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Đơn Giá">
                            <ItemTemplate>
                                <asp:Label ID="lblDonGia" runat="server" Text='<%# Eval("don_gia") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tiền thuế VAT">
                            <ItemTemplate>
                                <asp:Label ID="lblThueVat" runat="server" Text='<%# Eval("tien_thue_vat") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phần trăm thuế">
                            <ItemTemplate>
                                <asp:Label ID="lblPhanTramThue" runat="server" Text='<%# Eval("phan_tram_thue") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Đơn giá cũ">
                            <ItemTemplate>
                                <asp:Label ID="lblGiaBan" runat="server" Text='<%# Eval("don_gia_cu") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng thái">
                            <ItemTemplate>
                                <asp:Label ID="lblTrangThai" runat="server" Text='<%# (int)Eval("kich_hoat") == 1 ? "Active": "Deactive" %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Loại bảng giá" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblLoaiBangGia" runat="server" Text='<%# Eval("loai_bg") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID Trạng thái" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIDTrangThai" runat="server" Text='<%# (int)Eval("kich_hoat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thao tác" ItemStyle-Width="100px" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Button CssClass="btn btn-success" ID="btnSua" runat="server" CommandName="suaGiaDien" Text="Sửa"></asp:Button>
                                <%--<asp:Button CssClass="btn btn-success" ID="btnXoa" runat="server" CommandName="xoaGiaDien" Text="Xóa"></asp:Button>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <%--Thêm--%>
    <div class="modal fade" id="AddModal" tabindex="-1" role="dialog" aria-labelledby="EditModal" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Thêm bảng giá điện</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="user-info-row" style="border: none">
                        <label class="key">Tên bảng giá (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtTenBangGia_AddModal" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Tên viết tắt (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtTenVietTat_AddModal" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Đơn giá (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtDonGia_AddModal" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Tiền thuế VAT (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtTienThue_AddModal" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Phần trăm thuế (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtPhanTramThue_AddModal" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Đơn giá cũ (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtGiaBan_AddModal" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Loại bảng giá: </label>
                        <div class="value">
                            <asp:DropDownList ID="drpLoaiBg_AddModal" runat="server" CssClass="form-control">
                                <asp:ListItem Value="MDK">Mục đích khác</asp:ListItem>
                                <asp:ListItem Value="HH">Hỗn hợp</asp:ListItem>
                                <asp:ListItem Value="BT">Bậc thang</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="user-info-row" style="display: block">
                        <label class="key">Trạng thái:</label>
                        <div class="value">
                            <asp:CheckBox ID="ckbTrangThai_AddModal" runat="server" />
                            <label>Kích hoạt</label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnThem_AddModal" class="btn btn-success" onclick="onClickThemMoi();">Thêm mới</button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Quay lại</button>
                    <dx:aspxcallback id="cbThemMoi" clientinstancename="cbThemMoi" clientidmode="Static" runat="server" oncallback="btnThemMoi_Callback">
                                  <ClientSideEvents CallbackComplete="onClickThemMoiComplete" />
                            </dx:aspxcallback>
                </div>
            </div>
        </div>
    </div>

    <%--Sửa--%>
    <asp:UpdatePanel ID="upModal" runat="server">
        <ContentTemplate>
            <div class="modal fade" id="EditModal" tabindex="-1" role="dialog" aria-labelledby="EditModal" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Sửa thông tin</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="user-info-row" style="border: none">
                                <label class="key">ID (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control input-lg" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Tên bảng giá (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtTenBangGia" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>

                            </div>
                            <div class="user-info-row">
                                <label class="key">Tên viết tắt (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtTenVietTat" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>

                            </div>
                            <div class="user-info-row">
                                <label class="key">Đơn giá (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtDonGia" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>

                            </div>
                            <div class="user-info-row">
                                <label class="key">Tiền thuế VAT (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtTienThue" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Phần trăm thuế (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtPhanTramThue" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Đơn giá cũ (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtGiaBan" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Loại bảng giá: </label>
                                <div class="value">
                                    <asp:DropDownList ID="drpLoaiBg_EditModal" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="MDK">Mục đích khác</asp:ListItem>
                                        <asp:ListItem Value="HH">Hỗn hợp</asp:ListItem>
                                        <asp:ListItem Value="BT">Bậc thang</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="user-info-row" style="display: block">
                                <label class="key">Trạng thái:</label>
                                <div class="value">
                                    <asp:CheckBox ID="ckbTrangThai" runat="server" />
                                    <label>Kích hoạt</label>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnCapNhat" class="btn btn-success" onclick="onClickCapNhat();">Cập nhập</button>
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Quay lại</button>
                            <dx:aspxcallback id="cbCapNhat" clientinstancename="cbCapNhat" clientidmode="Static" runat="server" oncallback="btnSave_Callback">
                                <ClientSideEvents CallbackComplete="onClickCapNhatComplete" />
                            </dx:aspxcallback>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridViewEman" EventName="RowCommand" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
