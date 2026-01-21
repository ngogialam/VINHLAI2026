<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongKeBangThong.aspx.cs" Inherits="BaoCao_ThongKeBangThong" %>--%>

<%@ Page Language="C#" Title="Danh sách user" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DanhSachUser.aspx.cs" Inherits="DanhSachUser" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script>

</script>

</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-12">
        </div>
    </div>

    <div class="card mb-3">
        <div class="card-header">
            Danh sách người dùng
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GirdView" ClientIDMode="Static" runat="server" CssClass="table table-bordered">
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

