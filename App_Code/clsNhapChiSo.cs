using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

/// tuanbn.pto cls Nhập chỉ số điện năng
public class clsNhapChiSo
{
    clsConnect myCon = new clsConnect();

    public DataTable get_danh_sach_nhap_cs(string id_tramba, string ky)
    {
        SqlConnection myConn = null;
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "";
        if (id_tramba == "0")
        {
            sql = "select a.ma_kh, a.ten_kh,f.he_so_ti,b.ten_khu,a.dia_chi,a.dien_thoai,c.ten_bang_gia,d.cs_cu,d.cs_moi,f.ma_cong_to,e.ten_tram_bien_ap, a.id_tram_bien_ap,a.id_bang_gia,a.so_ho,a.id_khu, b.id_khu,d.trang_thai,tt.ten_trang_thai";
            sql = sql + " from khach_hang a, dm_khu b,bang_gia_dien c, chi_so_cong_to d, tram_bien_ap e,dm_cong_to f,dm_trang_thai_cs tt ";
            sql = sql + " where a.id_khu = b.id_khu and a.id_bang_gia=c.id_bang_gia and  a.id_tram_bien_ap=e.id_tram_bien_ap and a.ma_kh=f.ma_kh and d.ma_cong_to=f.ma_cong_to and d.trang_thai = tt.trang_thai_id and d.ky='" + ky + "'";
            sql = sql + " and d.id_doanh_nghiep = " + id_doanh_nghiep + "";
            sql = sql + " order by a.thu_tu, d.id";
        }
        else
        {
            sql = "select a.ma_kh,f.he_so_ti, a.ten_kh,b.ten_khu,a.dia_chi,a.dien_thoai,c.ten_bang_gia,d.cs_cu,d.cs_moi,f.ma_cong_to,e.ten_tram_bien_ap, a.id_tram_bien_ap,a.id_bang_gia,a.so_ho,a.id_khu, b.id_khu,d.trang_thai,tt.ten_trang_thai";
            sql = sql + " from khach_hang a, dm_khu b,bang_gia_dien c, chi_so_cong_to d, tram_bien_ap e,dm_cong_to f,dm_trang_thai_cs tt ";
            sql = sql + " where a.id_khu = b.id_khu and a.id_bang_gia=c.id_bang_gia and  a.id_tram_bien_ap=e.id_tram_bien_ap and a.ma_kh=f.ma_kh and d.ma_cong_to=f.ma_cong_to and d.trang_thai = tt.trang_thai_id and  a.id_tram_bien_ap='" + id_tramba + "' and d.ky='" + ky + "'";
            sql = sql + " and d.id_doanh_nghiep = " + id_doanh_nghiep + "";
            sql = sql + " order by a.thu_tu, d.id";
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
    public DataTable get_danh_cs_kymoi(string id_tramba, string ky)
    {
        SqlConnection myConn = null;
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "";
        if (id_tramba == "0")
        {
            sql = "select a.ma_kh, a.ten_kh,b.ten_khu,a.dia_chi,a.dien_thoai,c.ten_bang_gia,d.cs_cu,d.cs_moi,f.ma_cong_to,e.ten_tram_bien_ap, a.id_tram_bien_ap,a.id_bang_gia,a.so_ho,a.id_khu, b.id_khu,d.trang_thai,tt.ten_trang_thai";
            sql = sql + " from khach_hang a, dm_khu b,bang_gia_dien c, chi_so_cong_to d, tram_bien_ap e,dm_cong_to f,dm_trang_thai_cs tt ";
            sql = sql + " where a.id_khu = b.id_khu and a.id_bang_gia=c.id_bang_gia and  a.id_tram_bien_ap=e.id_tram_bien_ap and a.ma_kh=f.ma_kh and d.ma_cong_to=f.ma_cong_to and d.trang_thai = tt.trang_thai_id and d.ky='" + ky + "'";
            sql = sql + " and d.id_doanh_nghiep = " + id_doanh_nghiep + " and f.trang_thai=1";
            sql = sql + " order by a.thu_tu, d.id";
        }
        else
        {
            sql = "select a.ma_kh, a.ten_kh,b.ten_khu,a.dia_chi,a.dien_thoai,c.ten_bang_gia,d.cs_cu,d.cs_moi,f.ma_cong_to,e.ten_tram_bien_ap, a.id_tram_bien_ap,a.id_bang_gia,a.so_ho,a.id_khu, b.id_khu,d.trang_thai,tt.ten_trang_thai";
            sql = sql + " from khach_hang a, dm_khu b,bang_gia_dien c, chi_so_cong_to d, tram_bien_ap e,dm_cong_to f,dm_trang_thai_cs tt ";
            sql = sql + " where a.id_khu = b.id_khu and a.id_bang_gia=c.id_bang_gia and  a.id_tram_bien_ap=e.id_tram_bien_ap and a.ma_kh=f.ma_kh and d.ma_cong_to=f.ma_cong_to and d.trang_thai = tt.trang_thai_id and  a.id_tram_bien_ap='" + id_tramba + "' and d.ky='" + ky + "'";
            sql = sql + " and d.id_doanh_nghiep = " + id_doanh_nghiep + " and f.trang_thai=1";
            sql = sql + " order by a.thu_tu, d.id";
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
    public DataTable get_danh_sach_nhap_cs_tong(string ky)
    {
        SqlConnection myConn = null;
        string sql = "";
        sql = string.Format("select a.*, b.*, (a.cs_moi - a.cs_cu) as so_mua, e.so_ban from chi_so_cong_to_tong as a, tram_bien_ap as b, (select c.id_tram_bien_ap, sum(d.cs_moi - d.cs_cu) as so_ban from khach_hang as c, chi_so_cong_to as d where c.ma_cong_to like CONCAT('%', d.ma_cong_to, '%') and d.ky = '{0}' group by c.id_tram_bien_ap) as e where a.ma_cong_to = b.ma_so_cong_to and a.ky = '{0}' and b.trang_thai = 1 and e.id_tram_bien_ap = b.id_tram_bien_ap", ky);
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
    // Trạng thái chỉ số 1 ( chưa chốt)
    public DataTable get_danh_sach_lap_hd(string id_tramba, string ky)
    {
        SqlConnection myConn = null;
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "";
        sql = "select a.thu_tu,a.ma_kh,f.he_so_ti, a.ten_kh,b.ten_khu,a.dia_chi,a.dien_thoai,c.ten_bang_gia,d.cs_cu,d.cs_moi,f.ma_cong_to,e.ten_tram_bien_ap, a.id_tram_bien_ap,a.id_bang_gia,a.so_ho,a.id_khu, b.id_khu,d.trang_thai";
        sql = sql + " from khach_hang a, dm_khu b,bang_gia_dien c, chi_so_cong_to d, tram_bien_ap e,dm_cong_to f ";
        sql = sql + " where a.id_khu = b.id_khu and a.id_bang_gia=c.id_bang_gia and  a.id_tram_bien_ap=e.id_tram_bien_ap and a.ma_kh=f.ma_kh and d.ma_cong_to=f.ma_cong_to and d.trang_thai=1 and a.id_tram_bien_ap='" + id_tramba + "' and d.ky='" + ky + "'";
        sql = sql + " and d.id_doanh_nghiep = " + id_doanh_nghiep + " and d.cs_moi > d.cs_cu";
        sql = sql + " order by a.thu_tu,d.id";
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
    public DataTable get_danh_sach_tba()
    {
        SqlConnection myConn = null;
        // string sql = "select '0' id_tram_bien_ap, N'-- Tất cả trạm --' ten_tram_bien_ap ";
        // sql = sql + " union all ";
        string sql = " select id_tram_bien_ap,ten_tram_bien_ap from tram_bien_ap where trang_thai = 1 order by id_tram_bien_ap";
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
    public DataTable get_danh_sach_tba_notall()
    {
        SqlConnection myConn = null;
        string sql = "select id_tram_bien_ap,ten_tram_bien_ap from tram_bien_ap where trang_thai=1 ";
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
    public string get_ten_tba(string id)
    {
        SqlConnection myConn = null;
        string sql = "select ten_viet_tat from tram_bien_ap where trang_thai=1 and id_tram_bien_ap=" + id;
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
            return dts.Tables[0].Rows[0]["ten_viet_tat"].ToString();
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
    public Double[] tinh_cs_6_muc(Double sanluong, int sh)
    {
        Double[] muc = new Double[] { };
        if (sanluong > (400 * sh))
        {
            Double bac6 = sanluong - (400 * sh);
            muc = new Double[] { 50 * sh, 50 * sh, 100 * sh, 100 * sh, 100 * sh, bac6 };

        }
        else
        {
            if (sanluong > (300 * sh))
            {
                Double bac5 = sanluong - (300 * sh);
                muc = new Double[] { 50 * sh, 50 * sh, 100 * sh, 100 * sh, bac5 };
            }
            else
            {
                if (sanluong > (200 * sh))
                {
                    Double bac4 = sanluong - (200 * sh);
                    muc = new Double[] { 50 * sh, 50 * sh, 100 * sh, bac4 };
                }
                else
                {
                    if (sanluong > (100 * sh))
                    {
                        Double bac3 = sanluong - (100 * sh);
                        muc = new Double[] { (50 * sh), (50 * sh), bac3 };
                    }
                    else
                    {
                        if (sanluong > (50 * sh))
                        {
                            Double bac2 = sanluong - (50 * sh);
                            muc = new Double[] { (50 * sh), bac2 };
                        }
                        else
                        {
                            Double bac1 = sanluong - 0;
                            muc = new Double[] { bac1 };
                        }
                    }
                }
            }
        }
        return muc;
    }
    //Tính tiền điện MDK
    public Double tinh_tien_dien_MDK(Double dntt, int sh, string id_bang_gia)
    {
        Double dongia = 0;
        Double total = 0;
        DataTable BangGia = lay_bang_gia(id_bang_gia);

        dongia = Convert.ToDouble(BangGia.Rows[0]["don_gia"].ToString());
        total = dntt * dongia;

        return total;

    }
    //Tính tiền điện MDK
    public Double tinh_tien_dien_sh(Double dntt, int sh, string id_bang_gia)
    {
        Double total = 0;
        DataTable BangGiaCT = lay_bang_gia_chi_tiet(id_bang_gia);
        Double[] muc = tinh_cs_6_muc(dntt, sh);
        Double[] dongiamuc = new Double[] { };
        int j = 0;
        for (j = 0; j < muc.Length; j++)
        {
            total = total + (muc[j] * Convert.ToDouble(BangGiaCT.Rows[j]["gia_ko_vat"].ToString()));
        }
        return total;
    }
    //Tính tiền điện hỗn hợp
    public Double tinh_tien_dien_HH(Double dntt, int sh, string id_bang_gia)
    {
        Double total = 0;
        Double dn = 0;
        Double sumDN = 0;
        DataTable BangGiaHH = lay_bang_gia_chi_tiet(id_bang_gia);
        int i = 0;
        for (i = 0; i < BangGiaHH.Rows.Count; i++)
        {
            DataTable dtbtemp = lay_bang_gia(BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
            int tyle = Convert.ToInt32(BangGiaHH.Rows[i]["ty_le"].ToString().Trim());
            if (i != BangGiaHH.Rows.Count - 1)
            {
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
                {
                    dn = dntt * tyle / 100;
                    dn = Math.Round(dn, 0, MidpointRounding.AwayFromZero);
                    sumDN = sumDN + dn;
                    total = total + tinh_tien_dien_MDK(dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "BT")
                {
                    dn = dntt * tyle / 100;
                    dn = Math.Round(dn, 0, MidpointRounding.AwayFromZero);
                    sumDN = sumDN + dn;
                    total = total + tinh_tien_dien_sh(dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "HH")
                {
                    dn = dntt * tyle / 100;
                    dn = Math.Round(dn, 0, MidpointRounding.AwayFromZero);
                    sumDN = sumDN + dn;
                    total = total + tinh_tien_dien_HH(dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                }

            }
            else
            {
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
                {
                    dn = dntt - sumDN;
                    total = total + tinh_tien_dien_MDK(dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "BT")
                {
                    dn = dntt - sumDN;
                    total = total + tinh_tien_dien_sh(dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "HH")
                {
                    dn = dntt - sumDN;
                    total = total + tinh_tien_dien_HH(dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                }
            }

        }

        return total;
    }
    //Tính tiền điện
    public Double tinh_tien_dien(Double dntt, int sh, string id_bang_gia)
    {

        Double total = 0;
        DataTable BangGia = lay_bang_gia(id_bang_gia);
        if (BangGia.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
        {

            // dongia = Convert.ToDouble(BangGia.Rows[0]["don_gia"].ToString());
            // total = dntt * dongia;
            total = tinh_tien_dien_MDK(dntt, sh, id_bang_gia);
        }
        if (BangGia.Rows[0]["loai_bg"].ToString().Trim() == "BT")
        {
            total = tinh_tien_dien_sh(dntt, sh, id_bang_gia);

        }
        if (BangGia.Rows[0]["loai_bg"].ToString().Trim() == "HH")
        {
            total = tinh_tien_dien_HH(dntt, sh, id_bang_gia);
        }
        //Làm tròn
        total = Math.Round(total, 0, MidpointRounding.AwayFromZero);
        return total;
    }

    //Lấy bảng giá
    public DataTable lay_bang_gia(string id_bang_gia)
    {
        SqlConnection myConn = null;
        string sql = "select * from bang_gia_dien where id_bang_gia=" + id_bang_gia;
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
            return dts.Tables[0];
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

    //Lấy bảng giá chi tiết
    public DataTable lay_bang_gia_chi_tiet(string id_bang_gia)
    {
        SqlConnection myConn = null;
        string sql = "select * from bang_gia_dien_chi_tiet where id_bang_gia=" + id_bang_gia;
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
            return dts.Tables[0];
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
    //Trạng thái kỳ 1-Chưa chốt, 0-đã chốt
    public DataTable get_danhsach_ky()
    {
        SqlConnection myConn = null;
        string sql = " select id,ky from ky where trang_thai=1 order by id DESC ";
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
    //
    public DataTable lay_tungay_denngay(string kyhd)
    {
        SqlConnection myConn = null;
        string sql = " select tu_ngay,den_ngay from ky where ky='" + kyhd + "' ";
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

    // check ma ct và ky có trong bảng chỉ số chưa
    public int check_cs_ct(string mact, string ky)
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select * from chi_so_cong_to where ma_cong_to = '" + mact + "' and ky='" + ky + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            return dts.Tables[0].Rows.Count;
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

    public int check_cs_ct_tong(string mact, string ky)
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select * from chi_so_cong_to_tong where ma_cong_to = '" + mact + "' and ky='" + ky + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            return dts.Tables[0].Rows.Count;
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
    public int cap_nhat_chi_so(string mact, string cscu, string csmoi, string ky)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        int recordsAffected = 0;
        string id_doanh_nghiep = myCon.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.Parameters.Clear();
            cmd.CommandText = "update chi_so_cong_to set cs_cu='" + cscu + "',cs_moi='" + csmoi + "', ngay_capnhat = CONVERT( Datetime, GETDATE() ,103) where ma_cong_to='" + mact + "' and ky='" + ky + "' and id_doanh_nghiep=" + id_doanh_nghiep;
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
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
    public int cap_nhat_chi_so_cong_to_tong(string mact, string csmoi, string ky)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        int recordsAffected = 0;
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("update chi_so_cong_to_tong set cs_moi = {1}, ngay_cap_nhat = CONVERT(Datetime, GETDATE(), 103) where ma_cong_to = '{0} ' and ky = '{2}'", mact, csmoi, ky);
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
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

    public int them_chi_so_ky_moi(string mact, string csmoi, string kymoi)
    {
        clsConnect cnstr = new clsConnect();
        string id_doanh_nghiep = cnstr.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        int recordsAffected = 0;
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into chi_so_cong_to(ma_cong_to,cs_cu,ky,ngay_capnhat,trang_thai,id_doanh_nghiep) values ('" + mact + "'," + csmoi + ",'" + kymoi + "',CONVERT( Datetime, GETDATE() ,103),1," + id_doanh_nghiep + ")";
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
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
    public int them_chi_so_cong_to_tong_ky_moi(string mact, string csmoi, string kymoi, int id_doanh_nghiep)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        int recordsAffected = 0;
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("insert into chi_so_cong_to_tong (ma_cong_to, cs_cu, cs_moi, ky, ngay_cap_nhat, id_doanh_nghiep) values ('{0}', {1}, {1}, '{2}',CONVERT( Datetime, GETDATE() ,103), {3})", mact, csmoi, kymoi, id_doanh_nghiep);
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
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
    public int them_kyhd(string ky, string thang, string nam, string tu_ngay, string den_ngay)
    {
        clsConnect cnstr = new clsConnect();
        string id_doanh_nghiep = cnstr.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        int recordsAffected = 0;
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into ky(ky,thang,nam,tu_ngay,den_ngay,trang_thai,id_doanh_nghiep) values ('" + ky + "'," + thang + "," + nam + ",CONVERT(date,'" + tu_ngay + "'),CONVERT(date,'" + den_ngay + "'),1," + id_doanh_nghiep + ")";
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
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

    public int chotchiso(string mact, string ky)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        int recordsAffected = 0;
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.Parameters.Clear();
            cmd.CommandText = "update chi_so_cong_to set trang_thai='0',ngay_chot = CONVERT(Datetime, GETDATE() ,103) where ma_cong_to='" + mact + "' and ky='" + ky + "'";
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
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

    public int lay_idhd()
    {
        int sohd;
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select case when max(id) is NULL then 0 else max(id) end sohd from hoa_don";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            sohd = Convert.ToInt32(dts.Tables[0].Rows[0]["sohd"].ToString()) + 1;
            return sohd;
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

    //Insert bang hoa_don
    public void them_moi_hoa_don(Int64 id, string ma_kh, string ky_hd, string tu_ngay, string den_ngay, string chi_so_cu, string chi_so_moi, string dien_nang_tt, Double tong_tien_truoc_thue, string vat_rate, Double thue_gtgt, Double tong_tien_sau_thue, string id_nguoi_nhap, string id_bang_gia_dien, string ma_cong_to, int so_ho, string ten_kh, string id_tram_bien_ap, string id_khu)
    {

        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        string id_doanh_nghiep = cnstr.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "insert into hoa_don(id,ma_kh,ky_hd,tu_ngay,den_ngay,chi_so_cu,chi_so_moi,dien_nang_tt,tong_tien_truoc_thue,vat_rate,thue_gtgt,tong_tien_sau_thue,id_nguoi_nhap,id_bang_gia_dien,ngay_nhap,trang_thai,ma_cong_to,id_doanh_nghiep,so_ho,ten_kh,id_tram_bien_ap,id_khu) ";
        sql = sql + " values(" + id + ",'" + ma_kh + "','" + ky_hd + "', '" + tu_ngay + "', '" + den_ngay + "'," + chi_so_cu + "," + chi_so_moi + "," + dien_nang_tt + "," + tong_tien_truoc_thue + ",'" + vat_rate + "'," + thue_gtgt + "," + tong_tien_sau_thue + ",'" + id_nguoi_nhap + "','" + id_bang_gia_dien + "',CONVERT( Datetime, GETDATE() ,103),1,'" + ma_cong_to + "'," + id_doanh_nghiep + "," + so_ho + ",N'" + ten_kh + "','" + id_tram_bien_ap + "'," + id_khu + ") ";

        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.Parameters.Clear();
            cmd.CommandText = sql;
            int recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
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
    //Insert hoa_don_chi_tiet

    public int them_moi_hoa_don_chi_tiet(Int64 id_hd, Double dntt, int sh, string id_bang_gia)
    {
        int recordsAffected = 0;
        DataTable BangGia = lay_bang_gia(id_bang_gia);
        if (BangGia.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
        {
            recordsAffected = them_moi_hoa_don_chi_tiet_mdk(id_hd, dntt, sh, id_bang_gia);

        }
        if (BangGia.Rows[0]["loai_bg"].ToString().Trim() == "BT")
        {
            recordsAffected = them_moi_hoa_don_chi_tiet_sh(id_hd, dntt, sh, id_bang_gia);
        }
        if (BangGia.Rows[0]["loai_bg"].ToString().Trim() == "HH")
        {
            recordsAffected = them_moi_hoa_don_chi_tiet_hh(id_hd, dntt, sh, id_bang_gia);
        }
        return recordsAffected;

    }
    public int them_moi_hoa_don_chi_tiet_mdk(Int64 id_hd, Double dntt, int sh, string id_bang_gia)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        string id_doanh_nghiep = cnstr.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "";
        Double dongia = 0;
        Double total = 0;
        string diengiai = "";
        int recordsAffected = 0;
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.Parameters.Clear();
            DataTable BangGia = lay_bang_gia(id_bang_gia);

            diengiai = BangGia.Rows[0]["ten_bang_gia"].ToString();
            dongia = Convert.ToDouble(BangGia.Rows[0]["don_gia"].ToString());
            total = dntt * dongia;
            sql = "insert into hoa_don_chi_tiet(id_hoa_don,dong,dien_giai,so_luong,don_gia,thanh_tien,ngay_nhap,id_doanh_nghiep)";
            sql = sql + " values(" + id_hd + ",1,N'" + diengiai + "'," + dntt + ",'" + dongia + "', '" + total + "', CONVERT( Datetime, GETDATE() ,103)," + id_doanh_nghiep + ")";

            cmd.CommandText = sql;
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
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
    public int them_moi_hoa_don_chi_tiet_sh(Int64 id_hd, Double dntt, int sh, string id_bang_gia)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        string id_doanh_nghiep = cnstr.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "";
        Double dongia = 0;
        Double total = 0;
        string diengiai = "";
        int recordsAffected = 0;
        DataTable BangGia = lay_bang_gia_chi_tiet(id_bang_gia);
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.Parameters.Clear();
            Double[] muc = tinh_cs_6_muc(dntt, sh);
            Double[] dongiamuc = new Double[] { };
            int j = 0;
            for (j = 0; j < muc.Length; j++)
            {
                diengiai = BangGia.Rows[j]["muc_thu"].ToString();
                dongia = Convert.ToDouble(BangGia.Rows[j]["gia_ko_vat"].ToString());
                total = muc[j] * dongia;
                sql = "insert into hoa_don_chi_tiet(id_hoa_don,dong,dien_giai,so_luong,don_gia,thanh_tien,ngay_nhap,id_doanh_nghiep)";
                sql = sql + " values(" + id_hd + "," + (j + 1) + ",N'" + diengiai + "','" + muc[j] + "','" + dongia + "', '" + total + "', CONVERT( Datetime, GETDATE() ,103)," + id_doanh_nghiep + ")";
                cmd.CommandText = sql;
                recordsAffected = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
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

    public int them_moi_hoa_don_chi_tiet_hh(Int64 id_hd, Double dntt, int sh, string id_bang_gia)
    {
        Double dn = 0;
        Double sumDN = 0;
        DataTable BangGiaHH = lay_bang_gia_chi_tiet(id_bang_gia);
        int i = 0;
        int recordsAffected = 0;
        for (i = 0; i < BangGiaHH.Rows.Count; i++)
        {
            DataTable dtbtemp = lay_bang_gia(BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
            int tyle = Convert.ToInt32(BangGiaHH.Rows[i]["ty_le"].ToString().Trim());
            if (i != BangGiaHH.Rows.Count - 1)
            {
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
                {
                    dn = dntt * tyle / 100;
                    dn = Math.Round(dn, 0, MidpointRounding.AwayFromZero);
                    recordsAffected = them_moi_hoa_don_chi_tiet_mdk(id_hd, dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                    sumDN = sumDN + dn;
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "BT")
                {
                    dn = dntt * tyle / 100;
                    dn = Math.Round(dn, 0, MidpointRounding.AwayFromZero);
                    recordsAffected = them_moi_hoa_don_chi_tiet_sh(id_hd, dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                    sumDN = sumDN + dn;
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "HH")
                {
                    dn = dntt * tyle / 100;
                    dn = Math.Round(dn, 0, MidpointRounding.AwayFromZero);
                    recordsAffected = them_moi_hoa_don_chi_tiet_hh(id_hd, dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                    sumDN = sumDN + dn;
                }
            }
            else
            {
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
                {
                    dn = dntt - sumDN;
                    recordsAffected = them_moi_hoa_don_chi_tiet_mdk(id_hd, dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                    //sumDN = sumDN + dn;
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "BT")
                {
                    dn = dntt - sumDN;
                    recordsAffected = them_moi_hoa_don_chi_tiet_sh(id_hd, dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                    //sumDN = sumDN + dn;
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "HH")
                {
                    dn = dntt - sumDN;
                    recordsAffected = them_moi_hoa_don_chi_tiet_hh(id_hd, dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                    //sumDN = sumDN + dn;
                }

            }
        }
        return recordsAffected;
    }
    //Tính tiền điện tăng giá
    public Double tinh_tien_dien_adjusted(Double dntt, int sh, string id_bang_gia)
    {

        Double total = 0;
        DataTable BangGia = lay_bang_gia(id_bang_gia);
        if (BangGia.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
        {

            // dongia = Convert.ToDouble(BangGia.Rows[0]["don_gia"].ToString());
            // total = dntt * dongia;
            total = tinh_tien_dien_MDK_adjusted(dntt, sh, id_bang_gia);
        }
        if (BangGia.Rows[0]["loai_bg"].ToString().Trim() == "BT")
        {
            total = tinh_tien_dien_sh_adjusted(dntt, sh, id_bang_gia);

        }
        if (BangGia.Rows[0]["loai_bg"].ToString().Trim() == "HH")
        {
            total = tinh_tien_dien_HH_adjusted(dntt, sh, id_bang_gia);
        }
        //Làm tròn
        total = Math.Round(total, 0, MidpointRounding.AwayFromZero);
        return total;
    }
    // Tính tiền điện sinh hoạt điều chỉnh giá
    public Double tinh_tien_dien_sh_adjusted(Double dntt, int sh, string id_bang_gia)
    {
        Double total_old = 0;
        Double total_new = 0;

        Double dntt_old = Math.Round(15 * dntt / 30, MidpointRounding.AwayFromZero);
        Double dntt_new = dntt - dntt_old;

        DataTable BangGiaCT = lay_bang_gia_chi_tiet(id_bang_gia);


        Double[] muc_old = tinh_cs_6_muc_adjusted_old(dntt_old, sh);
        Double[] muc_new = tinh_cs_6_muc_adjusted_new(dntt_new, sh);

        for (int j = 0; j < muc_old.Length; j++)
        {
            total_old = total_old + (muc_old[j] * Convert.ToDouble(BangGiaCT.Rows[j]["gia_ko_vat_cu"].ToString()));
        }

        for (int j = 0; j < muc_new.Length; j++)
        {
            total_new = total_new + (muc_new[j] * Convert.ToDouble(BangGiaCT.Rows[j]["gia_ko_vat"].ToString()));
        }

        return total_old + total_new;
    }

    //Tính mức theo giá cũ
    public Double[] tinh_cs_6_muc_adjusted_old(Double sanluong, int sh)
    {
        Double[] muc = new Double[] { };
        if (sanluong > (200 * sh))
        {
            Double bac6 = sanluong - (200 * sh);
            muc = new Double[] { 25 * sh, 25 * sh, 50 * sh, 50 * sh, 50 * sh, bac6 };

        }
        else
        {
            if (sanluong > (150 * sh))
            {
                Double bac5 = sanluong - (150 * sh);
                muc = new Double[] { 25 * sh, 25 * sh, 50 * sh, 50 * sh, bac5 };
            }
            else
            {
                if (sanluong > (100 * sh))
                {
                    Double bac4 = sanluong - (100 * sh);
                    muc = new Double[] { 25 * sh, 25 * sh, 50 * sh, bac4 };
                }
                else
                {
                    if (sanluong > (50 * sh))
                    {
                        Double bac3 = sanluong - (50 * sh);
                        muc = new Double[] { (25 * sh), (25 * sh), bac3 };
                    }
                    else
                    {
                        if (sanluong > (25 * sh))
                        {
                            Double bac2 = sanluong - (25 * sh);
                            muc = new Double[] { (25 * sh), bac2 };
                        }
                        else
                        {
                            Double bac1 = sanluong - 0;
                            muc = new Double[] { bac1 };
                        }
                    }
                }
            }
        }
        return muc;
    }

    //Tính mức theo giá mới
    public Double[] tinh_cs_6_muc_adjusted_new(Double sanluong, int sh)
    {
        Double[] muc = new Double[] { };
        if (sanluong > (200 * sh))
        {
            Double bac6 = sanluong - (200 * sh);
            muc = new Double[] { 25 * sh, 25 * sh, 50 * sh, 50 * sh, 50 * sh, bac6 };

        }
        else
        {
            if (sanluong > (150 * sh))
            {
                Double bac5 = sanluong - (150 * sh);
                muc = new Double[] { 25 * sh, 25 * sh, 50 * sh, 50 * sh, bac5 };
            }
            else
            {
                if (sanluong > (100 * sh))
                {
                    Double bac4 = sanluong - (100 * sh);
                    muc = new Double[] { 25 * sh, 25 * sh, 50 * sh, bac4 };
                }
                else
                {
                    if (sanluong > (50 * sh))
                    {
                        Double bac3 = sanluong - (50 * sh);
                        muc = new Double[] { (25 * sh), (25 * sh), bac3 };
                    }
                    else
                    {
                        if (sanluong > (25 * sh))
                        {
                            Double bac2 = sanluong - (25 * sh);
                            muc = new Double[] { (25 * sh), bac2 };
                        }
                        else
                        {
                            Double bac1 = sanluong - 0;
                            muc = new Double[] { bac1 };
                        }
                    }
                }
            }
        }
        return muc;
    }
    //Tính tiền điện MDK tăng giá
    public Double tinh_tien_dien_MDK_adjusted(Double dntt, int sh, string id_bang_gia)
    {
        Double dongia = 0;
        Double dongia_cu = 0;
        Double total = 0;
        DataTable BangGia = lay_bang_gia(id_bang_gia);

        Double dntt_old = Math.Round(15 * dntt / 30, MidpointRounding.AwayFromZero);
        Double dntt_new = dntt - dntt_old;

        dongia = Convert.ToDouble(BangGia.Rows[0]["don_gia"].ToString());
        dongia_cu = Convert.ToDouble(BangGia.Rows[0]["don_gia_cu"].ToString());
        total = (dntt_new * dongia) + (dntt_old * dongia_cu);

        return total;

    }

    //Tính tiền điện hỗn hợp
    public Double tinh_tien_dien_HH_adjusted(Double dntt, int sh, string id_bang_gia)
    {
        Double total = 0;
        Double dn = 0;
        Double sumDN = 0;
        DataTable BangGiaHH = lay_bang_gia_chi_tiet(id_bang_gia);
        int i = 0;


        for (i = 0; i < BangGiaHH.Rows.Count; i++)
        {
            DataTable dtbtemp = lay_bang_gia(BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
            int tyle = Convert.ToInt32(BangGiaHH.Rows[i]["ty_le"].ToString().Trim());
            if (i != BangGiaHH.Rows.Count - 1)
            {
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
                {
                    dn = dntt * tyle / 100;
                    dn = Math.Round(dn, 0, MidpointRounding.AwayFromZero);
                    sumDN = sumDN + dn;
                    total = total + tinh_tien_dien_MDK_adjusted(dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "BT")
                {
                    dn = dntt * tyle / 100;
                    dn = Math.Round(dn, 0, MidpointRounding.AwayFromZero);
                    sumDN = sumDN + dn;
                    total = total + tinh_tien_dien_sh_adjusted(dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "HH")
                {
                    dn = dntt * tyle / 100;
                    dn = Math.Round(dn, 0, MidpointRounding.AwayFromZero);
                    sumDN = sumDN + dn;
                    total = total + tinh_tien_dien_HH_adjusted(dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                }
            }
            else
            {
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
                {
                    dn = dntt - sumDN;
                    total = total + tinh_tien_dien_MDK_adjusted(dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "BT")
                {
                    dn = dntt - sumDN;
                    total = total + tinh_tien_dien_sh_adjusted(dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "HH")
                {
                    dn = dntt - sumDN;
                    total = total + tinh_tien_dien_HH_adjusted(dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                }
            }

        }

        return total;
    }
    //Insert hoa_don_chi_tiet điện tăng giá

    public int them_moi_hoa_don_chi_tiet_adjusted(Int64 id_hd, Double dntt, int sh, string id_bang_gia)
    {
        int recordsAffected = 0;
        DataTable BangGia = lay_bang_gia(id_bang_gia);
        if (BangGia.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
        {
            recordsAffected = them_moi_hoa_don_chi_tiet_mdk_adjusted(id_hd, dntt, sh, id_bang_gia);

        }
        if (BangGia.Rows[0]["loai_bg"].ToString().Trim() == "BT")
        {
            recordsAffected = them_moi_hoa_don_chi_tiet_sh_adjusted(id_hd, dntt, sh, id_bang_gia);
        }
        if (BangGia.Rows[0]["loai_bg"].ToString().Trim() == "HH")
        {
            recordsAffected = them_moi_hoa_don_chi_tiet_hh_adjusted(id_hd, dntt, sh, id_bang_gia);
        }
        return recordsAffected;

    }
    public int them_moi_hoa_don_chi_tiet_mdk_adjusted(Int64 id_hd, Double dntt, int sh, string id_bang_gia)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        string id_doanh_nghiep = cnstr.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "";
        Double dongia = 0;
        Double total = 0;
        string diengiai = "";

        Double dntt_old = Math.Round(15 * dntt / 30, MidpointRounding.AwayFromZero);
        Double dntt_new = dntt - dntt_old;

        int recordsAffected = 0;
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.Parameters.Clear();
            DataTable BangGia = lay_bang_gia(id_bang_gia);

            //Giá cũ
            diengiai = BangGia.Rows[0]["ten_bang_gia"].ToString() + " giá cũ";
            dongia = Convert.ToDouble(BangGia.Rows[0]["don_gia_cu"].ToString());
            total = dntt_old * dongia;
            sql = "insert into hoa_don_chi_tiet(id_hoa_don,dong,dien_giai,so_luong,don_gia,thanh_tien,ngay_nhap,id_doanh_nghiep)";
            sql = sql + " values(" + id_hd + ",1,N'" + diengiai + "'," + dntt_old + ",'" + dongia + "', '" + total + "', CONVERT( Datetime, GETDATE() ,103)," + id_doanh_nghiep + ")";

            cmd.CommandText = sql;
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            //Giá mới
            diengiai = BangGia.Rows[0]["ten_bang_gia"].ToString() + " giá mới"; ;
            dongia = Convert.ToDouble(BangGia.Rows[0]["don_gia"].ToString());
            total = dntt_new * dongia;
            sql = "insert into hoa_don_chi_tiet(id_hoa_don,dong,dien_giai,so_luong,don_gia,thanh_tien,ngay_nhap,id_doanh_nghiep)";
            sql = sql + " values(" + id_hd + ",2,N'" + diengiai + "'," + dntt_new + ",'" + dongia + "', '" + total + "', CONVERT( Datetime, GETDATE() ,103)," + id_doanh_nghiep + ")";

            cmd.CommandText = sql;
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();


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
    public int them_moi_hoa_don_chi_tiet_sh_adjusted(Int64 id_hd, Double dntt, int sh, string id_bang_gia)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        string id_doanh_nghiep = cnstr.get_iddoanhnghiep(HttpContext.Current.User.Identity.Name.ToString());
        string sql = "";
        Double dongia = 0;
        Double total = 0;
        string diengiai = "";
        int recordsAffected = 0;

        Double dntt_old = Math.Round(15 * dntt / 30, MidpointRounding.AwayFromZero);
        Double dntt_new = dntt - dntt_old;

        DataTable BangGia = lay_bang_gia_chi_tiet(id_bang_gia);
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.Parameters.Clear();
            Double[] muc_old = tinh_cs_6_muc_adjusted_old(dntt_old, sh);
            Double[] muc_new = tinh_cs_6_muc_adjusted_new(dntt_new, sh);

            Double[] dongiamuc = new Double[] { };
            int j = 0;
            for (j = 0; j < muc_old.Length; j++)
            {
                diengiai = BangGia.Rows[j]["muc_thu"].ToString();
                dongia = Convert.ToDouble(BangGia.Rows[j]["gia_ko_vat_cu"].ToString());
                total = muc_old[j] * dongia;
                sql = "insert into hoa_don_chi_tiet(id_hoa_don,dong,dien_giai,so_luong,don_gia,thanh_tien,ngay_nhap,id_doanh_nghiep)";
                sql = sql + " values(" + id_hd + "," + (j + 1) + ",N'" + diengiai + "','" + muc_old[j] + "','" + dongia + "', '" + total + "', CONVERT( Datetime, GETDATE() ,103)," + id_doanh_nghiep + ")";
                cmd.CommandText = sql;
                recordsAffected = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }

            //Giá mới
            int k = muc_old.Length;
            j = 0;
            for (j = 0; j < muc_new.Length; j++)
            {
                diengiai = BangGia.Rows[j]["muc_thu"].ToString();
                dongia = Convert.ToDouble(BangGia.Rows[j]["gia_ko_vat"].ToString());
                total = muc_new[j] * dongia;
                sql = "insert into hoa_don_chi_tiet(id_hoa_don,dong,dien_giai,so_luong,don_gia,thanh_tien,ngay_nhap,id_doanh_nghiep)";
                sql = sql + " values(" + id_hd + "," + (j + k + 1) + ",N'" + diengiai + "','" + muc_new[j] + "','" + dongia + "', '" + total + "', CONVERT( Datetime, GETDATE() ,103)," + id_doanh_nghiep + ")";
                cmd.CommandText = sql;
                recordsAffected = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
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

    public int them_moi_hoa_don_chi_tiet_hh_adjusted(Int64 id_hd, Double dntt, int sh, string id_bang_gia)
    {
        Double dn = 0;
        Double sumDN = 0;
        DataTable BangGiaHH = lay_bang_gia_chi_tiet(id_bang_gia);
        int i = 0;
        int recordsAffected = 0;

        Double dntt_old = Math.Round(15* dntt / 30, MidpointRounding.AwayFromZero);
        Double dntt_new = dntt - dntt_old;

        for (i = 0; i < BangGiaHH.Rows.Count; i++)
        {
            DataTable dtbtemp = lay_bang_gia(BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
            int tyle = Convert.ToInt32(BangGiaHH.Rows[i]["ty_le"].ToString().Trim());
            if (i != BangGiaHH.Rows.Count - 1)
            {
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
                {
                    dn = dntt * tyle / 100;
                    dn = Math.Round(dn, 0, MidpointRounding.AwayFromZero);
                    recordsAffected = them_moi_hoa_don_chi_tiet_mdk_adjusted(id_hd, dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                    sumDN = sumDN + dn;
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "BT")
                {
                    dn = dntt * tyle / 100;
                    dn = Math.Round(dn, 0, MidpointRounding.AwayFromZero);
                    recordsAffected = them_moi_hoa_don_chi_tiet_sh_adjusted(id_hd, dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                    sumDN = sumDN + dn;
                }
            }
            else
            {
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "MDK")
                {
                    dn = dntt - sumDN;
                    recordsAffected = them_moi_hoa_don_chi_tiet_mdk_adjusted(id_hd, dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                    //sumDN = sumDN + dn;
                }
                if (dtbtemp.Rows[0]["loai_bg"].ToString().Trim() == "BT")
                {
                    dn = dntt - sumDN;
                    recordsAffected = them_moi_hoa_don_chi_tiet_sh_adjusted(id_hd, dn, sh, BangGiaHH.Rows[i]["id_bang_gia_ty_le"].ToString().Trim());
                    //sumDN = sumDN + dn;
                }

            }
        }
        return recordsAffected;
    }

}