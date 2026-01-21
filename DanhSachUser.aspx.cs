using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class DanhSachUser : System.Web.UI.Page
{
    clsSanPham myProduct = new clsSanPham();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable User_tList = myProduct.get_danh_sach_nguoi_dung();
        User_tList.Columns["user_id"].ColumnName = "ID";
        User_tList.Columns["user_name"].ColumnName = "UserName";
        User_tList.Columns["name"].ColumnName = "Tên";
        User_tList.Columns["address"].ColumnName = "Địa chỉ";
        User_tList.Columns["user_type"].ColumnName = "Type";
        GirdView.DataSource = User_tList;
        GirdView.DataBind();
        GirdView.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}
