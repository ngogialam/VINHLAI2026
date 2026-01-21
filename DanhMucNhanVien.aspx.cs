using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DanhMucNhanVien : System.Web.UI.Page
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
        CusList = myCus.get_danh_sach_nhan_vien();
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
        Label maNV = (Label)row.FindControl("lblMaNV");
        Label tenNV = (Label)row.FindControl("lblTenNV");
        Label diaChi = (Label)row.FindControl("lblDiaChi");
        Label dienThoai = (Label)row.FindControl("lblDienThoai");
        Label ghiChu = (Label)row.FindControl("lblGhiChu");

        if (e.CommandName == "suaNhanVien")
        {
            //DataTable DiaBanList = myCus.get_dia_ban();
            txtMaNV.Text = maNV.Text;
            txtTenNV.Text = tenNV.Text;
            txtDiaChi.Text = diaChi.Text;
            txtDienThoai.Text = dienThoai.Text;
            txtGhiChu.Text = ghiChu.Text;

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
        string maNV = txtMaNV_AddModal.Text;
        string tenNv = txtTenNV_AddModal.Text;
        string diaChi = txtDiaChi_AddModal.Text;
        string dienThoai = txtDienThoai_AddModal.Text;
        string ghiChu = txtGhiChu_AddModal.Text;
        int i = myCus.them_moi_nhan_vien(maNV, tenNv, diaChi, dienThoai, ghiChu);
        if (i == 0)
            e.Result = "0";
        else
            e.Result = "1";
    }

    protected void btnCapNhat_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        string maNV = txtMaNV.Text;
        string tenNV = txtTenNV.Text;
        string diaChi = txtDiaChi.Text;
        string dienThoai = txtDienThoai.Text;
        string ghiChu = txtGhiChu.Text;
        string log = "Sửa nhân viên mã" + maNV;
        try
        {
            myCus.cap_nhat_nhan_vien(maNV, tenNV, diaChi, dienThoai, ghiChu);
            e.Result = "1";
        }
        catch
        {
            e.Result = "0";
        }
    }
}