using System;
using System.Data;
using DevExpress.XtraReports.UI;

public partial class BaoCaoTongHopDetail : System.Web.UI.Page
{
    clsBaocao myCus = new clsBaocao();

    protected void Page_Load(object sender, System.EventArgs e)
    {
        reportSo.Report = createReport();

    }
    public XtraReport createReport()
    {
        TongHopReport rpt = new TongHopReport(); // đối tượng này là report
        DataTable fixDs = new DataTable();
        DataTable ds = new DataTable();
        try
        {
            fixDs = (DataTable)Session["BaoCaoTongHopTable"];
            ds = fixDs.Copy();
            rpt.AddBindings(Session["BaoCaoTongHopTenXomKhu"].ToString(), Session["BaoCaoTongHopLoaiBaoCao"].ToString(), Session["BaoCaoTongHopThangNam"].ToString(), Session["BaoCaoTongHopNgayIn"].ToString(), Session["TenDoanhNghiep"].ToString());
            DataRow newRow = ds.NewRow();
            newRow.ItemArray = ds.Rows[0].ItemArray; // copy data
            ds.Rows.Remove(ds.Rows[0]);
            ds.Rows.InsertAt(newRow, ds.Rows.Count);
            rpt.DataSource = ds;
        }
        catch (Exception e)
        {
            rpt.AddBindings("", "", "", "", "");
        }

        return rpt;
    }
}
