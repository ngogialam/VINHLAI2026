using System;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;

public partial class ChiSoCongToTong : System.Web.UI.Page
{
    clsKhachHang myCus = new clsKhachHang();
    clsConnect myCon = new clsConnect();
    clsNhapChiSo myNCS = new clsNhapChiSo();
    DataTable CusList = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpKy.DataSource = myNCS.get_danhsach_ky();
            drpKy.DataBind();

            ddlKyCu.DataSource = myNCS.get_danhsach_ky();
            ddlKyCu.DataBind();
            lblErr.Text = "";
        }

    }

    protected void gv_bind(string kyhd)
    {
        CusList = myNCS.get_danh_sach_nhap_cs_tong(kyhd);
        GirdViewNoPaGE.DataSource = CusList;
        GirdViewNoPaGE.DataBind();
               if (CusList.Rows.Count > 0)
        {
            GirdViewNoPaGE.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void btnLaySL_Click(object sender, EventArgs e)
    {
        string kyhd = drpKy.SelectedItem.ToString();
        gv_bind(kyhd);
    }

    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        int i = 0;
        for (i = 0; i < GirdViewNoPaGE.Rows.Count; i++)
        {
            GridViewRow row = GirdViewNoPaGE.Rows[i];
            string ky = drpKy.SelectedItem.ToString();
            Label lblmact = (Label)row.FindControl("lblMaCT");
            TextBox txtCSMoi = (TextBox)row.FindControl("txtCSMoi");
            string mact = lblmact.Text.ToString();
            string csmoi = txtCSMoi.Text.ToString();
            if (csmoi != "")
            {
                int result = myNCS.cap_nhat_chi_so_cong_to_tong(mact, csmoi, ky);
                if (result == 0)
                {
                    lblErr.Text = "Có lỗi xảy ra trong quá trình cập nhật mã công tơ " + mact;
                }
            }

        }
    }

    protected void ThemKyHD(object sender, EventArgs e)
    {
        string tungay = Request.Form["strTuNgay"].ToString();
        string denngay = Request.Form["strDenNgay"].ToString();
        string kyhd = Request.Form["strKyHD"].ToString();
        int i = 0;
        System.Windows.Forms.MessageBox.Show(kyhd);
        System.Windows.Forms.MessageBox.Show(denngay);

        if (tungay != "-1" && denngay != "-1")
        {
            System.Windows.Forms.MessageBox.Show("sdsdf");

            int inttungay = Convert.ToInt32(tungay);
            int intdenngay = Convert.ToInt32(denngay);
            if (inttungay > intdenngay)
            {
                txtErr.Text = "Thời gian từ ngày phải nhỏ hơn đến ngày";
            }
            else
            {
                string tungay1 = tungay.Substring(0, 4) + "-" + tungay.Substring(4, 2) + "-" + tungay.Substring(6, 2);
                string denngay1 = denngay.Substring(0, 4) + "-" + denngay.Substring(4, 2) + "-" + denngay.Substring(6, 2);
                string thang = kyhd.Substring(0, 2);
                int intthang = Convert.ToInt32(thang) + 1;
                if (intthang < 10)
                {
                    thang = "0" + intthang.ToString();
                }
                string nam = kyhd.Substring(3, 4);
                kyhd = thang + "/" + nam;
                int result = myNCS.them_kyhd(kyhd, thang, nam, tungay1, denngay1);
                if (result == 1)
                {
                    string kycu = ddlKyCu.SelectedItem.ToString();
                    CusList = myNCS.get_danh_sach_nhap_cs_tong(kycu);
                    for (i = 0; i < CusList.Rows.Count; i++)
                    {

                        string mact = CusList.Rows[i]["ma_cong_to"].ToString();
                        string csmoi = CusList.Rows[i]["cs_moi"].ToString();
                        if (csmoi != "")
                        {
                            if (myNCS.check_cs_ct_tong(mact, kyhd) < 1)
                            {
                                try
                                {
                                    int id_dn = Int32.Parse(Session["IDDoanhNghiep"].ToString());
                                    result = myNCS.them_chi_so_cong_to_tong_ky_moi(mact, csmoi, kyhd, id_dn);
                                    if (result == 0)
                                    {
                                        lblErr.Text = "Có lỗi xảy ra trong quá trình khởi tạo dữ liệu kỳ sau mã công tơ " + mact;
                                        break;
                                    }
                                }
                                catch (Exception) {
                                    lblErr.Text = "Có lỗi xảy ra trong quá trình khởi tạo dữ liệu kỳ sau mã công tơ " + mact;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (result == 1)
                {
                    System.Windows.Forms.MessageBox.Show("sdsdf");
                    //Response.Redirect("ChiSoCongToTong.aspx");
                }
                
            }
        }

    }

    protected void btnXuatExcel_Click(object sender, EventArgs e)
    {
        int j;
        MemoryStream mem = new MemoryStream();
        int rowNo;
        int colNo;

        FileStream file = new FileStream(Server.MapPath("xls/ChiSoCongToTong.xls"), FileMode.Open, FileAccess.Read);
        // Khởi tạo workbook để đọc
        HSSFWorkbook hwbook = new HSSFWorkbook(file);
        HSSFRow row;
        HSSFCell cell;
        HSSFSheet hsheet;

        HSSFFont font;
        font = hwbook.CreateFont();
        font.FontName = "Times New Roman";
        font.Boldweight = HSSFFont.BOLDWEIGHT_BOLD;
        font.FontHeight = 220;
        font.FontHeightInPoints = 13;
        hsheet = hwbook.GetSheet("Sheet1");
        HSSFCellStyle styleleftnoborder;
        styleleftnoborder = hwbook.CreateCellStyle();
        styleleftnoborder.Alignment = HSSFCellStyle.ALIGN_LEFT;
        styleleftnoborder.SetFont(font);
        HSSFCellStyle stylecenternoborder;
        stylecenternoborder = hwbook.CreateCellStyle();
        stylecenternoborder.Alignment = HSSFCellStyle.ALIGN_CENTER;
        stylecenternoborder.SetFont(font);

        //Kỳ hợp đồng
        try
        {
            string kyhd = "Tháng " + drpKy.SelectedItem.ToString().Split('/')[0] + " năm " + drpKy.SelectedItem.ToString().Split('/')[1];
            rowNo = 3;
            colNo = 3;
            row = hsheet.CreateRow(rowNo);
            cell = row.CreateCell(colNo);
            cell.SetCellValue(kyhd);
            cell.CellStyle = stylecenternoborder;
        }
        catch (Exception)
        {

        }

        font = hwbook.CreateFont();
        font.FontName = "Times New Roman";
        font.FontHeight = 220;
        font.FontHeightInPoints = 13;
        HSSFCellStyle stylecenter;
        stylecenter = hwbook.CreateCellStyle();
        stylecenter.BorderTop = HSSFCellStyle.BORDER_THIN;
        stylecenter.BorderLeft = HSSFCellStyle.BORDER_THIN;
        stylecenter.BorderRight = HSSFCellStyle.BORDER_THIN;
        stylecenter.BorderBottom = HSSFCellStyle.BORDER_THIN;
        stylecenter.Alignment = HSSFCellStyle.ALIGN_CENTER;
        stylecenter.SetFont(font);
        HSSFCellStyle styleleft;
        styleleft = hwbook.CreateCellStyle();
        styleleft.BorderTop = HSSFCellStyle.BORDER_THIN;
        styleleft.BorderLeft = HSSFCellStyle.BORDER_THIN;
        styleleft.BorderRight = HSSFCellStyle.BORDER_THIN;
        styleleft.BorderBottom = HSSFCellStyle.BORDER_THIN;
        styleleft.Alignment = HSSFCellStyle.ALIGN_LEFT;
        styleleft.SetFont(font);
        HSSFCellStyle styleright;
        styleright = hwbook.CreateCellStyle();
        styleright.BorderTop = HSSFCellStyle.BORDER_THIN;
        styleright.BorderLeft = HSSFCellStyle.BORDER_THIN;
        styleright.BorderRight = HSSFCellStyle.BORDER_THIN;
        styleright.BorderBottom = HSSFCellStyle.BORDER_THIN;
        styleright.Alignment = HSSFCellStyle.ALIGN_RIGHT;
        styleright.SetFont(font);
        rowNo = 7;
        colNo = 0;
        int stt = 0;
        float tong_so_mua = 0, tong_so_ban = 0;
        DataTable dtb;
        dtb = myNCS.get_danh_sach_nhap_cs_tong(drpKy.SelectedItem.ToString());
        for (j = 0; j <= dtb.Rows.Count - 1; j++)
        {
            // STT
            row = hsheet.CreateRow(rowNo);
            cell = row.CreateCell(colNo);
            stt = stt + 1;
            cell.SetCellValue(stt);
            cell.CellStyle = stylecenter;
            colNo += 1;

            // Mã trạm
            string maTram = dtb.Rows[j]["ten_viet_tat"].ToString();
            cell = row.CreateCell(colNo);
            cell.SetCellValue(maTram);
            cell.CellStyle = stylecenter;
            colNo += 1;

            // Tên trạm
            string tenTram = dtb.Rows[j]["ten_tram_bien_ap"].ToString();
            cell = row.CreateCell(colNo);
            cell.SetCellValue(tenTram);
            cell.CellStyle = styleleft;
            colNo += 1;

            // Sản lượng mua vào
            float so_mua = float.Parse(dtb.Rows[j]["so_mua"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            cell = row.CreateCell(colNo);
            if (so_mua > 0)
            {
                cell.SetCellValue(so_mua);
                tong_so_mua += so_mua;
            }
            cell.CellStyle = styleright;
            colNo += 1;

            // Sản lượng bán ra
            float so_ban = float.Parse(dtb.Rows[j]["so_ban"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            cell = row.CreateCell(colNo);
            if (so_ban > 0)
            {
                cell.SetCellValue(so_ban);
                tong_so_ban += so_ban;
            }
            cell.CellStyle = styleright;
            colNo += 1;

            // KWh
            cell = row.CreateCell(colNo);
            if (so_mua >= so_ban)
            {
                cell.SetCellValue(so_mua - so_ban);
            }
            cell.CellStyle = styleright;
            colNo += 1;

            // % tổn thất
            float percent = 0;
            string tonThatPercent = "";
            try
            {
                percent = 100 * (so_mua - so_ban) / so_mua;
                if (percent > 0)
                {
                    tonThatPercent = percent.ToString("0.00") + " %";
                }
            }
            catch
            {
                tonThatPercent = "%";
            }
            cell = row.CreateCell(colNo);
            cell.SetCellValue(tonThatPercent);
            cell.CellStyle = styleright;
            colNo += 1;

            // Ghi chú
            string ghiChu = "";
            cell = row.CreateCell(colNo);
            cell.SetCellValue(ghiChu);
            cell.CellStyle = styleright;

            rowNo += 1;
            colNo = 0;

        }

        // Tổng
        colNo = 2;
        string tong = "Tổng:";
        row = hsheet.CreateRow(rowNo);
        cell = row.CreateCell(colNo);
        cell.SetCellValue(tong);
        cell.CellStyle = styleright;
        colNo += 1;

        // Tổng sản lượng mua vào
        cell = row.CreateCell(colNo);
        if (tong_so_mua > 0)
        {
            cell.SetCellValue(tong_so_mua);
        }
        cell.CellStyle = styleright;
        colNo += 1;

        // Tổng sản lượng bán ra
        cell = row.CreateCell(colNo);
        cell.SetCellValue(tong_so_ban);
        cell.CellStyle = styleright;
        colNo += 1;

        // Tổng KWh
        cell = row.CreateCell(colNo);
        if (tong_so_mua >= tong_so_ban)
        {
            cell.SetCellValue(tong_so_mua - tong_so_ban);
        }
        cell.CellStyle = styleright;
        colNo += 1;

        // Tổng % tổn thất
        float tong_percent = 0;
        string tong_tonThatPercent = "";
        try
        {
            tong_percent = 100 * (tong_so_mua - tong_so_ban) / tong_so_mua;
            if (tong_percent > 0)
            {
                tong_tonThatPercent = tong_percent.ToString("0.00") + " %";
            }
        }
        catch
        {
            tong_tonThatPercent = "%";
        }
        cell = row.CreateCell(colNo);
        cell.SetCellValue(tong_tonThatPercent);
        cell.CellStyle = styleright;
        colNo += 1;


        // Người lập hóa đơn
        //rowNo += 2;
        //colNo = 6;
        //row = hsheet.CreateRow(rowNo);
        //cell = row.CreateCell(colNo);
        //cell.SetCellValue("Ngày.... tháng..... năm.....");
        //cell.CellStyle = stylecenternoborder;
        //rowNo += 1;
        //colNo = 6;
        //row = hsheet.CreateRow(rowNo);
        //cell = row.CreateCell(colNo);
        //cell.SetCellValue("Nhân viên xuất");
        //cell.CellStyle = stylecenternoborder;
        //rowNo += 4;
        //colNo = 6;
        //row = hsheet.CreateRow(rowNo);
        //cell = row.CreateCell(colNo);
        //cell.SetCellValue("Họ tên");
        //cell.CellStyle = stylecenternoborder;
        hwbook.Write(mem);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "ChiSoCongToTong.xls"));
        Response.Clear();
        Response.BinaryWrite(mem.GetBuffer());
        Response.End();
    }
}