<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongKeBangThong.aspx.cs" Inherits="BaoCao_ThongKeBangThong" %>--%>

<%@ Page Language="C#" Title="Bán hàng" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="BanHang.aspx.cs" Inherits="BanHang" %>
<asp:Content runat="server" ID="head" ContentPlaceHolderID="head">
    <%--<script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src="http://cdn.rawgit.com/bassjobsen/Bootstrap-3-Typeahead/master/bootstrap3-typeahead.min.js"></script>--%>
<script type="text/javascript" src="Scripts/bootstrap3-typeahead.min.js"></script>
<script type="text/javascript">
    function getDate() { var e = new Date, t = e.getDate(), n = e.getMonth() + 1, a = e.getFullYear(), o = e.getHours(), i = e.getMinutes(), l = e.getSeconds(); return o < 10 && (o = "0" + o), i < 10 && (i = "0" + i), l < 10 && (l = "0" + l), t < 10 && (t = "0" + t), n < 10 && (n = "0" + n), e = t + "/" + n + "/" + a + " " + (o + ":" + i + ":" + l) } function getSoHD() { var e = (new Date).getFullYear(); $.ajax({ url: '<%=ResolveUrl("~/BanHang.aspx/GetSoHD") %>', data: "{ 'prefix': '" + e + "'}", dataType: "json", type: "POST", contentType: "application/json; charset=utf-8", success: function (e) { var t; items = [], map = {}, $.each(e.d, function (e, n) { t = n, document.getElementById("txtID").value = t, $("[id*=hfsoHD]").val(t) }) }, error: function (e) { alert(e.responseText) }, failure: function (e) { alert(e.responseText) } }) } function getSL() { $.ajax({ url: '<%=ResolveUrl("~/BanHang.aspx/GetSL") %>', data: "{ 'prefix': '1'}", dataType: "json", type: "POST", contentType: "application/json; charset=utf-8", success: function (e) { var t; items = [], map = {}, $.each(e.d, function (e, n) { t = n, document.getElementById("BOX20").value = t }) }, error: function (e) { alert(e.responseText) }, failure: function (e) { alert(e.responseText) } }), $.ajax({ url: '<%=ResolveUrl("~/BanHang.aspx/GetSL") %>', data: "{ 'prefix': '2'}", dataType: "json", type: "POST", contentType: "application/json; charset=utf-8", success: function (e) { var t; items = [], map = {}, $.each(e.d, function (e, n) { t = n, document.getElementById("BOX30").value = t }) }, error: function (e) { alert(e.responseText) }, failure: function (e) { alert(e.responseText) } }), $.ajax({ url: '<%=ResolveUrl("~/BanHang.aspx/GetSL") %>', data: "{ 'prefix': '3'}", dataType: "json", type: "POST", contentType: "application/json; charset=utf-8", success: function (e) { var t; items = [], map = {}, $.each(e.d, function (e, n) { t = n, document.getElementById("BOX50").value = t }) }, error: function (e) { alert(e.responseText) }, failure: function (e) { alert(e.responseText) } }), $.ajax({ url: '<%=ResolveUrl("~/BanHang.aspx/GetSL") %>', data: "{ 'prefix': '4'}", dataType: "json", type: "POST", contentType: "application/json; charset=utf-8", success: function (e) { var t; items = [], map = {}, $.each(e.d, function (e, n) { t = n, document.getElementById("KEG1").value = t }) }, error: function (e) { alert(e.responseText) }, failure: function (e) { alert(e.responseText) } }), $.ajax({ url: '<%=ResolveUrl("~/BanHang.aspx/GetSL") %>', data: "{ 'prefix': '5'}", dataType: "json", type: "POST", contentType: "application/json; charset=utf-8", success: function (e) { var t; items = [], map = {}, $.each(e.d, function (e, n) { t = n, document.getElementById("KEG2").value = t }) }, error: function (e) { alert(e.responseText) }, failure: function (e) { alert(e.responseText) } }), $.ajax({ url: '<%=ResolveUrl("~/BanHang.aspx/GetSL") %>', data: "{ 'prefix': '6'}", dataType: "json", type: "POST", contentType: "application/json; charset=utf-8", success: function (e) { var t; items = [], map = {}, $.each(e.d, function (e, n) { t = n, document.getElementById("BC1").value = t }) }, error: function (e) { alert(e.responseText) }, failure: function (e) { alert(e.responseText) } }), $.ajax({ url: '<%=ResolveUrl("~/BanHang.aspx/GetSL") %>', data: "{ 'prefix': '7'}", dataType: "json", type: "POST", contentType: "application/json; charset=utf-8", success: function (e) { var t; items = [], map = {}, $.each(e.d, function (e, n) { t = n, document.getElementById("BL").value = t }) }, error: function (e) { alert(e.responseText) }, failure: function (e) { alert(e.responseText) } }) } function getTotal() { var e = document.getElementById("sl20").value, t = document.getElementById("sl30").value, n = document.getElementById("sl50").value, a = document.getElementById("slkeg1l").value, o = document.getElementById("slkeg2l").value, i = document.getElementById("slbiachai").value, l = document.getElementById("slbialit").value, r = parseInt(20 * e) + parseInt(30 * t) + parseInt(50 * n) + parseInt(l); parseInt(r), parseInt(a), parseInt(2 * o); $("[id*=hfBH20]").val(e), $("[id*=hfBH30]").val(t), $("[id*=hfBH50]").val(n), $("[id*=hfBK1]").val(a), $("[id*=hfBK2]").val(o), $("[id*=hfBC]").val(i), $("[id*=hfBL]").val(l), $("[id*=hfTongBH]").val(r), $("[id*=txtTongSoBia]").val(r), $("[id*=txtTongChai]").val(i), 0 == a && 0 == o ? $("[id*=txtTongKeg]").val(0) : 0 == a ? $("[id*=txtTongKeg]").val(o + " (Keg2L)") : 0 == o ? $("[id*=txtTongKeg]").val(a + " (Keg1L)") : $("[id*=txtTongKeg]").val(a + " (Keg1L) - " + o + " (Keg2L)") } function validate() { var e = document.getElementById("txtTongSoBia").value, t = (document.getElementById("txtTongKeg").value, document.getElementById("txtTongChai").value), n = document.getElementById("slkeg1l").value, a = document.getElementById("slkeg2l").value; if ("" == document.getElementById("txtKhachHang").value || e + n + a + t <= 0) return alert("Bạn phải nhập khách hàng và số lượng bia"), !1 } function PrintPanel() { var e = document.getElementById("pnlContents"), t = window.open("", "", "height=800,width=1000"); t.document.write("<html><head><title>In phiếu xuất kho</title>"), t.document.write('<link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />'), t.document.write('<style type="text/css">'), t.document.write(" .table-print > thead > tr > th, .table-print > tbody > tr > th, .table-print > tfoot > tr > th, .table-print > thead > tr > td, .table-print > tbody > tr > td, .table-print > tfoot > tr > td {"), t.document.write("border: 1px solid #000000;"), t.document.write('}</style></head><body><div style="width: 886px;display: block;margin-left: auto;margin-right: auto;font-size:18px !important">'), t.document.write(e.innerHTML), t.document.write("</div></body></html>"), t.document.close(), setTimeout(function () { t.print() }, 0) } $(function () { $("[id*=txtKhachHang]").typeahead({ hint: !0, highlight: !0, minLength: 1, scrollHeight: 100, source: function (e, t) { $.ajax({ url: '<%=ResolveUrl("~/BanHang.aspx/GetCustomers") %>', data: "{ 'prefix': '" + e + "'}", dataType: "json", type: "POST", contentType: "application/json; charset=utf-8", success: function (e) { items = [], map = {}, $.each(e.d, function (e, t) { var n = t.split("$")[0], a = t.split("$")[1], o = t.split("$")[2], i = t.split("$")[3], l = t.split("$")[4]; map[n] = { id: n, name: a, phuong: o, diachi: i, dt: l }, items.push(n) }), t(items), $(".dropdown-menu").css("height", "auto") }, error: function (e) { alert(e.responseText) }, failure: function (e) { alert(e.responseText) } }) }, displayText: function (e) { return "<h6>" + map[e].id + "-" + map[e].name + "</h6><p >" + map[e].phuong + "</p> <p>Địa chỉ:" + map[e].diachi + "</p>" }, afterSelect: function (e) { $("[id*=txtKhachHang]").val(map[e].name) }, updater: function (e) { return $("[id*=hfKHId]").val(map[e].id), $("[id*=hfTenKH]").val(map[e].name), $("[id*=hfDT").val(map[e].dt), $("[id*=hfDiaChiKH").val(map[e].diachi), $("[id*=hfPhuong").val(map[e].phuong), e } }) }), $(document).ready(function () { document.getElementById("txtdate").value = getDate(), getSoHD(), getSL(), $("[id*=hfNgayBan]").val(getDate()) });
