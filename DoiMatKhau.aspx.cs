using System;
using System.Web.UI;

public partial class DoiMatKhau : System.Web.UI.Page
{
    clsKhachHang myCus = new clsKhachHang();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                int i = int.Parse(Session["loginSuccess"].ToString());
                if (i == 0)
                    Response.Redirect("Login.aspx");
                else
                {
                    txtTenDN.Text = Session["User"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }

           
        } 

        //DataTable CusList = myCus.get_danh_sach_khac_hang();
        ////ProductList.Columns["ma_hang"].ColumnName = "Mã sản phẩm";
        ////ProductList.Columns["ten_hang"].ColumnName = "Tên sản phẩm";
        ////ProductList.Columns["dv_tinh"].ColumnName = " Đơn vị tính";
        //GirdView.DataSource = CusList;
        //GirdView.DataBind();
        //GirdView.HeaderRow.TableSection = TableRowSection.TableHeader;

    }

    protected void ThayDoiMatKhau(object sender, EventArgs e)
    {

        string user_name = txtTenDN.Text.ToString();
        string pass = txtPass.Text.ToString();
        string passnew = txtPassNew.Text.ToString();
        string passnew1 = txtPassNew1.Text.ToString();
        clsConnect conn = new clsConnect();
        int check = conn.Authenticate(user_name, pass);

        if (passnew != passnew1 || check==0 )
        {
            txtErr.Text = "Thông tin password chưa chính xác, đề nghị kiểm tra lại !";
        }
        else
        {
            if (user_name != "" && pass != "" && passnew != "" && passnew1 != "")
            {
                int i = conn.change_pass(user_name, passnew);
                if (i == 0)
                    txtErr.Text = "Thay đổi mật khẩu thất bại!";
                else
                    txtErr.Text = "Thay đổi mật khẩu thành công!";

            }
            else
            {
                txtErr.Text = "Chưa nhập đủ dữ liệu!";
            }
        }

        

    }
   
    
}
