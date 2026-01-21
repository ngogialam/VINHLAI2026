using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DanhMucTramBienAp : System.Web.UI.Page
{
    clsKhachHang myCus = new clsKhachHang();
    clsConnect myCon = new clsConnect();
    DataTable CusList = new DataTable();
    DataTable EmployList = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EmployList = myCus.get_danh_sach_nhan_vien();
            drpNguoiPhuTrach.DataSource = EmployList;
            drpNguoiPhuTrach.DataBind();
            drpNguoiPhuTrach_AddModal.DataSource = EmployList;
            drpNguoiPhuTrach_AddModal.DataBind();
            gv_bind();
        }

    }
    protected void gv_bind()
    {
        CusList = myCus.get_danh_muc_tram_bien_ap();
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
        Label tenTramBienAp = (Label)row.FindControl("lblTenTramBienAp");
        Label diaChi = (Label)row.FindControl("lblDiaChi");
        Label nguoiPT = (Label)row.FindControl("lblNguoiPhuTrach");
        Label maCongTo = (Label)row.FindControl("lblMaCongTo");
        Label heSoNhan = (Label)row.FindControl("lblHeSoNhan");
        Label trangThai = (Label)row.FindControl("lblIDTrangThai");

        if (e.CommandName == "suaTramBienAp")
        {
            //DataTable DiaBanList = myCus.get_dia_ban();
            txtId.Text = id.Text;
            txtTenTramBA.Text = tenTramBienAp.Text;
            txtDiaChi.Text = diaChi.Text;
            drpNguoiPhuTrach.SelectedValue = nguoiPT.Text;
            txtMaSoCT.Text = maCongTo.Text;
            txtHeSoNhan.Text = heSoNhan.Text;

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

    }
    protected void btnThemMoi_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        string idTramBA = txtId_AddModal.Text;
        string tenTramBA = txtTenTramBA_AddModal.Text;
        string diaChi = txtDiaChi_AddModal.Text;
        string nguoiPT = drpNguoiPhuTrach_AddModal.SelectedValue;
        string maSoCT = txtMaSoCT_AddModal.Text;
        int heSoNhan = Convert.ToInt32(txtHeSoNhan_AddModal.Text);
        int kichHoat = 0;
        if (ckbTrangThai_AddModal.Checked == true)
            kichHoat = 1;
        int i = myCus.them_moi_tram_bien_ap(idTramBA, tenTramBA, diaChi, nguoiPT, maSoCT, heSoNhan, kichHoat);
        if (i == 0)
            e.Result = "0";
        else
            e.Result = "1";
    }

    protected void btnCapNhat_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        string idTramBA = txtId.Text;
        string tenTramBA = txtTenTramBA.Text;
        string diaChi = txtDiaChi.Text;
        string nguoiPT = drpNguoiPhuTrach.SelectedValue;
        string maSoCT = txtMaSoCT.Text;
        int heSoNhan = Convert.ToInt32(txtHeSoNhan.Text);
        string log = "Sửa trạm biến áp" + idTramBA;
        int trangThai = 0;
        if (ckbTrangThai.Checked == true) trangThai = 1;
        try
        {
            myCus.cap_nhat_tram_bien_ap(idTramBA, tenTramBA, diaChi, nguoiPT, maSoCT, heSoNhan, trangThai);
            myCon.save_log(Context.User.Identity.Name.ToString(), log, "4");
            e.Result = "1";
        }
        catch
        {
            e.Result = "0";
        }
    }
   
    protected string Convert_NguoiPhuTrach(object id_nguoiPT)
    {
        string result = "";
        DataRow[] rowResult = EmployList.Select("ma_nv = '" + (string) id_nguoiPT + "'");
        if (rowResult.Length > 0) {
            result = rowResult[0].Field<string>("ten_nv");
        }
        return result;
    }
}