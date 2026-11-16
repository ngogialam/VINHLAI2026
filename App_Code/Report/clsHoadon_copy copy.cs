using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web;
/// </summary>
/// tuanbn.pto cls Phat Hanh Hoa Don 

public class clsHoaDon
{
    clsConnect myCon = new clsConnect();
    public string adminName = "htxdnvinhlaiadmin";
    public string adminPass = "123456aA@";
    public string userName = "emanws";
    public string userPass = "123456aA@";
    public string pattern = "01GTKT0/001";
    public string serial = "VL/19E";
    //Danh sách hóa đơn mới lập
    public DataTable get_du_lieu_hd(string id_tramba, string ky, string trangthai)
    {
        SqlConnection myConn = null;
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "";
        if (id_tramba == "0")
         {
        sql = "select d.id,d.ma_tt,d.so_hd,d.mau_so,d.ky_hieu,a.ma_kh, a.ten_kh,b.ten_khu,a.dia_chi,a.dien_thoai,a.mst_kh,c.ten_viet_tat,nv.dien_thoai dt_sua_chua,d.chi_so_cu,d.chi_so_moi,d.dien_nang_tt dien_nang_tt,";
            sql = sql + "d.tong_tien_truoc_thue,d.vat_rate,d.thue_gtgt,d.tong_tien_sau_thue,d.ky_hd,d.ma_cong_to,d.tu_ngay,d.den_ngay,e.ten_tram_bien_ap, a.id_tram_bien_ap,a.id_bang_gia,a.so_ho,a.id_khu, b.id_khu,d.trang_thai,tt.ten_trang_thai";
            sql = sql + " from khach_hang a, dm_khu b,bang_gia_dien c, hoa_don d, tram_bien_ap e,dm_trang_thai_hd tt, nhan_vien nv";
            sql = sql + " where a.id_khu = b.id_khu and a.id_bang_gia=c.id_bang_gia and  a.id_tram_bien_ap=e.id_tram_bien_ap and e.nguoi_phu_trach=nv.ma_nv and  d.trang_thai=tt.trang_thai_id and d.ma_kh=a.ma_kh and d.trang_thai=" + trangthai + " and d.ky_hd='" + ky + "'";
            sql = sql + " and d.id_doanh_nghiep = " + id_doanh_nghiep;
            sql = sql + " order by d.id,d.dien_nang_tt DESC";
        }
        else
        {
			sql = "select d.id,d.ma_tt,d.so_hd,d.mau_so,d.ky_hieu,a.ma_kh, a.ten_kh,b.ten_khu,a.dia_chi,a.dien_thoai,a.mst_kh,c.ten_viet_tat,nv.dien_thoai dt_sua_chua,d.chi_so_cu,d.chi_so_moi,d.dien_nang_tt dien_nang_tt, ";
            sql = sql + "d.tong_tien_truoc_thue,d.vat_rate,d.thue_gtgt, d.tong_tien_sau_thue ,d.ky_hd,d.ma_cong_to,d.tu_ngay,d.den_ngay,e.ten_tram_bien_ap, a.id_tram_bien_ap,a.id_bang_gia,a.so_ho,a.id_khu, b.id_khu,d.trang_thai,tt.ten_trang_thai, ";
            sql = sql + " d.giam_tru_thang_10, d.giam_tru_thang_11, d.giam_tru_thang_12 ";
            sql = sql + " from khach_hang a, dm_khu b,bang_gia_dien c, hoa_don d, tram_bien_ap e,dm_trang_thai_hd tt, nhan_vien nv";
            sql = sql + " where a.id_khu = b.id_khu and a.id_bang_gia=c.id_bang_gia and  a.id_tram_bien_ap=e.id_tram_bien_ap and e.nguoi_phu_trach=nv.ma_nv and  d.trang_thai=tt.trang_thai_id and d.ma_kh=a.ma_kh and d.trang_thai=" + trangthai + " and  a.id_tram_bien_ap='" + id_tramba + "' and d.ky_hd='" + ky + "'";
            sql = sql + " and d.id_doanh_nghiep = " + id_doanh_nghiep;
            sql = sql + " order by d.id,d.dien_nang_tt DESC";
        }
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            return dts.Tables[0];
            // return dts;    
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myConn != null)
            {
                myConn.Close();
            }
        }

    }
    //Danh sách hóa đơn điện tử
    public DataTable get_danh_sach_hddt(string id_tramba, string ky, string trangthai)
    {
        SqlConnection myConn = null;
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "";

        sql = "select d.id,d.ma_tt,d.so_hd,d.mau_so,d.ky_hieu,d.ma_kh, d.ten_kh,b.ten_khu,a.dia_chi,a.dien_thoai,a.mst_kh,c.ten_viet_tat,nv.dien_thoai dt_sua_chua,d.chi_so_cu,d.chi_so_moi,d.dien_nang_tt dien_nang_tt,";
        sql = sql + "d.tong_tien_truoc_thue,d.vat_rate,d.thue_gtgt,d.tong_tien_sau_thue,d.ky_hd,d.ma_cong_to,d.tu_ngay,d.den_ngay,e.ten_tram_bien_ap, a.id_tram_bien_ap,a.id_bang_gia,a.so_ho,a.id_khu, b.id_khu,d.trang_thai,tt.ten_trang_thai";
        sql = sql + " from khach_hang a, dm_khu b,bang_gia_dien c, hoa_don d, tram_bien_ap e,dm_trang_thai_hd tt, nhan_vien nv";
        sql = sql + " where a.id_khu = b.id_khu and a.id_bang_gia=c.id_bang_gia and  a.id_tram_bien_ap=e.id_tram_bien_ap and e.nguoi_phu_trach=nv.ma_nv and  d.trang_thai=tt.trang_thai_id and d.ma_kh=a.ma_kh and d.trang_thai=" + trangthai + " and  d.id_tram_bien_ap='" + id_tramba + "' and d.ky_hd='" + ky + "'";
        sql = sql + " and d.id_doanh_nghiep = " + id_doanh_nghiep;
        sql = sql + " order by d.id,d.dien_nang_tt DESC";

        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            return dts.Tables[0];
            // return dts;    
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myConn != null)
            {
                myConn.Close();
            }
        }

    }
    //Danh sách fkey hóa đơn điện tử chuyển đổi
    public DataTable get_danh_sach_chuyen_doi(string id_tramba, string ky, string trangthai)
    {
        SqlConnection myConn = null;
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "select distinct id from hoa_don";
        sql = sql + " where trang_thai=" + trangthai + " and  id_tram_bien_ap='" + id_tramba + "' and ky_hd='" + ky + "'";
        sql = sql + " and id_doanh_nghiep = " + id_doanh_nghiep;
        // sql = sql + " and d.id_doanh_nghiep = " + id_doanh_nghiep;
        //sql = "select  d.id,d.so_hd,d.mau_so,d.ky_hieu,d.ma_kh, d.ten_kh,b.ten_khu,a.dia_chi,a.dien_thoai,a.mst_kh,c.ten_viet_tat,nv.dien_thoai dt_sua_chua,d.chi_so_cu,d.chi_so_moi,d.dien_nang_tt dien_nang_tt,";
        // sql = sql + "d.tong_tien_truoc_thue,d.vat_rate,d.thue_gtgt,d.tong_tien_sau_thue,d.ky_hd,d.ma_cong_to,d.tu_ngay,d.den_ngay,e.ten_tram_bien_ap, a.id_tram_bien_ap,a.id_bang_gia,a.so_ho,a.id_khu, b.id_khu,d.trang_thai,tt.ten_trang_thai";
        // sql = sql + " from khach_hang a, dm_khu b,bang_gia_dien c, hoa_don d, tram_bien_ap e,dm_trang_thai_hd tt, nhan_vien nv";
        // sql = sql + " where a.id_khu = b.id_khu and a.id_bang_gia=c.id_bang_gia and  a.id_tram_bien_ap=e.id_tram_bien_ap and e.nguoi_phu_trach=nv.ma_nv and  d.trang_thai=tt.trang_thai_id and d.ma_kh=a.ma_kh and d.trang_thai=" + trangthai + " and  d.id_tram_bien_ap='" + id_tramba + "' and d.ky_hd='" + ky + "'";
        // sql = sql + " and d.id_doanh_nghiep = " + id_doanh_nghiep;
        //  sql = sql + " order by d.id,d.dien_nang_tt DESC";

        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            return dts.Tables[0];
            // return dts;    
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myConn != null)
            {
                myConn.Close();
            }
        }

    }
    //Danh sách chuyển đổi theo số hóa đơn
    public DataTable get_danh_sach_chuyen_doi_theo_so(string tuso, string denso, string serial)
    {
        SqlConnection myConn = null;
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "select distinct id from hoa_don";
        sql = sql + " where mau_so='1/001' and ky_hieu='" + serial + "' and so_hd between " + tuso + " and " + denso;



        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            return dts.Tables[0];
            // return dts;    
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myConn != null)
            {
                myConn.Close();
            }
        }

    }
    //Danh sách fkey hóa đơn điện tử đồng bộ
    public DataTable get_danh_sach_dong_bo(string id_tramba, string ky)
    {
        SqlConnection myConn = null;
       // string id_doanh_nghiep = 1
        string sql = "select distinct id from hoa_don";
        sql = sql + " where so_hd is null and  id_tram_bien_ap='" + id_tramba + "' and ky_hd='" + ky + "'";
     

        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            return dts.Tables[0];
            // return dts;    
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myConn != null)
            {
                myConn.Close();
            }
        }

    }
    //Danh sách xử lý hóa đơn điện tử
    public DataTable get_danh_sach_xu_ly_hddt(string id_tramba, string ky, string trangthai)
    {
        SqlConnection myConn = null;
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "";

        sql = "select distinct d.id,d.ma_tt,d.so_hd,d.mau_so,d.ky_hieu,d.ma_kh, d.ten_kh,d.ky_hd,d.so_ho,d.id_bang_gia_dien,d.trang_thai";        
        sql = sql + " from hoa_don d ";
        sql = sql + "where d.trang_thai=" + trangthai + " and  d.id_tram_bien_ap='" + id_tramba + "' and d.ky_hd='" + ky + "'";
        sql = sql + " and d.id_doanh_nghiep = " + id_doanh_nghiep;
        sql = sql + " order by d.id DESC";

        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            return dts.Tables[0];
            // return dts;    
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myConn != null)
            {
                myConn.Close();
            }
        }

    }
    //Lấy hóa đơn theo Fkey
    public DataTable get_hddt_theo_fkey(string fkey)
    {
        SqlConnection myConn = null;
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "";

        sql = "select *";
        sql = sql + " from hoa_don ";
        sql = sql + "where id=" + fkey + "";
        sql = sql + " and id_doanh_nghiep = " + id_doanh_nghiep;
        sql = sql + " order by id DESC";

        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            return dts.Tables[0];
            // return dts;    
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myConn != null)
            {
                myConn.Close();
            }
        }

    }
    //Lấy hóa đơn theo Fkey
    public DataTable get_hddt_theo_so_hd(string sohd,string mauso, string kyhieu)
    {
        SqlConnection myConn = null;
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "";

       // sql = "select *";
       // sql = sql + " from hoa_don ";
       // sql = sql + "where so_hd=" + sohd + " and mau_so='" + mauso + "' and ky_hieu='" + kyhieu + "'";
      //  sql = sql + " and id_doanh_nghiep = " + id_doanh_nghiep;
       // sql = sql + " order by id DESC";

        sql = sql + "select d.id,d.ma_tt,d.so_hd,d.mau_so,d.ky_hieu,d.ma_kh, d.ten_kh,b.ten_khu,a.dia_chi,a.dien_thoai,a.mst_kh,c.ten_viet_tat,nv.dien_thoai dt_sua_chua,d.chi_so_cu,d.chi_so_moi,d.dien_nang_tt dien_nang_tt,";
        sql = sql + " d.tong_tien_truoc_thue,d.vat_rate,d.thue_gtgt,d.tong_tien_sau_thue,d.ky_hd,d.ma_cong_to,d.tu_ngay,d.den_ngay,e.ten_tram_bien_ap, d.id_tram_bien_ap,d.id_bang_gia_dien,d.so_ho,d.id_khu, b.id_khu,d.trang_thai,tt.ten_trang_thai";
        sql = sql + " from khach_hang a, dm_khu b,bang_gia_dien c, hoa_don d, tram_bien_ap e,dm_trang_thai_hd tt, nhan_vien nv ";
        sql = sql + "where a.id_khu = b.id_khu and a.id_bang_gia=c.id_bang_gia and  a.id_tram_bien_ap=e.id_tram_bien_ap and e.nguoi_phu_trach=nv.ma_nv and  d.trang_thai=tt.trang_thai_id and d.ma_kh=a.ma_kh and d.trang_thai=2";
        sql = sql + " and d.so_hd="+sohd+" and d.mau_so='"+mauso+"' and d.ky_hieu='"+kyhieu+"'";
        sql = sql + " and d.id_doanh_nghiep =" + id_doanh_nghiep;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();   
            return dts.Tables[0];
            // return dts;    
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myConn != null)
            {
                myConn.Close();
            }
        }

    }
    //Chuyen doi hoa don
    public string PrintInvoice(string Fkey, string userName, string userPass)
    {
        PortalInvWS.PortalService portalservice = new PortalInvWS.PortalService();
        string pdf = portalservice.convertForStoreFkey(Fkey, userName, userPass);
        if (CheckConvertFor(pdf).Contains("ERR"))
        {
            return CheckConvertFor(pdf);
        }
        else
        {
            return pdf;
        }

    }
    //Chuyen doi hoa don theo so 
    public string PrintInvoiceByNo(string invToken, string userName, string userPass)
    {
        PortalInvWS.PortalService portalservice = new PortalInvWS.PortalService();
        string pdf = portalservice.convertForStore(invToken, userName, userPass);
        if (CheckConvertFor(pdf).Contains("ERR"))
        {
            return CheckConvertFor(pdf);
        }
        else
        {


            return pdf;
        }

    }
    public string CheckConvertFor(string ReturnValue)
    {
        string error = "";
        switch (ReturnValue)
        {
            case "ERR:1":
                error = "ERR: " + "Tài khoản đăng nhập sai";

                break;
            case "ERR:2":
                error = "ERR: " + "Chuỗi token không chính xác";
                break;
            case "ERR:6":
                error = "ERR: " + "Chuỗi token không chính xác. Kiểm tra mẫu số, ký hiệu hoặc số hóa đơn.";
                break;
            case "ERR:8":
                error = "ERR: " + "Hóa đơn  đã  được chuyển đổi rồi";
                break;
        }
        return error;
    }

    //Lấy các dòng hóa đơn
    public DataTable lay_hoa_don_chi_tiet(string id_hoa_don)
    {
        SqlConnection myConn = null;
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "select * from hoa_don_chi_tiet where id_hoa_don=" + id_hoa_don;

        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            return dts.Tables[0];
            // return dts;    
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myConn != null)
            {
                myConn.Close();
            }
        }

    }
    //Cap Nhat So HDDT, ngayPH, mau so, ky hieu
    public int updateEInvoice(string id, string ky, string so_hd, string mau_so, string ky_hieu,string trang_thai)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        // cmd.Connection = myConn;            
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string CommandText = "update hoa_don set thanh_toan=0,ngay_phat_hanh = CONVERT(Date, GETDATE()),trang_thai=@trang_thai, so_hd = @so_hd, mau_so=@mau_so, ky_hieu=@ky_hieu where id=@id and ky_hd=@ky and id_doanh_nghiep=@id_doanh_nghiep";
        SqlCommand cmd = new SqlCommand(CommandText, myConn);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@so_hd", so_hd);
        cmd.Parameters.AddWithValue("@mau_so", mau_so);
        cmd.Parameters.AddWithValue("@ky_hieu", ky_hieu);
        cmd.Parameters.AddWithValue("@ky", ky);
        cmd.Parameters.AddWithValue("@trang_thai", trang_thai);
        cmd.Parameters.AddWithValue("@id_doanh_nghiep", id_doanh_nghiep);

        int recordsAffected = 0;
        try
        {
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myConn != null)
            {
                myConn.Close();
            }
        }
        return recordsAffected;
    }
    //Tạo xml hóa đơn phát hành
    public string ParseIInvoice(DataTable InvList)
    {
        DataTable objTable = InvList;
        StringBuilder rv = new StringBuilder();

        int i = 0;
        //tao file xml
        if (objTable.Rows.Count > 0)
        {
            rv = new StringBuilder("<Invoices>");
            StringBuilder Failed = new StringBuilder("<Invoices>");

            try
            {
                const string Fkey = "id";
                //khach hang
                //const string Buyer = "Khách hàng";
                const string CusCode = "ma_kh";
                const string CusName = "ten_kh";
                const string CusAddress = "dia_chi";
                const string CusPhone = "dien_thoai";
                const string CusTaxCode = "mst_kh";
                const string KindOfService = "ky_hd";
                const string DTSuaChua = "dt_sua_chua";

                //Core mo rong 
                const string StartDate = "tu_ngay";
                const string ToDate = "den_ngay";
                const string SoHo = "so_ho";
                const string CHI_SO_DAU_KY = "chi_so_cu";
                const string CHI_SO_CUOI_KY = "chi_so_moi";
                const string SAN_LUONG = "dien_nang_tt";
                //CongTo
                //Product-Dòng hóa đơn            

                const string ProdCode = "dong";
                const string ProdName = "dien_giai";
                //const string ProdUnit = "DonViTinh";
                const string ProdQuantity = "so_luong";
                const string ProdPrice = "don_gia";
                const string ProdTotal = "thanh_tien";

                //tien thue
                const string Total = "tong_tien_truoc_thue";
                const string VATAmount = "thue_gtgt";
                const string Amount = "tong_tien_sau_thue";
                const string VATRate = "vat_rate";
                //giảm trừ covid
                const string GiamTru1 = "giam_tru_thang_10";
                const string GiamTru2 = "giam_tru_thang_11";
                const string GiamTru3 = "giam_tru_thang_12";

                do
                {
                    DataRow dr = objTable.Rows[i];

                    string key = dr[Fkey].ToString();
                    StringBuilder sb = new StringBuilder("<Inv><key>");
                    sb.Append(key);
                    sb.Append("</key><Invoice>");
                    string makh = dr[CusCode].ToString();
                    if (string.IsNullOrEmpty(dr[CusCode].ToString()) || string.IsNullOrEmpty(dr[CusName].ToString()))
                    {

                        return null;
                    }
                    else
                    {
                        sb.Append("<CusCode>");
                        sb.Append(convertSpecialCharacter(dr[CusCode].ToString().Trim().Replace(" ", "")));
                        sb.Append("</CusCode>");
                        sb.Append("<CusName>");
                        sb.Append(convertSpecialCharacter(dr[CusName].ToString().Trim()));
                        sb.Append("</CusName>");
                        sb.Append("<Buyer>");
                        //sb.Append(convertSpecialCharacter(dr[Buyer].ToString().Trim()));
                        sb.Append("</Buyer>");
                    }
                    sb.Append("<CusAddress>");
                    if (dr.Table.Columns.Contains(CusAddress))
                    {
                        sb.Append(convertSpecialCharacter(dr[CusAddress].ToString().Trim()));
                    }
                    sb.Append("</CusAddress><CusPhone>");
                    if (dr.Table.Columns.Contains(CusPhone))
                    {
                        sb.Append(dr[CusPhone].ToString().Trim());
                    }
                    sb.Append("</CusPhone><CusTaxCode>");
                    string mst = "";
                    if (dr.Table.Columns.Contains(CusTaxCode))
                    {
                        mst = dr[CusTaxCode].ToString().Trim();
                        if (mst != "0" && mst != "" && mst.Length > 9)
                        {
                            sb.Append(dr[CusTaxCode].ToString().Trim());
                        }


                    }
                    sb.Append("</CusTaxCode><PaymentMethod>");
                    sb.Append(convertSpecialCharacter("TM/CK"));
                    sb.Append("</PaymentMethod>");
                    sb.Append("<KindOfService>");
                    if (dr.Table.Columns.Contains(KindOfService))
                    {
                        sb.Append(dr[KindOfService].ToString().Trim());
                    }
                    sb.Append("</KindOfService>");
                    // VND TT78
                    sb.Append("<CurrencyUnit>VND");
                    
                    sb.Append("</CurrencyUnit>");
                    //Giảm trừ
                    //sb.Append("<Extra1>");
                    //if (dr.Table.Columns.Contains(GiamTru1))
                    //{
                    //    sb.Append(dr[GiamTru1].ToString().Trim());
                    //}
                    //sb.Append("</Extra1>");
                    //sb.Append("<Extra2>");
                    //if (dr.Table.Columns.Contains(GiamTru2))
                    //{
                    //    sb.Append(dr[GiamTru2].ToString().Trim());
                    //}
                    //sb.Append("</Extra2>");
                    //sb.Append("<Extra3>");
                    //if (dr.Table.Columns.Contains(GiamTru3))
                    //{
                    //    sb.Append(dr[GiamTru3].ToString().Trim());
                    //}
                    //sb.Append("</Extra3>");
                    //Tunga-denngay
                    sb.Append("<FromDate>");
                    if (dr.Table.Columns.Contains(StartDate))
                    {
                        sb.Append(dr[StartDate].ToString().Trim());
                    }
                    sb.Append("</FromDate><ToDate>");
                    if (dr.Table.Columns.Contains(ToDate))
                    {
                        sb.Append(dr[ToDate].ToString().Trim());
                    }
                    sb.Append("</ToDate>");

                    //số hộ
                    sb.Append("<SoHo>");
                    if (dr.Table.Columns.Contains(SoHo))
                    {
                        sb.Append(dr[SoHo].ToString().Trim());
                    }
                    sb.Append("</SoHo>");

                    //ĐN Tiêu thụ
                    sb.Append("<DNSD>");
                    if (dr.Table.Columns.Contains(SAN_LUONG))
                    {
                        sb.Append(dr[SAN_LUONG].ToString().Trim());
                    }
                    sb.Append("</DNSD>");

                    string tempcscu = "";
                    string tempcsmoi = "";

                    //Cong to
                    sb.Append("<Sumptions>");
                    int j = i;
                    do
                    {
                        DataRow drSumtion = objTable.Rows[j];
                        sb.Append("<Sumption>");
                        sb.Append("<CHI_SO_DAU_KY>");
                        sb.Append(drSumtion[CHI_SO_DAU_KY].ToString().Trim());
                        tempcscu = tempcscu + ";" + drSumtion[CHI_SO_DAU_KY].ToString().Trim();
                        sb.Append("</CHI_SO_DAU_KY>");
                        sb.Append("<CHI_SO_CUOI_KY>");
                        sb.Append(drSumtion[CHI_SO_CUOI_KY].ToString().Trim());
                        tempcsmoi = tempcsmoi + ";" + drSumtion[CHI_SO_CUOI_KY].ToString().Trim();
                        sb.Append("</CHI_SO_CUOI_KY>");
                        sb.Append("<SAN_LUONG></SAN_LUONG><MA_TINH_TRANG_DH></MA_TINH_TRANG_DH>");
                        sb.Append("</Sumption>");
                        j++;
                    } while (j < objTable.Rows.Count && string.Compare(objTable.Rows[j][Fkey].ToString(), objTable.Rows[j - 1][Fkey].ToString()) == 0);
                    sb.Append("</Sumptions>");
                    //chỉ số nhiều công tơ
                    sb.Append("<ChiSoCu>");
                    sb.Append(tempcscu);
                    sb.Append("</ChiSoCu>");
                    sb.Append("<ChiSoMoi>");
                    sb.Append(tempcsmoi);
                    sb.Append("</ChiSoMoi>");
                    //bat dau den san pham
                    sb.Append("<Products>");
                    DataTable dtbInvLine = lay_hoa_don_chi_tiet(key);
                    int k = 0;
                    var mTotal = 0;
                    var mVATRate = int.Parse(dr[VATRate].ToString().Trim());

                    var mAmount = 0;
                    for (k = 0; k < dtbInvLine.Rows.Count; k++)
                    {
                        DataRow drProduct = dtbInvLine.Rows[k];
                        var curTotal = drProduct[ProdTotal].ToString().Trim().Replace(",", "");
                        mTotal = mTotal + int.Parse(curTotal);
                        sb.Append("<Product>");
                        // sb.Append(convertSpecialCharacter(drProduct[ProdCode].ToString().Trim()));
                        sb.Append("<ProdName>");
                        sb.Append(drProduct[ProdName].ToString().Trim());
                        sb.Append("</ProdName><ProdUnit>");
                        //sb.Append(convertSpecialCharacter(drProduct[ProdUnit].ToString().Trim()));
                        sb.Append("kWh");
                        sb.Append("</ProdUnit><ProdQuantity>");
                        sb.Append(drProduct[ProdQuantity].ToString().Replace(",", ""));
                        sb.Append("</ProdQuantity><ProdPrice>");
                        sb.Append(drProduct[ProdPrice].ToString().Trim().Replace(",", ""));
                        sb.Append("</ProdPrice><Total>");
                        sb.Append(drProduct[ProdTotal].ToString().Trim().Replace(",", ""));
                        sb.Append("</Total>");

                        //end
                        sb.Append("</Product>");
                    }
                    int mVATAmount = (int)((Convert.ToDouble(mTotal) / 100) * mVATRate);
                    double s1 = Convert.ToDouble(mTotal) / 100;
                    int vat1 = (int)((Convert.ToDouble(mTotal) / 100) * mVATRate);
                    mAmount = mTotal + mVATAmount;
                    sb.Append("</Products><Total>");
                    sb.Append(mTotal.ToString().Trim().Replace(",", ""));
                    sb.Append("</Total><VATRate>");
                    sb.Append(mVATRate.ToString().Trim());
                    sb.Append("</VATRate><VATAmount>");
                    sb.Append(mVATAmount.ToString().Trim().Replace(",", ""));
                    sb.Append("</VATAmount><Amount>");
                    sb.Append(mAmount.ToString().Trim().Replace(",", ""));
                    sb.Append("</Amount><AmountInWords>");
         
                    string tienBangChu = "";
                    NumberToLeter numToLetter = new NumberToLeter();

                    tienBangChu = numToLetter.DocTienBangChu(mAmount, tienBangChu);
           
                    sb.Append(tienBangChu);
                    sb.Append("</AmountInWords>");
                    sb.Append("</Invoice></Inv>");
                    rv.AppendLine(sb.ToString());
                    i = j;
                } while (i < objTable.Rows.Count);
            }

            catch (Exception ex)
            {
                return null;
            }

            rv.Append("</Invoices>");
        }
        return rv.ToString();
    }
    //Tạo xml hóa đơn thay thế
    public string ParseIInvoiceReplace(DataTable InvList)
    {
        DataTable objTable = InvList;
        StringBuilder rv = new StringBuilder();
        clsNhapChiSo myNCS = new clsNhapChiSo();
        int i = 0;
        //tao file xml
        if (objTable.Rows.Count > 0)
        {
            rv = new StringBuilder("<ReplaceInv>");
            StringBuilder Failed = new StringBuilder("<ReplaceInv>");

            try
            {
                const string Fkey = "id";
                //khach hang
                //const string Buyer = "Khách hàng";
                const string CusCode = "ma_kh";
                const string CusName = "ten_kh";
                const string CusAddress = "dia_chi";
                const string CusPhone = "dien_thoai";
                const string CusTaxCode = "mst_kh";
                const string KindOfService = "ky_hd";
                const string DTSuaChua = "dt_sua_chua";

                //Core mo rong 
                const string StartDate = "tu_ngay";
                const string ToDate = "den_ngay";
                const string SoHo = "so_ho";
                const string CHI_SO_DAU_KY = "chi_so_cu";
                const string CHI_SO_CUOI_KY = "chi_so_moi";
                const string SAN_LUONG = "dien_nang_tt";
                //CongTo
                //Product-Dòng hóa đơn            

                const string ProdCode = "dong";
                const string ProdName = "dien_giai";
                //const string ProdUnit = "DonViTinh";
                const string ProdQuantity = "so_luong";
                const string ProdPrice = "don_gia";
                const string ProdTotal = "thanh_tien";

                //tien thue
                const string Total = "tong_tien_truoc_thue";
                const string VATAmount = "thue_gtgt";
                const string Amount = "tong_tien_sau_thue";
                const string VATRate = "vat_rate";

                do
                {
                    DataRow dr = objTable.Rows[i];

                    string key = dr[Fkey].ToString();
                    StringBuilder sb = new StringBuilder("<key>");
                    sb.Append(key);
                    sb.Append("</key>");
                    string makh = dr[CusCode].ToString();
                    if (string.IsNullOrEmpty(dr[CusCode].ToString()) || string.IsNullOrEmpty(dr[CusName].ToString()))
                    {

                        return null;
                    }
                    else
                    {
                        sb.Append("<CusCode>");
                        sb.Append(convertSpecialCharacter(dr[CusCode].ToString().Trim().Replace(" ", "")));
                        sb.Append("</CusCode>");
                        sb.Append("<CusName>");
                        sb.Append(convertSpecialCharacter(dr[CusName].ToString().Trim()));
                        sb.Append("</CusName>");
                        sb.Append("<Buyer>");
                        //sb.Append(convertSpecialCharacter(dr[Buyer].ToString().Trim()));
                        sb.Append("</Buyer>");
                    }
                    sb.Append("<CusAddress>");
                    if (dr.Table.Columns.Contains(CusAddress))
                    {
                        sb.Append(convertSpecialCharacter(dr[CusAddress].ToString().Trim()));
                    }
                    sb.Append("</CusAddress><CusPhone>");
                    if (dr.Table.Columns.Contains(CusPhone))
                    {
                        sb.Append(dr[CusPhone].ToString().Trim());
                    }
                    sb.Append("</CusPhone><CusTaxCode>");
                    string mst = "";
                    if (dr.Table.Columns.Contains(CusTaxCode))
                    {
                        mst = dr[CusTaxCode].ToString().Trim();
                        if (mst != "0" && mst != "" && mst.Length > 9)
                        {
                            sb.Append(dr[CusTaxCode].ToString().Trim());
                        }


                    }
                    sb.Append("</CusTaxCode><PaymentMethod>");
                    sb.Append(convertSpecialCharacter("TM/CK"));
                    sb.Append("</PaymentMethod>");
                    sb.Append("<KindOfService>");
                    if (dr.Table.Columns.Contains(KindOfService))
                    {
                        sb.Append(dr[KindOfService].ToString().Trim());
                    }
                    sb.Append("</KindOfService>");

                    // VND TT78
                    sb.Append("<CurrencyUnit>VND");

                    sb.Append("</CurrencyUnit>");

                    sb.Append("<Extra1>");
                    sb.Append(dr[DTSuaChua].ToString().Trim());
                    sb.Append("</Extra1>");
                    //Tunga-denngay
                    sb.Append("<FromDate>");
                    if (dr.Table.Columns.Contains(StartDate))
                    {
                        sb.Append(dr[StartDate].ToString().Trim());
                    }
                    sb.Append("</FromDate><ToDate>");
                    if (dr.Table.Columns.Contains(ToDate))
                    {
                        sb.Append(dr[ToDate].ToString().Trim());
                    }
                    sb.Append("</ToDate>");

                    //số hộ
                    sb.Append("<SoHo>");
                    if (dr.Table.Columns.Contains(SoHo))
                    {
                        sb.Append(dr[SoHo].ToString().Trim());
                    }
                    sb.Append("</SoHo>");

                    //ĐN Tiêu thụ
                    sb.Append("<DNSD>");
                    if (dr.Table.Columns.Contains(SAN_LUONG))
                    {
                        sb.Append(dr[SAN_LUONG].ToString().Trim());
                    }
                    sb.Append("</DNSD>");

                    string tempcscu = "";
                    string tempcsmoi = "";

                    //Cong to
                    sb.Append("<Sumptions>");
                    int j = i;
                    do
                    {
                        DataRow drSumtion = objTable.Rows[j];
                        sb.Append("<Sumption>");
                        sb.Append("<CHI_SO_DAU_KY>");
                        sb.Append(drSumtion[CHI_SO_DAU_KY].ToString().Trim());
                        tempcscu = tempcscu + ";" + drSumtion[CHI_SO_DAU_KY].ToString().Trim();
                        sb.Append("</CHI_SO_DAU_KY>");
                        sb.Append("<CHI_SO_CUOI_KY>");
                        sb.Append(drSumtion[CHI_SO_CUOI_KY].ToString().Trim());
                        tempcsmoi = tempcsmoi + ";" + drSumtion[CHI_SO_CUOI_KY].ToString().Trim();
                        sb.Append("</CHI_SO_CUOI_KY>");
                        sb.Append("<SAN_LUONG></SAN_LUONG><MA_TINH_TRANG_DH></MA_TINH_TRANG_DH>");
                        sb.Append("</Sumption>");
                        j++;
                    } while (j < objTable.Rows.Count && string.Compare(objTable.Rows[j][Fkey].ToString(), objTable.Rows[j - 1][Fkey].ToString()) == 0);
                    sb.Append("</Sumptions>");
                    //chỉ số nhiều công tơ
                    sb.Append("<ChiSoCu>");
                    sb.Append(tempcscu);
                    sb.Append("</ChiSoCu>");
                    sb.Append("<ChiSoMoi>");
                    sb.Append(tempcsmoi);
                    sb.Append("</ChiSoMoi>");
                    //bat dau den san pham
                    sb.Append("<Products>");
                    DataTable dtbInvLine = lay_hoa_don_chi_tiet(key);
                    int k = 0;
                    for (k = 0; k < dtbInvLine.Rows.Count; k++)
                    {
                        DataRow drProduct = dtbInvLine.Rows[k];
                        sb.Append("<Product>");
                        // sb.Append(convertSpecialCharacter(drProduct[ProdCode].ToString().Trim()));
                        sb.Append("<ProdName>");
                        sb.Append(drProduct[ProdName].ToString().Trim());
                        sb.Append("</ProdName><ProdUnit>");
                        //sb.Append(convertSpecialCharacter(drProduct[ProdUnit].ToString().Trim()));
                        sb.Append("kWh");
                        sb.Append("</ProdUnit><ProdQuantity>");
                        sb.Append(drProduct[ProdQuantity].ToString().Replace(",", ""));
                        sb.Append("</ProdQuantity><ProdPrice>");
                        sb.Append(drProduct[ProdPrice].ToString().Trim().Replace(",", ""));
                        sb.Append("</ProdPrice><Total>");
                        sb.Append(drProduct[ProdTotal].ToString().Trim().Replace(",", ""));
                        sb.Append("</Total>");

                        //end
                        sb.Append("</Product>");
                    }
                    sb.Append("</Products><Total>");
                    sb.Append(dr[Total].ToString().Trim().Replace(",", ""));
                    sb.Append("</Total><DiscountAmount></DiscountAmount><VATRate>");
                    sb.Append(dr[VATRate].ToString().Trim());
                    sb.Append("</VATRate><VATAmount>");
                    sb.Append(dr[VATAmount].ToString().Trim().Replace(",", ""));
                    sb.Append("</VATAmount><Amount>");
                    sb.Append(dr[Amount].ToString().Trim().Replace(",", ""));
                    sb.Append("</Amount><AmountInWords>");
                    Int64 tongtien;
                    string tienBangChu = "";
                    NumberToLeter numToLetter = new NumberToLeter();
                    if (Int64.TryParse(dr[Amount].ToString().Trim().Replace(",", ""), out tongtien))
                        tienBangChu = numToLetter.DocTienBangChu(tongtien, tienBangChu);
                    sb.Append(tienBangChu);
                    sb.Append("</AmountInWords>");                    
                    rv.AppendLine(sb.ToString());
                    i = j;
                } while (i < objTable.Rows.Count);
            }

            catch (Exception ex)
            {
                return null;
            }

            rv.Append("</ReplaceInv>");
        }
        return rv.ToString();
    }
    private string convertSpecialCharacter(string xmlData)
    {
        return "<![CDATA[" + xmlData + "]]>";
    }
    //Cap Nhat tên KH mới, bảng giá mới khi thay thế hóa đơn
    public int updateKHreplace(string makh, string tenkh, string dia_chi, string soho, string idbg)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        // cmd.Connection = myConn;            
        string CommandText = "update khach_hang set ten_kh=@ten_kh,dia_chi=@dia_chi,so_ho=@so_ho,id_bang_gia=@id_bang_gia where ma_kh=@ma_kh and id_doanh_nghiep=@id_doanh_nghiep";
        SqlCommand cmd = new SqlCommand(CommandText, myConn);
        cmd.Parameters.AddWithValue("@ma_kh", makh);
        cmd.Parameters.AddWithValue("@so_ho", soho);
        cmd.Parameters.AddWithValue("@id_bang_gia", idbg);
        cmd.Parameters.AddWithValue("@ten_kh", tenkh);
        cmd.Parameters.AddWithValue("@dia_chi", dia_chi);
        cmd.Parameters.AddWithValue("@id_doanh_nghiep", id_doanh_nghiep);
        int recordsAffected = 0;
        try
        {
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myConn != null)
            {
                myConn.Close();
            }
        }
        return recordsAffected;
    }

}