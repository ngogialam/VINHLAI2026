<%@ Page Language="C#" Title="Danh sách chốt chỉ số công tơ" EnableEventValidation="false" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeFile="DSChotChiSo.aspx.cs" Inherits="DSChotChiSo" %>

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
                    <label class="key">Trạm biến áp (<span style="color: red">*</span>):</label>
                    <div class="value">
                        <asp:DropDownList ID="ddlTramBA" runat="server" DataTextField="ten_tram_bien_ap" DataValueField="id_tram_bien_ap" CssClass="form-control">
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
                    <label class="key">Khoảng thời gian (<span style="color: red">*</span>):</label>
                    <div class="value">
                        <asp:DropDownList ID="ddlThoiGian" runat="server" DataTextField="ten_bang_gia" DataValueField="id_thoi_gian" CssClass="form-control">
                            <asp:ListItem Value="03">03 tháng</asp:ListItem>
                            <asp:ListItem Value="06">06 tháng</asp:ListItem>
                            <asp:ListItem Value="12">12 tháng</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="user-info-row" style="border: none">
                    <label class="key">Chọn năm (<span style="color: red">*</span>):</label>
                    <div class="value">
                        <asp:DropDownList ID="ddlNam" runat="server" DataTextField="nam" DataValueField="nam" CssClass="form-control">
                        </asp:DropDownList>
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
            <a href="./DSChotChiSoDetail.aspx" class="btn btn-primary" target="_blank"><i class="fa fa-download" aria-hidden="true"></i>&nbsp;Xuất BC</a>
        </td>
        <asp:CheckBox ID="chkInTrang" runat="server" Text="In Sổ Trắng" />
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
                                <asp:BoundField DataField="ma_cong_to" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="Mã công tơ" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="T1" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="T1" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="T2" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="T2" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="T3" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="T3" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="T4" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="T4" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="T5" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="T5" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="T6" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="T6" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="T7" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="T7" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="T8" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="T8" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="T9" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="T9" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="T10" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="T10" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="T11" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="T11" DataFormatString="{0:0,0}" />
                            </Columns>
                            <Columns>
                                <asp:BoundField DataField="T12" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="T12" DataFormatString="{0:0,0}" />
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


