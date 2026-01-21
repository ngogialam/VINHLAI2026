<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongKeBangThong.aspx.cs" Inherits="BaoCao_ThongKeBangThong" %>--%>

<%@ Page Language="C#" Title="Đổi mật khẩu" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DoiMatKhau.aspx.cs" Inherits="DoiMatKhau" %>

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
       
        <div>
            <fieldset style="width: 97%; font-family: Verdana; padding-top: 20px">
                <legend>
                    <div style="margin: 2px 0px 0px 0px; height: 20px;">
                        <strong>THÔNG TIN NGƯỜI DÙNG</strong>
                    </div>
                </legend>
                <table align="center" border="0" width="100%" style="font-size: 13px; font-family: Verdana;
                    color: #000000;">
                  

                    <tr>
                        <td class="auto-style2">
                            <span style="font-family: Arial">Tên đăng nhập (*):</span></span></td>
                           
                        <td align="left" style="text-align: left;" class="auto-style4">
                            <asp:TextBox ID="txtTenDN" Enabled="false" runat="server" Width="200px" Font-Names="Arial" MaxLength="50"></asp:TextBox>
                            </td>
                        
                            <td align="right" class="auto-style2" >
                                <span style="font-family: Arial">Mật khẩu mới (*):</span></span></td>
                        <td style="text-align: left;" class="auto-style2">
                            <asp:TextBox ID="txtPassNew1" runat="server" Width="200px" Font-Names="Arial"
                                MaxLength="555"></asp:TextBox>&nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td class="auto-style3">
                            <span style="font-family: Arial"> &nbsp;Mật khẩu cũ (*):</span></span></td>
                        <td style="text-align: left" class="auto-style2">
                            <asp:TextBox ID="txtPass" runat="server" Width="200px" Font-Names="Arial" 
                                MaxLength="255"></asp:TextBox>
                            </td>
                        <td class="auto-style3">
                            <span style="font-family: Arial"> &nbsp;Nhập lại mật khẩu mới (*):</span></span></td>
                        <td style="text-align: left" class="auto-style2">
                            <asp:TextBox ID="txtPassNew" runat="server" Width="200px" Font-Names="Arial" 
                                MaxLength="255"></asp:TextBox>
                            </td>
                    </tr>
                    
                   
                    
                   

                      

                </table>
            </fieldset>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <span style="font-family: Verdana"></span>
        </div>


         <div class="card-header">
           <asp:Button ID="btnThemMoi" runat="server" Text="Lưu" OnClick="ThayDoiMatKhau"
                CssClass="btn btn-primary" />
        </div>
         <div class="form-group" style="clear: both;">
            <asp:Label ID="txtErr" runat="server" ForeColor="#FF3300"></asp:Label>
        </div>


       

    </div>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style2
        {
            height: 60px;
        }
        .auto-style3
        {
            width: 120px;
            height: 60px;
        }
        .auto-style4
        {
            height: 60px;
            width: 311px;
        }
        </style>
</asp:Content>


