<%@ Page Title="Không có quyền truy cập" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="PermissionDenied.aspx.cs" Inherits="PermissionDenied" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-12">
            <h5>Bạn không có quyền truy cập</h5>
            <hr>
            <a class="btn btn-primary" href="./default.aspx">Quay về trang chủ</a>
        </div>
    </div>
</asp:Content>
