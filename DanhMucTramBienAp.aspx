<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongKeBangThong.aspx.cs" Inherits="BaoCao_ThongKeBangThong" %>--%>

<%@ Page Language="C#" Title="Danh mục trạm biến áp" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DanhMucTramBienAp.aspx.cs" Inherits="DanhMucTramBienAp" %>

<asp:Content runat="server" ID="head" ContentPlaceHolderID="head">
    <script type="text/javascript">
        //Thêm mới
        function ThemMoi() {
            $('#AddModal').modal('show');
        }
        function onClickThemMoi() {
            var re = /d+/;
            var txtMaTram = $('#txtId_AddModal').val();
            var txtTenTram = $('#txtTenTramBA_AddModal').val();
            var txtDiaChi = $('#txtDiaChi_AddModal').val();
            var txtMaSoCT = $('#txtMaSoCT_AddModal').val();
            var txtHeSoNhan = $('#txtHeSoNhan_AddModal').val();

            if (txtMaTram === "") {
                alert("Vui lòng nhập ID trạm!");
                $('#txtId_AddModal').focus();
                return false
            }
            if (txtTenTram === "") {
                alert("Vui lòng nhập tên trạm!");
                $('#txtTenTramBA_AddModal').focus();
                return false
            }
            if (txtDiaChi === "") {
                alert("Vui lòng nhập địa chỉ!");
                $('#txtDiaChi_AddModal').focus();
                return false
            }
            if (txtMaSoCT === "") {
                alert("Vui lòng nhập số điện thoại!");
                $('#txtMaSoCT_AddModal').focus();
                return false
            }
            var isMaSoCT = re.test(txtMaSoCT);
            if (isMaSoCT) {
                alert("Bạn chỉ được nhập số!");
                $('#txtMaSoCT_AddModal').focus();
                return false;
            }
            if (txtHeSoNhan === "") {
                alert("Vui lòng nhập hệ số nhân!");
                $('#txtHeSoNhan_AddModal').focus();
                return false
            }
            var isHeSoNhan = re.test(txtHeSoNhan);
            if (isHeSoNhan) {
                alert("Bạn chỉ được nhập số!");
                $('#txtHeSoNhan_AddModal').focus();
                return false;
            }
            cbThemMoi.PerformCallback();
        }
        function onClickThemMoiComplete(s, e) {
            if (e.result == "1") {
                alert("Thêm mới trạm biến áp thành công");
                location.href = "./DanhMucTramBienAp.aspx";
            } else {
                alert("Thêm mới thất bại. Vui lòng thử lại!");
            }
        }

        //Sửa thông tin
        function onClickCapNhat() {
            var re = /d+/;
            var txtTenTram = $('#txtTenTramBA').val();
            var txtDiaChi = $('#txtDiaChi').val();
            var txtMaSoCT = $('#txtMaSoCT').val();
            var txtHeSoNhan = $('#txtHeSoNhan').val();
            if (txtTenTram === "") {
                alert("Vui lòng nhập tên trạm!");
                $('#txtTenTramBA').focus();
                return false
            }
            if (txtDiaChi === "") {
                alert("Vui lòng nhập địa chỉ!");
                $('#txtDiaChi').focus();
                return false
            }
            if (txtMaSoCT === "") {
                alert("Vui lòng nhập số điện thoại!");
                $('#txtMaSoCT').focus();
                return false
            }
            var isMaSoCT = re.test(txtMaSoCT);
            if (isMaSoCT) {
                alert("Bạn chỉ được nhập số!");
                $('#txtMaSoCT').focus();
                return false;
            }
            if (txtHeSoNhan === "") {
                alert("Vui lòng nhập hệ số nhân!");
                $('#txtHeSoNhan').focus();
                return false
            }
            var isHeSoNhan = re.test(txtHeSoNhan);
            if (isHeSoNhan) {
                alert("Bạn chỉ được nhập số!");
                $('#txtHeSoNhan').focus();
                return false;
            }
            cbCapNhat.PerformCallback()
        }
        function onClickCapNhatComplete(s, e) {
            if (e.result == "1") {
                alert("Cập nhật thành công");
                location.href = "./DanhMucTramBienAp.aspx";
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
                        <asp:TemplateField HeaderText="ID" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Eval("id_tram_bien_ap") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên trạm biến áp">
                            <ItemTemplate>
                                <asp:Label ID="lblTenTramBienAp" runat="server" Text='<%# Eval("ten_tram_bien_ap") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Địa chỉ">
                            <ItemTemplate>
                                <asp:Label ID="lblDiaChi" runat="server" Text='<%# Eval("dia_chi") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Người phụ trách">
                            <ItemTemplate>
                                <asp:Label ID="lblTenNguoiPhuTrach" runat="server" Text='<%# Convert_NguoiPhuTrach(Eval("nguoi_phu_trach")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã người phụ trách" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblNguoiPhuTrach" runat="server" Text='<%# Eval("nguoi_phu_trach") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã số công tơ">
                            <ItemTemplate>
                                <asp:Label ID="lblMaCongTo" runat="server" Text='<%# Eval("ma_so_cong_to") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hệ só nhân">
                            <ItemTemplate>
                                <asp:Label ID="lblHeSoNhan" runat="server" Text='<%# Eval("he_so_nhan") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Trạng thái">
                            <ItemTemplate>
                                <asp:Label ID="lblTrangThai" runat="server" Text='<%# (int)Eval("trang_thai") == 1 ? "Active": "Deactive" %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID Trạng thái" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIDTrangThai" runat="server" Text='<%# (int)Eval("trang_thai") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thao tác" ItemStyle-Width="100px" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Button CssClass="btn btn-success" ID="btnSua" runat="server" CommandName="suaTramBienAp" Text="Sửa"></asp:Button>
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
                    <h5 class="modal-title">Thêm trạm biến áp</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="user-info-row" style="border: none">
                        <label class="key">ID (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtId_AddModal" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Tên trạm biến áp (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtTenTramBA_AddModal" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Địa chỉ (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtDiaChi_AddModal" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Người phụ trách (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:DropDownList runat="server" ClientIDMode="Static" ID="drpNguoiPhuTrach_AddModal" DataValueField="ma_nv" DataTextField="ten_nv" CssClass="form-control input-lg"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Mã số công tơ (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtMaSoCT_AddModal" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Hệ số nhân (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtHeSoNhan_AddModal" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Trạng thái (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:CheckBox ID="ckbTrangThai_AddModal" runat="server" ClientIDMode="Static" />
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
                                    <asp:TextBox ID="txtId" runat="server" ClientIDMode="Static" CssClass="form-control input-lg" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Tên trạm biến áp (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtTenTramBA" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Địa chỉ (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtDiaChi" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Người phụ trách (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:DropDownList runat="server" ClientIDMode="Static" ID="drpNguoiPhuTrach" DataValueField="ma_nv" DataTextField="ten_nv" CssClass="form-control input-lg"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Mã số công tơ (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtMaSoCT" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Hệ số nhân (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtHeSoNhan" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Trạng thái (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:CheckBox ID="ckbTrangThai" runat="server" ClientIDMode="Static" />
                                    <label>Kích hoạt</label>
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridViewEman" EventName="RowCommand" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
