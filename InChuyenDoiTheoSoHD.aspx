<%@ Page Language="C#" Title="In chuyển đổi theo lô" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="InChuyenDoiTheoSoHD.aspx.cs" Inherits="InChuyenDoiTheoSoHD" %>

<asp:Content runat="server" ID="head" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-xl-3 col-sm-4 mb-2">
                <asp:TextBox ID="txtTuSo" CssClass="form-control" runat="server" placeholder="Từ số"></asp:TextBox>
            </div>
            <div class="col-xl-3 col-sm-4 mb-2">
                <asp:TextBox ID="txtDenSo" CssClass="form-control" placeholder="Đến số" runat="server"></asp:TextBox>
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
		   <asp:ListItem Value="C23TVL"> C23TVL </asp:ListItem>
                   <asp:ListItem Value="C22TVL" > C22TVL </asp:ListItem>
                    <asp:ListItem Value="VL/20E"> VL/20E </asp:ListItem>
                    <asp:ListItem Value="VL/19E"> VL/19E </asp:ListItem>               
               </asp:DropDownList>                         
            </div>
            </div>
              
            <div class="col-xl-3 col-sm-2 mb-2">
                <%-- <asp:button id="btnLaySL" runat="server" text="Lấy số liệu" cssclass="btn btn-primary" onclick="btnLaySL_Click" />--%>
                <asp:Button ID="btnInLoHD" runat="server" class="btn btn-success" Text="In chuyển đổi theo lô" OnClick="btnInLoHD_Click" OnClientClick="return confirm('Bạn có chắc chắn in lô hóa đơn (Chỉ in các hóa đơn đã phát hành)?')" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 mb-2">
                <asp:Label runat="server" ID="txtErr" Font-Size="14px"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
