using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class DanhMucSanPham : System.Web.UI.Page
{
    clsSanPham myProduct = new clsSanPham();
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    int i = int.Parse(Session["loginSuccess"].ToString());
        //    if (i == 0)
        //        Response.Redirect("Login.aspx");
        //    else
        //    {
                DataTable ProductList = myProduct.get_danh_sach_san_pham();
                ProductList.Columns["ma_hang"].ColumnName = "Mã sản phẩm";
                ProductList.Columns["ten_hang"].ColumnName = "Tên sản phẩm";
                ProductList.Columns["dv_tinh"].ColumnName = " Đơn vị tính";
                GirdView.DataSource = ProductList;
                GirdView.DataBind();
                GirdView.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Response.Redirect("Login.aspx");
        //}

      

    }
   
    
}
