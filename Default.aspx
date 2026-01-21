<%@ Page Title="Phần mềm quản lý hóa đơn điện" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="baocao._Default" %>

<%--<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Trang Báo Cáo Quan Trắc</h1>
              
            </hgroup>            
        </div>
    </section>
</asp:Content>--%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Icon Cards-->
    <div class="row">
        <div class="col-xl-4 col-sm-6 mb-3">
            <div class="card text-white bg-danger o-hidden h-100">
                <div class="card-body">
                    <div class="card-body-icon">
                        <i class="fa fa-fw fa-bell"></i>
                    </div>
                    <div class="mr-5">
                        Khách hàng
                        <asp:Label ID="txtUPE" runat="server" Font-Size="25px" Font-Bold="true"></asp:Label>
                    </div>
                </div>
                <a class="card-footer text-white clearfix small z-1" href="./DanhSachKhachHang.aspx">
                     <span class="float-left">Xem chi tiết</span>
                    <span class="float-right">
                        <i class="fa fa-angle-right"></i>
                    </span>
                </a>
            </div>
        </div>
          <div class="col-xl-4 col-sm-6 mb-3">
                <div class="card text-white bg-warning o-hidden h-100">
                    <div class="card-body">
                        <div class="card-body-icon">
                            <i class="fa fa-fw fa-cart-plus"></i>
                        </div>
                        <div class="mr-5">
                            NHẬP CHỈ SỐ                       
                        </div>
                    </div>
                    <a class="card-footer text-white clearfix small z-1" href="./NhapChiSo.aspx">
                         <span class="float-left">Xem chi tiết</span>
                        <span class="float-right">
                            <i class="fa fa-angle-right"></i>
                        </span>
                    </a>
                </div>
            </div>
        <div class="col-xl-4 col-sm-6 mb-3">
            <div class="card text-white bg-primary o-hidden h-100">
                <div class="card-body">
                    <div class="card-body-icon">
                        <i class="fa fa-fw fa-bell"></i>
                    </div>
                    <div class="mr-5">
                        Báo cáo thống kê
                        <asp:Label ID="txtSW" runat="server" Font-Size="25px" Font-Bold="true"></asp:Label>
                    </div>
                </div>
                <a class="card-footer text-white clearfix small z-1" href="./BAO_CAO/BaoCaoDSKhachHang.aspx">
                     <span class="float-left">Xem chi tiết</span>
                    <span class="float-right">
                        <i class="fa fa-angle-right"></i>
                    </span>
                </a>
            </div>
          
        </div>
    </div>
</asp:Content>
