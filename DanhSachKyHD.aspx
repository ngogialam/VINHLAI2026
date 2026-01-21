<%@ Page Language="C#" Title="Danh sách kỳ HĐ" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DanhSachKyHD.aspx.cs" Inherits="DanhSachKyHD" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script></script>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-12">
        </div>
    </div>
    <div class="card mb-3">
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridViewEman" ClientIDMode="Static" runat="server" CssClass="table table-bordered">
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