</script>   
</asp:Content>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">  
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="card mb-1">
        <div class="card-header">
            <div class="row">
                <div class="col-auto ">
                   <button type="button" class="btn">BOX 50L<br /> 
                    <input class="form-noti border border-light rounded " readonly="read-only" id="BOX50"  /></button>
                </div> 
                <div class="col-auto ">
                   <button type="button" class="btn btn-warning">BOX 30L<br /> 
                    <input class="form-noti border border-light rounded " readonly="read-only" id="BOX30"  /></button>
                </div> 
                 <div class="col-auto ">
                   <button type="button" class="btn btn-primary">BOX 20L<br /> 
                    <input class="form-noti border border-light rounded " readonly="read-only" id="BOX20"  /></button>
                </div> 
                <div class=" col-auto ">
                   <button type="button" class="btn btn-danger">BIA LẺ<br /> 
                    <input class="form-noti border border-light rounded " readonly="read-only" id="BL"  /></button>
                </div> 
                 <div class="col-auto ">
                   <button type="button" class="btn btn-success">KEG 2L<br /> 
                    <input class="form-noti border border-light rounded " readonly="read-only" id="KEG2"  /></button>
                </div> 
                 <div class=" col-auto ">
                   <button type="button" class="btn btn-info">KEG 1L<br /> 
                    <input class="form-noti border border-light rounded " readonly="read-only" id="KEG1"  /></button>
                </div> 
                 <div class="col-auto ">
                   <button type="button" class="btn ">CHAI 1L<br /> 
                    <input class="form-noti border border-light rounded " readonly="read-only" id="BC1"  /></button>
                </div> 
            </div>
        </div>   
        </div>  
    <div class="card mb-1">     
        <div class="card-body">
            <div class="row">
                <div class="col-sm-4 mb-1">
                    <label>Số phiếu </label>
                     <input  class="form-control" readonly="read-only" id="txtID"  name="txtID">                 
                </div>
                  <div class="col-sm-4 mb-1">
                    <label>Ngày bán hàng </label>
                     <input  class="form-control" readonly="read-only" id="txtdate" name="txtdate">
                </div>
                <div class="col-sm-4 mb-1">
                    <label>Người bán hàng </label>
                     <asp:TextBox  Cssclass="form-control" runat="server" ID="txtNguoiBan" ReadOnly="True"></asp:TextBox>
                </div>
            </div>

             <div class="row">
                <div class="col-sm-8 mb-1">
                    <label>Khách hàng</label>
                    <%--<asp:TextBox  Cssclass="form-control" runat="server" ID="txtKhachHang" ClientIDMode="Static" autocomplete="off"></asp:TextBox>--%>
                    <input  class="form-control" id="txtKhachHang" autocomplete="off"  name="txtKhachHang">          
                    <asp:HiddenField ID="hfKHId" runat="server" />
                    <asp:HiddenField ID="hfTenKH" runat="server" />
                    <asp:HiddenField ID="hfsoHD" runat="server" />
                    <asp:HiddenField ID="hfNguoiBan" runat="server" />
                    <asp:HiddenField ID="hfNgayBan" runat="server" />
                    <asp:HiddenField ID="hfBH20" runat="server" />
                    <asp:HiddenField ID="hfBH30" runat="server" />
                    <asp:HiddenField ID="hfBH50" runat="server" />
                    <asp:HiddenField ID="hfBK1" runat="server" />
                    <asp:HiddenField ID="hfBK2" runat="server" />
                    <asp:HiddenField ID="hfBC" runat="server" />
                    <asp:HiddenField ID="hfBL" runat="server" />
                    <asp:HiddenField ID="hfTongBH" runat="server" />
                    <%--<asp:HiddenField ID="hfTongSL" runat="server" />--%>
                    <asp:HiddenField ID="hfDiaChiKH" runat="server" />
                    <asp:HiddenField ID="hfPhuong" runat="server" />
                    <asp:HiddenField ID="hfDT" runat="server" />
                </div>          
            
                 <div class="col-sm-2 mb-1">                     
                    <button type="button" style="margin-top: 30px;width: 100%;" class="btn btn-success" data-toggle="modal" data-target="#addCusModal">Thêm KH</button>
                 </div>
                 <div class="col-sm-2 mb-1">                     
                    <a href="ChotCa.aspx" ><button  type="button" style="margin-top: 30px;width: 100%;" class="btn btn-danger" >Chốt ca</button></a>
                 </div>
             </div>
            <div class="row">
                 <div class="col-sm-2 mb-1">
                    <label>Bia hơi 50L</label>
                     <input  class="form-control" type="number" min="0" id="sl50" name="sl50" value="0" onchange="getTotal()">
                </div> 
                <div class="col-sm-2 mb-1">
                    <label>Bia hơi 30L</label>
                     <input  class="form-control" type="number" min="0" id="sl30" name="sl30" value="0" onchange="getTotal()">
                </div>   
                 <div class="col-sm-2 mb-1">
                    <label>Bia hơi 20L</label>
                     <input  class="form-control" type="number" min="0" id="sl20" name="sl20" value="0" onchange="getTotal()">                    
                </div>    
                <div class="col-sm-2 mb-1">
                    <label>Bia keg 2L</label>
                    <input  class="form-control" type="number" min="0" id="slkeg2l" name="slkeg2l" value="0" onchange="getTotal()">
                </div>   
                <div class="col-sm-2 mb-1">
                    <label>Bia keg 1L</label>
                     <input  class="form-control" type="number" min="0" id="slkeg1l" name="slkeg1l" value="0" onchange="getTotal()">
                </div>     
                <div class="col-sm-2 mb-1">
                    <label>Bia chai 1L</label>
                     <input  class="form-control" type="number" min="0" id="slbiachai" name="slbiachai" value="0" onchange="getTotal()">
                </div>           
            </div>

            <div class="row">
              <div class="col-sm-2 mb-1">
                    <label>Bia lẻ</label>
                     <input  class="form-control" type="number" min="0" id="slbialit" name="slbialit" value="0" onchange="getTotal()">
                </div>                
               
            </div>           
            <div class="row">
                <div class="col-sm-4 mb-2">
                    <label><b>Tổng số bia hơi (lít)</b>  </label>               
                    <input id="txtTongSoBia" class="form-control" readonly="read-only"  style="font-weight: bold;"/>              
                </div>
                <div class="col-sm-4 mb-2">
                    <label><b>Tổng số bia keg (keg)</b></label>                
                    <input id="txtTongKeg" class="form-control" readonly="read-only"  style="font-weight: bold;"/>                   
                </div> 
                <div class="col-sm-4 mb-2">
                    <label><b>Tổng số bia chai (chai)</b></label>                
                    <input id="txtTongChai" class="form-control" readonly="read-only"  style="font-weight: bold;"/>                   
                </div>            
            </div>         
            <div class="row">
                <div class="col-sm-12 mb-1">                    
                    <asp:Button ID="btnLuuIn"  Text="Lưu và in" CssClass="btn btn-primary" runat="server" Width="100%" OnClientClick="return validate()" OnClick="btnLuuIn_Click"  />          
                </div>   
                    
            </div>             
        </div>
    </div>
    <asp:Panel ID="pnlContents" runat="server" CssClass="hidden"  ClientIDMode="Static">
        <div style="text-align: left; height: 80px;">
            <p style="margin: 0; font-size: 20px"><b>CÔNG TY CỔ PHẦN BIA RƯỢU NƯỚC GIẢI KHÁT VIGER</b></p>
            <p style="margin-top: 5px; font-size: 18px">
                Địa chỉ: Khu 7, Phường Thanh Miếu, Thành phố Việt Trì, Phú Thọ<br />
                Điện thoại: 02103 862 721
            </p>          
        </div>
        <div class="row">
            <div class="col-sm-12 mb-3" style="text-align: center">
                 <p style="margin: 0; font-size: 30px"><b>PHIẾU XUẤT KHO</b></p>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4 mb-3" style="text-align: right">
                
            </div>
            <div class="col-sm-4 mb-3" style="text-align: center">
                <asp:Label runat="server" ID="lblngaythang"></asp:Label>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: center">
                 Số: <b><asp:Label runat="server" ID="lblSoHD"></asp:Label></b>
            </div>
        </div>            
         <div class="row">
            <div class="col-sm-8 mb-3" style="text-align: left">
                <p style="margin: 0;">Khách hàng:<b> <asp:Label runat="server"  ID="lblTenKH"></asp:Label></b></p>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: left">
                   <p style="margin: 0;">Điện thoại:<b> <asp:Label runat="server"  ID="lblDT"></asp:Label></b></p>
            </div>           
        </div> 
        <div class="row">
            <div class="col-sm-8 mb-3" style="text-align: left">
                <p style="margin: 0;">Địa chỉ:<b> <asp:Label runat="server" ID="lblDiaChi"></asp:Label></b></p>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: left">
                   <p style="margin: 0;">Phường/Xã:<b> <asp:Label runat="server" ID="lblDiaBan"></asp:Label></b></p>
            </div>           
        </div> 
        <table runat="server" style="width:100%; padding-top: 10px;text-align:center" id="DSSanPham" class="table table-print">
            <thead>
                <tr>
                  <th style="width:23px">
                    STT
                  </th>
                  <th style="width:150px">
                    Sản phẩm
                  </th>
                  <th style="width:120px">
                    Đơn vị tính 
                  </th>
                  <th style="width:100px">
                    Số lượng
                  </th>  
                  <th style="width:180px">
                    Số lượng bằng chữ
                  </th>                 
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
        <div class="row">
            <div class="col-sm-3 mb-3" style="text-align: right">                
            </div>
            <div class="col-sm-3 mb-3" style="text-align: right">                
            </div>
            <div class="col-sm-6 mb-3" style="text-align: center; height:150px;padding-top:10px;">
                 <b style="margin-left: 0px;">Người bán hàng</b><br />
                <i style="margin-left: 0px;">(Ký, ghi rõ họ, tên)</i>
            </div>           
        </div>
         <div class="row">
              <div class="col-sm-3 mb-3" style="text-align: right">                
            </div>
            <div class="col-sm-3 mb-3" style="text-align: right">                
            </div>
            <div class="col-sm-6 mb-3" style="text-align: center; padding-top:10px;">
                
            </div>
        </div>
    </asp:Panel>
