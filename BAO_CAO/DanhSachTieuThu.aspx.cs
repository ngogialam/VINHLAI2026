using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhSachTieuThu : System.Web.UI.Page
{
    clsBaocao myCus = new clsBaocao();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            Session.Remove("DanhSachTieuThuTable");
            Session.Remove("DanhSachTieuThuTenXomKhu");
            Session.Remove("DanhSachTieuThuTenTramBA");
            Session.Remove("DanhSachTieuThuQuyNam");
            Session.Remove("DanhSachTieuThuNgayIn");

            DataTable tram_bien_ap = myCus.get_tram_bien_ap();
            DataRow newRow = tram_bien_ap.NewRow();
            newRow[0] = 0;
            newRow[1] = "Tất cả";
            tram_bien_ap.Rows.InsertAt(newRow, 0);
            ddlTramBA.DataSource = tram_bien_ap;
            ddlTramBA.DataBind();

           

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
      //  string thang = ddlThang.SelectedValue.ToString();

        string nam = ddlNam.SelectedValue.ToString();
        
        if (nam != "")
        {
                int id_dia_ban = int.Parse(ddlXomKhu.SelectedValue.ToString());
                string id_tram_bien_ap = ddlTramBA.SelectedValue.ToString();
                string id_thoi_gian = ddlThoiGian.SelectedValue.ToString();
                bindGrid(id_tram_bien_ap, id_dia_ban, id_thoi_gian);
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
    void bindGrid(string id_tram_bien_ap, int id_khu, string id_thoi_gian)
    {
        DataTable tbx = new DataTable();
        DataTable tbxView = new DataTable();
        clsBaocao cslBC = new clsBaocao();
     //   string thoi_gian_xem = ddlThoiGian.SelectedValue.ToString();
        string nam = ddlNam.SelectedValue.ToString();
        //if(thoi_gian_xem == "01")
        //    tbx = cslBC.SELECT_CHOT_CONG_TO(id_tram_bien_ap, id_khu, id_thoi_gian, ky_hd);
        //else
        string id_doanh_nghiep = Session["IDDoanhNghiep"].ToString();
        tbx = cslBC.SELECT_CHOT_CONG_TO_ALL(id_tram_bien_ap, id_khu, nam, id_doanh_nghiep);


        DataRow dr;
        tbxView.Columns.Add("stt", typeof(String));
        tbxView.Columns.Add("ma_kh", typeof(String));
        tbxView.Columns.Add("ten_kh", typeof(String));
        tbxView.Columns.Add("dia_chi", typeof(String));
        tbxView.Columns.Add("ma_cong_to", typeof(String));
        tbxView.Columns.Add("t1", typeof(Double));
        tbxView.Columns.Add("t2", typeof(Double));
        tbxView.Columns.Add("t3", typeof(Double));
        tbxView.Columns.Add("t4", typeof(Double));
        tbxView.Columns.Add("t5", typeof(Double));
        tbxView.Columns.Add("t6", typeof(Double));
        tbxView.Columns.Add("t7", typeof(Double));
        tbxView.Columns.Add("t8", typeof(Double));
        tbxView.Columns.Add("t9", typeof(Double));
        tbxView.Columns.Add("t10", typeof(Double));
        tbxView.Columns.Add("t11", typeof(Double));
        tbxView.Columns.Add("t12", typeof(Double));
        
        dr = tbxView.NewRow();

   
        double tong_thang_1 = 0;
        double tong_thang_2 = 0;
        double tong_thang_3 = 0;
        double tong_thang_4 = 0;
        double tong_thang_5 = 0;
        double tong_thang_6 = 0;
        double tong_thang_7 = 0;
        double tong_thang_8 = 0;
        double tong_thang_9 = 0;
        double tong_thang_10 = 0;
        double tong_thang_11 = 0;
        double tong_thang_12 = 0;

        

        for (int i = 0; i < tbx.Rows.Count; i++)
        {
            DataRow newRowTong = tbxView.NewRow();
            newRowTong[0] = (i+1).ToString();
            newRowTong[1] = tbx.Rows[i]["ma_kh"].ToString();
            newRowTong[2] = tbx.Rows[i]["ten_kh"].ToString();
            newRowTong[3] = tbx.Rows[i]["dia_chi"].ToString();
            newRowTong[4] = tbx.Rows[i]["ma_cong_to"].ToString();

            if (id_thoi_gian == "03")
            {
                tong_thang_1 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "01", nam);
                tong_thang_2 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "02", nam);
                tong_thang_3 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "03", nam);
            }
            else if (id_thoi_gian == "06")
            {
                tong_thang_1 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "01", nam);
                tong_thang_2 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "02", nam);
                tong_thang_3 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "03", nam);
                tong_thang_4 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "04", nam);
                tong_thang_5 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "05", nam);
                tong_thang_6 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "06", nam);
            }
            else
            {
                tong_thang_1 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "01", nam);
                tong_thang_2 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "02", nam);
                tong_thang_3 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "03", nam);
                tong_thang_4 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "04", nam);
                tong_thang_5 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "05", nam);
                tong_thang_6 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "06", nam);
                tong_thang_7 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "07", nam);
                tong_thang_8 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "08", nam);
                tong_thang_9 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "09", nam);
                tong_thang_10 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "10", nam);
                tong_thang_11 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "11", nam);
                tong_thang_12 = cslBC.SELECT_DIEN_NANG_TT(tbx.Rows[i]["ma_kh"].ToString(), "12", nam);
            }
            
            newRowTong[5] = tong_thang_1;
            newRowTong[6] = tong_thang_2;
            newRowTong[7] = tong_thang_3;
            newRowTong[8] = tong_thang_4;
            newRowTong[9] = tong_thang_5;
            newRowTong[10] = tong_thang_6;
            newRowTong[11] = tong_thang_7;
            newRowTong[12] = tong_thang_8;
            newRowTong[13] = tong_thang_9;
            newRowTong[14] = tong_thang_10;
            newRowTong[15] = tong_thang_11;
            newRowTong[16] = tong_thang_12;

            //tong_1_kh = tong_thang_1 + tong_thang_2 + tong_thang_3 + tong_thang_4 + tong_thang_5 + tong_thang_6 + tong_thang_7 + tong_thang_8 + tong_thang_9 + tong_thang_10 + tong_thang_11 + tong_thang_12;
            //newRowTong[16] = tong_1_kh;
            // tong_nam = tong_nam + tong_1_kh;
            tbxView.Rows.InsertAt(newRowTong, i);

        }


        GridView1.DataSource = tbxView;
        GridView1.DataBind();
        ViewState["DataTable"] = tbxView;
        Session["DanhSachTieuThuTable"] = tbxView;
        Session["DanhSachTieuThuTenXomKhu"] = "Xóm/khu: " + ddlXomKhu.SelectedItem.ToString();
        Session["DanhSachTieuThuTenTramBA"] = "Trạm: " + ddlTramBA.SelectedItem.ToString();
        Session["DanhSachTieuThuQuyNam"] = "Khoảng thời gian: " + ddlThoiGian.SelectedItem + ", năm " + ddlNam.SelectedItem;
        Session["DanhSachTieuThuNgayIn"] = "Ngày in:  " + DateTime.Today.ToString("dd/MM/yyyy");
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
