<%@ Page Language="C#" Title="Báo cáo tổng hợp" EnableEventValidation="false" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeFile="BaoCaoTongHop.aspx.cs" Inherits="BaoCaoTongHop" %>

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
                    <label class="key">Chọn báo cáo (<span style="color: red">*</span>):</label>
                    <div class="value">
                        <asp:DropDownList ID="ddlChonBC" runat="server" DataTextField="ten_bc" DataValueField="id_bc" CssClass="form-control">
                            <asp:ListItem Value="01">Báo cáo tình hình bán điện các trạm BA</asp:ListItem>
                            <asp:ListItem Value="02">Báo cáo tổng hợp sản lượng theo bảng giá</asp:ListItem>
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
            </div>
            <div class="col-sm-6">
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
        <div class="row">
            <asp:Label runat="server" ID="lblErr"></asp:Label>
        </div>
    </div>

    <div class="card-header">
        <td>
            <button id="btnBaoCao" runat="server" onserverclick="XemBC" class="btn btn-primary"><i class="fa fa-eye" aria-hidden="true"></i>&nbsp;Xem</button>
        </td>
        <td>
            <a href="./BaoCaoTongHopDetail.aspx" class="btn btn-primary" target="_blank"><i class="fa fa-download" aria-hidden="true"></i>&nbsp;Xuất BC</a>
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
                                <asp:BoundField DataField="ma" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="Mã KH" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="ten" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="Tên" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="dien_nang_tt" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="Sản lượng" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="tong_tien_truoc_thue" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="Trước thuế" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="thue_gtgt" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="Thuế VAT" DataFormatString="{0:0,0}" />
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


