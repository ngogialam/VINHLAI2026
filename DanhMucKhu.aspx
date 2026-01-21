<%@ Page Language="C#" Title="Danh mục khu" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DanhMucKhu.aspx.cs" Inherits="DanhMucKhu" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script>
        //Thêm mới
        function ThemMoi() {
            $('#AddModal').modal('show');
        }
        function onClickThemMoi() {
            var re = /d+/;
            var txtTenKhu = $('#txtTenKhu_AddModal').val();

            if (txtTenKhu === "") {
                alert("Vui lòng nhập tên bảng giá!");
                $('#txtTenKhu_AddModal').focus();
                return false
            }
            cbThemMoi.PerformCallback()
        }
        function onClickThemMoiComplete(s, e) {
            if (e.result == "1") {
                alert("Thêm mới khu thành công");
                location.href = "./DanhMucKhu.aspx";
            } else {
                alert("Thêm mới thất bại. Vui lòng thử lại!");
            }
        }

        //Sửa thông tin
        function onClickCapNhat() {
            var re = /d+/;
            var txtTenKhu = $('#txtTenKhu').val();

            if (txtTenKhu === "") {
                alert("Vui lòng nhập tên bảng giá!");
                $('#txtTenKhu').focus();
                return false
            }
            cbCapNhat.PerformCallback();
        }
        function onClickCapNhatComplete(s, e) {
            if (e.result == "1") {
                alert("Cập nhật thành công");
                location.href = "./DanhMucKhu.aspx";
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
                        <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Eval("id_khu") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên khu">
                            <ItemTemplate>
                                <asp:Label ID="lblTenKhu" runat="server" Text='<%# Eval("ten_khu") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID phường/xã" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIdPhuongXa" runat="server" Text='<%# Eval("id_phuong_xa") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phường/xã">
                            <ItemTemplate>
                                <asp:Label ID="lblTenPhuongXa" runat="server" Text='<%# Eval("ten_phuong_xa") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thao tác" ItemStyle-Width="100px" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Button CssClass="btn btn-success" ID="btnSua" runat="server" CommandName="suaDMKhu" Text="Sửa"></asp:Button>
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
                    <h5 class="modal-title">Thêm khu</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="user-info-row" style="border: none">
                        <label class="key">Tên khu (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:TextBox ID="txtTenKhu_AddModal" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>

                        </div>
                    </div>
                    <div class="user-info-row">
                        <label class="key">ID phường/xã (<span style="color: red">*</span>):</label>
                        <div class="value">
                            <asp:DropDownList runat="server" ID="drpPhuongXa_AddModal" DataValueField="id_phuong_xa" DataTextField="ten_phuong_xa" CssClass="form-control"></asp:DropDownList>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                <label class="key">Tên khu (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:TextBox ID="txtTenKhu" runat="server" ClientIDMode="Static" CssClass="form-control input-lg"></asp:TextBox>

                                </div>
                            </div>
                            <div class="user-info-row">
                                <label class="key">ID phường/xã (<span style="color: red">*</span>):</label>
                                <div class="value">
                                    <asp:DropDownList runat="server" ID="drpPhuongXa_EditModal" DataValueField="id_phuong_xa" DataTextField="ten_phuong_xa" CssClass="form-control"></asp:DropDownList>
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
