using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class LapHoaDon : System.Web.UI.Page
{
    clsKhachHang myCus = new clsKhachHang();
    clsConnect myCon = new clsConnect();
    clsNhapChiSo myNCS = new clsNhapChiSo();
    DataTable CusList = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpTram.DataSource = myNCS.get_danh_sach_tba();
            drpTram.DataBind();

            drpKy.DataSource = myNCS.get_danhsach_ky();
            drpKy.DataBind();

            ddlKyCu.DataSource = myNCS.get_danhsach_ky();
            ddlKyCu.DataBind();
            lblErr.Text = "";

            string kyhd = drpKy.SelectedItem.ToString();
            string tungay = myNCS.lay_tungay_denngay(kyhd).Rows[0]["tu_ngay"].ToString().Substring(0, 10);
            string denngay = myNCS.lay_tungay_denngay(kyhd).Rows[0]["den_ngay"].ToString().Substring(0, 10);
            lblTuNgay.Text = tungay;
            lblDenNgay.Text = denngay;

        }

    }

    protected void gv_bind()
    {
        string id_tramba = drpTram.SelectedValue.ToString();
        string kyhd = drpKy.SelectedItem.ToString();
        CusList = dtb_bind(id_tramba, kyhd);
        
        GridViewEman.DataSource = CusList;
        GridViewEman.DataBind();
        
        if (CusList.Rows.Count > 0)
        {
            GridViewEman.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected DataTable dtb_bind(string id_tramba, string kyhd)
    {
        CusList = myNCS.get_danh_sach_lap_hd(id_tramba, kyhd);
        int i = 0;
        int j = 0;
        CusList.Columns.Add("san_luong", typeof(String));
        CusList.Columns.Add("total", typeof(Double));
        CusList.Columns.Add("vatamount", typeof(Double));
        CusList.Columns.Add("amount", typeof(Double));
        CusList.Columns.Add("vatrate", typeof(String));
        if (CusList.Rows.Count > 0)
        {
            do
            {
                Double dntt = 0;
                int sh = 0;
                Double total = 0;
                Double vatamount = 0;
                Double amount = 0; // amount = total + vatamount

                string id_bg = CusList.Rows[i]["id_bang_gia"].ToString();
                DataTable BangGia = myNCS.lay_bang_gia(id_bg);
                Double vatrate = Convert.ToDouble(BangGia.Rows[0]["phan_tram_thue"].ToString());
                
                Double cs_cu = 0;
                Double cs_moi = 0;
                j = i;
                do
                {
                    Double he_so_ti = Convert.ToDouble(CusList.Rows[j]["he_so_ti"].ToString());
                    cs_cu = Convert.ToDouble(CusList.Rows[j]["cs_cu"].ToString());
                    cs_moi = Convert.ToDouble(CusList.Rows[j]["cs_moi"].ToString());
                    dntt = dntt + (cs_moi - cs_cu) * he_so_ti;
                    j++;
                } while (j < CusList.Rows.Count && string.Compare(CusList.Rows[j]["ma_kh"].ToString(), CusList.Rows[j - 1]["ma_kh"].ToString()) == 0);
                               
                sh = Convert.ToInt32(CusList.Rows[i]["so_ho"].ToString());
                total = myNCS.tinh_tien_dien(dntt, sh, id_bg);

                vatamount = vatrate * total / 100;
                //Làm tròn
                vatamount = Math.Round(vatamount, 0, MidpointRounding.AwayFromZero);
                amount = total + vatamount;
              //  j = i;
               // do
                //{
                    CusList.Rows[i]["san_luong"] = dntt.ToString();
                    CusList.Rows[i]["total"] = total;
                    CusList.Rows[i]["vatrate"] = vatrate.ToString();
                    CusList.Rows[i]["vatamount"] = vatamount;
                    CusList.Rows[i]["amount"] = amount;
                    //CusList.Rows[j]["san_luong"] = null;
                    //CusList.Rows[j]["total"] = null;
                    //CusList.Rows[j]["vatrate"] = null;
                    //CusList.Rows[j]["vatamount"] = null;
                    //CusList.Rows[j]["amount"] = null;
                   // j++;
                //} while (j < CusList.Rows.Count && string.Compare(CusList.Rows[j]["ma_kh"].ToString(), CusList.Rows[j - 1]["ma_kh"].ToString()) == 0);
                i =j;
            } while (i < CusList.Rows.Count);
        }
        return CusList;

    }

    protected void btnLaySL_Click(object sender, EventArgs e)
    {
        gv_bind();
    }

    protected void btnChotSL_Click(object sender, EventArgs e)
    {
        int recordsAffected = 0;
        string id_tram = drpTram.SelectedValue.ToString();
        string kyhd = drpKy.SelectedItem.ToString();
        string tungay = myNCS.lay_tungay_denngay(kyhd).Rows[0]["tu_ngay"].ToString().Substring(0, 10);
        string denngay = myNCS.lay_tungay_denngay(kyhd).Rows[0]["den_ngay"].ToString().Substring(0, 10);
        string user = Context.User.Identity.Name.ToString();
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(user);
        DataTable dtbInv = dtb_bind(id_tram, kyhd);
        int i = 0;
        if (dtbInv.Rows.Count > 0)
        {
            do
            {
                recordsAffected = 0;
                string makh = dtbInv.Rows[i]["ma_kh"].ToString();
                string mact = "";
                int soho = Convert.ToInt32(dtbInv.Rows[i]["so_ho"].ToString());
                string cscu = dtbInv.Rows[i]["cs_cu"].ToString();
                string csmoi = dtbInv.Rows[i]["cs_moi"].ToString();

                mact = dtbInv.Rows[i]["ma_cong_to"].ToString();
                Double dntt = 0;
                Double total = 0;
                Double vatamount = 0;
                Double amount = 0;
                string idKhu = dtbInv.Rows[i]["id_khu"].ToString();
                string idTram = dtbInv.Rows[i]["id_tram_bien_ap"].ToString();
                string idBangGia = dtbInv.Rows[i]["id_bang_gia"].ToString();
                string vaterate = dtbInv.Rows[i]["vatrate"].ToString();
                string ten_kh = dtbInv.Rows[i]["ten_kh"].ToString();
                string id_tram_bien_ap = dtbInv.Rows[i]["id_tram_bien_ap"].ToString();
                string id_khu = dtbInv.Rows[i]["id_khu"].ToString();               


                if (dtbInv.Rows[i]["total"].ToString() == ""){
                    dtbInv.Rows[i]["total"] = "0";
                }
                if (dtbInv.Rows[i]["vatamount"].ToString() == "")
                {
                    dtbInv.Rows[i]["vatamount"] = "0";
                }
                if (dtbInv.Rows[i]["amount"].ToString() == "")
                {
                    dtbInv.Rows[i]["amount"] = "0";
                }
                if (dtbInv.Rows[i]["san_luong"].ToString() == "")
                {
                    dtbInv.Rows[i]["san_luong"] = "0";
                }

                total = Convert.ToDouble(dtbInv.Rows[i]["total"].ToString());
                vatamount = Convert.ToDouble(dtbInv.Rows[i]["vatamount"].ToString());
                amount = Convert.ToDouble(dtbInv.Rows[i]["amount"].ToString());
                dntt = Convert.ToDouble(dtbInv.Rows[i]["san_luong"].ToString());

                Int64 idHD = myNCS.lay_idhd();
                if (i > 0)
                {
                    if (i < dtbInv.Rows.Count && string.Compare(dtbInv.Rows[i]["ma_kh"].ToString(), dtbInv.Rows[i - 1]["ma_kh"].ToString()) == 0)
                    {
                        idHD = idHD - 1;
                     
                    }
                }
                myNCS.them_moi_hoa_don(idHD, makh, kyhd, tungay, denngay, cscu, csmoi, dntt.ToString(), total, vaterate, vatamount, amount, user, idBangGia, mact,soho,ten_kh,id_tram_bien_ap,id_khu);
                if (i > 0)
                {
                    if (i < dtbInv.Rows.Count && string.Compare(dtbInv.Rows[i]["ma_kh"].ToString(), dtbInv.Rows[i - 1]["ma_kh"].ToString()) != 0)
                    {
                        recordsAffected = myNCS.them_moi_hoa_don_chi_tiet(idHD, dntt, soho, idBangGia);
                    }
                }
                if (i == 0)
                {
                    recordsAffected = myNCS.them_moi_hoa_don_chi_tiet(idHD, dntt, soho, idBangGia);
                }
                //if (i == (dtbInv.Rows.Count - 1))
                //{
                //    recordsAffected = myNCS.them_moi_hoa_don_chi_tiet(idHD, dntt, soho, idBangGia);
                //}
                myNCS.chotchiso(mact, kyhd);
                i++;
            } while (i < dtbInv.Rows.Count);
        }

        else
        {
            txtErr.Text = "Không có dữ liệu";
        }
        gv_bind();
    }

    protected void ThemKyHD(object sender, EventArgs e)
    {
        string tungay = Request.Form["strTuNgay"].ToString();
        string denngay = Request.Form["strDenNgay"].ToString();
        string kyhd = Request.Form["strKyHD"].ToString();
        int i = 0;
        if (tungay != "-1" && denngay != "-1")
        {
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
                    CusList = myNCS.get_danh_sach_nhap_cs("0", kycu);
                    for (i = 0; i < CusList.Rows.Count; i++)
                    {
                        string mact = CusList.Rows[i]["ma_cong_to"].ToString();
                        string csmoi = CusList.Rows[i]["cs_moi"].ToString();
                        if (csmoi != "")
                        {
                            if (myNCS.check_cs_ct(mact, kyhd) < 1)
                            {
                                result = myNCS.them_chi_so_ky_moi(mact, csmoi, kyhd);
                                if (result == 0)
                                {
                                    lblErr.Text = "Có lỗi xảy ra trong quá trình khởi tạo dữ liệu kỳ sau mã công tơ " + mact;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (result == 1)
                {
                    Response.Redirect("NhapChiSo.aspx");
                }

            }
        }

    }

}