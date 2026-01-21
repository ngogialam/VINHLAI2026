<%@ Page Language="C#" Title="Danh mục nhân viên" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DanhMucNhanVien.aspx.cs" Inherits="DanhMucNhanVien" %>

<asp:Content runat="server" ID="head" ContentPlaceHolderID="head">
    <script>
        //Thêm mới
        function ThemMoi() {
            $('#AddModal').modal('show');
        }
        function onClickThemMoi() {
            var re = /d+/;
            var txtMaNV = $('#txtMaNV_AddModal').val();
            var txtTenNV = $('#txtTenNV_AddModal').val();
            var txtDiaChi = $('#txtDiaChi_AddModal').val();
            var txtDienThoai = $('#txtDienThoai_AddModal').val();
            var txtChiChu = $('#txtGhiChu_AddModal').val();

            if (txtMaNV === "") {
                alert("Vui lòng nhập mã nhân viên!");
                $('#txtMaNV_AddModal').focus();
                return false
            }
            if (txtTenNV === "") {
                alert("Vui lòng nhập tên nhân viên!");
                $('#txtTenNV_AddModal').focus();
                return false
            }
            if (txtDiaChi === "") {
                alert("Vui lòng nhập địa chỉ!");
                $('#txtDiaChi_AddModal').focus();
                return false
            }
            if (txtDienThoai === "") {
                alert("Vui lòng nhập số điện thoại!");
                $('#txtDienThoai_AddModal').focus();
                return false
            }
            var isDienThoai = re.test(txtDienThoai);
            if (isDienThoai) {
                alert("Bạn chỉ được nhập số!");
                $('#txtDienThoai_AddModal').focus();
                return false;
            }
            cbThemMoi.PerformCallback();
        }
        function onClickThemMoiComplete(s, e) {
            if (e.result == "1") {
                alert("Thêm mới nhân viên thành công");
                location.href = "./DanhMucNhanVien.aspx";
            } else {
                alert("Thêm mới thất bại. Vui lòng thử lại!");
            }
        }

        //Sửa thông tin
        function onClickCapNhat() {
            var re = /d+/;
            var txtTenNV = $('#txtTeNV').val();
            var txtDiaChi = $('#txtDiaChi').val();
            var txtDienThoai = $('#txtDienThoai').val();
            var txtChiChu = $('#txtGhiChu').val();
            if (txtTenNV === "") {
                alert("Vui lòng nhập tên nhân viên!");
                $('#txtTeNV').focus();
                return false
            }

            if (txtDiaChi === "") {
                alert("Vui lòng nhập địa chỉ!");
                $('#txtDiaChi').focus();
                return false
            }

            if (txtDienThoai === "") {
                alert("Vui lòng nhập số điện thoại!");
                $('#txtDienThoai').focus();
                return false
            }
            var isDienThoai = re.test(txtDienThoai);
            if (isDienThoai) {
                alert("Bạn chỉ được nhập số!");
                $('#txtDienThoai').focus();
                return false;
            }

            cbCapNhat.PerformCallback()
        }
        function onClickCapNhatComplete(s, e) {
            if (e.result == "1") {
                alert("Cập nhật thành công");
                location.href = "./DanhMucNhanVien.aspx";
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
            <button id="btnThemMoiKhu" class="btn btn-primary" type="button" onclick="ThemMoi()">Thêm mới</button>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridViewEman" ClientIDMode="Static" runat="server" CssClass="table table-striped table-bordered table-hover dataTable no-footer dtr-inline" AutoGenerateColumns="False" OnRowCommand="GridView_OnRowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Mã nhân viên" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lblMaNV" runat="server" Text='<%# Eval("ma_nv") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên nhân viên">
                            <ItemTemplate>
                                <asp:Label ID="lblTenNV" runat="server" Text='<%# Eval("ten_nv") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Địa chỉ">
                            <ItemTemplate>
                                <asp:Label ID="lblDiaChi" runat="server" Text='<%# Eval("dia_chi") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Điện thoại">
                            <ItemTemplate>
                                <asp:Label ID="lblDienThoai" runat="server" Text='<%# Eval("dien_thoai") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ghi chú">
                            <ItemTemplate>
                                <asp:Label ID="lblGhiChu" runat="server" Text='<%# Eval("ghi_chu") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thao tác" ItemStyle-Width="100px" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Button CssClass="btn btn-success" ID="btnSua" runat="server" CommandName="suaNhanVien" Text="Sửa"></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <%--Thêm--%>
    <div class="modal fade" id="AddModal" tabindex="-1" role="dialog" aria-labelledby="AddModal" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Thêm nhân viên</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="user-info-row" style="border: none">
                        <label class="key">Mã nhân viên (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtMaNV_AddModal" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row" style="border: none">
                        <label class="key">Tên nhân viên (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtTenNV_AddModal" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Địa chỉ (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtDiaChi_AddModal" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Điện thoại (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtDienThoai_AddModal" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Ghi chú:</label>
                        <div class="value">
                            <asp:TextBox ID="txtGhiChu_AddModal" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
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
                                <label class="key">Mã nhân viên:</label>
                                <div class="value">
                                    <asp:TextBox ID="txtMaNV" runat="server" CssClass="form-control input-lg" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Tên nhân viên (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtTenNV" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Địa chỉ (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtDiaChi" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Điện thoại (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtDienThoai" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Ghi chú:</label>
                                <div class="value">
                                    <asp:TextBox ID="txtGhiChu" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnCapNhat" class="btn btn-success" onclick="onClickCapNhat();">Cập nhật</button>
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Quay lại</button>
                            <dx:aspxcallback id="cbCapNhat" clientinstancename="cbCapNhat" clientidmode="Static" runat="server" oncallback="btnCapNhat_Callback">
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
