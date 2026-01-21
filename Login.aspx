<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<html>
<head id="loginhead" runat="server">
    <meta charset="utf-8" />
    <title>Đăng nhập - VNPT PHÚ THỌ</title>
   
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width" />
    <!-- Bootstrap core CSS-->
 
    <link href="css/sb-admin-2.min.css" rel="stylesheet" />
     
</head>
<body class="bg-gradient-primary" id="page-top">
     <div class="container">
    <!-- Outer Row -->
    <div class="row justify-content-center">
      <div class="col-xl-10 col-lg-12 col-md-9">
        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
            <!-- Nested Row within Card Body -->
            <div class="row">
              <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
              <div class="col-lg-6">
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Đăng nhập!</h1>
                  </div>
                 <form runat="server" id="login" class="user">
                    <div class="form-group">
                        <asp:TextBox ID="txtTenDangNhap" CssClass="form-control form-control-user" runat="server" placeholder="Tên đăng nhập"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtMatKhau" runat="server" CssClass="form-control form-control-user" TextMode="Password" placeholder="Mật khẩu"></asp:TextBox>
                    </div>
                    <div class="form-group">
                      <div class="custom-control custom-checkbox small">                        
                       <input id="chkSave" runat="server" name="chkSave" type="checkbox" />
                              
                        <label >Lưu thông tin đăng nhập</label>
                      </div>
                    </div>
                     <asp:Button ID="btnDangNhap" text="Đăng nhập" CssClass="btn btn-primary btn-user btn-block" runat="server" OnClick="btnDangNhap_Click" />
                    <hr>
                       <asp:Label ID="lblThongBao" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>                    
                  </form>
              
                </div>
                 <div class="p-1">
                      <img src="Images/evn.jpg" 
                          style="height: 180px;display: block;margin-left: auto;margin-right: auto;"/>
                  </div>
              </div>
            </div>
          </div>
        </div>

      </div>

    </div>                      
  </div>
</body>
 
</html>