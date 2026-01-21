using System;
using System.Data;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    clsSert mySert = new clsSert();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["USERNAME"] != null)
                txtTenDangNhap.Text = Request.Cookies["USERNAME"].Value;
            if (Request.Cookies["PASSWORD"] != null)
                txtMatKhau.Attributes.Add("value", Request.Cookies["PASSWORD"].Value);
            if (Request.Cookies["USERNAME"] != null && Request.Cookies["PASSWORD"] != null)
                chkSave.Checked = true;
        }
        lblThongBao.Text = "";
    }

    protected void btnDangNhap_Click(object sender, EventArgs e)
    {
        clsConnect mUserInfo = new clsConnect();
        try
        {
            int loginSuccess = mUserInfo.Authenticate(mySert.noneInject(txtTenDangNhap.Text), txtMatKhau.Text);

            if (loginSuccess == 1)
            {
                //Lưu thông tin doanh nghiệp
                try
                {
                    DataTable tblUser = mUserInfo.getUser(txtTenDangNhap.Text);
                    Session["TenDoanhNghiep"] = tblUser.Rows[0]["ten_doanh_nghiep"];
                    Session["IDDoanhNghiep"] = tblUser.Rows[0]["id_doanh_nghiep"];
                }
                catch (Exception) {
                    Session["TenDoanhNghiep"] = "";
                }

                Session["User"] = txtTenDangNhap.Text.Trim();
                Session["loginSuccess"] = 1;
                // Nếu chọn lưu thông tin, đưa vào cookie
                if (chkSave.Checked == true)
                {
                    Response.Cookies["USERNAME"].Value = txtTenDangNhap.Text;
                    Response.Cookies["USERNAME"].Expires = DateTime.Now.AddMonths(1);
                    Response.Cookies["PASSWORD"].Value = txtMatKhau.Text;
                    Response.Cookies["PASSWORD"].Expires = DateTime.Now.AddMonths(1);
                }
                // Nếu không chọn lưu thông tin, xóa cookie
                else
                {
                    Response.Cookies["USERNAME"].Expires = DateTime.Now.AddMonths(-1);
                    Response.Cookies["PASSWORD"].Expires = DateTime.Now.AddMonths(-1);
                }
                //chuyển đến trang chính của hệ thống
                //Session.Add("userid", txtTenDangNhap.Text.ToString());
                FormsAuthentication.RedirectFromLoginPage(txtTenDangNhap.Text.ToString(), false);
                // Response.Redirect("Default.aspx");
                mUserInfo.save_log(txtTenDangNhap.Text, "Đăng nhập thành công!", "1");
            }
            else
            {
                lblThongBao.Text = "Đăng nhập thất bại !";
                mUserInfo.save_log(txtTenDangNhap.Text, "Đăng nhập thất bại !", "1");
                //Response.Redirect("Login.aspx");
                Session["loginSuccess"] = 0;
            }
        }
        catch (Exception ex)
        {
            lblThongBao.Text = ex.Message;
        }
    }
    //public void Thong_bao(string message)
    //{
    //    ((System.Web.UI.Page)this.Page).RegisterClientScriptBlock("Validate",
    //        "<script language = 'javascript'>alert('" + message + "');"
    //        + "</script>");
    //}

}
