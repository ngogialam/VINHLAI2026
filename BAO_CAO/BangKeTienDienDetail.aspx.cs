using System;
using System.Data;
using DevExpress.XtraReports.UI;

public partial class BangKeTienDienDetail: System.Web.UI.Page
{
    clsBaocao myCus = new clsBaocao();

    protected void Page_Load(object sender, System.EventArgs e)
    {
        reportSo.Report = createReport();

    }
    public XtraReport createReport()
    {
        KeTienDienReport rpt = new KeTienDienReport(); // đối tượng này là report
        DataTable fixDs = new DataTable();
        DataTable ds = new DataTable();
        try
        {
            fixDs = (DataTable)Session["KeTienDienTable"];
            ds = fixDs.Copy();
            string tentramBA = Session["KeTienDienTenTramBA"].ToString();
            string kyhd = Session["KeTienDienKyTramBA"].ToString();
            string ngaythang = Session["KeTienDienNgayThang"].ToString();
            string ngayin = Session["KeTienDienNgayIn"].ToString();
            string donvi = "HTX Điện năng Vĩnh Lại";

           rpt.AddBindings(tentramBA, kyhd, ngaythang, ngayin, donvi);
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
