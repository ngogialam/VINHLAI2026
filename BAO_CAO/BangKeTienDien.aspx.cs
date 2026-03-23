using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BangKeTienDien : System.Web.UI.Page
{
    clsBaocao myCus = new clsBaocao();
    clsConnect myCon = new clsConnect();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session.Remove("KeTienDienTable");
            Session.Remove("KeTienDienTenTramBA");
            Session.Remove("KeTienDienKyTramBA");
            Session.Remove("KeTienDienNgayThang");
            Session.Remove("KeTienDienNgayIn");

            DataTable tram_bien_ap = myCus.get_tram_bien_ap();
            DataRow newRow = tram_bien_ap.NewRow();
            newRow[0] = 0;
            newRow[1] = "Tất cả";
            tram_bien_ap.Rows.InsertAt(newRow, 0);
            ddlTramBA.DataSource = tram_bien_ap;
            ddlTramBA.DataBind();

            DataTable nam = myCus.get_nam();
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
            string id_tram_bien_ap = ddlTramBA.SelectedValue.ToString();

            bindGrid(id_tram_bien_ap, ky_hd);
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
    void bindGrid(string id_tram_bien_ap, string ky_hd)
    {
        DataTable tbx = new DataTable();
        DataTable tbxView = new DataTable();
        clsBaocao cslBC = new clsBaocao();
        //string id_doanh_nghiep = Session["IDDoanhNghiep"].ToString();
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(Context.User.Identity.Name.ToString());
        tbx = cslBC.SELECT_BANG_KE_TIEN_DIEN1(id_tram_bien_ap, ky_hd, id_doanh_nghiep);

        DataRow dr;
        tbxView.Columns.Add("stt", typeof(String));
        tbxView.Columns.Add("ten_kh", typeof(String));
        tbxView.Columns.Add("ma_kh", typeof(String));
        tbxView.Columns.Add("sl_dong_ho", typeof(String));
        tbxView.Columns.Add("cot_dien_so", typeof(String));
        tbxView.Columns.Add("dia_chi", typeof(String));
        tbxView.Columns.Add("dien_thoai", typeof(String));
        tbxView.Columns.Add("tong_tien_sau_thue", typeof(Double));
        tbxView.Columns.Add("ma_cong_to", typeof(String));
        tbxView.Columns.Add("chi_so_cu", typeof(Double));
        tbxView.Columns.Add("chi_so_moi", typeof(Double));
        tbxView.Columns.Add("so_ho", typeof(Double));
        tbxView.Columns.Add("dien_nang_tt", typeof(Double));
        tbxView.Columns.Add("sh1", typeof(Double));
        tbxView.Columns.Add("sh2", typeof(Double));
        tbxView.Columns.Add("sh3", typeof(Double));
        tbxView.Columns.Add("sh4", typeof(Double));
        tbxView.Columns.Add("sh5", typeof(Double));
        tbxView.Columns.Add("sh6", typeof(Double));
        tbxView.Columns.Add("NT", typeof(Double));
        tbxView.Columns.Add("BV", typeof(Double));
        tbxView.Columns.Add("KD", typeof(Double));
        tbxView.Columns.Add("CSCC", typeof(Double));
        tbxView.Columns.Add("TH", typeof(Double));
        tbxView.Columns.Add("HCSN", typeof(Double));
        tbxView.Columns.Add("BN", typeof(Double));
        tbxView.Columns.Add("SX", typeof(Double));
        tbxView.Columns.Add("DX", typeof(Double));
        tbxView.Columns.Add("GBT", typeof(Double));
        tbxView.Columns.Add("GTD", typeof(Double));
        tbxView.Columns.Add("GCD", typeof(Double));
        tbxView.Columns.Add("KDGBT", typeof(Double));
        tbxView.Columns.Add("KDGTD", typeof(Double));
        tbxView.Columns.Add("KDGCD", typeof(Double));
        tbxView.Columns.Add("TDKD", typeof(Double));
        dr = tbxView.NewRow();

        double sh1 = 0;
        double sh2 = 0;
        double sh3 = 0;
        double sh4 = 0;
        double sh5 = 0;
        double sh6 = 0;
        double NT = 0;
        double BV = 0;
        double KD = 0;
        double TDKD = 0;
        double CSCC = 0;
        double BN = 0;
        double HCSN = 0;
        double TH = 0;
        double SX = 0;
        double HH = 0;
        double HH_2 = 0;
        double DX = 0;
        double GBT = 0;
        double GTD = 0;
        double GCD = 0;
        double KDGBT = 0;
        double KDGTD = 0;
        double KDGCD = 0;

        double san_luong_tt = 0;
        double tong_tien = 0;
        double so_ho = 0;
        string ma_kh = "";
        for (int i = 0; i < tbx.Rows.Count; i++)
        {
            ma_kh = tbx.Rows[i]["ma_kh"].ToString().Trim();
            if (ma_kh != "")
            {
                DataRow newRowTong = tbxView.NewRow();
                newRowTong[0] = i + 1;
                newRowTong[1] = tbx.Rows[i]["ten_kh"].ToString();
                newRowTong[2] = tbx.Rows[i]["ma_kh"].ToString();
                newRowTong[3] = tbx.Rows[i]["sl_dong_ho"].ToString();
                newRowTong[4] = tbx.Rows[i]["cot_dien_so"].ToString();
                newRowTong[5] = tbx.Rows[i]["dia_chi"].ToString();
                newRowTong[6] = tbx.Rows[i]["dien_thoai"].ToString();
                newRowTong[7] = tbx.Rows[i]["tong_tien_sau_thue"].ToString();
                newRowTong[8] = tbx.Rows[i]["ma_cong_to"].ToString();
                newRowTong[9] = tbx.Rows[i]["chi_so_cu"].ToString();
                newRowTong[10] = tbx.Rows[i]["chi_so_moi"].ToString();
                newRowTong[12] = tbx.Rows[i]["dien_nang_tt"].ToString();
                if (tbx.Rows[i]["dien_nang_tt"].ToString() == "0")
                {
                    // check xem hộ đó có dùng nhiều công tơ không, nếu dùng nhiều vẫn chỉ tính là 1 hộ
                    string so_cong_to = cslBC.CheckCongTo(tbx.Rows[i]["ma_kh"].ToString());
                    if (so_cong_to == "1")
                        newRowTong[11] = "1";
                    else
                        newRowTong[11] = "0";
                }
                else
                    newRowTong[11] = tbx.Rows[i]["so_ho"].ToString();

                //=================tinh san luong dien sinh hoat theo tung muc===============
                if (tbx.Rows[i]["ten_viet_tat"].ToString() == "SH")
                {
                    string[] muc = new string[] { };
                    muc = cslBC.TINH_BAC_DIEN_SH(double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString()), int.Parse(tbx.Rows[i]["so_ho"].ToString()));
                     newRowTong[13] = muc[0];
                    sh1 = sh1 + double.Parse(muc[0]);
                    newRowTong[14] = muc[1];
                    sh2 = sh2 + double.Parse(muc[1]);
                    newRowTong[15] = muc[2];
                    sh3 = sh3 + double.Parse(muc[2]);
                    newRowTong[16] = muc[3];
                    sh4 = sh4 + double.Parse(muc[3]);
                    newRowTong[17] = muc[4];
                    sh5 = sh5 + double.Parse(muc[4]);
                    newRowTong[18] = muc[5];
                    sh6 = sh6 + double.Parse(muc[5]);

                    //newRowTong[16] = "";
                    //newRowTong[17] = "";
                    //newRowTong[18] = "";
                    //newRowTong[19] = "";
                    //newRowTong[20] = "";
                    //newRowTong[21] = "";
                    //newRowTong[22] = "";
                    //newRowTong[23] = "";
                }
                else //========================tinh san luong dien su dung muc dich khac=====================
                {

                    //newRowTong[10] = "";
                    //newRowTong[11] = "";
                    //newRowTong[12] = "";
                    //newRowTong[13] = "";
                    //newRowTong[14] = "";
                    //newRowTong[15] = "";

                    if (tbx.Rows[i]["ten_viet_tat"].ToString() == "NT")
                    {
                        newRowTong[19] = double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        NT = NT + double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        //newRowTong[17] = "";
                        //newRowTong[18] = "";
                        //newRowTong[19] = "";
                        //newRowTong[20] = "";
                        //newRowTong[21] = "";
                        //newRowTong[22] = "";
                        //newRowTong[23] = "";
                    }
                    else if (tbx.Rows[i]["ten_viet_tat"].ToString() == "BV")
                    {
                        //newRowTong[16] = "";
                        newRowTong[20] = double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        BV = BV + double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        //newRowTong[18] = "";
                        //newRowTong[19] = "";
                        //newRowTong[20] = "";
                        //newRowTong[21] = "";
                        //newRowTong[22] = "";
                        //newRowTong[23] = "";
                    }
                    else if (tbx.Rows[i]["ten_viet_tat"].ToString() == "KD")
                    {
                        //newRowTong[16] = "";
                        //newRowTong[17] = "";
                        newRowTong[21] = double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        KD = KD + double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        //newRowTong[19] = "";
                        //newRowTong[20] = "";
                        //newRowTong[21] = "";
                        //newRowTong[22] = "";
                        //newRowTong[23] = "";
                    }
                    else if (tbx.Rows[i]["ten_viet_tat"].ToString() == "CSCC")
                    {
                        //newRowTong[16] = "";
                        //newRowTong[17] = "";
                        //newRowTong[18] = "";
                        newRowTong[22] = double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        CSCC = CSCC + double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        //newRowTong[20] = "";
                        //newRowTong[21] = "";
                        //newRowTong[22] = "";
                        //newRowTong[23] = "";
                    }
                    else if (tbx.Rows[i]["ten_viet_tat"].ToString() == "TH")
                    {
                        //newRowTong[16] = "";
                        //newRowTong[17] = "";
                        //newRowTong[18] = "";
                        //newRowTong[19] = "";
                        newRowTong[23] = double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        TH = TH + double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        //newRowTong[21] = "";
                        //newRowTong[22] = "";
                        //newRowTong[23] = "";
                    }
                    else if (tbx.Rows[i]["ten_viet_tat"].ToString() == "HCSN")
                    {
                        //newRowTong[16] = "";
                        //newRowTong[17] = "";
                        //newRowTong[18] = "";
                        //newRowTong[19] = "";
                        //newRowTong[20] = "";
                        newRowTong[24] = double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        HCSN = HCSN + double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        //newRowTong[22] = "";
                        //newRowTong[23] = "";
                    }
                    else if (tbx.Rows[i]["ten_viet_tat"].ToString() == "BN")
                    {
                        //newRowTong[16] = "";
                        //newRowTong[17] = "";
                        //newRowTong[18] = "";
                        //newRowTong[19] = "";
                        //newRowTong[20] = "";
                        //newRowTong[21] = "";
                        newRowTong[25] = double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        BN = BN + double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        //newRowTong[23] = "";
                    }
                    else if (tbx.Rows[i]["ten_viet_tat"].ToString() == "SX")
                    {
                        //newRowTong[16] = "";
                        //newRowTong[17] = "";
                        //newRowTong[18] = "";
                        //newRowTong[19] = "";
                        //newRowTong[20] = "";
                        //newRowTong[21] = "";
                        //newRowTong[22] = "";
                        newRowTong[26] = double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        SX = SX + double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                    }
                    else if (tbx.Rows[i]["ten_viet_tat"].ToString() == "DX")
                    {
                        //newRowTong[16] = "";
                        //newRowTong[17] = "";
                        //newRowTong[18] = "";
                        //newRowTong[19] = "";
                        //newRowTong[20] = "";
                        //newRowTong[21] = "";
                        //newRowTong[22] = "";
                        newRowTong[22] = double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        CSCC = CSCC + double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());

                        newRowTong[27] = double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        DX = DX + double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                    }
                    else if (tbx.Rows[i]["ten_viet_tat"].ToString() == "HH")
                    {
                        //newRowTong[16] = "";
                        Double sumDN = 0;
                        Double dn = 0;
                        HH = double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                        string id_bang_gia = tbx.Rows[i]["id_bang_gia_dien"].ToString(); // ID = 24
                        clsNhapChiSo myNCS = new clsNhapChiSo();
                        DataTable BangGiaHH = myNCS.lay_bang_gia_chi_tiet(id_bang_gia); // ra 2 dòng id bang gia ty le 1 va 48
                        int j;
                        for (j = 0; j < BangGiaHH.Rows.Count; j++)
                        {
                            DataTable dtbtemp = myNCS.lay_bang_gia(BangGiaHH.Rows[j]["id_bang_gia_ty_le"].ToString().Trim());//Ten viet tat hh
                            int tyle = Convert.ToInt32(BangGiaHH.Rows[j]["ty_le"].ToString().Trim());

                            if (j != BangGiaHH.Rows.Count - 1)
                            {
                                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
                                {
                                    dn = HH * tyle / 100;
                                    dn = Math.Round(dn, 0, MidpointRounding.AwayFromZero);
                                    sumDN = sumDN + dn;
                                    if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "NT")
                                    {
                                        newRowTong[19] = dn;
                                        NT = NT + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "BV")
                                    {

                                        newRowTong[20] = dn;
                                        BV = BV + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "KD")
                                    {

                                        newRowTong[21] = dn;
                                        KD = KD + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "CSCC")
                                    {

                                        newRowTong[22] = dn;
                                        CSCC = CSCC + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "TH")
                                    {

                                        newRowTong[23] = dn;
                                        TH = TH + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "HCSN")
                                    {

                                        newRowTong[24] = dn;
                                        HCSN = HCSN + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "BN")
                                    {

                                        newRowTong[25] = dn;
                                        BN = BN + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "SX")
                                    {
                                        newRowTong[26] = dn;
                                        SX = SX + dn;
                                    }
                                    //Code thêm điện theo giờ --- START
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "GBT")
                                    {
                                        newRowTong[28] = dn;
                                        GBT = GBT + dn;
                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "GTÐ")
                                    {
                                        newRowTong[29] = dn;
                                        GTD = GTD + dn;
                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "GCÐ")
                                    {
                                        newRowTong[30] = dn;
                                        GCD = GCD + dn;
                                    }
                                    //Code thêm điện theo giờ --- END
                                    //Code thêm điện kinh doanh theo giờ --- START
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "KDGBT")
                                    {
                                        newRowTong[31] = dn;
                                        KDGBT = KDGBT + dn;
                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "KDGTD")
                                    {
                                        newRowTong[32] = dn;
                                        KDGTD = KDGTD + dn;
                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "KDGCD")
                                    {
                                        newRowTong[33] = dn;
                                        KDGCD = KDGCD + dn;
                                    }
                                    //Code thêm điện kinh doanh theo giờ --- END
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "TDKD")
                                    {
                                        newRowTong[34] = dn;
                                        TDKD = TDKD + dn;
                                    }

                                }
                                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "BT")
                                {
                                    dn = HH * tyle / 100;
                                    dn = Math.Round(dn, 0, MidpointRounding.AwayFromZero);
                                    sumDN = sumDN + dn;
                                    string[] muc = new string[] { };
                                    muc = cslBC.TINH_BAC_DIEN_SH(dn, int.Parse(tbx.Rows[i]["so_ho"].ToString()));
                                    newRowTong[13] = muc[0];
                                    sh1 = sh1 + double.Parse(muc[0]);
                                    newRowTong[14] = muc[1];
                                    sh2 = sh2 + double.Parse(muc[1]);
                                    newRowTong[15] = muc[2];
                                    sh3 = sh3 + double.Parse(muc[2]);
                                    newRowTong[16] = muc[3];
                                    sh4 = sh4 + double.Parse(muc[3]);
                                    newRowTong[17] = muc[4];
                                    sh5 = sh5 + double.Parse(muc[4]);
                                    newRowTong[18] = muc[5];
                                    sh6 = sh6 + double.Parse(muc[5]);

                                }

                                //OS ngày 09/01/2025 -- START
                                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "HH")
                                {
                                    Double sumDN_2 = 0;
                                    Double dn_2 = 0;
                                    dn_2 = HH * tyle / 100;
                                    HH_2 = Math.Round(dn_2, 0, MidpointRounding.AwayFromZero);

                                    string id_bang_gia_2 = dtbtemp.Rows[0]["id_bang_gia"].ToString().Trim(); // ID = 48
                                    DataTable BangGiaHH_2 = myNCS.lay_bang_gia_chi_tiet(id_bang_gia_2); // ra 3 dòng id bang gia ty le 49, 50, 51
                                    int k;
                                    for (k = 0; k < BangGiaHH_2.Rows.Count; k++)
                                    {
                                        // Ra được don gia 3007, tên viết tắt KDGBT
                                        DataTable dtbtemp_2 = myNCS.lay_bang_gia(BangGiaHH_2.Rows[k]["id_bang_gia_ty_le"].ToString().Trim());
                                        int tyle_2 = Convert.ToInt32(BangGiaHH_2.Rows[k]["ty_le"].ToString().Trim());
                                        if (k != BangGiaHH_2.Rows.Count - 1)
                                        {
                                            dn_2 = Math.Round(HH_2 * tyle_2 / 100, 0, MidpointRounding.AwayFromZero);
                                            sumDN_2 = sumDN_2 + dn_2;

                                            if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "GBT")
                                            {
                                                newRowTong[28] = dn_2;
                                                GBT = GBT + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "GTÐ")
                                            {
                                                newRowTong[29] = dn_2;
                                                GTD = GTD + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "GCÐ")
                                            {
                                                newRowTong[30] = dn_2;
                                                GCD = GCD + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "KDGBT")
                                            {
                                                newRowTong[31] = dn_2;
                                                KDGBT = KDGBT + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "KDGTD")
                                            {
                                                newRowTong[32] = dn_2;
                                                KDGTD = KDGTD + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "KDGCD")
                                            {
                                                newRowTong[33] = dn_2;
                                                KDGCD = KDGCD + dn_2;
                                            }
                                        }
                                        else
                                        {
                                            dn_2 = HH_2 - dn_2;
                                            dn_2 = Math.Round(HH_2 * tyle_2 / 100, 0, MidpointRounding.AwayFromZero);
                                            sumDN_2 = sumDN_2 + dn_2;

                                            if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "GBT")
                                            {
                                                newRowTong[28] = dn_2;
                                                GBT = GBT + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "GTÐ")
                                            {
                                                newRowTong[29] = dn_2;
                                                GTD = GTD + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "GCÐ")
                                            {
                                                newRowTong[30] = dn_2;
                                                GCD = GCD + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "KDGBT")
                                            {
                                                newRowTong[31] = dn_2;
                                                KDGBT = KDGBT + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "KDGTD")
                                            {
                                                newRowTong[32] = dn_2;
                                                KDGTD = KDGTD + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "KDGCD")
                                            {
                                                newRowTong[33] = dn_2;
                                                KDGCD = KDGCD + dn_2;
                                            }
                                        }

                                    }
                                }
                                //OS ngày 09/01/2025 -- END
                            }
                            else
                            {
                                dn = HH - sumDN;
                                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
                                {

                                    if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "NT")
                                    {
                                        newRowTong[19] = dn;
                                        NT = NT + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "BV")
                                    {

                                        newRowTong[20] = dn;
                                        BV = BV + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "KD")
                                    {

                                        newRowTong[21] = dn;
                                        KD = KD + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "CSCC")
                                    {

                                        newRowTong[22] = dn;
                                        CSCC = CSCC + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "TH")
                                    {

                                        newRowTong[23] = dn;
                                        TH = TH + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "HCSN")
                                    {

                                        newRowTong[24] = dn;
                                        HCSN = HCSN + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "BN")
                                    {

                                        newRowTong[25] = dn;
                                        BN = BN + dn;

                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "SX")
                                    {
                                        newRowTong[26] = dn;
                                        SX = SX + dn;
                                    }
                                    //Code thêm điện sản xuất theo giờ --- START
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "GBT")
                                    {
                                        newRowTong[28] = dn;
                                        GBT = GBT + dn;
                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "GTÐ")
                                    {
                                        newRowTong[29] = dn;
                                        GTD = GTD + dn;
                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "GCÐ")
                                    {
                                        newRowTong[30] = dn;
                                        GCD = GCD + dn;
                                    }
                                    //Code thêm điện sản xuất theo giờ --- END
                                    //Code thêm điện kinh doanh theo giờ --- START
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "KDGBT")
                                    {
                                        newRowTong[31] = dn;
                                        KDGBT = KDGBT + dn;
                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "KDGTD")
                                    {
                                        newRowTong[32] = dn;
                                        KDGTD = KDGTD + dn;
                                    }
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "KDGCD")
                                    {
                                        newRowTong[33] = dn;
                                        KDGCD = KDGCD + dn;
                                    }
                                    //Code thêm điện kinh doanh theo giờ --- END
                                    else if (dtbtemp.Rows[0]["ten_viet_tat"].ToString() == "TDKD")
                                    {
                                        newRowTong[34] = dn;
                                        TDKD = TDKD + dn;
                                    }

                                }
                                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "BT")
                                {
                                    string[] muc = new string[] { };
                                    muc = cslBC.TINH_BAC_DIEN_SH(dn, int.Parse(tbx.Rows[i]["so_ho"].ToString()));
                                    newRowTong[13] = muc[0];
                                    sh1 = sh1 + double.Parse(muc[0]);
                                    newRowTong[14] = muc[1];
                                    sh2 = sh2 + double.Parse(muc[1]);
                                    newRowTong[15] = muc[2];
                                    sh3 = sh3 + double.Parse(muc[2]);
                                    newRowTong[16] = muc[3];
                                    sh4 = sh4 + double.Parse(muc[3]);
                                    newRowTong[17] = muc[4];
                                    sh5 = sh5 + double.Parse(muc[4]);
                                    newRowTong[18] = muc[5];
                                    sh6 = sh6 + double.Parse(muc[5]);
                                }

                                //OS ngày 09/01/2025 -- START
                                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "HH")
                                {
                                    Double sumDN_2 = 0;
                                    Double dn_2 = 0;
                                    dn_2 = HH * tyle / 100;
                                    HH_2 = Math.Round(dn_2, 0, MidpointRounding.AwayFromZero);

                                    string id_bang_gia_2 = dtbtemp.Rows[0]["id_bang_gia"].ToString().Trim(); // ID = 48
                                    DataTable BangGiaHH_2 = myNCS.lay_bang_gia_chi_tiet(id_bang_gia_2); // ra 3 dòng id bang gia ty le 49, 50, 51
                                    int k;
                                    for (k = 0; k < BangGiaHH_2.Rows.Count; k++)
                                    {
                                        // Ra được don gia 3007, tên viết tắt KDGBT
                                        DataTable dtbtemp_2 = myNCS.lay_bang_gia(BangGiaHH_2.Rows[k]["id_bang_gia_ty_le"].ToString().Trim());
                                        int tyle_2 = Convert.ToInt32(BangGiaHH_2.Rows[k]["ty_le"].ToString().Trim());
                                        if (k != BangGiaHH_2.Rows.Count - 1)
                                        {
                                            dn_2 = Math.Round(HH_2 * tyle_2 / 100, 0, MidpointRounding.AwayFromZero);
                                            sumDN_2 = sumDN_2 + dn_2;

                                            if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "GBT")
                                            {
                                                newRowTong[28] = dn_2;
                                                GBT = GBT + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "GTÐ")
                                            {
                                                newRowTong[29] = dn_2;
                                                GTD = GTD + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "GCÐ")
                                            {
                                                newRowTong[30] = dn_2;
                                                GCD = GCD + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "KDGBT")
                                            {
                                                newRowTong[31] = dn_2;
                                                KDGBT = KDGBT + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "KDGTD")
                                            {
                                                newRowTong[32] = dn_2;
                                                KDGTD = KDGTD + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "KDGCD")
                                            {
                                                newRowTong[33] = dn_2;
                                                KDGCD = KDGCD + dn_2;
                                            }
                                        }
                                        else
                                        {
                                            dn_2 = HH_2 - dn_2;
                                            dn_2 = Math.Round(HH_2 * tyle_2 / 100, 0, MidpointRounding.AwayFromZero);
                                            sumDN_2 = sumDN_2 + dn_2;

                                            if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "GBT")
                                            {
                                                newRowTong[28] = dn_2;
                                                GBT = GBT + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "GTÐ")
                                            {
                                                newRowTong[29] = dn_2;
                                                GTD = GTD + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "GCÐ")
                                            {
                                                newRowTong[30] = dn_2;
                                                GCD = GCD + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "KDGBT")
                                            {
                                                newRowTong[31] = dn_2;
                                                KDGBT = KDGBT + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "KDGTD")
                                            {
                                                newRowTong[32] = dn_2;
                                                KDGTD = KDGTD + dn_2;
                                            }
                                            else if (dtbtemp_2.Rows[0]["ten_viet_tat"].ToString() == "KDGCD")
                                            {
                                                newRowTong[33] = dn_2;
                                                KDGCD = KDGCD + dn_2;
                                            }
                                        }

                                    }
                                }
                                //OS ngày 09/01/2025 -- END
                            }


                        }
                    }
                    else
                    {
                        //newRowTong[16] = "";
                        //newRowTong[17] = "";
                        //newRowTong[18] = "";
                        //newRowTong[19] = "";
                        //newRowTong[20] = "";
                        //newRowTong[21] = "";
                        //newRowTong[22] = "";
                        //newRowTong[23] = "";
                    }

                }

                tong_tien += double.Parse(tbx.Rows[i]["tong_tien_sau_thue"].ToString());
                so_ho += double.Parse(newRowTong[11].ToString());
                san_luong_tt += double.Parse(tbx.Rows[i]["dien_nang_tt"].ToString());
                tbxView.Rows.InsertAt(newRowTong, i);
            }
        }

        DataRow newRow4 = tbxView.NewRow();
        //newRow4[0] = "Tổng";
        newRow4[1] = "Tổng";
        //newRow4[2] = "";
        //newRow4[3] = "";
        //newRow4[4] = "";
        newRow4[7] = tong_tien;
        //newRow4[4] = tong_tien;
        //newRow4[8] = so_ho;
        newRow4[11] = so_ho;
        newRow4[12] = san_luong_tt;

        newRow4[13] = sh1;
        newRow4[14] = sh2;
        newRow4[15] = sh3;
        newRow4[16] = sh4;
        newRow4[17] = sh5;
        newRow4[18] = sh6;


        newRow4[19] = NT;
        newRow4[20] = BV;
        newRow4[21] = KD;
        newRow4[22] = CSCC;
        newRow4[23] = TH;
        newRow4[24] = HCSN;
        newRow4[25] = BN;
        newRow4[26] = SX;
        newRow4[27] = DX;
        //Code thêm điện sản xuất theo giờ --- START
        newRow4[28] = GBT;
        newRow4[29] = GTD;
        newRow4[30] = GCD;
        //Code thêm điện sản xuất theo giờ --- END
        //Code thêm điện kinh doanh theo giờ --- START
        newRow4[31] = KDGBT;
        newRow4[32] = KDGTD;
        newRow4[33] = KDGCD;
        //Code thêm điện kinh doanh theo giờ --- END
        newRow4[34] = TDKD;

        tbxView.Rows.InsertAt(newRow4, 0);

        GridView1.DataSource = tbxView;
        GridView1.DataBind();
        ViewState["DataTable"] = tbxView;
        Session["KeTienDienTable"] = tbxView;
        Session["KeTienDienTenTramBA"] = "Trạm: " + ddlTramBA.SelectedItem;
        Session["KeTienDienKyTramBA"] = "Kỳ " + ddlThang.SelectedItem;
        Session["KeTienDienNgayThang"] = "THÁNG " + ddlThang.SelectedItem + " NĂM " + ddlNam.SelectedItem;
        Session["KeTienDienNgayIn"] = "Ngày in:  " + DateTime.Today.ToString("dd/MM/yyyy");
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
