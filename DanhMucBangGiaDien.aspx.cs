using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DanhMucBangGiaDien : System.Web.UI.Page
{
    clsKhachHang myCus = new clsKhachHang();
    clsConnect myCon = new clsConnect();
    DataTable CusList = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gv_bind();
        }

    }
    protected void gv_bind()
    {
        CusList = myCus.get_danh_muc_bang_gia_dien();
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
        Label id = (Label)row.FindControl("lblId");
        Label tenBangGia = (Label)row.FindControl("lblTenBangGia");
        Label tenVietTat = (Label)row.FindControl("lblTenVT");
        Label donGia = (Label)row.FindControl("lblDonGia");
        Label thueVat = (Label)row.FindControl("lblThueVat");
        Label phanTramThue = (Label)row.FindControl("lblPhanTramThue");
        Label giaBan = (Label)row.FindControl("lblGiaBan");
        Label trangThai = (Label)row.FindControl("lblIDTrangThai");
        Label loaiBangGia = (Label)row.FindControl("lblLoaiBangGia");

        if (e.CommandName == "suaGiaDien")
        {
            txtId.Text = id.Text.Trim();
            txtTenBangGia.Text = tenBangGia.Text.Trim();
            txtTenVietTat.Text = tenVietTat.Text.Trim();
            txtDonGia.Text = donGia.Text.Trim();
            txtTienThue.Text = thueVat.Text.Trim();
            txtPhanTramThue.Text = phanTramThue.Text.Trim();
            txtGiaBan.Text = giaBan.Text.Trim();
            drpLoaiBg_EditModal.SelectedValue = loaiBangGia.Text.Trim();
            if (Convert.ToInt32(trangThai.Text) == 1)
            {
                ckbTrangThai.Checked = true;
            }
            else
                ckbTrangThai.Checked = false;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#EditModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyModal",
            sb.ToString(), false);
        }
        else if (e.CommandName == "xoaGiaDien") { }
    }

    protected void btnSave_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        int id_bang_gia = Convert.ToInt32(txtId.Text);
        string log = "Sửa giá điện mã " + id_bang_gia;
        string ten_bang_gia = txtTenBangGia.Text;
        string ten_viet_tat = txtTenVietTat.Text;
        double don_gia = Convert.ToDouble(txtDonGia.Text);
        double tien_thue_vat = Convert.ToDouble(txtTienThue.Text);
        double phan_tram_thue = Convert.ToDouble(txtPhanTramThue.Text);
        double gia_ban = Convert.ToDouble(txtGiaBan.Text);
        string loaiBG = drpLoaiBg_EditModal.SelectedValue.Trim();
        int kich_hoat = 0;
        if (ckbTrangThai.Checked == true) kich_hoat = 1;
        try
        {
            myCus.cap_nhat_gia_dien(id_bang_gia, ten_bang_gia, ten_viet_tat, don_gia, tien_thue_vat, phan_tram_thue, gia_ban, kich_hoat, loaiBG);
            myCon.save_log(Context.User.Identity.Name.ToString(), log, "4");
            e.Result = "1";
        }
        catch
        {
            e.Result = "0";
        }
    }

    protected void btnThemMoi_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        string tenBangGia = txtTenBangGia_AddModal.Text;
        string tenVietTat = txtTenVietTat_AddModal.Text;
        double donGia = Convert.ToDouble(txtDonGia_AddModal.Text);
        double tienThue = Convert.ToDouble(txtTienThue_AddModal.Text);
        double phanTramThue = Convert.ToDouble(txtPhanTramThue_AddModal.Text);
        double giaBan = Convert.ToDouble(txtGiaBan_AddModal.Text);
        string loaiBG = drpLoaiBg_AddModal.SelectedValue.Trim();
        int kichHoat = 0;
        int i = 0;
        if (ckbTrangThai_AddModal.Checked == true)
            kichHoat = 1;
        i = myCus.them_moi_gia_dien(tenBangGia, tenVietTat, donGia, tienThue, phanTramThue, giaBan, kichHoat, loaiBG);
        if (i == 0)
            e.Result = "0";
        else
            e.Result = "1";
    }
}
