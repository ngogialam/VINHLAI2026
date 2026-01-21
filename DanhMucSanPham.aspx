<%@ Page Language="C#" Title="Danh mục sản phẩm" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DanhMucSanPham.aspx.cs" Inherits="DanhMucSanPham" %>

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
            Danh mục sản phẩm
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GirdView" ClientIDMode="Static" runat="server" CssClass="table table-bordered" >
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

