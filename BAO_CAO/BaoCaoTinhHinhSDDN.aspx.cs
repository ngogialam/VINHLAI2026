using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BaoCaoTinhHinhSDDN : System.Web.UI.Page
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


            bindGrid(ky_hd);
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
    void bindGrid(string ky_hd)
    {
        DataTable tbx = new DataTable();
        clsBaocao cslBC = new clsBaocao();
        string id_doanh_nghiep = "1";

        tbx = cslBC.BAO_CAO_TINH_HINH_SU_DUNG(ky_hd, id_doanh_nghiep);
        int i = tbx.Rows.Count;

        DataRow newRowTong = tbx.NewRow();
        //newRowTong[0] = tbx.Rows[i]["ten_viet_tat"].ToString();
        newRowTong[0] = i;
        newRowTong[1] = "TC";
        newRowTong[2] = "Tổng cộng";
        newRowTong[3] = tbx.Compute("Sum(muc1)", string.Empty);
        newRowTong[4] = tbx.Compute("Sum(muc2)", string.Empty);
        newRowTong[5] = tbx.Compute("Sum(muc3)", string.Empty);
        newRowTong[6] = tbx.Compute("Sum(muc4)", string.Empty);
        newRowTong[7] = tbx.Compute("Sum(muc5)", string.Empty);
        newRowTong[8] = tbx.Compute("Sum(muc6)", string.Empty);
        newRowTong[9] = tbx.Compute("Sum(SX)", string.Empty);
        newRowTong[10] = tbx.Compute("Sum(TDKD)", string.Empty);
        newRowTong[11] = tbx.Compute("Sum(KD)", string.Empty);
        newRowTong[12] = tbx.Compute("Sum(CS)", string.Empty);
        newRowTong[13] = tbx.Compute("Sum(DX)", string.Empty);
        newRowTong[14] = tbx.Compute("Sum(NT)", string.Empty);
        newRowTong[15] = tbx.Compute("Sum(BN)", string.Empty);
        newRowTong[16] = tbx.Compute("Sum(GBT)", string.Empty);
        newRowTong[17] = tbx.Compute("Sum(GCD)", string.Empty);
        newRowTong[18] = tbx.Compute("Sum(GTD)", string.Empty);
        newRowTong[19] = tbx.Compute("Sum(TongCong)", string.Empty);
        
        tbx.Rows.InsertAt(newRowTong, i);

        GridView1.DataSource = tbx;
        GridView1.DataBind();
        ViewState["DataTable"] = tbx;
        Session["BaoCaoTongHopTable"] = tbx;
        Session["BaoCaoTongHopTenXomKhu"] = "Hợp tác xã Vĩnh Lại";
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
