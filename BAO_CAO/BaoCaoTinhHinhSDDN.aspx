<%@ Page Language="C#" Title="Báo cáo tổng hợp" EnableEventValidation="false" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeFile="BaoCaoTinhHinhSDDN.aspx.cs" Inherits="BaoCaoTinhHinhSDDN" %>

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
            <a href="./BaoCaoTinhHinhSDDNDetail.aspx" class="btn btn-primary" target="_blank"><i class="fa fa-download" aria-hidden="true"></i>&nbsp;Xuất BC</a>
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
                                <asp:BoundField DataField="ten_tram_bien_ap" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    HeaderText="Tên trạm" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="muc1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="Mức 1" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="muc2" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="Mức 2" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="muc3" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="Mức 3" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="muc4" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="Mức 4" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="muc5" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="Mức 5" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="muc6" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="Mức 6" />
                            </Columns>
                           <Columns>
                                <asp:BoundField DataField="SX" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="SX" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="TDKD" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="TĐKD" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="KD" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="KD" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="CS" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="CS" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="DX" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="DX" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="NT" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="NT" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="BN" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="BN" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="GBT" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="GBT" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="GCD" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="GCD" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="GTD" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="GTD" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="TongCong" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderText="Tổng cộng" />
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


