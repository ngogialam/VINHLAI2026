using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DanhMucBangGiaDienChiTiet : System.Web.UI.Page
{
    clsKhachHang myCus = new clsKhachHang();
    clsConnect myCon = new clsConnect();
    DataTable CusList = new DataTable();
    clsBaocao myBC = new clsBaocao();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable bang_gia_dien_BT = myBC.get_bang_gia_dien_theo_loai_bang_gia("BT");
            DataTable bang_gia_HH = myBC.get_bang_gia_dien_theo_loai_bang_gia("HH");
            bang_gia_dien_BT.Merge(bang_gia_HH);
            drpBangGia_AddModal.DataSource = bang_gia_dien_BT;
            drpBangGia_AddModal.DataBind();

            DataTable bang_gia_dien_MDK = myBC.get_bang_gia_dien();
            drpBangGiaTyLe.DataSource = bang_gia_dien_MDK;
            drpBangGiaTyLe.DataBind();
            if (drpBangGiaTyLe.Items.FindByValue("0") == null)
            {
                drpBangGiaTyLe.Items.Add(new ListItem("Không sử dụng bảng giá tỷ lệ", "0"));
            }
            drpBangGiaTyLe_AddModal.DataSource = bang_gia_dien_MDK;
            drpBangGiaTyLe_AddModal.DataBind();
            if (drpBangGiaTyLe_AddModal.Items.FindByValue("0") == null)
            {
                drpBangGiaTyLe_AddModal.Items.Add(new ListItem("Không sử dụng bảng giá tỷ lệ", "0"));
            }
            gv_bind();
        }

    }
    protected void gv_bind()
    {
        CusList = myCus.get_danh_muc_bang_gia_dien_chi_tiet();
        GridViewEman.DataSource = CusList;
        GridViewEman.DataBind();
        if (CusList.Rows.Count > 0)
        {
            GridViewEman.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        Label idBangGia = (Label)row.FindControl("lblId");
        if (e.CommandName == "xoaGiaDien")
        {
            try
            {
                myCus.xoa_gia_dien_chi_tiet(Convert.ToInt32(idBangGia.Text.Trim()));
                Response.Redirect("DanhMucBangGiaDienChiTiet.aspx");
            }
            catch
            {

            }
        }
    }

    protected void btnSave_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        int id = Convert.ToInt32(hfIDEdit.Value);
        double tuSo = Convert.ToDouble(txtTuSo.Text);
        double denSo = Convert.ToDouble(txtDenSo.Text);
        double giaKhongVAT = Convert.ToDouble(txtGiaKhongVAT.Text);
        string mucThu = txtMucThu.Text;
        double dongiacu = Convert.ToDouble(txtPhanTramThue.Text);
        int idBangGiaTyLe = Convert.ToInt32(drpBangGiaTyLe.SelectedValue);
        double tyLe = 0;
        try
        {
            tyLe = Convert.ToDouble(txtTyLe.Text);

        }
        catch (Exception) {}
        string moTa = txtMoTa.Text;
        try
        {
            if (idBangGiaTyLe == 0)
            {
                myCus.cap_nhat_gia_dien_chi_tiet(id, tuSo, denSo, giaKhongVAT, mucThu, dongiacu, idBangGiaTyLe, 0, moTa);
            }
            else
            {
                myCus.cap_nhat_gia_dien_chi_tiet(id, 0, 0, 0, mucThu, 0, idBangGiaTyLe, tyLe, moTa);
            }
            e.Result = "1";
        }
        catch
        {
            e.Result = "0";
        }
    }

    protected void btnThemMoi_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        int idBangGia = Convert.ToInt32(drpBangGia_AddModal.SelectedValue);
        double tuSo = Convert.ToDouble(txtTuSo_AddModal.Text);
        double denSo = Convert.ToDouble(txtDenSo_AddModal.Text);
        double giaKhongVAT = Convert.ToDouble(txtGiaKhongVAT_AddModal.Text);
        string mucThu = txtMucThu_AddModal.Text;
        double phanTramThue = Convert.ToDouble(txtPhanTramThue_AddModal.Text);
        int idBangGiaTyLe = Convert.ToInt32(drpBangGiaTyLe_AddModal.SelectedValue);
        double tyLe = Convert.ToDouble(txtTyLe_AddModal.Text);
        string moTa = txtMoTa_AddModal.Text;
        int i = 0;
        if (idBangGiaTyLe == 0)
        {
            i = myCus.them_moi_gia_dien_chi_tiet(idBangGia, tuSo, denSo, giaKhongVAT, mucThu, phanTramThue, idBangGiaTyLe, 0, moTa);
        }
        else
        {
            i = myCus.them_moi_gia_dien_chi_tiet(idBangGia, 0, 0, 0, mucThu, 0, idBangGiaTyLe, tyLe, moTa);
        }
        if (i == 0)
            e.Result = "0";
        else
            e.Result = "1";
    }
}
