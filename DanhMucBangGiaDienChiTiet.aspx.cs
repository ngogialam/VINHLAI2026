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
            drpBangGiaTyLe_AddModal.DataSource = bang_gia_dien_MDK;
            drpBangGiaTyLe_AddModal.DataBind();
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
        int index = row.RowIndex;
        Label idBangGia = (Label)row.FindControl("lblId");
        Label tenBangGia = (Label)row.FindControl("lblTenBangGia");
        Label tuSo = (Label)row.FindControl("lblTuSo");
        Label denSo = (Label)row.FindControl("lblDenSo");
        Label giaKhongVAT = (Label)row.FindControl("lblGiaKhongVAT");
        Label phanTramThue = (Label)row.FindControl("lblPhanTramThue");
        Label mucThu = (Label)row.FindControl("lblMucThu");
        Label IDBangGiaTyLe = (Label)row.FindControl("lblIDBangGiaTyLe");
        Label tyLe = (Label)row.FindControl("lblTyLe");
        Label moTa = (Label)row.FindControl("lblMoTa");

        if (e.CommandName == "suaGiaDien")
        {
            txtID.Text = idBangGia.Text.Trim();
            txtTenBangGia.Text = tenBangGia.Text.Trim();
            txtTuSo.Text = tuSo.Text.Trim();
            txtDenSo.Text = denSo.Text.Trim();
            txtGiaKhongVAT.Text = giaKhongVAT.Text.Trim();
            txtMucThu.Text = mucThu.Text.Trim();
            txtPhanTramThue.Text = phanTramThue.Text.Trim();
            txtTyLe.Text = tyLe.Text.Trim();
            txtMoTa.Text = moTa.Text.Trim();
            try
            {
                drpBangGiaTyLe.SelectedValue = IDBangGiaTyLe.Text.Trim();
            }
            catch
            {
                drpBangGiaTyLe.SelectedValue = "0";
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#EditModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyModal",
            sb.ToString(), false);
        }
        else if (e.CommandName == "xoaGiaDien") {
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
        int id = Convert.ToInt32(txtID.Text);
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
