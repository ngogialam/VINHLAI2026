<%@ Page Language="C#" Title="Danh mục bảng giá chi tiết" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DanhMucBangGiaDienChiTiet.aspx.cs" Inherits="DanhMucBangGiaDienChiTiet" %>

<%@ Register Assembly="DevExpress.Web.v12.1, Version=12.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script>
        //Thêm mới
        function ThemMoi() {
            $('#AddModal').modal('show');
        }
        function SuaGiaDien(button) {
            var row = $(button).closest('tr');
            function getText(id) {
                return $.trim(row.find("[id$='" + id + "']").first().text());
            }

            $('#hfIDEdit').val(getText('lblId'));
            $('#txtTenBangGia').val(getText('lblTenBangGia'));
            $('#txtTuSo').val(getText('lblTuSo'));
            $('#txtDenSo').val(getText('lblDenSo'));
            $('#txtGiaKhongVAT').val(getText('lblGiaKhongVAT'));
            $('#txtMucThu').val(getText('lblMucThu'));
            $('#txtPhanTramThue').val(getText('lblPhanTramThue'));
            $('#txtTyLe').val(getText('lblTyLe'));
            $('#txtMoTa').val(getText('lblMoTa'));

            var idBangGiaTyLe = row.find("[id$='hfIDBangGiaTyLe']").val() || '0';
            var drpBangGiaTyLe = $('#drpBangGiaTyLe');
            if (drpBangGiaTyLe.find('option').filter(function () {
                return this.value === idBangGiaTyLe;
            }).length === 0) {
                idBangGiaTyLe = '0';
            }
            drpBangGiaTyLe.val(idBangGiaTyLe);
            $('#EditModal').modal('show');
            return false;
        }
        function onClickThemMoi() {
            var re = /d+/;
            var txtGiaKhongVAT = $('#txtGiaKhongVAT_AddModal').val();
            var txtPhanTramThue = $('#txtPhanTramThue_AddModal').val();
            var txtTyLe = $('#txtTyLe_AddModal').val();
            var isGiaKhongVAT = re.test(txtGiaKhongVAT);
            if (isGiaKhongVAT) {
                alert("Bạn chỉ được nhập số!");
                $('#txtGiaKhongVAT_AddModal').focus();
                return false;
            }

            var isPhanTramThue = re.test(txtPhanTramThue);
            if (isPhanTramThue) {
                alert("Bạn chỉ được nhập số!");
                $('#txtPhanTramThue_AddModal').focus();
                return false;
            }

            var isTyLe = re.test(txtTyLe);
            if (isTyLe) {
                alert("Bạn chỉ được nhập số!");
                $('#txtTyLe_AddModal').focus();
                return false;
            }
            cbThemMoi.PerformCallback()
        }
        function onClickThemMoiComplete(s, e) {
            if (e.result == "1") {
                alert("Thêm mới chi tiết bảng giá điện thành công");
                location.href = "./DanhMucBangGiaDienChiTiet.aspx";
            } else {
                alert("Thêm mới thất bại. Vui lòng thử lại!");
            }
        }

        //Sửa thông tin
        function onClickCapNhat() {
            var re = /d+/;
            var txtGiaKhongVAT = $('#txtGiaKhongVAT').val();
            var txtPhanTramThue = $('#txtPhanTramThue').val();
            var txtTyLe = $('#txtTyLe').val();
            var isGiaKhongVAT = re.test(txtGiaKhongVAT);
            if (isGiaKhongVAT) {
                alert("Bạn chỉ được nhập số!");
                $('#txtGiaKhongVAT').focus();
                return false;
            }

            var isPhanTramThue = re.test(txtPhanTramThue);
            if (isPhanTramThue) {
                alert("Bạn chỉ được nhập số!");
                $('#txtPhanTramThue').focus();
                return false;
            }

            var isTyLe = re.test(txtTyLe);
            if (isTyLe) {
                alert("Bạn chỉ được nhập số!");
                $('#txtTyLe').focus();
                return false;
            }
            cbCapNhat.PerformCallback()
        }
        function onClickCapNhatComplete(s, e) {
            if (e.result == "1") {
                alert("Cập nhật thành công");
                location.href = "./DanhMucBangGiaDienChiTiet.aspx";
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
            <a href="javascript:history.go(-1)" class="btn btn-primary btn-flat">Quay lại</a>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridViewEman" ClientIDMode="Static" runat="server" CssClass="table table-striped table-bordered table-hover dataTable no-footer dtr-inline" AutoGenerateColumns="False" OnRowCommand="GridView_OnRowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID bảng giá" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIdBangGia" runat="server" Text='<%# Eval("id_bang_gia") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bảng giá">
                            <ItemTemplate>
                                <asp:Label ID="lblTenBangGia" runat="server" Text='<%# Eval("ten_bang_gia") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Từ số">
                            <ItemTemplate>
                                <asp:Label ID="lblTuSo" runat="server" Text='<%# Eval("tu_so") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Đến số">
                            <ItemTemplate>
                                <asp:Label ID="lblDenSo" runat="server" Text='<%# Eval("den_so") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Giá không VAT">
                            <ItemTemplate>
                                <asp:Label ID="lblGiaKhongVAT" runat="server" Text='<%# Eval("gia_ko_vat") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mức thu">
                            <ItemTemplate>
                                <asp:Label ID="lblMucThu" runat="server" Text='<%# Eval("muc_thu") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Đơn giá cũ">
                            <ItemTemplate>
                                <asp:Label ID="lblPhanTramThue" runat="server" Text='<%# Eval("gia_ko_vat_cu") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID Bảng giá tỷ lệ" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIDBangGiaTyLe" runat="server" Text='<%# Eval("id_bang_gia_ty_le") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bảng giá tỷ lệ">
                            <ItemTemplate>
                                <asp:Label ID="lblTenBangGiaTyLe" runat="server" Text='<%# Eval("ten_bang_gia_ty_le") %>'></asp:Label>
                                <asp:HiddenField ID="hfIDBangGiaTyLe" runat="server" Value='<%# Eval("id_bang_gia_ty_le") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tỷ lệ">
                            <ItemTemplate>
                                <asp:Label ID="lblTyLe" runat="server" Text='<%# Eval("ty_le") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mô tả">
                            <ItemTemplate>
                                <asp:Label ID="lblMoTa" runat="server" Text='<%# Eval("mo_ta") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thao tác" ItemStyle-Width="130px" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Button CssClass="btn btn-success" ID="btnSua" runat="server" Text="Sửa" OnClientClick="return SuaGiaDien(this);"></asp:Button>
                                <asp:Button CssClass="btn btn-success" ID="btnXoa" runat="server" CommandName="xoaGiaDien" Text="Xóa"></asp:Button>
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
                    <h5 class="modal-title">Thêm bảng giá chi tiết</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="user-info-row" style="border: none">
                        <label class="key">Tên bảng giá (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:DropDownList ID="drpBangGia_AddModal" runat="server" CssClass="form-control" DataTextField="ten_bang_gia" DataValueField="id_bang_gia">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Từ số:</label>
                        <div class="value">
                            <asp:TextBox ID="txtTuSo_AddModal" type="number" ClientIDMode="Static" runat="server" Text="0" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Đến số:</label>
                        <div class="value">
                            <asp:TextBox ID="txtDenSo_AddModal" type="number" ClientIDMode="Static" runat="server" Text="0" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Giá không VAT:</label>
                        <div class="value">
                            <asp:TextBox ID="txtGiaKhongVAT_AddModal" ClientIDMode="Static" runat="server" Text="0" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Mức thu:</label>
                        <div class="value">
                            <asp:TextBox ID="txtMucThu_AddModal" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Đơn giá cũ:</label>
                        <div class="value">
                            <asp:TextBox ID="txtPhanTramThue_AddModal" ClientIDMode="Static" runat="server" Text="0" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Bảng giá tỷ lệ: </label>
                        <div class="value">
                            <asp:DropDownList ID="drpBangGiaTyLe_AddModal" runat="server" CssClass="form-control" DataTextField="ten_bang_gia" DataValueField="id_bang_gia">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Tỷ lệ:</label>
                        <div class="value">
                            <asp:TextBox ID="txtTyLe_AddModal" ClientIDMode="Static" runat="server" Text="0" CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">Mô tả:</label>
                        <div class="value">
                            <asp:TextBox ID="txtMoTa_AddModal" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
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
                            <asp:HiddenField ID="hfIDEdit" ClientIDMode="Static" runat="server" />
                            <div class="user-info-row" style="border: none">
                                <label class="key">Tên bảng giá (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtTenBangGia" ClientIDMode="Static" runat="server" CssClass="form-control input-lg" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Từ số:</label>
                                <div class="value">
                                    <asp:TextBox ID="txtTuSo" type="number" Text="0" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Đến số:</label>
                                <div class="value">
                                    <asp:TextBox ID="txtDenSo" type="number" Text="0" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Giá không VAT:</label>
                                <div class="value">
                                    <asp:TextBox ID="txtGiaKhongVAT" Text="0" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Mức thu:</label>
                                <div class="value">
                                    <asp:TextBox ID="txtMucThu" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Đơn giá cũ</label>
                                <div class="value">
                                    <asp:TextBox ID="txtPhanTramThue" Text="0" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Bảng giá tỷ lệ: </label>
                                <div class="value">
                                    <asp:DropDownList ID="drpBangGiaTyLe" ClientIDMode="Static" runat="server" CssClass="form-control" DataTextField="ten_bang_gia" DataValueField="id_bang_gia">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Tỷ lệ:</label>
                                <div class="value">
                                    <asp:TextBox ID="txtTyLe" ClientIDMode="Static" Text="0" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Mô tả:</label>
                                <div class="value">
                                    <asp:TextBox ID="txtMoTa" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
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
            <asp:PostBackTrigger ControlID="GridViewEman" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
