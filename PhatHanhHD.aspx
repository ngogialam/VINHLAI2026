<%@ Page Language="C#" Title="Phát hành hóa đơn" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="PhatHanhHD.aspx.cs" Inherits="PhatHanhHD" %>

<asp:Content runat="server" ID="head" ContentPlaceHolderID="head">     
  
 <script type="text/javascript">
     function CheckAll(oCheckbox) {
         var GridView1 = document.getElementById("<%=GirdViewNoPaGE.ClientID%>");        
         for (i = 1; i < GridView1.rows.length; i++) {
             GridView1.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
         }
     }
    </script>

</asp:Content>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
  https://htxdnvinhlai-tt78admin.vnpt-invoice.com.vn
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div id="page-wrapper">  
        <div class="row">
            <div class="col-xl-3 col-sm-4 mb-2">
                <%--<asp:DropDownList CssClass="form-control" runat="server" ID="ddlCa">
                    <asp:ListItem Selected="True" Value="01GTKT0/001">01GTKT0/001</asp:ListItem>
                    <asp:ListItem Value="3">Ca 3</asp:ListItem>
                    <asp:ListItem Value="1">Ca 1</asp:ListItem>
                    <asp:ListItem Value="2">Ca 2</asp:ListItem>
                </asp:DropDownList>--%>
                <asp:DropDownList runat="server" ID="drpTram" DataValueField="id_tram_bien_ap" DataTextField="ten_tram_bien_ap" CssClass="form-control"></asp:DropDownList>            
            </div>
            <div class="col-xl-3 col-sm-4 mb-2">
               <asp:DropDownList runat="server" ID="drpKy" DataValueField="id" DataTextField="ky" CssClass="form-control"></asp:DropDownList>                         
            </div>
                <div class="col-xl-3 col-sm-4 mb-2">
               <asp:DropDownList runat="server" ID="drpPattern" CssClass="form-control">
                   <asp:ListItem Value="1/001" Selected="True" >1/001</asp:ListItem>
                    <asp:ListItem Value="01GTKT0/001" >01GTKT0/001</asp:ListItem>
                   <asp:ListItem Value="01GTKT0/002" >01GTKT0/002</asp:ListItem>
                               
               </asp:DropDownList>                         
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
         
           
        </div>
         <div class="row">
              <div class="col-xl-6 col-sm-2 mb-2"> 
                <asp:Button ID="btnLaySL" runat="server" Text="Lấy số liệu" CssClass="btn btn-primary" OnClick="btnLaySL_Click" />               
                <asp:Button ID="btnPhatHanh" runat="server" class="btn btn-danger" Text="Phát hành HD cả trạm" OnClick="btnPhatHanh_Click" OnClientClick="return confirm('Bạn có chắc chắn phát hành hóa đơn?')" />
           <asp:Button ID="btnDongBo" runat="server" class="btn btn-danger" Text="Đồng bộ hóa đơn lỗi" OnClick="btnDongBo_Click" OnClientClick="return confirm('Bạn có chắc chắn muốn đồng bộ hóa đơn?')" />
                </div>
             </div>
        <div class="row">
                <div class="col-sm-12 mb-2">
                <asp:Label runat="server" ID="txtErr" Font-Size="14px" ></asp:Label>
            </div>
        </div>
      
    <div class="card mb-3">
        <div class="card-header">
            Danh sách cái hóa đơn mới tạo lập
        </div>
        <div class="card-body-5">
            <div class="table-responsive">
                <asp:GridView ID="GirdViewNoPaGE" ClientIDMode="Static" runat="server" CssClass="table table-responsive table-bordered" AutoGenerateColumns="false">
                    <Columns>                   
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblIDHD" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã KH">
                            <ItemTemplate>
                                <asp:Label ID="lblMaKH" runat="server" Text='<%# Eval("ma_kh") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên khách hàng">
                            <ItemTemplate>
                                <asp:Label ID="lblTenKH" runat="server" Text='<%# Eval("ten_kh") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Khu">
                            <ItemTemplate>
                                <asp:Label ID="lblDB" runat="server" Text='<%# Eval("ten_khu") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạm">
                            <ItemTemplate>
                                <asp:Label ID="lblMaTram" runat="server" Text='<%# Eval("ten_tram_bien_ap") %>'></asp:Label>
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
                        <asp:TemplateField HeaderText="CS cũ">
                            <ItemTemplate>
                                <asp:Label ID="lblCSCu" runat="server" Text='<%# Eval("chi_so_cu") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CS mới">
                            <ItemTemplate>
                                <asp:Label ID="lblCSMoi" runat="server" Text='<%# Eval("chi_so_moi") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ĐNTT">
                            <ItemTemplate>
                                <asp:Label ID="lblDNTT" runat="server" Text='<%# Eval("dien_nang_tt") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="Thành tiền">
                            <ItemTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("tong_tien_truoc_thue") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tiền thuế">
                            <ItemTemplate>
                                <asp:Label ID="lblVatAmount" runat="server" Text='<%# Eval("thue_gtgt") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tổng tiền" ItemStyle-Font-Bold="true">
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("tong_tien_sau_thue") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Giảm trừ tháng 10" ItemStyle-Font-Bold="true">
                            <ItemTemplate>
                                <asp:Label ID="lblGiamThang10" runat="server" Text='<%# Eval("giam_tru_thang_10")  %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Giảm trừ tháng 11" ItemStyle-Font-Bold="true">
                            <ItemTemplate>
                                <asp:Label ID="lblGiamThang11" runat="server" Text='<%# Eval("giam_tru_thang_11") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Giảm trừ tháng 12" ItemStyle-Font-Bold="true">
                            <ItemTemplate>
                                <asp:Label ID="lblGiamThang12" runat="server" Text='<%# Eval("giam_tru_thang_12") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã CT">
                            <ItemTemplate>
                                <asp:Label ID="lblMaCT" runat="server" Text='<%# Eval("ma_cong_to") %>'></asp:Label>
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
        
</asp:Content>