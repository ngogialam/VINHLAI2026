using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NReco.PdfGenerator;
using System.IO;
public partial class HuyHoaDon : System.Web.UI.Page
{
    private static string adminName = "eman";
    private static string adminPass = "Einv@oi@vn#pt21";
    private static string userName = "emanws";
    private static string userPass = "Einv@oi@vn#pt20";
    // public string pattern = "01GTKT0/001";
    //  public string serial = "VL/19E";

    HtmlToPdfConverter htmlToPdf = new HtmlToPdfConverter();
    clsHoaDon myINV = new clsHoaDon();
    clsNguoiBan mySeller = new clsNguoiBan();
    clsNhapChiSo myNCS = new clsNhapChiSo();
    clsBaocao myBC = new clsBaocao();
    clsConnect myCon = new clsConnect();
    DataTable invList = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        txtErr.Text = "";
        if (!IsPostBack)
        {

        }
    }

    protected void btnLaySoLieu_Click(object sender, EventArgs e)
    {

        string strSoHD = txtSoHD.Text.ToString();
        string serial = drpSerial.SelectedValue.ToString();
        string pattern = drpPattern.SelectedValue.ToString();
        if (!string.IsNullOrEmpty(strSoHD))

        {
            //  string strDenso = txtDenSo.Text.ToString();
            DataTable invReplace = myINV.get_hddt_theo_so_hd(strSoHD, pattern, serial);
            GirdViewReplace.DataSource = invReplace;
            GirdViewReplace.DataBind();
            if (GirdViewReplace.Rows.Count > 0)
            {
                GirdViewReplace.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }

    protected void GirdViewReplace_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable bang_gia_dien = myBC.get_bang_gia_dien();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList DDBangGia = (e.Row.FindControl("drpBangGia") as DropDownList);
            Label idBG = (e.Row.FindControl("idBangGia") as Label);
            DDBangGia.DataSource = bang_gia_dien;
            DDBangGia.DataBind();
            DDBangGia.SelectedValue = idBG.Text.ToString();

        }

    }
    protected void updateChange()
    {
        // Thông tin cũ
        string fkey_cu = (GirdViewReplace.Rows[0].FindControl("lblID") as Label).Text.ToString();
        string mau_so = (GirdViewReplace.Rows[0].FindControl("lblMauSo") as Label).Text.ToString();
        string ky_hieu = (GirdViewReplace.Rows[0].FindControl("lblKyHieu") as Label).Text.ToString();
        string ky = (GirdViewReplace.Rows[0].FindControl("idBangGia") as Label).Text.ToString();
        string makh = (GirdViewReplace.Rows[0].FindControl("lblMaKH") as Label).Text.ToString();
        string idtram_ba = (GirdViewReplace.Rows[0].FindControl("idTramBA") as Label).Text.ToString();
        string id_khu = (GirdViewReplace.Rows[0].FindControl("idKhu") as Label).Text.ToString();

        //Thông tin mới
        string tenkhnew = (GirdViewReplace.Rows[0].FindControl("lblTenKH") as TextBox).Text.ToString();
        int sohonew = Convert.ToInt16((GirdViewReplace.Rows[0].FindControl("lblSoHo") as TextBox).Text.ToString());
        // Double cs_moinew = ;
        DropDownList DDBangGia = (GirdViewReplace.Rows[0].FindControl("drpBangGia") as DropDownList);
        string id_bg_new = DDBangGia.SelectedValue.ToString();

        Double dntt = 0;

        Double total = 0;
        Double vatamount = 0;
        Double amount = 0; // amount = total + vatamount

        Double vatrate = 10;
        int i = 0;
        Double cs_cu = 0;
        Double cs_moi = 0;
        do
        {
            cs_cu = cs_cu + Convert.ToDouble((GirdViewReplace.Rows[i].FindControl("txtCSCu") as TextBox).Text.ToString());

            cs_moi = cs_moi + Convert.ToDouble((GirdViewReplace.Rows[i].FindControl("txtCSMoi") as TextBox).Text.ToString());
            i++;
        } while (i < GirdViewReplace.Rows.Count && string.Compare((GirdViewReplace.Rows[i].FindControl("lblMaKH") as Label).Text.ToString(), (GirdViewReplace.Rows[i - 1].FindControl("lblMaKH") as Label).Text.ToString()) == 0);

        dntt = cs_moi - cs_cu;
        total = myNCS.tinh_tien_dien(dntt, sohonew, id_bg_new);
        vatamount = vatrate * total / 100;
        //Làm tròn
        vatamount = Math.Round(vatamount, 0, MidpointRounding.AwayFromZero);
        amount = total + vatamount;

        (GirdViewReplace.Rows[0].FindControl("lblAmount") as Label).Text = amount.ToString("###,0");
        (GirdViewReplace.Rows[0].FindControl("lblDienNangTT") as Label).Text = dntt.ToString();

    }

    protected void drpBangGia_SelectedIndexChanged(object sender, EventArgs e)
    {
        updateChange();
    }
    protected void txtCSMoi_TextChanged(object sender, EventArgs e)
    {
        updateChange();
    }
    protected void txtCSCu_TextChanged(object sender, EventArgs e)
    {
        updateChange();
    }
    protected void lblSoHo_TextChanged(object sender, EventArgs e)
    {
        updateChange();
    }

    protected void btnPhatHanhHD_Click(object sender, EventArgs e)
    {
        string fkey_cu = (GirdViewReplace.Rows[0].FindControl("lblID") as Label).Text.ToString();
        string sohd_cu = (GirdViewReplace.Rows[0].FindControl("lblSoHD") as Label).Text.ToString();
        string mau_so = (GirdViewReplace.Rows[0].FindControl("lblMauSo") as Label).Text.ToString();
        string ky_hieu = (GirdViewReplace.Rows[0].FindControl("lblKyHieu") as Label).Text.ToString();
        string ky = (GirdViewReplace.Rows[0].FindControl("lblKy") as Label).Text.ToString();
        string pattern = drpPattern.SelectedValue.ToString();
        string serial = drpSerial.SelectedValue.ToString();
        try
        {
            
                BusinessInvWS.BusinessService service = new BusinessInvWS.BusinessService();

                var result = service.cancelInvNoPay(adminName, adminPass,fkey_cu, userName, userPass);
                //  var result = service.ImportInv(xmlData, userName, userPass,0);
                if (result.StartsWith("OK:"))                {
                    
                    //cập nhật hóa đơn mới
                  //  myINV.updateEInvoice(fkey, ky, so_hd, pattern, serial, "2");
                    //Cập nhật hóa đơn cũ
                    myINV.updateEInvoice(fkey_cu, ky, sohd_cu, pattern, serial, "3");
                    txtErr.Text = "Hủy hóa đơn thành công. ";
                    string log = "Hủy hóa đơn số " + sohd_cu ;
                    myCon.save_log("admin", log, "666");

                }
                else
                {
                    txtErr.Text = "Có lỗi xảy ra" + result;
                }
                       
        }
        catch (Exception ex)
        {
            txtErr.Text = "Có lỗi";
        }

    }
}
