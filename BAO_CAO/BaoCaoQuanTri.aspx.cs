using System;
using System.IO;
using System.Data;
using System.Web.UI;
using ClosedXML.Excel;
using System.Web.UI.WebControls;

public partial class BaoCaoQuanTri : System.Web.UI.Page
{
    clsBaocao myCus = new clsBaocao();
    clsConnect myCon = new clsConnect();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session.Remove("BaoCaoQuanTriTable");
            Session.Remove("BaoCaoQuanTriXomKhu");
            Session.Remove("BaoCaoQuanTriTramBA");
            Session.Remove("BaoCaoQuanTriThangNam");
            Session.Remove("BaoCaoQuanTriNgayIn");
            Session.Remove("BaoCaoQuanTriThamSo");
            Session.Remove("BaoCaoQuanTriLoaiBaoCao");

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
        string thang = ddlThang.SelectedValue.ToString();

        string nam = ddlNam.SelectedValue.ToString();
        
        if (thang != "" && nam != "")
        {

            string ky_hd = thang + "/" + nam;
                int id_dia_ban = int.Parse(ddlXomKhu.SelectedValue.ToString());
                string id_tram_bien_ap = ddlTramBA.SelectedValue.ToString();
                int id_bang_gia_dien = 0;
                bindGrid(id_tram_bien_ap, id_dia_ban, id_bang_gia_dien, ky_hd);
           //     bindGrid(tungay1, denngay1, id_dia_ban);
            
        }
        else
        {
            txtErr.Text = "Bạn phải nhập tháng, năm để tính được kì hóa đơn ";
        }
    }

    protected void XuatExcel(object sender, EventArgs e)
    {
        ////getting datatable from viewstate  
        DataTable dt = (DataTable)ViewState["DataTable"];
        if (dt.Rows.Count == 0)
        {
            return;
        }
        
        string nameFile = "BaoCaoSanLuong_" + DateTime.Now.Year + ".xlsx";
        //calling create Excel File Method and ing dataTable   
        CreateExcelFile(dt, nameFile);
    }

    public void CreateExcelFile(DataTable baocao, string FileName)
    {
        using (baocao)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(baocao, "Sheet1");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }

            }
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
        double tham_so = 0;
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(Context.User.Identity.Name.ToString());
        if (ddlChonBC.SelectedValue == "01")//Danh sách KH có chỉ số đồng hồ lớn
        {
            //lblTenThamSo.Text = "Chỉ số đồng hồ lớn hơn hoặc bằng:";
            //txtThamSo.Text = "10000";
            tham_so = double.Parse(txtThamSo.Text.Trim());
            tbx = cslBC.SELECT_KHACH_HANG_CSCK_LON(id_tram_bien_ap, id_khu, id_bang_gia_dien, ky_hd, tham_so, id_doanh_nghiep);
            
        }
        else if (ddlChonBC.SelectedValue == "02")//Danh sách KH có mức tiêu thụ lớn
        {
            //lblTenThamSo.Text = "Mức tiêu thụ lớn hơn hoặc bằng (kWh):";
            //txtThamSo.Text = "1000";
            tham_so = double.Parse(txtThamSo.Text.Trim());
            tbx = cslBC.SELECT_KHACH_HANG_TIEU_THU_LON(id_tram_bien_ap, id_khu, id_bang_gia_dien, ky_hd, tham_so, id_doanh_nghiep);
            
        }
        else if (ddlChonBC.SelectedValue == "03")//Danh sách KH có mức tiêu thụ nhỏ
        {
            //lblTenThamSo.Text = "Mức tiêu thụ nhỏ hơn hoặc bằng (kWh):";
            //txtThamSo.Text = "50";
            tham_so = double.Parse(txtThamSo.Text.Trim());
            tbx = cslBC.SELECT_KHACH_HANG_TIEU_THU_NHO(id_tram_bien_ap, id_khu, id_bang_gia_dien, ky_hd, tham_so, id_doanh_nghiep);
            
        }
        else if (ddlChonBC.SelectedValue == "04")//Danh sách KH không sử dụng điện
        {
            //lblTenThamSo.Text = "Số tháng không sử dụng:";
            //txtThamSo.Text = "1";
            tham_so = double.Parse(txtThamSo.Text.Trim());
            tbx = cslBC.SELECT_KHACH_HANG_KSD(id_tram_bien_ap, id_khu, id_bang_gia_dien, ky_hd, id_doanh_nghiep);
            
        }
        else //if (ddlChonBC.SelectedValue == "05")Danh sách KH không phát hành hóa đơn
        {
            //lblTenThamSo.Text = "Số tháng không phát hành hóa đơn:";
            //txtThamSo.Text = "1";
            tham_so = double.Parse(txtThamSo.Text.Trim());
            tbx = cslBC.SELECT_KHACH_HANG_KPH_HD(id_tram_bien_ap, id_khu, id_bang_gia_dien, ky_hd, id_doanh_nghiep);
            
        }
        

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
        Session["BaoCaoQuanTriTable"] = tbx;
        Session["BaoCaoQuanTriXomKhu"] = "Xóm/khu: " + ddlXomKhu.SelectedItem.ToString();
        Session["BaoCaoQuanTriTramBA"] = "Trạm: " + ddlTramBA.SelectedItem.ToString();
        Session["BaoCaoQuanTriThangNam"] = "Tháng " + ddlThang.SelectedItem + ", năm " + ddlNam.SelectedItem;
        Session["BaoCaoQuanTriNgayIn"] = "Ngày in:  " + DateTime.Today.ToString("dd/MM/yyyy");
        Session["BaoCaoQuanTriThamSo"] = "Tham số:  " + txtThamSo.Text;
        Session["BaoCaoQuanTriLoaiBaoCao"] = ddlChonBC.SelectedItem.ToString().ToUpper();
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


    protected void ddlChonBC_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChonBC.SelectedValue == "01")//Danh sách KH có chỉ số đồng hồ lớn
        {
            lblTenThamSo.Text = "Chỉ số đồng hồ lớn hơn hoặc bằng:";
            txtThamSo.Text = "10000";
        }
        else if (ddlChonBC.SelectedValue == "02")//Danh sách KH có mức tiêu thụ lớn
        {
            lblTenThamSo.Text = "Mức tiêu thụ lớn hơn hoặc bằng (kWh):";
            txtThamSo.Text = "1000";
        }
        else if (ddlChonBC.SelectedValue == "03")//Danh sách KH có mức tiêu thụ nhỏ
        {
            lblTenThamSo.Text = "Mức tiêu thụ nhỏ hơn hoặc bằng (kWh):";
            txtThamSo.Text = "50";
        }
        else if (ddlChonBC.SelectedValue == "04")//Danh sách KH không sử dụng điện
        {
            lblTenThamSo.Text = "Số tháng không sử dụng:";
            txtThamSo.Text = "1";
        }
        else //if (ddlChonBC.SelectedValue == "05")Danh sách KH không phát hành hóa đơn
        {
            lblTenThamSo.Text = "Số tháng không phát hành hóa đơn:";
            txtThamSo.Text = "1";
        }
    }
    protected void ddlChonBC_TextChanged(object sender, EventArgs e)
    {
        if (ddlChonBC.SelectedValue == "01")//Danh sách KH có chỉ số đồng hồ lớn
        {
            lblTenThamSo.Text = "Chỉ số đồng hồ lớn hơn hoặc bằng:";
            txtThamSo.Text = "10000";
        }
        else if (ddlChonBC.SelectedValue == "02")//Danh sách KH có mức tiêu thụ lớn
        {
            lblTenThamSo.Text = "Mức tiêu thụ lớn hơn hoặc bằng (kWh):";
            txtThamSo.Text = "1000";
        }
        else if (ddlChonBC.SelectedValue == "03")//Danh sách KH có mức tiêu thụ nhỏ
        {
            lblTenThamSo.Text = "Mức tiêu thụ nhỏ hơn hoặc bằng (kWh):";
            txtThamSo.Text = "50";
        }
        else if (ddlChonBC.SelectedValue == "04")//Danh sách KH không sử dụng điện
        {
            lblTenThamSo.Text = "Số tháng không sử dụng:";
            txtThamSo.Text = "1";
        }
        else //if (ddlChonBC.SelectedValue == "05")Danh sách KH không phát hành hóa đơn
        {
            lblTenThamSo.Text = "Số tháng không phát hành hóa đơn:";
            txtThamSo.Text = "1";
        }
    }
}