<asp:UpdatePanel ID="upModal" runat="server">   
    <ContentTemplate>     
        <!-- Modal -->
                
        <div class="modal fade" id="addCusModal" tabindex="-1" role="dialog" aria-labelledby="addCusModal" aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="huyModalLable">Thêm mới khách hàng</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body m-xl-3">
                   <div class="row mx5">   
                        <label>Tên khách hàng</label>               
                        <asp:TextBox ID="txtTenKh" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqfTenPB" runat="server" ControlToValidate="txtTenKh"
                            ErrorMessage="Bạn phải nhập tên KH">*</asp:RequiredFieldValidator>
                    </div>
                  <div class="row mx5">   
                      <label>Địa chỉ</label>  
                      <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control input-lg" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDiaChi"
                        ErrorMessage="Bạn phải nhập địa chỉ">*</asp:RequiredFieldValidator>
                      </div>
                   <div class="row mx5"> 
                       <label>Phường/Xã</label>                        
                     <asp:DropDownList ID="cbVung" runat="server" CssClass="form-control input-lg" DataTextField="ten_dia_ban" DataValueField="id_dia_ban" >                            
                    </asp:DropDownList>                  
                    </div>
                  <br />
                   <div class="row mx5">
                     <label>Điện thoại</label>                          
                    <asp:TextBox ID="txtSoDT" runat="server" CssClass="form-control input-lg" ></asp:TextBox>
                    
                    </div>
                <div class="row mx5">
                    <label>Năm bán hàng</label>                          
                    <asp:TextBox ID="txtNamBH" runat="server" CssClass="form-control input-lg" >2019</asp:TextBox>
                </div>
                   <div class="row mx5">
                        <asp:Label CssClass="label label-success" runat="server" ID="txtErr"></asp:Label>
                    </div>
              </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Quay lại</button>
                <asp:Button ID="btnAdd" runat="server" OnClick="ThemMoiKhachHang"  CssClass="btn btn-success" Text="Thêm mới"/>
              </div>
            </div>
          </div>
        </div>   
       
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

