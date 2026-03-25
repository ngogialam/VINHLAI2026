using System;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml;
public partial class PhatHanhHD : System.Web.UI.Page
{   

    clsHoaDon myINV = new clsHoaDon();
    clsNguoiBan mySeller = new clsNguoiBan();
    clsNhapChiSo myNCS = new clsNhapChiSo();
    DataTable invList = new DataTable();

    private static string adminName = "eman";
    private static string adminPass = "Einv@oi@vn#pt21";
    private static string userName = "emanws";
    private static string userPass = "Einv@oi@vn#pt20";
    //public string pattern = "01GTKT0/001";

    string sophieu = "";
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
        string id_tram = drpTram.SelectedValue.ToString();
        string kyhd = drpKy.SelectedItem.ToString();
        gv_bind(id_tram, kyhd);
        txtErr.Text = "";

    }
    protected void gv_bind(string id_tramba, string kyhd)
    {
        invList = myINV.get_du_lieu_hd(id_tramba, kyhd, "1");
        GirdViewNoPaGE.DataSource = invList;
        GirdViewNoPaGE.DataBind();

        if (invList.Rows.Count > 0)
        {
            GirdViewNoPaGE.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }    

    protected void btnPhatHanh_Click(object sender, EventArgs e)
    {
        string id_tram = drpTram.SelectedValue.ToString();
        string kyhd = drpKy.SelectedItem.ToString();
        invList = myINV.get_du_lieu_hd(id_tram, kyhd, "1");
        string serial = drpSerial.SelectedValue.ToString();
        string pattern = drpPattern.SelectedValue.ToString();
        string xmlData = myINV.ParseIInvoice(invList);
        int i = 0;
 
        try
        {
            if (xmlData != null)
            {
                PublishInvWS.PublishService service = new PublishInvWS.PublishService();
                ((System.Web.Services.Protocols.SoapHttpClientProtocol)service).Timeout = 600000;
                var result = service.ImportAndPublishInv(adminName, adminPass, xmlData, userName, userPass, pattern, serial, 0);
              //  var result = service.ImportInv(xmlData, userName, userPass,0);
                if (result.StartsWith("OK:"))
                {
                    string[] ketqua = result.ToString().Split('-');
                    string[] FkeyLists = ketqua[1].ToString().Split(',');                    
                    foreach (string FkeyList in FkeyLists)
                    {
                        string[] invDatas = FkeyList.Split('_');
                        string fkey = invDatas[0];
                        string so_hd = invDatas[1];
                        myINV.updateEInvoice(fkey, kyhd, so_hd, pattern, serial,"2");
                    }
                    txtErr.Text = "Phát hành "+FkeyLists.Length+" hóa đơn thành công";
                }
                else
                {
                    txtErr.Text = "Có lỗi xảy ra" + result +"\n"+xmlData ;
                }


            }

            else
            {
                txtErr.Text = "Không có dữ liệu";
            }
        }
        catch (Exception ex)
        {
            txtErr.Text = "Có lỗi " + ex.ToString();
        }

    }
    protected void btnDongBo_Click(object sender, EventArgs e)
    {
        string id_tram = drpTram.SelectedValue.ToString();
        string kyhd = drpKy.SelectedItem.ToString();
        invList = myINV.get_danh_sach_dong_bo(id_tram, kyhd); 
        int i = 0;      
        string fkey;
        int j = 0;
        int fail = 0;
        XmlDocument doc = new XmlDocument();
        try
        {
            for (i = 0; i < invList.Rows.Count; i++)
            {
                fkey = invList.Rows[i]["id"].ToString();               
                PortalInvWS.PortalService service = new PortalInvWS.PortalService();
                var result = service.downloadInvFkeyNoPay(fkey, userName, userPass);
                string err = myINV.CheckConvertFor(result);
                if (result.Contains("ERR:"))
                {
                    // continue;
                    fail++;
                }
                else
                {
                    j = i;
                    doc.LoadXml(result);
                    XmlNodeList elemList = doc.GetElementsByTagName("SHDon");                 
                    string so_hd = elemList[0].InnerXml.ToString();
                    elemList = doc.GetElementsByTagName("KHHDon");
                    string  serial = elemList[0].InnerXml.ToString();
                    elemList = doc.GetElementsByTagName("KHMSHDon");
                    string pattern = elemList[0].InnerXml.ToString();

                   myINV.updateEInvoice(fkey, kyhd, so_hd, pattern, serial, "2");
                   
                    
                }             

            }
            txtErr.Text = "Đồng bộ " + j.ToString() + " hóa đơn thành công";

        }
        catch (Exception ex)
        {
            txtErr.Text = "Có lỗi " + ex.ToString();
        }

    }

}
