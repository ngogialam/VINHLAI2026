<%@ Page Language="C#" Title="Danh sách hóa đơn điện tử" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DanhSachHoaDon.aspx.cs" Inherits="DanhSachHoaDon" %>

<asp:Content runat="server" ID="head" ContentPlaceHolderID="head">

    <script>
        function PrintPanel() {
            var printWindow = window.open('', '', 'height=800,width=1000');
            var panel = document.getElementById("pnlContents");
            printWindow.document.write(panel.innerHTML);
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 00);
        }
    </script>

</asp:Content>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style>
        .marginTop10 {
            margin-top: 10px
        }
    </style>
    <div id="page-wrapper">
        <div class="row">
            <div class="col-xl-3 col-sm-4 mb-2">
                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlTrangThaiHD">
                    <asp:ListItem Selected="True" Value="2">Hóa đơn đã phát hành</asp:ListItem>
                    <asp:ListItem Value="1">Hóa đơn mới khởi tạo</asp:ListItem>
                    <asp:ListItem Value="3">Hóa đơn đã hủy</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-xl-3 col-sm-4 mb-2">
                <asp:DropDownList runat="server" ID="drpTram" DataValueField="id_tram_bien_ap" DataTextField="ten_tram_bien_ap" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-xl-3 col-sm-4 mb-2">
                <asp:DropDownList runat="server" ID="drpKy" DataValueField="id" DataTextField="ky" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-xl-3 col-sm-2 mb-2">
                <asp:Button ID="btnLaySL" runat="server" Text="Lấy số liệu" CssClass="btn btn-primary" OnClick="btnLaySL_Click" />
                <asp:Button ID="btnInLoHD" runat="server" class="btn btn-success" Text="In chuyển đổi theo lô" OnClick="btnInLoHD_Click" OnClientClick="return confirm('Bạn có chắc chắn in lô hóa đơn (Chỉ in các hóa đơn đã phát hành)?')" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 mb-2">
                <asp:Label runat="server" ID="txtErr" Font-Size="14px"></asp:Label>
            </div>
        </div>

        <div class="card mb-3">
            <div class="card-header">
                Danh sách hóa đơn điện tử
            </div>
            <div class="card-body-5 marginTop10">
                <div class="table-responsive">

                    <asp:GridView ID="GridViewEman" ClientIDMode="Static" runat="server" CssClass="table table-striped table-bordered table-hover dataTable no-footer dtr-inline" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Mẫu số">
                                <ItemTemplate>
                                    <asp:Label ID="lblMauSo" runat="server" Text='<%# Eval("mau_so") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ký hiệu">
                                <ItemTemplate>
                                    <asp:Label ID="lblKyHieu" runat="server" Text='<%# Eval("ky_hieu") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Số hóa đơn">
                                <ItemTemplate>
                                    <asp:Label ID="lblSoHD" runat="server" Text='<%# Eval("so_hd") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên khách hàng">
                                <ItemTemplate>
                                    <asp:Label ID="lblTenKH" runat="server" Text='<%# Eval("ten_kh") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mã KH">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaKH" runat="server" Text='<%# Eval("ma_kh") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bảng giá">
                                <ItemTemplate>
                                    <asp:Label ID="lblBangGia" runat="server" Text='<%# Eval("ten_viet_tat") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Số hộ">
                                <ItemTemplate>
                                    <asp:Label ID="lblSoHo" runat="server" Text='<%# Eval("so_ho") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ĐNTT">
                                <ItemTemplate>
                                    <asp:Label ID="lblDNTT" runat="server" Text='<%# Eval("dien_nang_tt") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Thành tiền" ItemStyle-CssClass="text-right">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("tong_tien_truoc_thue") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tiền thuế" ItemStyle-CssClass="text-right">
                                <ItemTemplate>
                                    <asp:Label ID="lblVatAmount" runat="server" Text='<%# Eval("thue_gtgt") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tổng tiền" ItemStyle-Font-Bold="true" ItemStyle-CssClass="text-right">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("tong_tien_sau_thue") %>'></asp:Label>
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
    </div>
    <asp:Panel ID="pnlContents" runat="server" CssClass="hidden" ClientIDMode="Static">
    </asp:Panel>
</asp:Content>
