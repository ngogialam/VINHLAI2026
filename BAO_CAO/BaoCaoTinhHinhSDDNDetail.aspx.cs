using System;
using System.Data;
using DevExpress.XtraReports.UI;

public partial class BaoCaoTinhHinhSDDNDetail : System.Web.UI.Page
{
    clsBaocao myCus = new clsBaocao();

    protected void Page_Load(object sender, System.EventArgs e)
    {
        reportSo.Report = createReport();

    }
    public XtraReport createReport()
    {
        TinhHinhSDReport rpt = new TinhHinhSDReport(); // đối tượng này là report
        DataTable fixDs = new DataTable();
        DataTable ds = new DataTable();
        try
       {
            fixDs = (DataTable)Session["BaoCaoTongHopTable"];
            ds = fixDs.Copy();          
            rpt.AddBindings("BÁO CÁO TÌNH HÌNH SỬ DỤNG ĐIỆN NĂNG", Session["BaoCaoTongHopThangNam"].ToString(), Session["BaoCaoTongHopNgayIn"].ToString(), "HTX Điện Năng Vĩnh Lại" );
            DataRow newRow = ds.NewRow();
          
            rpt.DataSource = ds;
       }
        catch (Exception e)
        {
           rpt.AddBindings("", "", "", "");
        }

        return rpt;
    }
}
