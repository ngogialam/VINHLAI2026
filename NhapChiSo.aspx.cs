using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class NhapChiSo : System.Web.UI.Page
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
        }

    }

    protected void gv_bind(string id_tramba, string kyhd)
    {
        CusList = myNCS.get_danh_sach_nhap_cs(id_tramba, kyhd);
        GirdViewNoPaGE.DataSource = CusList;
        GirdViewNoPaGE.DataBind();
        for (int i = 0; i < CusList.Rows.Count; i++)
        {
            string status = CusList.Rows[i]["trang_thai"].ToString();
            GridViewRow row = GirdViewNoPaGE.Rows[i];
            if (status == "0")
            {
                GirdViewNoPaGE.Rows[i].Cells[9].CssClass = "label label-success";
                TextBox txtCSMoi = (TextBox)row.FindControl("txtCSMoi");
                txtCSMoi.ReadOnly = true;
                TextBox lblCSCu = (TextBox)row.FindControl("lblCSCu");
                lblCSCu.ReadOnly = true;

                ///GirdView.Rows[i]..BackColor = System.Drawing.Color.Red;
            }
            else
            {
                GirdViewNoPaGE.Rows[i].Cells[9].CssClass = "label label-danger";
            }
        }
        if (CusList.Rows.Count > 0)
        {
            GirdViewNoPaGE.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void btnLaySL_Click(object sender, EventArgs e)
    {
        string id_tram = drpTram.SelectedValue.ToString();
        string kyhd = drpKy.SelectedItem.ToString();
        gv_bind(id_tram, kyhd);
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
            TextBox txtCSCu = (TextBox)row.FindControl("lblCSCu");
            string mact = lblmact.Text.ToString();
            string csmoi = txtCSMoi.Text.ToString();
            string cscu = txtCSCu.Text.ToString();
            if (csmoi != "")
            {
                int result = myNCS.cap_nhat_chi_so(mact, cscu, csmoi, ky);

            }

        }
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
                int intthang = Convert.ToInt32(thang);
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
                    CusList = myNCS.get_danh_cs_kymoi("0", kycu);
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

    protected void btnCapNhat_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        String[] arrData = e.Parameter.Split('|');
        string ky = drpKy.SelectedItem.ToString();
        if (arrData[1].Trim() != "")
        {
            int result = myNCS.cap_nhat_chi_so(arrData[0].Trim(), arrData[2].Trim(), arrData[1].Trim(), ky);
        }
    }

    protected int dienNangTieuThu(object csu, object csmoi, object heSo)
    {
        int result = 0;
        try
        {
            result = (Int32.Parse(csmoi.ToString()) - Int32.Parse(csu.ToString())) * Int32.Parse(heSo.ToString());
        }
        catch (Exception) { }
        return result;
    }
}