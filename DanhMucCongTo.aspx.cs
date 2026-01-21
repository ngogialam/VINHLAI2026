using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DanhMucCongTo : System.Web.UI.Page
{
    clsKhachHang myCus = new clsKhachHang();
    clsConnect myCon = new clsConnect();
    DataTable CusList = new DataTable();
    clsNhapChiSo myNCS = new clsNhapChiSo();
    public int id_tramba = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpTramBienAp_1.DataSource = myNCS.get_danh_sach_tba();
            drpTramBienAp_1.DataBind();
            try
            {
                if (id_tramba == -1)
                {
                    id_tramba = Int32.Parse(drpTramBienAp_1.SelectedValue.ToString());
                }
            }
            catch (Exception) { }
            gv_bind(id_tramba);

        }

    }
    protected void gv_bind(int id_tramba)
    {
        CusList = myCus.get_danh_muc_cong_to_theo_tram_BA(id_tramba);
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
        Label maCto = (Label)row.FindControl("lblMaCTo");
        Label maKh = (Label)row.FindControl("lblMaKh");
        Label chungLoai = (Label)row.FindControl("lblChungLoai");
        Label heSoTi = (Label)row.FindControl("lblHeSoTi");
        Label nhaSanXuat = (Label)row.FindControl("lblNhaSanXuat");
        Label ngaySD = (Label)row.FindControl("lblNgaySuDung");
        Label ngayHetHan = (Label)row.FindControl("lblNgayHetHan");
        Label trangThai = (Label)row.FindControl("lblTrangThai");

        if (e.CommandName == "suaCongto")
        {
            //DataTable DiaBanList = myCus.get_dia_ban();
            txtMaCTo.Text = maCto.Text;
            txtMaKh.Text = maKh.Text;
            txtChungLoai.Text = chungLoai.Text;
            txtHeSoTi.Text = heSoTi.Text;
            txtNhaSanXuat.Text = nhaSanXuat.Text;
            txtNgaySD.Text = ngaySD.Text;
            txtNgayHetHan.Text = ngayHetHan.Text;
            txtTrangThai.Text = trangThai.Text;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#EditModal').modal('show');");
            sb.Append("$('.datetimepicker').datepicker({ language: 'vi', format: 'yyyy-mm-dd', todayHighlight: true });");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyModal",
            sb.ToString(), false);
        }
        else if (e.CommandName == "xoaCongto")
        {
        }

    }

    protected void btnCapNhat_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        string maCto = txtMaCTo.Text;

        string chungLoai = txtChungLoai.Text;
        string nSxuat = txtNhaSanXuat.Text;
        string ngaySD = txtNgaySD.Text;
        string ngayHetHan = txtNgayHetHan.Text;
        string heso = txtHeSoTi.Text;
        myCus.cap_nhat_cong_to(maCto, chungLoai, nSxuat, ngaySD, ngayHetHan, heso);
        try
        {
            myCus.cap_nhat_cong_to(maCto, chungLoai, nSxuat, ngaySD, ngayHetHan, heso);
            string log = "Sửa công tơ " + maCto;
            myCon.save_log(Context.User.Identity.Name.ToString(), log, "4");
            e.Result = "1";
        }
        catch
        {
            e.Result = "0";
        }
    }
    protected void btnLaySL_Click(object sender, EventArgs e)
    {
        id_tramba = Int32.Parse(drpTramBienAp_1.SelectedValue.ToString());
        gv_bind(id_tramba);
    }
}
