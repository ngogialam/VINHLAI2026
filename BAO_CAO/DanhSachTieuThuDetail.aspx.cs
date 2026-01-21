using System;
using System.Data;
using DevExpress.XtraReports.UI;

public partial class DanhSachTieuThuDetail : System.Web.UI.Page
{
    clsBaocao myCus = new clsBaocao();

    protected void Page_Load(object sender, System.EventArgs e)
    {
        reportSo.Report = createReport();

    }
    public XtraReport createReport()
    {
        TieuThuReport rpt = new TieuThuReport(); // đối tượng này là report
        DataTable fixDs = new DataTable();
        DataTable ds = new DataTable();
        try
        {
            fixDs = (DataTable)Session["DanhSachTieuThuTable"];
            rpt.AddBindings(Session["DanhSachTieuThuTenXomKhu"].ToString(), Session["DanhSachTieuThuTenTramBA"].ToString(), Session["DanhSachTieuThuQuyNam"].ToString(), Session["DanhSachTieuThuNgayIn"].ToString(), Session["TenDoanhNghiep"].ToString());
            rpt.DataSource = fixDs;
        }
        catch (Exception e)
        {
            rpt.AddBindings("", "", "", "", "");
        }

        return rpt;
    }
}
