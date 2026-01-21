<%@ Page Language="C#" Title="Danh mục công tơ" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DanhMucCongTo.aspx.cs" Inherits="DanhMucCongTo" %>

<%@ Register Assembly="DevExpress.Web.v12.1, Version=12.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script type="text/javascript">
        //Sửa thông tin
        function onClickCapNhat() {

            cbCapNhat.PerformCallback()
        }
        function onClickCapNhatComplete(s, e) {
            if (e.result == "1") {
                alert("Cập nhật thành công");
                location.reload();
            } else {
                alert("Cập nhật thất bại. Vui lòng thử lại!");
            }
        }
        $(function () {
            $('.datetimepicker').datepicker({
                language: "vi",
                format: 'dd/mm/yyyy',
                todayHighlight: true
            });
        });
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
            <div class="row">
                <div class="col-sm-3 mb-1">
                    <asp:DropDownList runat="server" ID="drpTramBienAp_1" DataValueField="id_tram_bien_ap" DataTextField="ten_tram_bien_ap" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-sm-3 mb-1">
                    <asp:Button ID="btnLaySL" runat="server" Text="Lấy số liệu" CssClass="btn btn-primary" OnClick="btnLaySL_Click" />
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridViewEman" ClientIDMode="Static" runat="server" CssClass="table table-striped table-bordered table-hover dataTable no-footer dtr-inline" AutoGenerateColumns="False" OnRowCommand="GridView_OnRowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Mã công tơ">
                            <ItemTemplate>
                                <asp:Label ID="lblMaCTo" runat="server" Text='<%# Eval("ma_cong_to") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã khách hàng">
                            <ItemTemplate>
                                <asp:Label ID="lblMaKh" runat="server" Text='<%# Eval("ma_kh") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Chủng loại">
                            <ItemTemplate>
                                <asp:Label ID="lblChungLoai" runat="server" Text='<%# Eval("chung_loai") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hệ số nhân">
                            <ItemTemplate>
                                <asp:Label ID="lblHeSoTi" runat="server" Text='<%# Eval("he_so_ti") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nhà sản xuất">
                            <ItemTemplate>
                                <asp:Label ID="lblNhaSanXuat" runat="server" Text='<%# Eval("nha_san_xuat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày sử dụng">
                            <ItemTemplate>
                                <asp:Label ID="lblNgaySuDung" runat="server" Text='<%# Eval("ngay_sd") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày hết hạn">
                            <ItemTemplate>
                                <asp:Label ID="lblNgayHetHan" runat="server" Text='<%# Eval("ngay_het_han") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng thái">
                            <ItemTemplate>
                                <asp:Label ID="lblTrangThai" runat="server" Text='<%# (int)Eval("trang_thai") == 1 ? "Active": "Deactive" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID Trạng thái" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIDTrangThai" runat="server" Text='<%# (int)Eval("trang_thai") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thao tác" ItemStyle-Width="100px" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Button CssClass="btn btn-success" ID="btnSua" runat="server" CommandName="suaCongto" Text="Sửa"></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
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
                            <h5 class="modal-title">Thêm công tơ</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="user-info-row" style="border: none">
                                <label class="key">Mã công tơ (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtMaCTo" ClientIDMode="Static" runat="server" CssClass="form-control input-lg" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Mã khách hàng (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtMaKh" ClientIDMode="Static" runat="server" CssClass="form-control input-lg" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Chủng loại (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtChungLoai" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Hệ số nhân (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtHeSoTi" ClientIDMode="Static" runat="server" type="number" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Nhà sản xuất :</label>
                                <div class="value">
                                    <asp:TextBox ID="txtNhaSanXuat" ClientIDMode="Static" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Ngày sử dụng :</label>
                                <div class="value">
                                    <asp:TextBox ID="txtNgaySD" ClientIDMode="Static" runat="server" CssClass="form-control input-lg datetimepicker" placeholder="dd/mm/yyyy"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Ngày hết hạn :</label>
                                <div class="value">
                                    <asp:TextBox ID="txtNgayHetHan" ClientIDMode="Static" runat="server" CssClass="form-control input-lg datetimepicker" placeholder="dd/mm/yyyy"></asp:TextBox>
                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">Trạng thái (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtTrangThai" ClientIDMode="Static" runat="server" CssClass="form-control input-lg" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-success" onclick="onClickCapNhat();">Cập nhật</button>
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
