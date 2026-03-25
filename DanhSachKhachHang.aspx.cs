using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class DanhSachKhachHang : System.Web.UI.Page
{
    clsNhapChiSo myNCS = new clsNhapChiSo();
    clsKhachHang myCus = new clsKhachHang();
    clsSanPham mySP = new clsSanPham();
    clsConnect myCon = new clsConnect();
    DataTable CusList = new DataTable();
    clsBaocao myBC = new clsBaocao();
    public string id_tba = "";
    public static DataTable bang_gia_dien = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpTramBienAp_1.DataSource = myNCS.get_danh_sach_tba();
            drpTramBienAp_1.DataBind();
            try
            {
                if (id_tba == "")
                {
                    id_tba = drpTramBienAp_1.SelectedValue.ToString();
                }
                gv_bind(id_tba);
            }
            catch (Exception) { }
            DataTable DiaBanList = myCus.get_danh_muc_khu();
            cbKhu.DataSource = DiaBanList;
            cbKhu.DataBind();
            drpKhu_AddModal.DataSource = DiaBanList;
            drpKhu_AddModal.DataBind();
            DataTable HuyenList = myCus.get_danh_muc_huyen();
            drpHuyen.DataSource = HuyenList;
            drpHuyen.DataBind();
            drpHuyen_AddModal.DataSource = HuyenList;
            drpHuyen_AddModal.DataBind();
            DataTable PhuongXaList = myCus.get_danh_muc_phuong_xa();
            drpPhuongXa.DataSource = PhuongXaList;
            drpPhuongXa.DataBind();
            drpPhuongXa_AddModal.DataSource = PhuongXaList;
            drpPhuongXa_AddModal.DataBind();
            DataTable tram_bien_ap = myBC.get_tram_bien_ap();
            drpTramBienAp.DataSource = tram_bien_ap;
            drpTramBienAp.DataBind();
            drpTramBienAp_AddModal.DataSource = tram_bien_ap;
            drpTramBienAp_AddModal.DataBind();
            bang_gia_dien = myBC.get_bang_gia_dien();
            drpBangGia.DataSource = bang_gia_dien;
            drpBangGia.DataBind();
            drpBangGia_AddModal.DataSource = bang_gia_dien;
            drpBangGia_AddModal.DataBind();
            DataTable tblSms = new DataTable();
            tblSms.Columns.Add(new DataColumn("trang_thai", typeof(int)));
            tblSms.Columns.Add(new DataColumn("ten", typeof(String)));
            // Thêm row trạng thái sms
            tblSms.Rows.Add(1, "Có");
            tblSms.Rows.Add(0, "Không");
            drpSms.DataSource = tblSms;
            drpSms.DataBind();
            drpSms_AddModal.DataSource = tblSms;
            drpSms_AddModal.DataBind();

            // Modal thêm mới (kỳ hợp đồng)
            DataTable tblKyHD = mySP.get_danh_sach_ky_hd();
            drpKy_AddModal.DataSource = tblKyHD;
            drpKy_AddModal.DataBind();

            // Modal đổi công tơ (kỳ hợp đồng)
            DataTable tblKyHDMoiNhat = mySP.get_ky_hd_moi_nhat();
            drp_swapModal_ky.DataSource = tblKyHDMoiNhat;
            drp_swapModal_ky.DataBind();
        }
    }

    protected void gv_bind(string id_tramba)
    {
        CusList = myCus.get_danh_sach_khach_hang_theo_tram_bien_ap(id_tramba);
        GridViewEman.DataSource = CusList;
        GridViewEman.DataBind();
        if (CusList.Rows.Count > 0)
        {
            GridViewEman.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        //DataTable DiaBanList = myCus.get_danh_muc_khu();
        //ddlKhu.DataSource = DiaBanList;
        //ddlKhu.DataBind();

    }

    protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        int index = row.RowIndex;
        Label id = (Label)row.FindControl("lblMaKH");
        Label name = (Label)row.FindControl("lblTenKH");
        Label diachi = (Label)row.FindControl("lblDiaChi");
        Label dt = (Label)row.FindControl("lblDienThoai");
        Label sms = (Label)row.FindControl("lblNumSms");
        Label thutu = (Label)row.FindControl("lblThuTu");
        Label matt = (Label)row.FindControl("lblMaTT");
        Label iddb = (Label)row.FindControl("lblKhu");

        Label idsoho = (Label)row.FindControl("lblsoHo");
        Label idHeSoti = (Label)row.FindControl("lbldHeSoti");
        Label idCotDienSo = (Label)row.FindControl("lblCotDienSo");
        Label idSLDongHo = (Label)row.FindControl("lblSLDongHo");
        Label idMaCongTo = (Label)row.FindControl("lblMaCongTo");
        Label idtba = (Label)row.FindControl("lblIdBA");
        Label idbg = (Label)row.FindControl("lblIdBangGia");
        Label idMtsKHg = (Label)row.FindControl("lblMtsKH");

        Label idPhuongXa = (Label)row.FindControl("lblIdPhuongXa");
        Label idHuyen = (Label)row.FindControl("lblMIdHuyen");
        Label trang_thai = (Label)row.FindControl("lblTrangThai");

        if (e.CommandName == "suaKH")
        {
            drpSms.SelectedValue = sms.Text;

            txtMaKH.Text = id.Text;
            txtTenKh.Text = name.Text;
            txtDiaChi.Text = diachi.Text;
            txtSoDT.Text = dt.Text;
            txtSoHo.Text = idsoho.Text;
            txtHSTi.Text = idHeSoti.Text;
            txtSoCot.Text = idCotDienSo.Text;
            txtSoDongHo.Text = idSLDongHo.Text;
            txtMaCongTo.Text = idMaCongTo.Text;
            txtThuTu.Text = thutu.Text;
            txtMaTT.Text = matt.Text;
            txtMstKH.Text = idMtsKHg.Text;
            //txtNamBH.Text = nambh.Text;
            cbKhu.SelectedValue = iddb.Text;
            drpPhuongXa.SelectedValue = idPhuongXa.Text;
            drpHuyen.SelectedValue = idHuyen.Text;
            drpTramBienAp.SelectedValue = idtba.Text;
            drpBangGia.SelectedValue = idbg.Text;
            if (trang_thai.Text == "1")
            {
                ckbTrangThai.Checked = true;
            }
            //cbVung.DataSource = DiaBanList;            
            //cbVung.SelectedValue = iddb.Text;
            //cbVung.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#EditModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyModal", sb.ToString(), false);
        }
        else if (e.CommandName == "doiCTo")
        {
            txt_swapModal_maKH.Text = id.Text;
            txt_swapModal_tenKH.Text = id.Text + " - " + name.Text;
            string cac_cong_to_hien_tai = idMaCongTo.Text;
            string[] arrMaCTo = cac_cong_to_hien_tai.Split('|');
            drp_swapModal_cTo.DataSource = arrMaCTo;
            drp_swapModal_cTo.DataBind();

            DataTable tblcsCu = myCus.get_chi_so_cto_theo_ma_cong_to_va_ky(drp_swapModal_cTo.SelectedValue, drp_swapModal_ky.SelectedValue);
            try
            {
                txt_swapModal_csCu.Text = tblcsCu.Rows[0]["cs_cu"].ToString();
                txt_swapModal_csCuoiCu.Text = tblcsCu.Rows[0]["cs_moi"].ToString();

                if (txt_swapModal_csCu.Text == "")
                {
                    txt_swapModal_csCu.Text = "0";
                }
                if (txt_swapModal_csCuoiCu.Text == "")
                {
                    txt_swapModal_csCuoiCu.Text = txt_swapModal_csCu.Text;
                }
            }
            catch
            {
                txt_swapModal_csCu.Text = "0";
                txt_swapModal_csCuoiCu.Text = "0";
            }

            txt_swapModal_csDauMoi.Text = "0";
            txt_swapModal_csCuoiMoi.Text = "0";
            txt_swapModal_maCtoMoi.Text = "";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#SwapModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyModal", sb.ToString(), false);
        }

    }

    protected void btnLaySL_Click(object sender, EventArgs e)
    {
        string id_tram = drpTramBienAp_1.SelectedValue.ToString();
        gv_bind(id_tram);
    }

    protected void btnThemMoi_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        //string ma_tu_sinh = myCus.get_ma_kh_tu_sinh();
        // txtThuTu.Text = ma_tu_sinh;
        // string ma_kh = ma_tu_sinh + "." + myCus.get_ten_viet_tat_TBA(drpTramBienAp_AddModal.SelectedValue.ToString());
        string ma_kh = txtMaKh_AddModal.Text.ToString().Trim();
        string ten_kh = txtTenKh_AddModal.Text.ToString().Trim();
        int id_bang_gia = int.Parse(drpBangGia_AddModal.SelectedValue.ToString());
        string dia_chi = txtDiaChi_AddModal.Text.ToString().Trim();
        int id_khu = int.Parse(drpKhu_AddModal.SelectedValue.ToString());
        string id_tram_bien_ap = drpTramBienAp_AddModal.SelectedValue.ToString();
        int so_ho = int.Parse(txtSoHo_AddModal.Text.Trim());
        float he_so_ti = float.Parse(txtHSTi_AddModal.Text.Trim());
        string dien_thoai = txtSoDT_AddModal.Text.ToString().Trim();
        int sms = Convert.ToInt32(drpSms_AddModal.SelectedValue);
        string mst_kh = txtMstKH_AddModal.Text.Trim();
        string cot_dien_so = txtSoCot_AddModal.Text.Trim();
        int sl_dong_ho = int.Parse(txtSoDongHo_AddModal.Text.Trim());
        int trang_thai = ckbTrangThai_AddModal.Checked ? 1 : 0;
        int thu_tu = int.Parse(txtThuTu_AddModal.Text.Trim());
        int id_phuong_xa = int.Parse(drpPhuongXa_AddModal.SelectedValue.ToString());
        int id_huyen = int.Parse(drpHuyen_AddModal.SelectedValue.ToString());
        string ky_hd = drpKy_AddModal.SelectedValue;

        string ma_cong_to = txtMaCongTo_AddModal.Text.Trim();
        string[] list_ma_cong_to = ma_cong_to.Split('|');
        string[] list_ma_cong_to_check = ma_cong_to.Split('|');
        for (int i = 0; i < list_ma_cong_to.Length; i++)
        {
            list_ma_cong_to_check[i] = string.Format("'{0}'", list_ma_cong_to_check[i]);
        }
        int check_ma = myCus.check_list_ma_cong_to(string.Join(", ", list_ma_cong_to_check));
        int check_ma_kh = myCus.check_ma_khach_hang(ma_kh);
        if (check_ma >= 1)
        {
            e.Result = "2"; //Mã công tơ đã tồn tại
        }
        else if (check_ma_kh >= 1)
        {
            e.Result = "3"; //Mã khách hàng đã tồn tại
        }
        else
        {
            if (ten_kh != "" && dia_chi != "" && dien_thoai != "" && ma_cong_to != "" && cot_dien_so != "" && ma_kh != "" && thu_tu != 0 && sl_dong_ho != 0)
            {
                try
                {
                    string id_doanh_nghiep = myCon.get_iddoanhnghiep(Context.User.Identity.Name.ToString());
                    int id_dn = Convert.ToInt32(id_doanh_nghiep);
                    //thêm khách hàng phải thêm cả 2 bảng dm_cong_to và chi_so_cong_to
                    int i = myCus.them_moi_khach_hang(ma_kh, ten_kh, id_bang_gia, dia_chi, id_khu, id_tram_bien_ap, so_ho, he_so_ti, dien_thoai, mst_kh, cot_dien_so, sl_dong_ho, ma_cong_to, trang_thai, thu_tu, id_phuong_xa, id_huyen, sms, id_dn);
                    if (i == 0)
                    {
                        e.Result = "0";
                    }
                    else
                    {
                        e.Result = "1";
                    }
                    foreach (string unique_ma_cto in list_ma_cong_to)
                    {
                        if (unique_ma_cto.Trim() != "" & i != 0)
                        {
                            int j = myCus.them_moi_cong_to(unique_ma_cto, ma_kh, he_so_ti, id_dn, trang_thai);
                            int k = myCus.them_moi_chi_so_cong_to(unique_ma_cto, 0, 0, ky_hd, id_dn);
                        }
                    }
                }
                catch (Exception) { }
            }
            else
            {
                e.Result = "0";
            }
        }
    }

    protected void btnCapNhat_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        string ma_kh = txtMaKH.Text;
        DataTable selected_kh = myCus.get_khach_hang_theo_makh(ma_kh);
        string ten_kh = txtTenKh.Text;
        int id_bang_gia = int.Parse(drpBangGia.SelectedValue.ToString());
        string dia_chi = txtDiaChi.Text;
        int id_khu = int.Parse(cbKhu.SelectedValue.ToString());
        string id_tram_bien_ap = drpTramBienAp.SelectedValue.ToString();
        int so_ho = int.Parse(txtSoHo.Text);
        float he_so_ti = float.Parse(txtHSTi.Text);
        string dien_thoai = txtSoDT.Text;
        int sms = int.Parse(drpSms.SelectedValue);
        string mst_kh = txtMstKH.Text.ToString();
        string cot_dien_so = txtSoCot.Text;
        int sl_dong_ho = int.Parse(txtSoDongHo.Text);
        string ma_cong_to = txtMaCongTo.Text.Trim();
        int trang_thai = 0;
        if (ckbTrangThai.Checked)
            trang_thai = 1;
        int thu_tu = int.Parse(txtThuTu.Text);
        string ma_tt = txtMaTT.Text.Trim();
        int id_phuong_xa = int.Parse(drpPhuongXa.SelectedValue.ToString());
        int id_huyen = int.Parse(drpHuyen.SelectedValue.ToString());
        try
        {
            string log = "Sửa khách hàng mã " + ma_kh;
            myCus.cap_nhat_khach_hang(ma_kh, ten_kh, id_bang_gia, dia_chi, id_khu, id_tram_bien_ap, so_ho, he_so_ti, dien_thoai, mst_kh, cot_dien_so, sl_dong_ho, ma_cong_to, trang_thai, thu_tu, id_phuong_xa, id_huyen, sms, ma_tt);
            if (selected_kh.Rows[0]["trang_thai"].ToString() != trang_thai.ToString())
            {
                string[] list_ma_cong_to = ma_cong_to.Split('|');
                foreach (string unique_ma_cto in list_ma_cong_to)
                {
                    myCus.cap_nhat_trang_thai_cong_to(unique_ma_cto, trang_thai);
                }
            }

            myCon.save_log(Context.User.Identity.Name.ToString(), log, "4");
            e.Result = "1";
        }
        catch
        {
            e.Result = "0";
        }
    }

    protected void btnDoiCTo_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {

        string ma_kh = txt_swapModal_maKH.Text;
        string ten_kh = txt_swapModal_tenKH.Text;
        float csDau_CToCu = float.Parse(txt_swapModal_csCu.Text);
        float csCuoi_CToCu = float.Parse(txt_swapModal_csCuoiCu.Text);
        float csDau_CToMoi = float.Parse(txt_swapModal_csDauMoi.Text);
        float csCuoi_CToMoi = float.Parse(txt_swapModal_csCuoiMoi.Text);
        string ma_cto_cu = drp_swapModal_cTo.SelectedValue;
        string ma_cto_moi = txt_swapModal_maCtoMoi.Text;
        // Lấy kỳ hợp đồng hiện tại
        string ky_hd = drp_swapModal_ky.SelectedValue;

        int check_ky_mcto = myCus.check_ma_cong_to_theo_ky(ma_cto_cu, ky_hd);
        int check_ma = myCus.check_ma_cong_to(ma_cto_moi);
        if (check_ma >= 1)
        {
            e.Result = "2"; // Mã công tơ đã tồn tại
        }
        else if (check_ky_mcto == 0)
        {
            e.Result = "3"; // Kỳ hợp đồng
        }
        else
        {
            DataTable tblKH = myCus.get_khach_hang_theo_makh(ma_kh);
            // Thêm mã công tơ mới trong bảng dm_cong_to và chi_so_cong_to
            string id_doanh_nghiep = myCon.get_iddoanhnghiep(Context.User.Identity.Name.ToString());
            int id_dn = Convert.ToInt32(id_doanh_nghiep);
            DataTable tblCToCu = myCus.get_cong_to_theo_maCTo(ma_cto_cu.Trim());
            int trang_thai = tblCToCu.Rows[0].Field<int>("trang_thai");
            //float hSoTiCu = tblCToCu.Rows[0].Field<float>("he_so_ti");
            //System.Windows.Forms.MessageBox.Show(trang_thai.ToString());
            myCus.them_moi_cong_to(ma_cto_moi, ma_kh, 1, id_dn, trang_thai);
            myCus.them_moi_chi_so_cong_to(ma_cto_moi, csDau_CToMoi, csCuoi_CToMoi, ky_hd, id_dn);

            // Cập nhật trạng thái công tơ cũ trong bảng chi_so_cong_to và dm_cong_to
            // myCus.cap_nhat_trang_thai_chi_so_cong_to(ma_cto_cu, ky_hd, 0);
            myCus.cap_nhat_trang_thai_cong_to(ma_cto_cu, 0);

            // Cập nhật chỉ số công tơ cũ trong bảng chi_so_cong_to
            //myCus.cap_nhat_chi_so_cong_to(ma_cto_cu, ky_hd, csCuoi_CToCu);

            string maCtoKh = tblKH.Rows[0].Field<string>("ma_cong_to");
            // Cập nhật mã công tơ mới trong bảng khach_hang
            string maCtoMoiKh = maCtoKh.Replace(ma_cto_cu, ma_cto_moi);
            myCus.cap_nhat_cong_to_khach_hang(ma_kh, maCtoMoiKh);
            e.Result = "1";
            string log = "Đổi công tơ của khách hàng có mã " + ten_kh + " mã công tơ cũ: " + ma_cto_cu + ", mã công tơ mới: " + ma_cto_moi;
            myCon.save_log(Context.User.Identity.Name.ToString(), log, "4");
            try
            {
            }
            catch (Exception)
            {
                e.Result = "0";
            }
        }
    }

    protected void btnXoaCTo_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        string ma_kh = txt_swapModal_maKH.Text;
        string ten_kh = txt_swapModal_tenKH.Text;
        string ma_cto_cu = drp_swapModal_cTo.SelectedValue;

        DataTable tblKH = myCus.get_khach_hang_theo_makh(ma_kh);
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(Context.User.Identity.Name.ToString());
        int id_dn = Convert.ToInt32(id_doanh_nghiep);


        try
        {
            // Cập nhật trạng thái công tơ và xóa
            myCus.cap_nhat_trang_thai_cong_to(ma_cto_cu, 0);
            string[] arrMaCTo = tblKH.Rows[0].Field<string>("ma_cong_to").Split('|');
            List<string> listMaCTo = new List<string>(arrMaCTo);
            listMaCTo.Remove(ma_cto_cu);
            string maCtoMoiKh = String.Join("|", listMaCTo.ToArray());
            myCus.cap_nhat_cong_to_khach_hang(ma_kh, maCtoMoiKh);
            e.Result = "1";
            string log = "Xóa công tơ của khách hàng " + ten_kh + " mã công tơ: " + ma_cto_cu;
            myCon.save_log(Context.User.Identity.Name.ToString(), log, "4");
        }
        catch (Exception)
        {
            e.Result = "0";
        }
    }

    protected void btnThemCTo_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        string ma_kh = txt_swapModal_maKH.Text;
        string ten_kh = txt_swapModal_tenKH.Text;
        float csDau_CToMoi = float.Parse(txt_swapModal_csDauMoi.Text);
        float csCuoi_CToMoi = float.Parse(txt_swapModal_csCuoiMoi.Text);
        string ma_cto_moi = txt_swapModal_maCtoMoi.Text;
        string ky_hd = drp_swapModal_ky.SelectedValue;

        int check_ma = myCus.check_ma_cong_to(ma_cto_moi);
        if (check_ma >= 1)
        {
            e.Result = "2"; // Mã công tơ đã tồn tại
        }
        else
        {
            DataTable tblKH = myCus.get_khach_hang_theo_makh(ma_kh);
            // Thêm mã công tơ mới trong bảng dm_cong_to và chi_so_cong_to
            string id_doanh_nghiep = myCon.get_iddoanhnghiep(Context.User.Identity.Name.ToString());
            int id_dn = Convert.ToInt32(id_doanh_nghiep);
            myCus.them_moi_cong_to(ma_cto_moi, ma_kh, 1, id_dn, 1);
            myCus.them_moi_chi_so_cong_to(ma_cto_moi, csDau_CToMoi, csCuoi_CToMoi, ky_hd, id_dn); // Cập nhật trạng thái công tơ và xóa
            string[] arrMaCTo = tblKH.Rows[0].Field<string>("ma_cong_to").Split('|');
            List<string> listMaCTo = new List<string>(arrMaCTo);
            listMaCTo.Add(ma_cto_moi);
            string maCtoMoiKh = String.Join("|", listMaCTo.ToArray());
            myCus.cap_nhat_cong_to_khach_hang(ma_kh, maCtoMoiKh);
            e.Result = "1";
            string log = "Thêm công tơ của khách hàng " + ten_kh + " mã công tơ: " + csCuoi_CToMoi;
            myCon.save_log(Context.User.Identity.Name.ToString(), log, "4");
            try
            {
               
            }
            catch (Exception)
            {
                e.Result = "0";
            }
        }
    }

    protected string convertTenBangGia(object idBangGia)
    {
        string result = "";
        bang_gia_dien = myBC.get_bang_gia_dien();
        try
        {
            string expression = "id_bang_gia = " + idBangGia;
            DataRow[] foundRows = bang_gia_dien.Select(expression);
            result = foundRows[0][1].ToString();
        }
        catch { }
        return result;
    }
    protected void Change_Ma_Cong_to(object sender, EventArgs e)
    {
        DataTable tblcsCu = myCus.get_chi_so_cto_theo_ma_cong_to_va_ky(drp_swapModal_cTo.SelectedValue, drp_swapModal_ky.SelectedValue);
        try
        {
            txt_swapModal_csCu.Text = tblcsCu.Rows[0]["cs_cu"].ToString();
            txt_swapModal_csCuoiCu.Text = tblcsCu.Rows[0]["cs_moi"].ToString();

            if (txt_swapModal_csCu.Text == "")
            {
                txt_swapModal_csCu.Text = "0";
            }
            if (txt_swapModal_csCuoiCu.Text == "")
            {
                txt_swapModal_csCuoiCu.Text = txt_swapModal_csCu.Text;
            }
        }
        catch
        {
            txt_swapModal_csCu.Text = "0";
            txt_swapModal_csCuoiCu.Text = "0";
        }

        txt_swapModal_csDauMoi.Text = "0";
        txt_swapModal_csCuoiMoi.Text = "0";
        txt_swapModal_maCtoMoi.Text = "";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('.modal-backdrop').remove();");
        sb.Append("$('#SwapModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyModal", sb.ToString(), false);
    }
}
