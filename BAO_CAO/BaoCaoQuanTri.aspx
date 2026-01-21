<%@ Page Language="C#" Title="Báo cáo quản trị" EnableEventValidation="false" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeFile="BaoCaoQuanTri.aspx.cs" Inherits="BaoCaoQuanTri" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script type="text/javascript"></script>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-12">
        </div>
    </div>
    <div class="card-header">
        <div class="row">
            <div class="col-sm-6">
                <div class="user-info-row" style="border: none">
                    <label class="key">Chọn báo cáo:</label>
                    <div class="value">
                        <asp:DropDownList ID="ddlChonBC" runat="server" DataTextField="chon_bc" DataValueField="id_chon_bc" CssClass="form-control"
                            OnSelectedIndexChanged="ddlChonBC_SelectedIndexChanged" OnTextChanged="ddlChonBC_TextChanged">
                            <asp:ListItem Value="01">Danh sách KH có chỉ số đồng hồ lớn</asp:ListItem>
                            <asp:ListItem Value="02">Danh sách KH có mức tiêu thụ lớn</asp:ListItem>
                            <asp:ListItem Value="03">Danh sách KH có mức tiêu thụ nhỏ</asp:ListItem>
                            <asp:ListItem Value="04">Danh sách KH không sử dụng điện</asp:ListItem>
                            <asp:ListItem Value="05">Danh sách KH không phát hành hóa đơn</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="user-info-row" style="border: none">
                    <label class="key">Xóm/Khu (<span style="color: red">*</span>):</label>
                    <div class="value">
                        <asp:DropDownList ID="ddlXomKhu" runat="server" DataTextField="ten_khu" DataValueField="id_khu" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="user-info-row" style="border: none">
                    <asp:Label ID="lblTenThamSo" runat="server" Text="Tham số:" CssClass="key"></asp:Label>
                    <div class="value">
                        <asp:TextBox ID="txtThamSo" runat="server" CssClass="form-control">0</asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="user-info-row" style="border: none">
                    <label class="key">Trạm biến áp (<span style="color: red">*</span>):</label>
                    <div class="value">
                        <asp:DropDownList ID="ddlTramBA" runat="server" DataTextField="ten_tram_bien_ap" DataValueField="id_tram_bien_ap" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="user-info-row" style="border: none">
                    <label class="key">Chọn tháng, năm (<span style="color: red">*</span>):</label>
                    <div class="value">
                        <div class="row">
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlThang" runat="server" DataTextField="ca" DataValueField="ca" CssClass="form-control">
                                    <asp:ListItem Value="01">01</asp:ListItem>
                                    <asp:ListItem Value="02">02</asp:ListItem>
                                    <asp:ListItem Value="03">03</asp:ListItem>
                                    <asp:ListItem Value="04">04</asp:ListItem>
                                    <asp:ListItem Value="05">05</asp:ListItem>
                                    <asp:ListItem Value="06">06</asp:ListItem>
                                    <asp:ListItem Value="07">07</asp:ListItem>
                                    <asp:ListItem Value="08">08</asp:ListItem>
                                    <asp:ListItem Value="09">09</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlNam" runat="server" DataTextField="nam" DataValueField="nam" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="card-header">
        <td>
            <button id="btnBaoCao" runat="server" onserverclick="XemBC" class="btn btn-primary"><i class="fa fa-eye" aria-hidden="true"></i>&nbsp;Xem</button>
        </td>
        <td>
            <a href="./BaoCaoQuanTriDetail.aspx" class="btn btn-primary" target="_blank"><i class="fa fa-download" aria-hidden="true"></i>&nbsp;Xuất BC</a>
        </td>
    </div>
    <div class="form-group" style="clear: both;">
        <asp:Label ID="txtErr" runat="server" ForeColor="#FF3300"></asp:Label>
    </div>
    <div runat="server" id="Div1">
        <div class="box-body">
            <div class="row">
                <div class="col-md-2"></div>
                <%--<div class="col-md-12" runat="server" id="divTieuDe">
                                <label>
                                    Danh sách thuê bao<span class="style2" style="color: red">
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label></span>.</label>
                            </div>--%>
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="Không có dữ liệu hiển thị"
                            CssClass="table table-striped table-bordered table-hover" OnPageIndexChanged="GridView1_PageIndexChanged"
                            OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4" ForeColor="#333333"
                            GridLines="None">

                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                            <PagerSettings Mode="Numeric" Position="Bottom" PageButtonCount="20" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="stt" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    HeaderText="STT" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="ma_kh" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="Mã KH" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="ten_kh" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="Họ tên" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="dia_chi" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="Địa chỉ" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="so_ho" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="Số hộ" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="ten_viet_tat" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="Loại hình" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="chi_so_cu" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="CSĐK" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="chi_so_moi" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="CSCK" DataFormatString="{0:0,0}" />
                            </Columns>

                            <Columns>
                                <asp:BoundField DataField="dien_nang_tt" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="Tiêu thụ" DataFormatString="{0:0,0}" />
                            </Columns>

                            <Columns>
                                <asp:BoundField DataField="tong_tien_sau_thue" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="Sau thuế" DataFormatString="{0:0,0}" />
                            </Columns>

                            <PagerStyle BackColor="#2461BF" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head"> 
</asp:Content>


