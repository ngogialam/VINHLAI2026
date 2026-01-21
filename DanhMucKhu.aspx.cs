using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DanhMucKhu : System.Web.UI.Page
{
    clsKhachHang myCus = new clsKhachHang();
    clsConnect myCon = new clsConnect();
    DataTable CusList = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable DiaBanList = myCus.get_danh_muc_phuong_xa();
            drpPhuongXa_AddModal.DataSource = DiaBanList;
            drpPhuongXa_AddModal.DataBind();
            drpPhuongXa_EditModal.DataSource = DiaBanList;
            drpPhuongXa_EditModal.DataBind();
            gv_bind();
        }

    }
    protected void gv_bind()
    {
        CusList = myCus.get_danh_muc_khu();
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
        Label tenKhu = (Label)row.FindControl("lblTenKhu");
        Label idPhuongXa = (Label)row.FindControl("lblIdPhuongXa");

        if (e.CommandName == "suaDMKhu")
        {
            //DataTable DiaBanList = myCus.get_dia_ban();
            txtId.Text = id.Text;
            txtTenKhu.Text = tenKhu.Text;
            try
            {
                drpPhuongXa_EditModal.SelectedValue = idPhuongXa.Text;
            }
            catch { }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#EditModal').modal('show');");
            sb.Append(@"</script>");


            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyModal",
            sb.ToString(), false);
        }

    }
    
    protected void btnCapNhat_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        int id_khu = Convert.ToInt32(txtId.Text);
        string log = "Sửa khu mã " + id_khu;
        string ten_khu = txtTenKhu.Text;
        int id_phuong_xa = Convert.ToInt32(drpPhuongXa_EditModal.SelectedValue);
        try
        {
            myCus.cap_nhat_khu(id_khu, ten_khu, id_phuong_xa);
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
        string tenKhu = txtTenKhu_AddModal.Text;
        string IDPhuongXa = drpPhuongXa_AddModal.SelectedValue;
        int i = myCus.them_moi_khu(tenKhu, Convert.ToInt32(IDPhuongXa));
        if (i == 0)
            e.Result = "0";
        else
            e.Result = "1";
    }

}
