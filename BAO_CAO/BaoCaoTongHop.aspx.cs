using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BaoCaoTongHop : System.Web.UI.Page
{
    clsBaocao myCus = new clsBaocao();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session.Remove("BaoCaoTongHopTable");
            Session.Remove("BaoCaoTongHopTenXomKhu");
            Session.Remove("BaoCaoTongHopLoaiBaoCao");
            Session.Remove("BaoCaoTongHopThangNam");
            Session.Remove("BaoCaoTongHopNgayIn");
            //DataTable tram_bien_ap = myCus.get_tram_bien_ap();
            //DataRow newRow = tram_bien_ap.NewRow();
            //newRow[0] = 0;
            //newRow[1] = "Tất cả";
            //tram_bien_ap.Rows.InsertAt(newRow, 0);
            //ddlTramBA.DataSource = tram_bien_ap;
            //ddlTramBA.DataBind();

            //DataTable bang_gia_dien = myCus.get_bang_gia_dien();
            ////DataRow newRow1 = bang_gia_dien.NewRow();
            ////newRow[0] = 0;
            ////newRow[1] = "Tất cả";
            ////bang_gia_dien.Rows.InsertAt(newRow, 0);
            //ddlBangGiaDien.DataSource = bang_gia_dien;
            //ddlBangGiaDien.DataBind();

            DataTable khu = myCus.get_khu();
            DataRow newRow2 = khu.NewRow();
            newRow2[0] = 0;
            newRow2[1] = "Tất cả";
            khu.Rows.InsertAt(newRow2, 0);
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
            string loai_bc = ddlChonBC.SelectedValue.ToString();

            bindGrid(loai_bc, id_dia_ban, ky_hd);
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
    void bindGrid(string loai_bc, int id_khu, string ky_hd)
    {
        DataTable tbx = new DataTable();
        clsBaocao cslBC = new clsBaocao();
        string id_doanh_nghiep = Session["IDDoanhNghiep"].ToString();
        if (loai_bc == "01")
        {
            if (id_khu == 0)
            {
                foreach (ListItem id_khu_item in ddlXomKhu.Items)
                {
                    //System.Windows.Forms.MessageBox.Show(id_khu_item.Value);
                    if (Convert.ToInt32(id_khu_item.Value) != id_khu) 
                        tbx.Merge(cslBC.SELECT_SAN_LUONG_THEO_TRAM_BA(Convert.ToInt32(id_khu_item.Value), ky_hd, id_doanh_nghiep));
                }
            }
            else
            {
                tbx.Merge(cslBC.SELECT_SAN_LUONG_THEO_TRAM_BA(id_khu, ky_hd, id_doanh_nghiep));
            }
        }
        else
            tbx = cslBC.SELECT_SAN_LUONG_THEO_BANG_GIA_DIEN(id_khu, ky_hd, id_doanh_nghiep);

        double san_luong = 0;
        double tong_tien_truoc_thue = 0;
        double thue_gtgt = 0;
        double tong_tien_sau_thue = 0;

        string dien_nang_tt = "";
        for (int i = 0; i < tbx.Rows.Count; i++)
        {
            dien_nang_tt = tbx.Rows[i]["dien_nang_tt"].ToString().Trim();
            if (dien_nang_tt != "")
            {
                san_luong += double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                tong_tien_truoc_thue += double.Parse(tbx.Rows[i]["tong_tien_truoc_thue"].ToString());
                thue_gtgt += double.Parse(tbx.Rows[i]["thue_gtgt"].ToString());
                tong_tien_sau_thue += double.Parse(tbx.Rows[i]["tong_tien_sau_thue"].ToString());
            }
        }

        DataRow newRow4 = tbx.NewRow();
        //newRow4[0] = "Tổng";
        newRow4[2] = "Tổng";
        newRow4[3] = san_luong;
        newRow4[4] = tong_tien_truoc_thue;
        newRow4[5] = thue_gtgt;
        newRow4[6] = tong_tien_sau_thue;

        tbx.Rows.InsertAt(newRow4, 0);

        GridView1.DataSource = tbx;
        GridView1.DataBind();
        ViewState["DataTable"] = tbx;
        Session["BaoCaoTongHopTable"] = tbx;
        Session["BaoCaoTongHopTenXomKhu"] = "Xóm/khu: " + ddlXomKhu.SelectedItem.ToString();
        Session["BaoCaoTongHopLoaiBaoCao"] = ddlChonBC.SelectedItem.ToString().ToUpper();
        Session["BaoCaoTongHopThangNam"] = "THÁNG " + ddlThang.SelectedItem + " NĂM " + ddlNam.SelectedItem;
        Session["BaoCaoTongHopNgayIn"] = "Ngày in:  " + DateTime.Today.ToString("dd/MM/yyyy");
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
