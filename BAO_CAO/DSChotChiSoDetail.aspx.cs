using System;
using System.Data;
using DevExpress.XtraReports.UI;

public partial class DSChotChiSoDetail : System.Web.UI.Page
{
    clsBaocao myCus = new clsBaocao();

    protected void Page_Load(object sender, System.EventArgs e)
    {
        reportSo.Report = createReport();

    }
    public XtraReport createReport()
    {
        try
        {
            if (Session["DSChotChiSoInSoTrang"].ToString() == "true")
            {
                if (Session["DSChotChiSoKhoangThoiGian"].ToString() == "03")
                {
                    ChotChiSoCto03Report rpt = new ChotChiSoCto03Report(); // đối tượng này là report
                    DataTable fixDs = new DataTable();
                    DataTable ds = new DataTable();
                    try
                    {
                        fixDs = (DataTable)Session["DSChotChiSoCtoTable"];
                        rpt.AddBindings(Session["DSChotChiSoCtoTenXomKhu"].ToString(), Session["DSChotChiSoCtoTenTramBA"].ToString(), Session["DSChotChiSoCtoQuyNam"].ToString(), Session["DSChotChiSoCtoNgayIn"].ToString(), Session["TenDoanhNghiep"].ToString());
                        rpt.DataSource = fixDs;
                    }
                    catch (Exception e)
                    {
                        rpt.AddBindings("", "", "", "", "");
                    }
                    return rpt;
                }
                if (Session["DSChotChiSoKhoangThoiGian"].ToString() == "06")
                {
                    ChotChiSoCto06Report rpt = new ChotChiSoCto06Report(); // đối tượng này là report
                    DataTable fixDs = new DataTable();
                    DataTable ds = new DataTable();
                    try
                    {
                        fixDs = (DataTable)Session["DSChotChiSoCtoTable"];
                        rpt.AddBindings(Session["DSChotChiSoCtoTenXomKhu"].ToString(), Session["DSChotChiSoCtoTenTramBA"].ToString(), Session["DSChotChiSoCtoQuyNam"].ToString(), Session["DSChotChiSoCtoNgayIn"].ToString(), Session["TenDoanhNghiep"].ToString());
                        rpt.DataSource = fixDs;
                    }
                    catch (Exception e)
                    {
                        rpt.AddBindings("", "", "", "", "");
                    }
                    return rpt;
                }
                if (Session["DSChotChiSoKhoangThoiGian"].ToString() == "12")
                {
                    ChotChiSoCto12Report rpt = new ChotChiSoCto12Report(); // đối tượng này là report
                    DataTable fixDs = new DataTable();
                    DataTable ds = new DataTable();
                    try
                    {
                        fixDs = (DataTable)Session["DSChotChiSoCtoTable"];
                        rpt.AddBindings(Session["DSChotChiSoCtoTenXomKhu"].ToString(), Session["DSChotChiSoCtoTenTramBA"].ToString(), Session["DSChotChiSoCtoQuyNam"].ToString(), Session["DSChotChiSoCtoNgayIn"].ToString(), Session["TenDoanhNghiep"].ToString());
                        rpt.DataSource = fixDs;
                    }
                    catch (Exception e)
                    {
                        rpt.AddBindings("", "", "", "", "");
                    }
                    return rpt;
                }
            }
            else
            {
                ChotChiSoCtoReport rpt = new ChotChiSoCtoReport(); // đối tượng này là report
                DataTable fixDs = new DataTable();
                DataTable ds = new DataTable();
                try
                {
                    fixDs = (DataTable)Session["DSChotChiSoCtoTable"];
                    rpt.AddBindings(Session["DSChotChiSoCtoTenXomKhu"].ToString(), Session["DSChotChiSoCtoTenTramBA"].ToString(), Session["DSChotChiSoCtoQuyNam"].ToString(), Session["DSChotChiSoCtoNgayIn"].ToString(), Session["TenDoanhNghiep"].ToString());
                    rpt.DataSource = fixDs;
                }
                catch (Exception e)
                {
                    rpt.AddBindings("", "", "", "", "");
                }
                return rpt;
            }
        }
        catch
        {
            ChotChiSoCtoReport rpt = new ChotChiSoCtoReport(); // đối tượng này là report
            DataTable fixDs = new DataTable();
            DataTable ds = new DataTable();
            try
            {
                fixDs = (DataTable)Session["DSChotChiSoCtoTable"];
                rpt.AddBindings(Session["DSChotChiSoCtoTenXomKhu"].ToString(), Session["DSChotChiSoCtoTenTramBA"].ToString(), Session["DSChotChiSoCtoQuyNam"].ToString(), Session["DSChotChiSoCtoNgayIn"].ToString(), Session["TenDoanhNghiep"].ToString());
                rpt.DataSource = fixDs;
            }
            catch (Exception e)
            {
                rpt.AddBindings("", "", "", "", "");
            }
            return rpt;
        }
        return new ChotChiSoCtoReport();
    }
}
