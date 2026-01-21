using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class DanhSachKyHD : System.Web.UI.Page
{
    clsSanPham myProduct = new clsSanPham();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable KyHD_tList = myProduct.get_danh_sach_ky_hd();
        KyHD_tList.Columns["id"].ColumnName = "ID";
        KyHD_tList.Columns["ky"].ColumnName = "Kỳ HĐ";
        KyHD_tList.Columns["thang"].ColumnName = "Tháng";
        KyHD_tList.Columns["nam"].ColumnName = "Năm";
        KyHD_tList.Columns["tu_ngay"].ColumnName = "Từ ngày";
        KyHD_tList.Columns["den_ngay"].ColumnName = "Đến ngày";
        KyHD_tList.Columns["trang_thai"].ColumnName = "Trạng thái";

        GridViewEman.DataSource = KyHD_tList;
        GridViewEman.DataBind();
        if (KyHD_tList.Rows.Count > 0)
        {
            GridViewEman.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }


}
