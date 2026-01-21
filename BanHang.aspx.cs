using System;
using System.Web.UI;
using System.Data;
using System.Web.Services;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

public partial class BanHang : System.Web.UI.Page
{
    clsSert mySert = new clsSert();
    clsKhachHang myCus = new clsKhachHang();
    clsBanHang myPOS = new clsBanHang();
    clsConnect cnt = new clsConnect();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable DiaBanList = myCus.get_dia_ban();
            cbVung.DataSource = DiaBanList;
            cbVung.DataBind();
        }
        txtNguoiBan.Text = cnt.get_tenND(Context.User.Identity.Name.ToString());
    }
    [WebMethod]
    public static string[] GetCustomers(string prefix)
    {
        clsSert mySert = new clsSert();
        prefix = mySert.noneInject(prefix);
        clsKhachHang myCus = new clsKhachHang();
        List<string> cusArr = new List<string>();
        cusArr = myCus.get_danh_sach_khac_hang_searchtext(prefix);
        return cusArr.ToArray();
    }
    [WebMethod]
    public static string[] GetSoHD(string prefix)
    {
        clsSert mySert = new clsSert();
        prefix = mySert.noneInject(prefix);
        clsBanHang myPOS = new clsBanHang();
        List<string> cusArr = new List<string>();
        cusArr = myPOS.get_sohd(prefix);
        return cusArr.ToArray();
    }
    [WebMethod]
    public static string[] GetSL(string prefix)
    {
        clsBanHang myPOS = new clsBanHang();
        List<string> cusArr = new List<string>();
        clsSert mySert = new clsSert();
        prefix = mySert.noneInject(prefix);
        cusArr = myPOS.laysolieuTHca(prefix);
        return cusArr.ToArray();
    }
    protected void addRowSP(string stt, string sanpham, string dvt, string soluong)
    {
        HtmlTableRow row = new HtmlTableRow();
        HtmlTableCell tt = new HtmlTableCell();
        HtmlTableCell sp = new HtmlTableCell();
        HtmlTableCell dv = new HtmlTableCell();
        HtmlTableCell sl = new HtmlTableCell();
        HtmlTableCell bangchu = new HtmlTableCell();

        bangchu.Attributes.Add("class", "text-left");
        sp.Attributes.Add("class", "text-left");
        sl.Attributes.Add("class", "text-right");

        tt.InnerText = stt;
        sp.InnerText = sanpham;
        dv.InnerText = dvt;
        sl.InnerText = soluong;
        bangchu.InnerText = myPOS.NumberToTextVN(Convert.ToDecimal(soluong));

        row.Cells.Add(tt);
        row.Cells.Add(sp);
        row.Cells.Add(dv);
        row.Cells.Add(sl);
        row.Cells.Add(bangchu);
        row.Height = "20px";

        DSSanPham.Rows.Add(row);

    }
    protected void btnLuuIn_Click(object sender, EventArgs e)
    {
        clsBanHang myPOS = new clsBanHang();
        string khID = Request.Form[hfKHId.UniqueID];
        string tenKH = Request.Form[hfTenKH.UniqueID];
        string DT = Request.Form[hfDT.UniqueID];
        string diachi = Request.Form[hfDiaChiKH.UniqueID];
        string diaban = Request.Form[hfPhuong.UniqueID];
        string soHD = Request.Form[hfsoHD.UniqueID];
        string nguoiban = Context.User.Identity.Name.ToString();
        string ngayban = Request.Form[hfNgayBan.UniqueID];
        string bh20 = Request.Form[hfBH20.UniqueID];
        string bh30 = Request.Form[hfBH30.UniqueID];
        string bh50 = Request.Form[hfBH50.UniqueID];
        string bk1 = Request.Form[hfBK1.UniqueID];
        string bk2 = Request.Form[hfBK2.UniqueID];
        string bc = Request.Form[hfBC.UniqueID];
        string bl = Request.Form[hfBL.UniqueID];
        string tongBH = Request.Form[hfTongBH.UniqueID];
        //int tongBK = Convert.ToInt32(bk1) + Convert.ToInt32(bk2);
        int i = 0;

        //Insert In hóa đơn
        lblngaythang.Text = "Ngày " + ngayban.Substring(0, 2) + " tháng " + ngayban.Substring(3, 2) + " năm " + ngayban.Substring(6, 4);
        lblSoHD.Text = soHD;
        lblTenKH.Text = tenKH;
        lblDT.Text = DT;
        lblDiaChi.Text = diachi;
        lblDiaBan.Text = diaban;

        if (tongBH != "" && tongBH != "0")
        {
            i++;
            addRowSP(i.ToString(), "Bia hơi", "Lít", tongBH);
        }

        // Insert DB
        myPOS.them_moi_don_hang(khID, tongBH, bk1, bk2, bc, ngayban, nguoiban);
        if (bh20 != "" && bh20 != "0")
        {
            myPOS.them_moi_don_hang_chitiet(soHD, khID, "1", bh20, ngayban);
        }
        if (bh30 != "" && bh30 != "0")
        {
            myPOS.them_moi_don_hang_chitiet(soHD, khID, "2", bh30, ngayban);
        }
        if (bh50 != "" && bh50 != "0")
        {
            myPOS.them_moi_don_hang_chitiet(soHD, khID, "3", bh50, ngayban);
        }
        if (bk1 != "" && bk1 != "0")
        {
            myPOS.them_moi_don_hang_chitiet(soHD, khID, "4", bk1, ngayban);
            i++;
            addRowSP(i.ToString(), "Bia keg 1L", "Keg", bk1);
        }
        if (bk2 != "" && bk2 != "0")
        {
            myPOS.them_moi_don_hang_chitiet(soHD, khID, "5", bk2, ngayban);
            i++;
            addRowSP(i.ToString(), "Bia keg 2L", "Keg", bk2);
        }
        if (bc != "" && bc != "0")
        {
            myPOS.them_moi_don_hang_chitiet(soHD, khID, "6", bc, ngayban);
            i++;
            addRowSP(i.ToString(), "Bia chai 1L", "Chai", bc);
        }
        if (bl != "" && bl != "0")
        {
            myPOS.them_moi_don_hang_chitiet(soHD, khID, "7", bl, ngayban);
        }
        ClientScript.RegisterStartupScript(this.GetType(), "Print", "PrintPanel();", true);

    }
    protected void ThemMoiKhachHang(object sender, EventArgs e)
    {

        string tenkh = txtTenKh.Text.ToString();
        string dia_chi = txtDiaChi.Text.ToString();
        string so_dt = txtSoDT.Text.ToString();
        int nam_bh = int.Parse(txtNamBH.Text.ToString());
        int id_dia_ban = int.Parse(cbVung.SelectedValue.ToString());
      //  int id_dia_ban = int.Parse(txtVung.Text.ToString());
        string phuong = cbVung.SelectedItem.ToString();

        if (tenkh != "" && dia_chi != "")
        {
            int i = 0;// myCus.them_moi_khach_hang(tenkh, dia_chi, so_dt, nam_bh, id_dia_ban);
            if (i == 0)
            {
                txtErr.Text = "Thêm mới thất bại!";
            }
            else
            {
                txtErr.Text = "Thêm mới khách hàng thành công!";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#addCusModal').modal('hide');$(document.body).removeClass('modal-open');$('.modal-backdrop').remove();");
                sb.Append("$('[id*=txtKhachHang]').val('");
                sb.Append(tenkh);
                sb.Append("');");
                sb.Append("$('[id*=hfKHId]').val('");
                sb.Append(myCus.get_ma_kh_addmodal());
                sb.Append("');");
                sb.Append("$('[id*=hfTenKH]').val('");
                sb.Append(tenkh);
                sb.Append("');");
                sb.Append("$('[id*=hfDT]').val('");
                sb.Append(so_dt);
                sb.Append("');");
                sb.Append("$('[id*=hfDiaChiKH]').val('");
                sb.Append(dia_chi);
                sb.Append("');");
                sb.Append("$('[id*=hfPhuong]').val('");
                sb.Append(phuong);
                sb.Append("');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyModal", sb.ToString(), false);
                //Response.Redirect("BanHang.aspx");
                txtTenKh.Text = "";
                txtDiaChi.Text = "";
                txtSoDT.Text = "";
              
            }

        }
        else
        {
            txtErr.Text = "Chưa nhập đủ dữ liệu!";
        }

    }
   
    //protected void btnChotCa_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("ChotCa.aspx");
    //}
}