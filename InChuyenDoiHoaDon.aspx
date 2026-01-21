<%@ Page Language="C#" Title="In chuyển đổi theo lô" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="InChuyenDoiHoaDon.aspx.cs" Inherits="InChuyenDoiHoaDon" %>

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
    <div id="page-wrapper">
        <div class="row">
            <div class="col-xl-3 col-sm-4 mb-2">
                <asp:dropdownlist runat="server" id="drpTram" AutoPostBack="true" datavaluefield="id_tram_bien_ap" datatextfield="ten_tram_bien_ap" cssclass="form-control" OnSelectedIndexChanged="drpTram_SelectedIndexChanged"></asp:dropdownlist>
            </div>
            <div class="col-xl-3 col-sm-4 mb-2">
                <asp:dropdownlist runat="server" id="drpKy" datavaluefield="id" datatextfield="ky" cssclass="form-control"></asp:dropdownlist>
            </div>
            <div class="col-xl-3 col-sm-2 mb-2">
               <%-- <asp:button id="btnLaySL" runat="server" text="Lấy số liệu" cssclass="btn btn-primary" onclick="btnLaySL_Click" />--%>
                <asp:button id="btnInLoHD" runat="server" class="btn btn-success" text="In chuyển đổi theo lô" onclick="btnInLoHD_Click" onclientclick="return confirm('Bạn có chắc chắn in lô hóa đơn (Chỉ in các hóa đơn đã phát hành)?')" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 mb-2">
                <asp:label runat="server" id="txtErr" font-size="14px"></asp:label>
            </div>
        </div>

        <div class="card mb-3">
            <div class="card-header">
                Danh sách cái hóa đơn điện tử
            </div>
            <div class="card-body-5">
                <div class="table-responsive">
                    <asp:gridview ID="GridViewEman" clientidmode="Static" runat="server" EmptyDataText="Không có hóa đơn nào"  cssclass="table table-responsive table-bordered" autogeneratecolumns="false">
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
                </asp:gridview>
                </div>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlContents" runat="server" CssClass="hidden"  ClientIDMode="Static">
    </asp:Panel>
</asp:Content>
