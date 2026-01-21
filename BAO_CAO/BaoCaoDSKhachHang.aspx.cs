using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BaoCaoDSKhachHang : System.Web.UI.Page
{
    clsBaocao myCus = new clsBaocao();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session.Remove("BaoCaoDSKhachHangTable");
            Session.Remove("BaoCaoDSKhachHangTenTramBA");
            Session.Remove("BaoCaoDSKhachHangXomKhu");
            Session.Remove("BaoCaoDSKhachHangThangNam");
            Session.Remove("BaoCaoDSKhachHangBangGia");

            DataTable tram_bien_ap = myCus.get_tram_bien_ap();
            DataRow newRow = tram_bien_ap.NewRow();
            newRow[0] = 0;
            newRow[1] = "Tất cả";
            tram_bien_ap.Rows.InsertAt(newRow, 0);
            ddlTramBA.DataSource = tram_bien_ap;
            ddlTramBA.DataBind();

            DataTable bang_gia_dien = myCus.get_bang_gia_dien();
            //DataRow newRow1 = bang_gia_dien.NewRow();
            //newRow[0] = 0;
            //newRow[1] = "Tất cả";
            //bang_gia_dien.Rows.InsertAt(newRow, 0);
            ddlBangGiaDien.DataSource = bang_gia_dien;
            ddlBangGiaDien.DataBind();

            DataTable khu = myCus.get_khu();
            //DataRow newRow1 = bang_gia_dien.NewRow();
            //newRow[0] = 0;
            //newRow[1] = "Tất cả";
            //bang_gia_dien.Rows.InsertAt(newRow, 0);
            ddlXomKhu.DataSource = khu;
            ddlXomKhu.DataBind();

            DataTable nam = myCus.get_nam();
            //DataRow newRow1 = bang_gia_dien.NewRow();
            //newRow[0] = 0;
            //newRow[1] = "Tất cả";
            //bang_gia_dien.Rows.InsertAt(newRow, 0);
            ddlNam.DataSource = nam;
            ddlNam.DataBind();
        }

    }

    protected void XemBC(object sender, EventArgs e)
    {
        txtErr.Text = "";
        string thang = ddlThang.SelectedValue.ToString();

        string nam = ddlNam.SelectedValue.ToString();
        
        if (thang != "" && nam != "")
        {

            string ky_hd = thang + "/" + nam;
                int id_dia_ban = int.Parse(ddlXomKhu.SelectedValue.ToString());
                string id_tram_bien_ap = ddlTramBA.SelectedValue.ToString();
                int id_bang_gia_dien = int.Parse(ddlBangGiaDien.SelectedValue.ToString());
                bindGrid(id_tram_bien_ap, id_dia_ban, id_bang_gia_dien, ky_hd);
           //     bindGrid(tungay1, denngay1, id_dia_ban);
            
        }
        else
        {
            txtErr.Text = "Bạn phải nhập tháng, năm để tính được kì hóa đơn ";
        }
    }

    void DisplayCurrentPage()
    {
        // Calculate the current page number.
        int currentPage = GridView1.PageIndex + 1;
    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        DisplayCurrentPage();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
       // bindGrid(int.Parse(drpDonVi.SelectedValue.ToString()));
    }
    void bindGrid(string id_tram_bien_ap, int id_khu, int id_bang_gia_dien, string ky_hd)
    {
        DataTable tbx = new DataTable();
        DataTable tbxView = new DataTable();
        clsBaocao cslBC = new clsBaocao();
        string id_doanh_nghiep = Session["IDDoanhNghiep"].ToString();
        tbx = cslBC.SELECT_KHACH_HANG_THEO_CAC_DK(id_tram_bien_ap, id_khu, id_bang_gia_dien, ky_hd, id_doanh_nghiep);

        double san_luong_tt = 0;
        double tong_tien = 0;

        string ma_kh = "";
        for (int i = 0; i < tbx.Rows.Count; i++)
        {
            ma_kh = tbx.Rows[i]["ma_kh"].ToString().Trim();
            if (ma_kh != "")
            { 
                    san_luong_tt += double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                    tong_tien += double.Parse(tbx.Rows[i]["tong_tien_sau_thue"].ToString());
            }
        }

        DataRow newRow4 = tbx.NewRow();
        //newRow4[0] = "Tổng";
        newRow4[1] = "Tổng";
        //newRow4[2] = "";
        //newRow4[3] = "";
        //newRow4[4] = "";
        //newRow4[5] = "";
        newRow4[8] = san_luong_tt;
        newRow4[9] = tong_tien;
        tbx.Rows.InsertAt(newRow4, 0);

        GridView1.DataSource = tbx;
        GridView1.DataBind();
        ViewState["DataTable"] = tbx;
        Session["BaoCaoDSKhachHangTable"] = tbx;
        Session["BaoCaoDSKhachHangTenTramBA"] = "Trạm: " + ddlTramBA.SelectedItem;
        Session["BaoCaoDSKhachHangXomKhu"] = "Xóm/khu: " + ddlXomKhu.SelectedItem;
        Session["BaoCaoDSKhachHangThangNam"] = "Tháng " + ddlThang.SelectedItem + ", năm " + ddlNam.SelectedItem;
        Session["BaoCaoDSKhachHangBangGia"] = ddlBangGiaDien.SelectedItem.ToString().ToUpper();
    }


    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayCurrentPage();
        }
    }
    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }

    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowIndex == GridView1.SelectedIndex)
            {
                row.ToolTip = string.Empty;
            }
            else
            {
                row.ToolTip = "Bấm để chọn dữ liệu.";
                Session["madonvi_chon"] = GridView1.SelectedRow.Cells[2].Text.ToString();
            }
        }

    }
   
    
}
