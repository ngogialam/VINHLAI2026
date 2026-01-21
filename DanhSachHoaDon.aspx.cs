using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DanhSachHoaDon : System.Web.UI.Page
{
    private static string adminName = "htxthuyvanadmin";
    private static string adminPass = "123456aA@";
    private static string userName = "thuyvanws";
    private static string userPass = "123456aA@";
    private static string pattern = "01GTKT0/001";
    private static string serial = "TV/19E";

    clsHoaDon myINV = new clsHoaDon();
    clsNguoiBan mySeller = new clsNguoiBan();
    clsNhapChiSo myNCS = new clsNhapChiSo();
    DataTable invList = new DataTable(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        txtErr.Text = "";
        if (!IsPostBack)
        {
            drpTram.DataSource = myNCS.get_danh_sach_tba();
            drpTram.DataBind();

            drpKy.DataSource = myNCS.get_danhsach_ky();
            drpKy.DataBind();            
        }
    }

    protected void btnLaySL_Click(object sender, EventArgs e)
    {

        gv_bind();
        txtErr.Text = "";
    }

    protected void gv_bind()
    {
        string id_tram = drpTram.SelectedValue.ToString();
        string kyhd = drpKy.SelectedItem.ToString();
        string trangthaihd = ddlTrangThaiHD.SelectedValue.ToString();
        invList = myINV.get_danh_sach_hddt(id_tram, kyhd, trangthaihd);
        GridViewEman.DataSource = invList;
        GridViewEman.DataBind();

        if (invList.Rows.Count > 0)
        {
            GridViewEman.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void btnInLoHD_Click(object sender, EventArgs e)
    {
        string id_tram = drpTram.SelectedValue.ToString();
        string kyhd = drpKy.SelectedItem.ToString();
        invList = myINV.get_danh_sach_hddt(id_tram, kyhd, "2");
        int i;
        string fkey;
        string htmlInv = "";
        for (i = 0; i < invList.Rows.Count; i++)
        {
            fkey = invList.Rows[i]["id"].ToString();
            htmlInv = htmlInv + "<p style='page-break-after:always;'></p>" + myINV.PrintInvoice(fkey, userName, userPass);
        }
        if (GridViewEman.Rows.Count > 0)
        {
            GridViewEman.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        Literal txtPNL = new Literal();
        txtPNL.Text = htmlInv;
        pnlContents.Controls.Add(txtPNL);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "PrintPanel()", true);

    }

}
