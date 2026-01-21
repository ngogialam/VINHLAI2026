<%@ Page Language="C#" Title="Thay thế hóa đơn" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ThayTheHoaDon.aspx.cs" Inherits="ThayTheHoaDon" %>

<asp:Content runat="server" ID="head" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-xl-3 col-sm-4 mb-2">
                <asp:TextBox ID="txtSoHD" CssClass="form-control" runat="server" placeholder="Nhập số hóa đơn cần thay thế"></asp:TextBox>
            </div>
              
             <div class="col-xl-3 col-sm-4 mb-2">
               <asp:DropDownList runat="server" ID="drpSerial" CssClass="form-control">
			   <asp:ListItem Value="C26TVL" Selected="True"> C26TVL </asp:ListItem>
				<asp:ListItem Value="C25TVL" > C25TVL </asp:ListItem>
                   		   <asp:ListItem Value="C24TVL" > C24TVL </asp:ListItem>
                   		   <asp:ListItem Value="C23TVL" > C23TVL </asp:ListItem>
                   <asp:ListItem Value="C22TVL" > C22TVL </asp:ListItem>
                    <asp:ListItem Value="VL/20E"> VL/20E </asp:ListItem>
                    <asp:ListItem Value="VL/19E"> VL/19E </asp:ListItem>               
               </asp:DropDownList>                         
            </div>
            <div class="col-xl-3 col-sm-2 mb-2">
                <asp:Button ID="btnLaySoLieu" runat="server" class="btn btn-success" Text="Thay thế" OnClick="btnLaySoLieu_Click"/>
                <asp:Button ID="btnThayThe" runat="server" class="btn btn-primary" Text="Phát hành hóa đơn" OnClick="btnPhatHanhHD_Click" OnClientClick="return confirm('Bạn có chắc chắn thay thế hóa đơn?')" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 mb-2">
                <asp:Label runat="server" ID="txtErr" Font-Size="14px"></asp:Label>
				 <asp:Label runat="server" ID="txtErr2" Font-Size="14px"></asp:Label>
            </div>
        </div>
        <div class="card mb-3">
            <div class="card-header">
                Danh sách cái hóa đơn điện tử
            </div>
            <div class="card-body-5">
                <div class="table-responsive">
                    <asp:GridView ID="GirdViewReplace" ClientIDMode="Static" runat="server" CssClass="table table-striped table-bordered table-hover dataTable no-footer dtr-inline" AutoGenerateColumns="False" OnRowDataBound="GirdViewReplace_RowDataBound" >
                        <Columns>
                             <asp:TemplateField HeaderText="ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="Mẫu số"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblMauSo" runat="server" Text='<%# Eval("mau_so") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ký hiệu"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblKyHieu" runat="server" Text='<%# Eval("ky_hieu") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Số HĐ"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblSoHD" runat="server" Text='<%# Eval("so_hd") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Kỳ">
                                <ItemTemplate>
                                    <asp:Label ID="lblKy" runat="server" Text='<%# Eval("ky_hd") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mã KH">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaKH" runat="server" Text='<%# Eval("ma_kh") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên khách hàng" ControlStyle-Width="280px">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblTenKH" runat="server" Text='<%# Eval("ten_kh") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
							<asp:TemplateField HeaderText="Từ ngày" ControlStyle-Width="180px">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblTuNgay" runat="server" Text='<%# Eval("tu_ngay") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
							<asp:TemplateField HeaderText="Đến ngày" ControlStyle-Width="180px">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblDenNgay" runat="server" Text='<%# Eval("den_ngay") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Địa chỉ" ControlStyle-Width="280px">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblDiaChi" runat="server" Text='<%# Eval("dia_chi") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Số hộ" ControlStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblSoHo" runat="server" Text='<%# Eval("so_ho") %>' OnTextChanged="lblSoHo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bảng giá" ControlStyle-Width="250px">
                                <ItemTemplate>
                                    <asp:DropDownList ID="drpBangGia" runat="server" ClientIDMode="Static" CssClass="form-control input-lg" DataTextField="ten_bang_gia" DataValueField="id_bang_gia" OnSelectedIndexChanged="drpBangGia_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mã CT">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaCT" runat="server" Text='<%# Eval("ma_cong_to") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CS cũ" ControlStyle-Width="100px">
                                <ItemTemplate>
                                   <%-- <asp:Label ID="lblCSCu" runat="server" Text='<%# Eval("chi_so_cu") %>'></asp:Label>--%>
                                    <asp:TextBox ID="txtCSCu" CssClass="form-control" runat="server" Text='<%# Eval("chi_so_cu") %>' OnTextChanged="txtCSCu_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CS mới" ControlStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCSMoi" CssClass="form-control" runat="server" Text='<%# Eval("chi_so_moi") %>' OnTextChanged="txtCSMoi_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Thuế suất" ControlStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtVatrate" CssClass="form-control" runat="server" Text='<%# Eval("vat_rate") %>' OnTextChanged="txtVatRate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ĐNTT">
                                <ItemTemplate>
                                     <asp:Label ID="lblDienNangTT" runat="server" Text='<%# Eval("dien_nang_tt") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Thành tiền" ItemStyle-CssClass="text-right" Visible="True">
                            <ItemTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text='<%# string.Format("{0:#,0}",Eval("tong_tien_truoc_thue") )%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tiền thuế" ItemStyle-CssClass="text-right" Visible="True">
                            <ItemTemplate>
                                <asp:Label ID="lblVatAmount" runat="server" Text='<%# string.Format("{0:#,0}",Eval("thue_gtgt")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tổng tiền" ItemStyle-Font-Bold="true" ItemStyle-CssClass="text-right">
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" runat="server" Text='<%# string.Format("{0:#,0}",Eval("tong_tien_sau_thue")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                       
                            <asp:TemplateField HeaderText="idTrangThai" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblTrangThaiID" runat="server" Text='<%# Eval("trang_thai") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="idTramBA" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="idTramBA" runat="server" Text='<%# Eval("id_tram_bien_ap") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="idBangGia" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="idBangGia" runat="server" Text='<%# Eval("id_bang_gia_dien") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="idKhu" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="idKhu" runat="server" Text='<%# Eval("id_khu") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
