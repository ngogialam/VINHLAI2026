using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for clsDonvi
/// </summary>

public class clsBaocao
{
    public string[] TINH_BAC_DIEN_SH(double sanluong, int sh)
    {
        string[] muc = new string[] { };
        if (sanluong > (400 * sh))
        {
            string bac6 = (sanluong - (400 * sh)).ToString();
            muc = new string[] { (50 * sh).ToString(), (50 * sh).ToString(), (100 * sh).ToString(), (100 * sh).ToString(), (100 * sh).ToString(), bac6 };

        }
        else if (sanluong > (300 * sh))
        {
            string bac5 = (sanluong - (300 * sh)).ToString();
            muc = new string[] { (50 * sh).ToString(), (50 * sh).ToString(), (100 * sh).ToString(), (100 * sh).ToString(), bac5, "0" };
        }
        else if (sanluong > (200 * sh))
        {
            string bac4 = (sanluong - (200 * sh)).ToString();
            muc = new string[] { (50 * sh).ToString(), (50 * sh).ToString(), (100 * sh).ToString(), bac4, "0", "0" };
        }
        else if (sanluong > (100 * sh))
        {
            string bac3 = (sanluong - (100 * sh)).ToString();
            muc = new string[] { (50 * sh).ToString(), (50 * sh).ToString(), bac3, "0", "0", "0" };
        }
        else if (sanluong > (50 * sh))
        {
            string bac2 = (sanluong - (50 * sh)).ToString();
            muc = new string[] { (50 * sh).ToString(), bac2, "0", "0", "0", "0" };
        }
        else
        {
            string bac1 = (sanluong - 0).ToString();
            muc = new string[] { bac1, "0", "0", "0", "0", "0" };
        }


        return muc;

    }

    public DataTable get_tram_bien_ap()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select id_tram_bien_ap, ten_tram_bien_ap from tram_bien_ap where trang_thai = 1 ORDER BY id_tram_bien_ap";
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

    public DataTable get_khu()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select id_khu, ten_khu from dm_khu order by id_khu";
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

    public DataTable get_bang_gia_dien()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select id_bang_gia,ten_bang_gia from bang_gia_dien where kich_hoat = 1 order by id_bang_gia ";
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

    public DataTable get_bang_gia_dien_theo_loai_bang_gia(string loaiBG)
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = string.Format("select id_bang_gia, ten_bang_gia from bang_gia_dien where kich_hoat = 1 and loai_bg = '{0}' order by id_bang_gia", loaiBG);
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

    public DataTable get_bang_gia_dien_theo_loai_bang_gia_with_none(string loaiBG)
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = string.Format("select '0' as id_bang_gia, N'-- None --' as ten_bang_gia union all select id_bang_gia, ten_bang_gia from bang_gia_dien where kich_hoat = 1 and loai_bg = '{0}' order by id_bang_gia", loaiBG);
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

    public DataTable get_nam()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select id,nam from dm_nam  order by id desc";
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

    public DataTable SELECT_SAN_LUONG_BIA(string tu_ngay, string den_ngay, int id_dia_ban)
    {
        string sql = "";
        tu_ngay = tu_ngay + " 00:00:00";
        den_ngay = den_ngay + " 23:59:59";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_dia_ban == 0)
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) AS stt,a.ma_kh,b.ten_kh,b.dia_chi,b.nam_bh,b.so_dt,a.ca, ";
            sql = sql + "sum(a.tong_bh) as tong_bh,sum(a.tong_bk2) as tong_bk2,sum(a.tong_bk1) as tong_bk1,sum(a.tong_bc) as tong_bc, c.ten_dia_ban ";
            sql = sql + " from hoa_don a,khach_hang b,dm_dia_ban c ";
            sql = sql + " where a.ma_kh=b.ma_kh and (a.tong_bh >0 or a.tong_bc>0 or a.tong_bk1>0 or a.tong_bk2>0) ";
            sql = sql + " and a.ngay_nhap  >= CONVERT(datetime,'" + tu_ngay + "') AND  a.ngay_nhap <= CONVERT(datetime,'" + den_ngay + "') ";
            sql = sql + " and a.trangthai_id=1 and b.id_dia_ban=c.id_dia_ban";// 0 la hoa don huy
            sql = sql + " group by a.ma_kh,b.ten_kh,b.dia_chi,b.nam_bh,b.so_dt,a.ca,c.ten_dia_ban";
            sql = sql + " order by stt asc";
        }
        else
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) AS stt,a.ma_kh,b.ten_kh,b.dia_chi,b.nam_bh,b.so_dt,a.ca, ";
            sql = sql + "sum(a.tong_bh) as tong_bh,sum(a.tong_bc) as tong_bc,sum(a.tong_bk1) as tong_bk1,sum(a.tong_bk2) as tong_bk2, c.ten_dia_ban ";
            sql = sql + " from hoa_don a,khach_hang b,dm_dia_ban c ";
            sql = sql + " where a.ma_kh=b.ma_kh and (a.tong_bh >0 or a.tong_bc>0 or a.tong_bk1>0 or a.tong_bk2>0) ";
            sql = sql + " and a.ngay_nhap  >= CONVERT(datetime,'" + tu_ngay + "') AND  a.ngay_nhap <= CONVERT(datetime,'" + den_ngay + "')";
            sql = sql + " and a.trangthai_id=1 and b.id_dia_ban=c.id_dia_ban";// 0 la hoa don huy
            sql = sql + " and b.id_dia_ban=" + id_dia_ban + "  ";
            sql = sql + " group by a.ma_kh,b.ten_kh,b.dia_chi,b.nam_bh,b.so_dt,a.ca,c.ten_dia_ban ";
            sql = sql + " order by stt asc";

        }
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

    public string CheckThoiDiem()
    {
        string mua = "MuaHe";
        int nam = DateTime.Now.Year;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        cmd.CommandText = "SELECT IIF(GETDATE()>='" + nam + "-04-16 00:00:00' and GETDATE()<='" + nam + "-10-16 00:00:00','MuaHe', 'MuaDong') as thoi_diem";
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataSet dts = new DataSet();
        myConn.Open();
        myData.Fill(dts);
        myData.Dispose();
        cmd.Parameters.Clear();
        cmd.Connection.Close();
        myConn.Close();
        mua = dts.Tables[0].Rows[0]["thoi_diem"].ToString();
        return mua;

    }

    public string CheckCongTo(string ma_kh)
    {
        string so_luong = "0";
        int nam = DateTime.Now.Year;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        cmd.CommandText = "select count(*) as so_luong, ma_kh from dm_cong_to where ma_kh='" + ma_kh.Trim() + "' group by ma_kh ";
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataSet dts = new DataSet();
        myConn.Open();
        myData.Fill(dts);
        myData.Dispose();
        cmd.Parameters.Clear();
        cmd.Connection.Close();
        myConn.Close();
        so_luong = dts.Tables[0].Rows[0]["so_luong"].ToString();
        return so_luong;

    }


    public DataTable SELECT_CHOT_CONG_TO(string id_tram_bien_ap, int id_khu, int id_thoi_gian, string ky_hd)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_tram_bien_ap == "0")
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,month(ngay_nhap) as Thang, year(ngay_nhap) as Nam,b.ma_kh,b.ten_kh,b.dia_chi,a.ma_cong_to,a.chi_so_moi  ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";
        }
        else
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,month(ngay_nhap) as Thang, year(ngay_nhap) as Nam,b.ma_kh,b.ten_kh,b.dia_chi,a.ma_cong_to,a.chi_so_moi  ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + " and b.id_tram_bien_ap='" + id_tram_bien_ap + "' ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";
        }
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

    public DataTable SELECT_CHOT_CONG_TO_ALL(string id_tram_bien_ap, int id_khu, string nam, string id_doanh_nghiep)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_tram_bien_ap == "0")
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,month(ngay_nhap) as Thang, year(ngay_nhap) as Nam,b.ma_kh,b.ten_kh,b.dia_chi,a.ma_cong_to,a.chi_so_moi  ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh and a.trang_thai=2 ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            sql = sql + " and SUBSTRING(ky_hd,4,4)='" + nam + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";
        }
        else
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,month(ngay_nhap) as Thang, year(ngay_nhap) as Nam,b.ma_kh,b.ten_kh,b.dia_chi,a.ma_cong_to,null as chi_so_moi  ";
            sql = sql + " from dm_cong_to a,khach_hang b,dm_khu c,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and b.id_tram_bien_ap='" + id_tram_bien_ap + "' ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            sql = sql + " and SUBSTRING(ky_hd,4,4)='" + nam + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";

        }
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

    public DataTable SELECT_CHOT_CONG_TO_TRANG(string id_tram_bien_ap, int id_khu, string nam, string id_doanh_nghiep)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_tram_bien_ap == "0")
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY m.ma_kh ASC) as stt,ma_kh,ten_kh,dia_chi,cot_dien_so,ma_cong_to from ( select b.thu_tu,b.ma_kh,b.ten_kh,b.dia_chi,b.cot_dien_so,a.ma_cong_to ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh and a.trang_thai=2 ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            // sql = sql + " and SUBSTRING(ky_hd,4,4)='" + nam + "'  ";
            //sql = sql + " and b.trang_thai=1 ";
            sql = sql + " group by b.thu_tu,b.ma_kh,b.ten_kh,b.dia_chi,b.cot_dien_so,a.ma_cong_to ";
            sql = sql + " ) m  order by m.thu_tu ";

        }
        else
        {
            //sql = "select ROW_NUMBER() OVER(ORDER BY m.ma_kh ASC) as stt,ma_kh,ten_kh,dia_chi,cot_dien_so,ma_cong_to from ( select b.thu_tu,b.ma_kh,b.ten_kh,b.dia_chi,b.cot_dien_so,a.ma_cong_to ";
            //sql = sql + " from hoa_don a,khach_hang b,dm_khu c,tram_bien_ap e ";
            //sql = sql + " where a.ma_kh=b.ma_kh and a.trang_thai=2 ";
            //sql = sql + " and b.id_khu=c.id_khu ";
            //sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            //sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            //sql = sql + " and b.id_tram_bien_ap='" + id_tram_bien_ap + "' ";
            //sql = sql + " and c.id_khu=" + id_khu + "  ";
            ////sql = sql + " and SUBSTRING(ky_hd,4,4)='" + nam + "'  ";
            //sql = sql + " and b.trang_thai=1 ";
            //sql = sql + " group by b.thu_tu,b.ma_kh,b.ten_kh,b.dia_chi,b.cot_dien_so,a.ma_cong_to ";
            //sql = sql + " ) m  order by m.thu_tu ";
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.cot_dien_so,a.ma_cong_to  ";
            sql = sql + " from dm_cong_to a,khach_hang b,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh and  b.id_tram_bien_ap=e.id_tram_bien_ap and b.id_tram_bien_ap='" + id_tram_bien_ap + "' ";
            sql = sql + " order by b.thu_tu ";

        }
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

    public double SELECT_CHOT_CONG_TO_THEO_MAKH(string ma_ct, string thang, string nam)
    {
        string sql = "";
        double chi_so_cong_to = 0;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        string ky_hd = thang + "/" + nam;

        //sql = "select b.ma_kh,b.ten_kh,b.dia_chi,a.ma_cong_to,a.chi_so_moi  ";
        //sql = sql + " from hoa_don a,khach_hang b,dm_khu c,tram_bien_ap e ";
        //sql = sql + " where a.ma_kh=b.ma_kh ";
        //sql = sql + " and b.id_khu=c.id_khu ";
        //sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
        //sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
        //sql = sql + " and b.ma_kh='" + ma_kh + "'  ";
        //sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";
        sql = "select cs_moi as chi_so_moi from chi_so_cong_to where ";
        sql = sql + " ky='" + ky_hd + "'  ";
        sql = sql + " and ma_cong_to='" + ma_ct + "'  ";
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

        if (dts.Tables[0].Rows.Count >= 1)
            if (dts.Tables[0].Rows[0]["chi_so_moi"] != DBNull.Value)
            {
                chi_so_cong_to = double.Parse(dts.Tables[0].Rows[0]["chi_so_moi"].ToString());
            }
            else
            {
                chi_so_cong_to = 0;
            }
        else
            chi_so_cong_to = 0;

        return chi_so_cong_to;
    }

    public double SELECT_DIEN_NANG_TT(string ma_kh, string thang, string nam)
    {
        string sql = "";
        double dien_nang_tt = 0;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        string ky_hd = thang + "/" + nam;

        sql = "select b.ma_kh,b.ten_kh,b.dia_chi,a.ma_cong_to,a.dien_nang_tt  ";
        sql = sql + " from hoa_don a,khach_hang b,dm_khu c,tram_bien_ap e ";
        sql = sql + " where a.ma_kh=b.ma_kh ";
        sql = sql + " and b.id_khu=c.id_khu ";
        sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
        sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
        sql = sql + " and b.ma_kh='" + ma_kh + "'  ";
        sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";

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

        if (dts.Tables[0].Rows.Count >= 1)
            dien_nang_tt = double.Parse(dts.Tables[0].Rows[0]["dien_nang_tt"].ToString());
        else
            dien_nang_tt = 0;

        return dien_nang_tt;
    }

    public DataTable SELECT_KHACH_HANG_THEO_CAC_DK(string id_tram_bien_ap, int id_khu, int id_bang_gia_dien, string ky_hd, string id_doanh_nghiep)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_tram_bien_ap == "0")
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2 ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            sql = sql + " and d.id_bang_gia=" + id_bang_gia_dien + "  ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";

        }
        else
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2 ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            sql = sql + " and d.id_bang_gia=" + id_bang_gia_dien + "  ";
            sql = sql + " and b.id_tram_bien_ap='" + id_tram_bien_ap + "' ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";
        }
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


    public DataTable SELECT_KHACH_HANG_CSCK_LON(string id_tram_bien_ap, int id_khu, int id_bang_gia_dien, string ky_hd, double chi_so, string id_doanh_nghiep)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_tram_bien_ap == "0")
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2  ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " and a.chi_so_moi>='" + chi_so + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";

        }
        else
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2 ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and b.id_tram_bien_ap='" + id_tram_bien_ap + "' ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " and a.chi_so_moi>='" + chi_so + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";
        }
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

    public DataTable SELECT_KHACH_HANG_TIEU_THU_LON(string id_tram_bien_ap, int id_khu, int id_bang_gia_dien, string ky_hd, double chi_so, string id_doanh_nghiep)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_tram_bien_ap == "0")
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2 ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " and a.dien_nang_tt>='" + chi_so + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";

        }
        else
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2 ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and b.id_tram_bien_ap='" + id_tram_bien_ap + "' ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " and a.dien_nang_tt>='" + chi_so + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";
        }
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

    public DataTable SELECT_KHACH_HANG_TIEU_THU_NHO(string id_tram_bien_ap, int id_khu, int id_bang_gia_dien, string ky_hd, double chi_so, string id_doanh_nghiep)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_tram_bien_ap == "0")
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2 ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " and a.dien_nang_tt<='" + chi_so + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";

        }
        else
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2  ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and b.id_tram_bien_ap='" + id_tram_bien_ap + "' ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " and a.dien_nang_tt<='" + chi_so + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";
        }
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


    public DataTable SELECT_KHACH_HANG_KSD(string id_tram_bien_ap, int id_khu, int id_bang_gia_dien, string ky_hd, string id_doanh_nghiep)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_tram_bien_ap == "0")
        {
            //sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue ";
            //sql = sql + " from hoa_don a,khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e ";
            //sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2 ";
            //sql = sql + " and b.id_khu=c.id_khu ";
            //sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            //sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            //sql = sql + " and c.id_khu=" + id_khu + "  ";
            //sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            //sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            //sql = sql + " and a.chi_so_moi is null  ";
            //sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";

            sql = " select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,cs.cs_cu as chi_so_cu,cs.cs_moi as chi_so_moi, 0 as dien_nang_tt, 0 as tong_tien_sau_thue ";
            sql = sql + " from chi_so_cong_to cs,dm_cong_to a, khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e  ";
            sql = sql + " where a.ma_kh=b.ma_kh and  b.id_khu=c.id_khu ";
            sql = sql + " and b.id_bang_gia = d.id_bang_gia  and b.id_tram_bien_ap=e.id_tram_bien_ap";
            sql = sql + " and a.ma_cong_to =cs.ma_cong_to and (cs.cs_cu=cs.cs_moi  )";
            sql = sql + " and cs.ky='" + ky_hd + "' order by b.id_tram_bien_ap";


        }
        else
        {
            sql = " select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,cs.cs_cu as chi_so_cu,cs.cs_moi as chi_so_moi, 0 as dien_nang_tt, 0 as tong_tien_sau_thue ";
            sql = sql + " from chi_so_cong_to cs,dm_cong_to a, khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e  ";
            sql = sql + " where a.ma_kh=b.ma_kh and  b.id_khu=c.id_khu ";
            sql = sql + " and b.id_bang_gia = d.id_bang_gia  and b.id_tram_bien_ap=e.id_tram_bien_ap";
            sql = sql + " and a.ma_cong_to =cs.ma_cong_to and (cs.cs_cu=cs.cs_moi  )";
            sql = sql + " and b.id_tram_bien_ap='" + id_tram_bien_ap + "' ";
            sql = sql + " and cs.ky='" + ky_hd + "' order by b.id_tram_bien_ap";
        }
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

    public DataTable SELECT_KHACH_HANG_KPH_HD(string id_tram_bien_ap, int id_khu, int id_bang_gia_dien, string ky_hd, string id_doanh_nghiep)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_tram_bien_ap == "0")
        {
            //sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue ";
            //sql = sql + " from hoa_don a,khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e ";
            //sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2 ";
            //sql = sql + " and b.id_khu=c.id_khu ";
            //sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            //sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            //sql = sql + " and c.id_khu=" + id_khu + "  ";
            //sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            //sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            //sql = sql + " and a.chi_so_moi is null  ";
            //sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";

            sql = " select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,cs.cs_cu,cs.cs_moi, 0 as dien_nang_tt, 0 as tong_tien_sau_thue ";
            sql = sql + " from chi_so_cong_to cs,dm_cong_to a, khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e  ";
            sql = sql + " where a.ma_kh=b.ma_kh and  b.id_khu=c.id_khu ";
            sql = sql + " and b.id_bang_gia = d.id_bang_gia  and b.id_tram_bien_ap=e.id_tram_bien_ap";
            sql = sql + " and a.ma_cong_to =cs.ma_cong_to and (cs.cs_cu=cs.cs_moi  )";
            sql = sql + " and cs.ky='" + ky_hd + "' order by b.id_tram_bien_ap";


        }
        else
        {
            sql = " select ROW_NUMBER() OVER(ORDER BY a.ma_kh ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,cs.cs_cu,cs.cs_moi, 0 as dien_nang_tt, 0 as tong_tien_sau_thue ";
            sql = sql + " from chi_so_cong_to cs,dm_cong_to a, khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e  ";
            sql = sql + " where a.ma_kh=b.ma_kh and  b.id_khu=c.id_khu ";
            sql = sql + " and b.id_bang_gia = d.id_bang_gia  and b.id_tram_bien_ap=e.id_tram_bien_ap";
            sql = sql + " and a.ma_cong_to =cs.ma_cong_to and (cs.cs_cu=cs.cs_moi  )";
            sql = sql + " and b.id_tram_bien_ap='" + id_tram_bien_ap + "' ";
            sql = sql + " and cs.ky='" + ky_hd + "' order by b.id_tram_bien_ap";
        }
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

    public DataTable SELECT_BANG_KE_TIEN_DIEN1(string id_tram_bien_ap, string ky_hd, string id_doanh_nghiep)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_tram_bien_ap == "0")
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY b.thu_tu ASC) as stt,b.ma_kh,b.ten_kh,b.dien_thoai,b.dia_chi,b.so_ho,d.ten_viet_tat,a.ma_cong_to, a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue,a.id_bang_gia_dien,d.ten_viet_tat ";
            sql = sql + " from hoa_don a,khach_hang b,bang_gia_dien d,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh and a.trang_thai = 2 ";
            ///sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            //  sql = sql + " and c.id_khu=" + id_khu + "  ";
            //sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            //  sql = sql + " and b.id_tram_bien_ap='" + id_tram_bien_ap + "' ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " order by b.id_tram_bien_ap ";

        }
        else
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY b.thu_tu ASC) as stt,b.ma_kh,b.ten_kh,b.dien_thoai,b.dia_chi,b.so_ho,d.ten_viet_tat,a.ma_cong_to, a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue,a.id_bang_gia_dien,d.ten_viet_tat ";
            sql = sql + " from hoa_don a,khach_hang b,bang_gia_dien d,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh and a.trang_thai = 2 ";
            ///sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            //  sql = sql + " and c.id_khu=" + id_khu + "  ";
            //sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and b.id_tram_bien_ap='" + id_tram_bien_ap + "' ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " order by b.id_tram_bien_ap ";
        }
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

    public DataTable SELECT_BANG_KE_TIEN_DIEN(string id_tram_bien_ap, int id_khu, string ky_hd, string id_doanh_nghiep)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_tram_bien_ap == "0")
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY b.thu_tu ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,a.ma_cong_to,a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue,a.id_bang_gia_dien,d.ten_viet_tat ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh and a.trang_thai < 3 ";
            sql = sql + " and b.id_khu=c.id_khu   ";
            sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            // sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";

        }
        else
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY b.thu_tu ASC) as stt,b.ma_kh,b.ten_kh,b.dia_chi,b.so_ho,d.ten_viet_tat,a.ma_cong_to, a.chi_so_cu,a.chi_so_moi,a.dien_nang_tt,a.tong_tien_sau_thue,a.id_bang_gia_dien,d.ten_viet_tat ";
            sql = sql + " from hoa_don a,khach_hang b,dm_khu c,bang_gia_dien d,tram_bien_ap e ";
            sql = sql + " where a.ma_kh=b.ma_kh and a.trang_thai < 3 ";
            sql = sql + " and b.id_khu=c.id_khu ";
            sql = sql + " and a.id_bang_gia_dien = d.id_bang_gia ";
            sql = sql + " and b.id_tram_bien_ap=e.id_tram_bien_ap ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            //sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and b.id_tram_bien_ap='" + id_tram_bien_ap + "' ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " order by b.id_tram_bien_ap, c.id_khu ";
        }
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


    public DataTable SELECT_SAN_LUONG_THEO_BANG_GIA_DIEN(int id_khu, string ky_hd, string id_doanh_nghiep)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_khu == 0)
        {

            sql = " select ROW_NUMBER() OVER(ORDER BY d.ten_bang_gia ASC) as stt,";
            sql = sql + " d.id_bang_gia as ma,d.ten_bang_gia as ten,sum(a.dien_nang_tt) as dien_nang_tt ,sum(a.tong_tien_truoc_thue) as tong_tien_truoc_thue , ";
            sql = sql + " sum(a.thue_gtgt) as thue_gtgt ,sum(a.tong_tien_sau_thue) as tong_tien_sau_thue ";
            sql = sql + "   from hoa_don a,khach_hang b,dm_khu c, bang_gia_dien d ";
            sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2 ";
            sql = sql + " and b.id_khu=c.id_khu  ";
            sql = sql + " and a.id_bang_gia_dien=d.id_bang_gia ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " group by d.id_bang_gia,d.ten_bang_gia ";
            sql = sql + " order by d.ten_bang_gia ";

        }
        else
        {
            sql = " select ROW_NUMBER() OVER(ORDER BY d.ten_bang_gia ASC) as stt,";
            sql = sql + " d.id_bang_gia as ma,d.ten_bang_gia as ten,sum(a.dien_nang_tt) as dien_nang_tt,sum(a.tong_tien_truoc_thue) as tong_tien_truoc_thue , ";
            sql = sql + " sum(a.thue_gtgt) as thue_gtgt ,sum(a.tong_tien_sau_thue) as tong_tien_sau_thue ";
            sql = sql + "   from hoa_don a,khach_hang b,dm_khu c, bang_gia_dien d ";
            sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2 ";
            sql = sql + " and b.id_khu=c.id_khu  ";
            sql = sql + " and a.id_bang_gia_dien=d.id_bang_gia ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + " and c.id_khu=" + id_khu + "  ";
            sql = sql + " and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " group by d.id_bang_gia,d.ten_bang_gia ";
            sql = sql + " order by d.ten_bang_gia ";
        }
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
    public DataTable BAO_CAO_TINH_HINH_SU_DUNG(string ky_hd, string id_doanh_nghiep)
    {
        string sql = "";
        DataSet ds = new DataSet();
        SqlConnection con = new clsConnect().ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con; //database connection
        cmd.CommandText = "TEST"; //  Stored procedure name
        cmd.CommandType = CommandType.StoredProcedure; // set it to stored proc
        //add parameter if necessary
        cmd.Parameters.Add("@ky_hd", SqlDbType.VarChar).Value = ky_hd;

        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(ds);
        return ds.Tables[0];
        // return dts;    
    }

    public DataTable SELECT_SAN_LUONG_THEO_TRAM_BA(int id_khu, string ky_hd, string id_doanh_nghiep)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_khu == 0)
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY d.ten_tram_bien_ap ASC) as stt, ";
            sql = sql + " d.id_tram_bien_ap as ma, d.ten_tram_bien_ap as ten,sum(a.dien_nang_tt) as dien_nang_tt,sum(a.tong_tien_truoc_thue) as tong_tien_truoc_thue , ";
            sql = sql + " sum(a.thue_gtgt) as thue_gtgt ,sum(a.tong_tien_sau_thue) as tong_tien_sau_thue ";
            sql = sql + "  from hoa_don a,khach_hang b,dm_khu c, tram_bien_ap d ";
            sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2 ";
            sql = sql + " and b.id_khu=c.id_khu  ";
            sql = sql + " and b.id_tram_bien_ap=d.id_tram_bien_ap ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + "  and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " group by d.id_tram_bien_ap,d.ten_tram_bien_ap ";
            sql = sql + " order by d.ten_tram_bien_ap ";
        }
        else
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY d.ten_tram_bien_ap ASC) as stt, ";
            sql = sql + " d.id_tram_bien_ap as ma, d.ten_tram_bien_ap as ten,sum(a.dien_nang_tt) as dien_nang_tt,sum(a.tong_tien_truoc_thue) as tong_tien_truoc_thue , ";
            sql = sql + " sum(a.thue_gtgt) as thue_gtgt ,sum(a.tong_tien_sau_thue) as tong_tien_sau_thue ";
            sql = sql + "  from hoa_don a,khach_hang b,dm_khu c, tram_bien_ap d ";
            sql = sql + " where a.ma_kh=b.ma_kh  and a.trang_thai=2 ";
            sql = sql + " and b.id_khu=c.id_khu  ";
            sql = sql + " and b.id_tram_bien_ap=d.id_tram_bien_ap ";
            sql = sql + "   and a.ma_kh in ( select ma_kh from khach_hang where id_doanh_nghiep=" + id_doanh_nghiep + ")  ";
            sql = sql + "  and c.id_khu=" + id_khu + "  ";
            sql = sql + "  and a.ky_hd='" + ky_hd + "'  ";
            sql = sql + " group by d.id_tram_bien_ap,d.ten_tram_bien_ap ";
            sql = sql + " order by d.ten_tram_bien_ap ";
        }
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
    public DataTable SELECT_SAN_LUONG_THEO_CA(string tu_ngay, string den_ngay, int id_dia_ban)
    {
        string sql = "";
        string thoi_diem = CheckThoiDiem();
        if (thoi_diem == "MuaHe")// mùa hè chốt từ 9h tối
        {
            tu_ngay = tu_ngay + " 21:00:00";
            den_ngay = den_ngay + " 20:59:59";
        }
        else//mùa đông chốt từ 7h tối
        {
            tu_ngay = tu_ngay + " 19:00:00";
            den_ngay = den_ngay + " 18:59:59";
        }


        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_dia_ban == 0)
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_hang ASC) AS stt,a.ma_hang,b.ten_hang,c.ca, sum(a.so_luong) as tong_sl ";
            sql = sql + " from hoa_don_chi_tiet a,dm_hang_hoa b,hoa_don c ";
            sql = sql + " where a.ma_hang=b.ma_hang and c.ma_hd=a.ma_hd and  c.trangthai_id=1 ";
            sql = sql + " and a.ngay_nhap  >= DATEADD(day,-1,CONVERT(datetime,'" + tu_ngay + "')) AND  a.ngay_nhap <= CONVERT(datetime,'" + den_ngay + "')";
            sql = sql + " group by a.ma_hang,b.ten_hang,c.ca ";
            sql = sql + " order by c.ca ";

        }
        else
        {
            sql = "select ROW_NUMBER() OVER(ORDER BY a.ma_hang ASC) AS stt,a.ma_hang,b.ten_hang,c.ca, sum(a.so_luong) as tong_sl ";
            sql = sql + " from hoa_don_chi_tiet a,dm_hang_hoa b,hoa_don c ";
            sql = sql + " where a.ma_hang=b.ma_hang and c.ma_hd=a.ma_hd and c.trangthai_id=1 ";
            sql = sql + " and a.ngay_nhap  >= DATEADD(day,-1,CONVERT(datetime,'" + tu_ngay + "')) AND  a.ngay_nhap <= CONVERT(datetime,'" + den_ngay + "')";
            sql = sql + " and b.id_dia_ban=" + id_dia_ban + " ";
            sql = sql + " group by a.ma_hang,b.ten_hang,c.ca ";
            sql = sql + " order by c.ca ";
        }
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


    public DataTable SELECT_CHI_TIET_CA(string tu_ngay, string den_ngay, int ca)
    {
        string sql = "";
        string thoi_diem = CheckThoiDiem();
        if (thoi_diem == "MuaHe")// mùa hè chốt từ 9h tối
        {
            tu_ngay = tu_ngay + " 21:00:00";
            den_ngay = den_ngay + " 20:59:59";
        }
        else//mùa đông chốt từ 7h tối
        {
            tu_ngay = tu_ngay + " 19:00:00";
            den_ngay = den_ngay + " 18:59:59";
        }

        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (ca == 0)
        {
            sql = "select c.ma_hd,c.ca,d.ten_kh,d.so_dt,d.dia_chi, c.tong_bc,c.tong_bh,c.tong_bk1,c.tong_bk2 ";
            sql = sql + "from hoa_don c ,khach_hang d ";
            sql = sql + " where c.trangthai_id=1 and c.ma_kh=d.ma_kh  ";
            sql = sql + " and c.ngay_nhap  >= DATEADD(day,-1,CONVERT(datetime,'" + tu_ngay + "')) AND  c.ngay_nhap <= CONVERT(datetime,'" + den_ngay + "')";
            // sql = sql +" and ca="+ ca +" ";
            sql = sql + " order by c.ma_hd  ";

        }
        else
        {
            sql = "select c.ma_hd,c.ca,d.ten_kh,d.so_dt,d.dia_chi, c.tong_bc,c.tong_bh,c.tong_bk1,c.tong_bk2 ";
            sql = sql + "from hoa_don c ,khach_hang d ";
            sql = sql + " where c.trangthai_id=1 and c.ma_kh=d.ma_kh  ";
            sql = sql + " and c.ngay_nhap  >= DATEADD(day,-1,CONVERT(datetime,'" + tu_ngay + "')) AND  c.ngay_nhap <= CONVERT(datetime,'" + den_ngay + "')";
            sql = sql + " and c.ca=" + ca + " ";
            sql = sql + " order by c.ma_hd  ";
        }
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


    public DataTable SELECT_CHI_TIET_NAM(int id_dia_ban, int nam)
    {
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_dia_ban == 0)
        {
            sql = "select month(ngay_nhap) as Thang, year(ngay_nhap) as Nam, ";
            sql = sql + " a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt ,c.id_dia_ban,c.ten_dia_ban, ";
            sql = sql + " sum(a.tong_bh) as tong_bh,sum(a.tong_bk2) as tong_bk2,sum(a.tong_bk1) as tong_bk1,sum(a.tong_bc) as tong_bc ";
            sql = sql + " from hoa_don a,khach_hang b,dm_dia_ban c ";
            sql = sql + " where a.ma_kh=b.ma_kh and b.id_dia_ban=c.id_dia_ban ";
            sql = sql + " and year(ngay_nhap)=" + nam + " ";
            sql = sql + " group by a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt,c.id_dia_ban,c.ten_dia_ban,month(ngay_nhap) ,year(ngay_nhap) ";
            sql = sql + " order by a.ma_kh,c.ten_dia_ban ";
        }
        else
        {
            sql = "select month(ngay_nhap) as Thang, year(ngay_nhap) as Nam, ";
            sql = sql + " a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt ,c.id_dia_ban,c.ten_dia_ban, ";
            sql = sql + " sum(a.tong_bh) as tong_bh,sum(a.tong_bk2) as tong_bk2,sum(a.tong_bk1) as tong_bk1,sum(a.tong_bc) as tong_bc ";
            sql = sql + " from hoa_don a,khach_hang b,dm_dia_ban c ";
            sql = sql + " where a.ma_kh=b.ma_kh and b.id_dia_ban=c.id_dia_ban ";
            sql = sql + " and year(ngay_nhap)=" + nam + " ";
            sql = sql + " and c.id_dia_ban=" + id_dia_ban + " ";
            sql = sql + " group by a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt,c.id_dia_ban,c.ten_dia_ban,month(ngay_nhap) ,year(ngay_nhap) ";
            sql = sql + " order by a.ma_kh,c.ten_dia_ban ";
        }
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


    public double SELECT_SAN_LUONG_THANG_THEO_SP(int id_dia_ban, int ma_kh, int loai_san_pham, int nam, int thang)
    {
        double tong_san_luong = 0;
        string sql = "";
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (id_dia_ban == 0)// tinh tat ca
        {
            if (loai_san_pham == 0)//bia hoi
            {
                sql = " select N.tong_bh as tong_san_luong from ( ";
                sql = sql + "select month(ngay_nhap) as Thang, year(ngay_nhap) as Nam, ";
                sql = sql + " a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt ,c.id_dia_ban,c.ten_dia_ban, ";
                sql = sql + " sum(a.tong_bh) as tong_bh,sum(a.tong_bk2) as tong_bk2,sum(a.tong_bk1) as tong_bk1,sum(a.tong_bc) as tong_bc ";
                sql = sql + " from hoa_don a,khach_hang b,dm_dia_ban c ";
                sql = sql + " where a.ma_kh=b.ma_kh and b.id_dia_ban=c.id_dia_ban ";
                sql = sql + " and year(ngay_nhap)=" + nam + " ";
                sql = sql + " and month(ngay_nhap)=" + thang + " ";
                //sql = sql + " and c.id_dia_ban=" + id_dia_ban + " ";
                sql = sql + " group by a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt,c.id_dia_ban,c.ten_dia_ban,month(ngay_nhap) ,year(ngay_nhap) ";
                sql = sql + " ) N where N.ma_kh=" + ma_kh + " ";
            }
            else if (loai_san_pham == 1)//bia keg 2l
            {
                sql = " select N.tong_bk2 as tong_san_luong from ( ";
                sql = sql + "select month(ngay_nhap) as Thang, year(ngay_nhap) as Nam, ";
                sql = sql + " a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt ,c.id_dia_ban,c.ten_dia_ban, ";
                sql = sql + " sum(a.tong_bh) as tong_bh,sum(a.tong_bk2) as tong_bk2,sum(a.tong_bk1) as tong_bk1,sum(a.tong_bc) as tong_bc ";
                sql = sql + " from hoa_don a,khach_hang b,dm_dia_ban c ";
                sql = sql + " where a.ma_kh=b.ma_kh and b.id_dia_ban=c.id_dia_ban ";
                sql = sql + " and year(ngay_nhap)=" + nam + " ";
                sql = sql + " and month(ngay_nhap)=" + thang + " ";
                //sql = sql + " and c.id_dia_ban=" + id_dia_ban + " ";
                sql = sql + " group by a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt,c.id_dia_ban,c.ten_dia_ban,month(ngay_nhap) ,year(ngay_nhap) ";
                sql = sql + " ) N where N.ma_kh=" + ma_kh + " ";
            }
            else if (loai_san_pham == 2)//bia keg 1l
            {
                sql = " select N.tong_bk1 as tong_san_luong from ( ";
                sql = sql + "select month(ngay_nhap) as Thang, year(ngay_nhap) as Nam, ";
                sql = sql + " a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt ,c.id_dia_ban,c.ten_dia_ban, ";
                sql = sql + " sum(a.tong_bh) as tong_bh,sum(a.tong_bk2) as tong_bk2,sum(a.tong_bk1) as tong_bk1,sum(a.tong_bc) as tong_bc ";
                sql = sql + " from hoa_don a,khach_hang b,dm_dia_ban c ";
                sql = sql + " where a.ma_kh=b.ma_kh and b.id_dia_ban=c.id_dia_ban ";
                sql = sql + " and year(ngay_nhap)=" + nam + " ";
                sql = sql + " and month(ngay_nhap)=" + thang + " ";
                //sql = sql + " and c.id_dia_ban=" + id_dia_ban + " ";
                sql = sql + " group by a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt,c.id_dia_ban,c.ten_dia_ban,month(ngay_nhap) ,year(ngay_nhap) ";
                sql = sql + " ) N where N.ma_kh=" + ma_kh + " ";
            }
            else if (loai_san_pham == 3)//bia chai
            {
                sql = " select N.tong_bk1 as tong_san_luong from ( ";
                sql = sql + "select month(ngay_nhap) as Thang, year(ngay_nhap) as Nam, ";
                sql = sql + " a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt ,c.id_dia_ban,c.ten_dia_ban, ";
                sql = sql + " sum(a.tong_bh) as tong_bh,sum(a.tong_bk2) as tong_bk2,sum(a.tong_bk1) as tong_bk1,sum(a.tong_bc) as tong_bc ";
                sql = sql + " from hoa_don a,khach_hang b,dm_dia_ban c ";
                sql = sql + " where a.ma_kh=b.ma_kh and b.id_dia_ban=c.id_dia_ban ";
                sql = sql + " and year(ngay_nhap)=" + nam + " ";
                sql = sql + " and month(ngay_nhap)=" + thang + " ";
                //sql = sql + " and c.id_dia_ban=" + id_dia_ban + " ";
                sql = sql + " group by a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt,c.id_dia_ban,c.ten_dia_ban,month(ngay_nhap) ,year(ngay_nhap) ";
                sql = sql + " ) N where N.ma_kh=" + ma_kh + " ";
            }
            else// neu co san pham moi
            {
                tong_san_luong = 0;
            }

        }
        else// tinh theo tung dia ban
        {
            if (loai_san_pham == 0)//bia hoi
            {
                sql = " select N.tong_bh as tong_san_luong from ( ";
                sql = sql + "select month(ngay_nhap) as Thang, year(ngay_nhap) as Nam, ";
                sql = sql + " a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt ,c.id_dia_ban,c.ten_dia_ban, ";
                sql = sql + " sum(a.tong_bh) as tong_bh,sum(a.tong_bk2) as tong_bk2,sum(a.tong_bk1) as tong_bk1,sum(a.tong_bc) as tong_bc ";
                sql = sql + " from hoa_don a,khach_hang b,dm_dia_ban c ";
                sql = sql + " where a.ma_kh=b.ma_kh and b.id_dia_ban=c.id_dia_ban ";
                sql = sql + " and year(ngay_nhap)=" + nam + " ";
                sql = sql + " and month(ngay_nhap)=" + thang + " ";
                sql = sql + " and c.id_dia_ban=" + id_dia_ban + " ";
                sql = sql + " group by a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt,c.id_dia_ban,c.ten_dia_ban,month(ngay_nhap) ,year(ngay_nhap) ";
                sql = sql + " ) N where N.ma_kh=" + ma_kh + " ";
            }
            else if (loai_san_pham == 1)//bia keg 2l
            {
                sql = " select N.tong_bk2 as tong_san_luong from ( ";
                sql = sql + "select month(ngay_nhap) as Thang, year(ngay_nhap) as Nam, ";
                sql = sql + " a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt ,c.id_dia_ban,c.ten_dia_ban, ";
                sql = sql + " sum(a.tong_bh) as tong_bh,sum(a.tong_bk2) as tong_bk2,sum(a.tong_bk1) as tong_bk1,sum(a.tong_bc) as tong_bc ";
                sql = sql + " from hoa_don a,khach_hang b,dm_dia_ban c ";
                sql = sql + " where a.ma_kh=b.ma_kh and b.id_dia_ban=c.id_dia_ban ";
                sql = sql + " and year(ngay_nhap)=" + nam + " ";
                sql = sql + " and month(ngay_nhap)=" + thang + " ";
                sql = sql + " and c.id_dia_ban=" + id_dia_ban + " ";
                sql = sql + " group by a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt,c.id_dia_ban,c.ten_dia_ban,month(ngay_nhap) ,year(ngay_nhap) ";
                sql = sql + " ) N where N.ma_kh=" + ma_kh + " ";
            }
            else if (loai_san_pham == 2)//bia keg 1l
            {
                sql = " select N.tong_bk1 as tong_san_luong from ( ";
                sql = sql + "select month(ngay_nhap) as Thang, year(ngay_nhap) as Nam, ";
                sql = sql + " a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt ,c.id_dia_ban,c.ten_dia_ban, ";
                sql = sql + " sum(a.tong_bh) as tong_bh,sum(a.tong_bk2) as tong_bk2,sum(a.tong_bk1) as tong_bk1,sum(a.tong_bc) as tong_bc ";
                sql = sql + " from hoa_don a,khach_hang b,dm_dia_ban c ";
                sql = sql + " where a.ma_kh=b.ma_kh and b.id_dia_ban=c.id_dia_ban ";
                sql = sql + " and year(ngay_nhap)=" + nam + " ";
                sql = sql + " and month(ngay_nhap)=" + thang + " ";
                sql = sql + " and c.id_dia_ban=" + id_dia_ban + " ";
                sql = sql + " group by a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt,c.id_dia_ban,c.ten_dia_ban,month(ngay_nhap) ,year(ngay_nhap) ";
                sql = sql + " ) N where N.ma_kh=" + ma_kh + " ";
            }
            else if (loai_san_pham == 3)//bia chai
            {
                sql = " select N.tong_bk1 as tong_san_luong from ( ";
                sql = sql + "select month(ngay_nhap) as Thang, year(ngay_nhap) as Nam, ";
                sql = sql + " a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt ,c.id_dia_ban,c.ten_dia_ban, ";
                sql = sql + " sum(a.tong_bh) as tong_bh,sum(a.tong_bk2) as tong_bk2,sum(a.tong_bk1) as tong_bk1,sum(a.tong_bc) as tong_bc ";
                sql = sql + " from hoa_don a,khach_hang b,dm_dia_ban c ";
                sql = sql + " where a.ma_kh=b.ma_kh and b.id_dia_ban=c.id_dia_ban ";
                sql = sql + " and year(ngay_nhap)=" + nam + " ";
                sql = sql + " and month(ngay_nhap)=" + thang + " ";
                sql = sql + " and c.id_dia_ban=" + id_dia_ban + " ";
                sql = sql + " group by a.ma_kh,b.ten_kh,b.nam_bh,b.so_dt,c.id_dia_ban,c.ten_dia_ban,month(ngay_nhap) ,year(ngay_nhap) ";
                sql = sql + " ) N where N.ma_kh=" + ma_kh + " ";
            }
            else// neu co san pham moi
            {
                tong_san_luong = 0;
            }
        }
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
        if (dts.Tables[0].Rows.Count >= 1)
            tong_san_luong = double.Parse(dts.Tables[0].Rows[0]["tong_san_luong"].ToString());
        else
            tong_san_luong = 0;

        return tong_san_luong;
        // return dts;    
    }


    //===========================================================
    public DataSet SELECT_DANH_SACH_DON_VI()
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        cmd.CommandText = "select TEN_4 as TEN,DON_VI_ID from don_vi";
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataSet dts = new DataSet();
        //myConn.Open();
        //myData.Fill(dts);
        //myData.Dispose();
        //cmd.Parameters.Clear();
        //cmd.Connection.Close();
        //myConn.Close();

        return dts;
    }
    public Array SELECT_NGAY_GIO()
    {
        DateTime thisDay = DateTime.Today;
        string day = thisDay.AddDays(-7).ToString("yyyyMMdd");
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        cmd.CommandText = "select distinct ngay,gio from mane_solieu where ngay||trim(to_char(gio,'00'))=(select max(giomax) from (select distinct ngay||trim(to_char(gio,'00')) as giomax from mane_solieu where ngay > '" + day + "'))";
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataSet dts = new DataSet();
        myConn.Open();
        myData.Fill(dts);
        myData.Dispose();
        cmd.Parameters.Clear();
        cmd.Connection.Close();
        int gio = Int32.Parse(dts.Tables[0].Rows[0]["GIO"].ToString());
        string ngay = dts.Tables[0].Rows[0]["NGAY"].ToString();
        if (gio == 0)
        {
            gio = 23;
            string Sql = "select to_date(sysdate) as ngay from dual";
            cmd.Connection = myConn;
            cmd.CommandText = Sql;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myDate = new SqlDataAdapter(cmd);
            DataSet dts1 = new DataSet();
            myConn.Open();
            myDate.Fill(dts1);
            myDate.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            DateTime firstdate = Convert.ToDateTime(dts1.Tables[0].Rows[0]["NGAY"].ToString());
            ngay = firstdate.AddDays(-1).ToString("yyyyMMdd");

        }
        else
        {
            gio = gio - 1;
        }

        string[] ngaygio = new string[] { ngay, gio.ToString() };
        myConn.Close();
        return ngaygio;
    }

    public DataSet XUAT_BAO_CAO_MANE(string donvi, string ngay, string gio, string nguong, string luachon)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        string sql = "select ngay,gio,upe,port,description,min_range_rx,rx_power,max_range_rx,INPUT_BANDWIDTH,OUTPUT_BANDWIDTH from mane_solieu where ngay='" + ngay + "' and gio='" + gio + "' and INTERFACE_STATE='UP'and not (rx_power is null or tx_power is null) ";
        cmd.Connection = myConn;
        if (luachon == "2")
        {

            sql = sql + "and (substr(rx_power,2,instr(rx_power,'.')-2) + substr(rx_power,instr(rx_power,'.')+1,length(rx_power)-instr(rx_power,'.'))/100)*-1 < (substr(min_range_rx,2,instr(min_range_rx,'.')-2) + substr(min_range_rx,instr(min_range_rx,'.')+1,length(min_range_rx)-instr(min_range_rx,'.'))/100)*-1";

            //  sql = "select * from mane_solieu where ngay='20171109' and gio='7' and INTERFACE_STATE='UP'and not (rx_power is null or tx_power is null) and (substr(rx_power,2,instr(rx_power,'.')-2) + substr(rx_power,instr(rx_power,'.')+1,length(rx_power)-instr(rx_power,'.'))/100)*-1 < (substr(min_range_rx,2,instr(min_range_rx,'.')-2) + substr(min_range_rx,instr(min_range_rx,'.')+1,length(min_range_rx)-instr(min_range_rx,'.'))/100)*-1";
        }
        if (luachon == "3")
        {
            sql = sql + "and (to_number(INPUT_BANDWIDTH)>=" + nguong + " or to_number(OUTPUT_BANDWIDTH)>=" + nguong + ")";
        }
        if (donvi == "BDPT")
        {
            sql = sql + "order by upe,substr(port,1,3),to_number(substr(port,5,length(port)-4))";
        }
        else
        {
            sql = sql + "and upe in (select upe from mane where don_vi_id='" + donvi + "')" + "order by upe,substr(port,1,3),to_number(substr(port,5,length(port)-4))";
        }

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
        return dts;
    }
    public DataTable XUAT_BAO_CAO_OLT(string ngay, string gio)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        string sql = "select a.ten,b.ngay, b.gio, b.olt, b.port, b.MIN_RANGE_RX, b.TX_POWER as RX_POWER,b.MAX_RANGE_RX, b.RX_POWER as TX_POWER, (select c.loai_module from olt_module c where c.olt = b.olt and c.port = b.port) as loai_module, (select c.loai_soi from olt_module c where c.olt = b.olt and c.port = b.port) as loai_soi from olt a, olt_solieu b where a.olt=b.olt and b.ngay='" + ngay + "' and b.gio='" + gio + "' and b.INTERFACE_STATE='UP' order by a.loai,a.ten,b.port";
        cmd.Connection = myConn;
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataTable baocao = new DataTable();
        myConn.Open();
        myData.Fill(baocao);
        myData.Dispose();
        cmd.Parameters.Clear();
        cmd.Connection.Close();
        myConn.Close();
        //dts.Tables[0].Columns["TEN"].ColumnName = "TÊN";
        int i = 0;
        for (i = 0; i < baocao.Rows.Count; i++)
        {

            sql = "select RX_MIN,RX_MAX from olt_alu_rxrange where loai_module='" + baocao.Rows[i]["loai_module"].ToString() + "' and loai_soi='" + baocao.Rows[i]["loai_soi"].ToString() + "'";
            DataTable rx_range = SELECT_QUERY(sql);
            if (rx_range.Rows.Count > 0)
            {
                if (String.IsNullOrEmpty(baocao.Rows[i]["MIN_RANGE_RX"].ToString()))
                {
                    baocao.Rows[i]["MIN_RANGE_RX"] = rx_range.Rows[0]["RX_MIN"];
                }
                if (String.IsNullOrEmpty(baocao.Rows[i]["MAX_RANGE_RX"].ToString()))
                {
                    baocao.Rows[i]["MAX_RANGE_RX"] = rx_range.Rows[0]["RX_MAX"];
                }
            }
            if (baocao.Rows[i]["RX_POWER"].ToString() == "-80" && baocao.Rows[i]["TX_POWER"].ToString() == "-80")
            {
                baocao.Rows[i].Delete();
            }
        }
        baocao.AcceptChanges();
        return baocao;
    }
    public DataTable XUAT_BAO_CAO_OLT_VUOT_NGUONG(string ngay, string gio)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        string sql = "select a.ten,b.ngay, b.gio, b.olt, b.port, b.MIN_RANGE_RX, b.TX_POWER as RX_POWER,b.MAX_RANGE_RX, b.RX_POWER as TX_POWER, (select c.loai_module from olt_module c where c.olt = b.olt and c.port = b.port) as loai_module, (select c.loai_soi from olt_module c where c.olt = b.olt and c.port = b.port) as loai_soi from olt a, olt_solieu b where a.olt=b.olt and b.ngay='" + ngay + "' and b.gio='" + gio + "' and b.INTERFACE_STATE='UP' order by a.loai,a.ten,b.port";
        cmd.Connection = myConn;
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataTable baocao = new DataTable();
        myConn.Open();
        myData.Fill(baocao);
        myData.Dispose();
        cmd.Parameters.Clear();
        cmd.Connection.Close();
        myConn.Close();
        int i = 0;
        for (i = 0; i < baocao.Rows.Count; i++)
        {
            if (baocao.Rows[i]["RX_POWER"].ToString() == "-80" && baocao.Rows[i]["TX_POWER"].ToString() == "-80")
            {
                baocao.Rows[i].Delete();
            }
            else
            {
                sql = "select RX_MIN,RX_MAX from olt_alu_rxrange where loai_module='" + baocao.Rows[i]["loai_module"].ToString() + "' and loai_soi='" + baocao.Rows[i]["loai_soi"].ToString() + "'";
                DataTable rx_range = SELECT_QUERY(sql);
                if (rx_range.Rows.Count > 0)
                {
                    if (String.IsNullOrEmpty(baocao.Rows[i]["MIN_RANGE_RX"].ToString()))
                    {
                        baocao.Rows[i]["MIN_RANGE_RX"] = rx_range.Rows[0]["RX_MIN"];
                    }
                    if (String.IsNullOrEmpty(baocao.Rows[i]["MAX_RANGE_RX"].ToString()))
                    {
                        baocao.Rows[i]["MAX_RANGE_RX"] = rx_range.Rows[0]["RX_MAX"];
                    }
                    if (String.IsNullOrEmpty(rx_range.Rows[0]["RX_MIN"].ToString()))
                    {
                        baocao.Rows[i].Delete();
                    }
                    else
                    {
                        Double rx_min = Convert.ToDouble(baocao.Rows[i]["MIN_RANGE_RX"]);
                        Double rx = Convert.ToDouble(baocao.Rows[i]["RX_POWER"]);
                        if (rx_min < rx)
                        {
                            baocao.Rows[i].Delete();

                        }
                    }
                }
                else
                {
                    baocao.Rows[i].Delete();

                }
            }

        }
        baocao.AcceptChanges();
        return baocao;
    }
    public DataSet XUAT_BAO_CAO_SWITCH_S5328(string ngay, string gio, string luachon)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        string sql = "select a.ten as local,b.* from switch_l2 a, switch_solieu b where a.sw=b.sw and b.ngay='" + ngay + "' and b.gio=" + gio + " and b.INTERFACE_STATE='UP' and not (b.rx_power='-Inf' or b.rx_power is null or b.rx_power='0.00')";
        cmd.Connection = myConn;
        if (luachon == "2")
        {
            sql = sql + "and (substr(b.rx_power,2,length(b.rx_power)-4) + substr(b.rx_power,length(b.rx_power)-1,2)/100)*-1 < (substr(b.rx_power_low,2,length(b.rx_power_low)-4) + substr(b.rx_power_low,length(b.rx_power_low)-1,2)/100)*-1";
        }

        sql = sql + "order by a.ten,b.port";
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
        return dts;
    }
    public DataSet SELECT_DANH_SACH_UPE(string donvi)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (donvi == "BDPT")
        {
            cmd.CommandText = "select UPE from mane order by UPE";
        }
        else
        {
            cmd.CommandText = "select UPE from mane where don_vi_id =" + donvi;
        }
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataSet dts = new DataSet();
        myConn.Open();
        myData.Fill(dts);
        myData.Dispose();
        cmd.Parameters.Clear();
        cmd.Connection.Close();
        myConn.Close();
        return dts;
    }

    public DataSet SELECT_DANH_SACH_OLT(string donvi)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        if (donvi == "BDPT")
        {
            cmd.CommandText = "select OLT from olt where loai='ALU' order by OLT";
        }
        else
        {
            cmd.CommandText = "select OLT from OLT where loai='ALU' and don_vi_id =" + donvi;
        }
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataSet dts = new DataSet();
        myConn.Open();
        myData.Fill(dts);
        myData.Dispose();
        cmd.Parameters.Clear();
        cmd.Connection.Close();
        myConn.Close();
        return dts;
    }
    public DataSet SELECT_DANH_SACH_PORT(string upe)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        cmd.CommandText = "select PORT from mane_port where upe ='" + upe + "' order by port";
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataSet dts = new DataSet();
        myConn.Open();
        myData.Fill(dts);
        myData.Dispose();
        cmd.Parameters.Clear();
        cmd.Connection.Close();
        myConn.Close();
        return dts;
    }

    public DataSet XEM_BIEU_DO(string upe, string port, string tungay, string denngay)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        cmd.CommandText = "select ngay,INPUT_BANDWIDTH as INPUT, OUTPUT_BANDWIDTH as OUTPUT, DESCRIPTION as DIENGIAI from mane_solieu where UPE ='" + upe + "' and PORT = '" + port + "' and NGAY >=" + tungay + "and NGAY <=" + denngay;

        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataSet dts = new DataSet();
        myConn.Open();
        myData.Fill(dts);
        myData.Dispose();
        cmd.Parameters.Clear();
        cmd.Connection.Close();
        myConn.Close();
        return dts;
    }
    public DataSet TONGHOP_EXCEL(string tungay, string denngay)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        //cmd.CommandText = "select NGAY,GIO,INPUT_BANDWIDTH as INPUT_MAX from mane_solieu where UPE ='" + upe + "' and PORT = '" + port + "' and INTERFACE_STATE='UP' and INPUT_BANDWIDTH = (select max(INPUT_BANDWIDTH) from mane_solieu where UPE ='" + upe + "' and PORT = '" + port + "' and NGAY >=" + tungay + "and NGAY <=" + denngay + ")  and NGAY >=" + tungay + "and NGAY <=" + denngay;
        cmd.CommandText = "select c.donvi,a.upe,a.port,a.ngay as ngay_in,a.gio as gio_in,a.inPUT_BANDWIDTH ,b.ngay as ngay_out,b.gio as gio_out,b.outPUT_BANDWIDTH from (select upe,port,ngay,gio,inPUT_BANDWIDTH from mane_solieu where INTERFACE_STATE='UP' and ngay>='" + tungay + "' and ngay<='" + denngay + "' and (upe,port,inPUT_BANDWIDTH,ngay || trim(to_char(gio,'00'))) in (select upe,port,inPUT_BANDWIDTH,max(ngay || trim(to_char(gio,'00'))) as ngaygio from mane_solieu where INTERFACE_STATE='UP' and ngay>='" + tungay + "' and ngay<='" + denngay + "' and (upe,port,inPUT_BANDWIDTH) in (select upe,port,max(inpUT_BANDWIDTH) as max_in from mane_solieu where INTERFACE_STATE='UP' and ngay>='" + tungay + "' and ngay<='" + denngay + "' group by upe,port) group by upe,port,inPUT_BANDWIDTH)) a ,(select upe,port,ngay,gio,OUTPUT_BANDWIDTH from mane_solieu where INTERFACE_STATE='UP' and ngay>='" + tungay + "' and ngay<='" + denngay + "' and (upe,port,OUTPUT_BANDWIDTH,ngay || trim(to_char(gio,'00'))) in (select upe,port,OUTPUT_BANDWIDTH,max(ngay || trim(to_char(gio,'00'))) as ngaygio from mane_solieu where INTERFACE_STATE='UP' and ngay>='" + tungay + "' and ngay<='" + denngay + "' and (upe,port,OUTPUT_BANDWIDTH) in (select upe,port,max(OUTPUT_BANDWIDTH) as max_out from mane_solieu where INTERFACE_STATE='UP' and ngay>='" + tungay + "' and ngay<='" + denngay + "' group by upe,port) group by upe,port,OUTPUT_BANDWIDTH)) b ,(select a.TEN_4 as donvi, b.UPE from don_vi a, mane b where a.don_vi_id = b.don_vi_id) c where a.upe=b.upe and a.port=b.port and a.upe = c.upe order by a.upe,a.port ";
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataSet dts = new DataSet();
        myConn.Open();
        myData.Fill(dts);
        myData.Dispose();
        cmd.Parameters.Clear();
        cmd.Connection.Close();
        myConn.Close();
        return dts;
    }
    public DataSet SELECT_UPE_DONVI(string tungay, string denngay)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        //cmd.CommandText = "select NGAY,GIO,INPUT_BANDWIDTH as INPUT_MAX from mane_solieu where UPE ='" + upe + "' and PORT = '" + port + "' and INTERFACE_STATE='UP' and INPUT_BANDWIDTH = (select max(INPUT_BANDWIDTH) from mane_solieu where UPE ='" + upe + "' and PORT = '" + port + "' and NGAY >=" + tungay + "and NGAY <=" + denngay + ")  and NGAY >=" + tungay + "and NGAY <=" + denngay;
        cmd.CommandText = "select distinct a.TEN_4 as donvi, b.UPE, c.PORT from don_vi a, mane b, (select port,upe from mane_solieu where interface_state = 'UP' and ngay>='" + tungay + "' and ngay<='" + denngay + "') c where a.don_vi_id = b.don_vi_id and c.upe = b.upe order by b.upe, c.port";
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataSet dts = new DataSet();
        myConn.Open();
        myData.Fill(dts);
        myData.Dispose();
        cmd.Parameters.Clear();
        cmd.Connection.Close();
        myConn.Close();
        return dts;
    }
    public DataSet SELECT_MAX_INPUT(string tungay, string denngay)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        //cmd.CommandText = "select NGAY,GIO,INPUT_BANDWIDTH as INPUT_MAX from mane_solieu where UPE ='" + upe + "' and PORT = '" + port + "' and INTERFACE_STATE='UP' and INPUT_BANDWIDTH = (select max(INPUT_BANDWIDTH) from mane_solieu where UPE ='" + upe + "' and PORT = '" + port + "' and NGAY >=" + tungay + "and NGAY <=" + denngay + ")  and NGAY >=" + tungay + "and NGAY <=" + denngay;
        cmd.CommandText = "select upe,port,ngay,gio,inPUT_BANDWIDTH from mane_solieu where INTERFACE_STATE='UP' and ngay>='" + tungay + "' and ngay<='" + denngay + "' and (upe,port,inPUT_BANDWIDTH,ngay || trim(to_char(gio,'00'))) in (select upe,port,inPUT_BANDWIDTH,max(ngay || trim(to_char(gio,'00'))) as ngaygio from mane_solieu where INTERFACE_STATE='UP' and ngay>='" + tungay + "' and ngay<='" + denngay + "' and (upe,port,inPUT_BANDWIDTH) in (select upe,port,max(inpUT_BANDWIDTH) as max_in from mane_solieu where INTERFACE_STATE='UP' and ngay>='" + tungay + "' and ngay<='" + denngay + "' group by upe,port) group by upe,port,inPUT_BANDWIDTH ) order by upe,port";
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataSet dts = new DataSet();
        myConn.Open();
        myData.Fill(dts);
        myData.Dispose();
        cmd.Parameters.Clear();
        cmd.Connection.Close();
        myConn.Close();
        return dts;
    }
    public DataSet SELECT_MAX_OUTPUT(string tungay, string denngay)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConn;
        //cmd.CommandText = "select NGAY,GIO,INPUT_BANDWIDTH as INPUT_MAX from mane_solieu where UPE ='" + upe + "' and PORT = '" + port + "' and INTERFACE_STATE='UP' and INPUT_BANDWIDTH = (select max(INPUT_BANDWIDTH) from mane_solieu where UPE ='" + upe + "' and PORT = '" + port + "' and NGAY >=" + tungay + "and NGAY <=" + denngay + ")  and NGAY >=" + tungay + "and NGAY <=" + denngay;
        cmd.CommandText = "select upe,port,ngay,gio,OUTPUT_BANDWIDTH from mane_solieu where INTERFACE_STATE='UP' and ngay>='" + tungay + "' and ngay<='" + denngay + "' and (upe,port,OUTPUT_BANDWIDTH,ngay || trim(to_char(gio,'00'))) in (select upe,port,OUTPUT_BANDWIDTH,max(ngay || trim(to_char(gio,'00'))) as ngaygio from mane_solieu where INTERFACE_STATE='UP' and ngay>='" + tungay + "' and ngay<='" + denngay + "' and (upe,port,OUTPUT_BANDWIDTH) in (select upe,port,max(OUTPUT_BANDWIDTH) as max_out from mane_solieu where INTERFACE_STATE='UP' and ngay>='" + tungay + "' and ngay<='" + denngay + "' group by upe,port) group by upe,port,OUTPUT_BANDWIDTH)";
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter myData = new SqlDataAdapter(cmd);
        DataSet dts = new DataSet();
        myConn.Open();
        myData.Fill(dts);
        myData.Dispose();
        cmd.Parameters.Clear();
        cmd.Connection.Close();
        myConn.Close();
        return dts;
    }
    public DataTable SELECT_QUERY(string sql)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
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
    }
    public void ExecuteSQL(string sql)
    {
        clsConnect cnstr = new clsConnect();

        using (SqlConnection connection = cnstr.ConnectSQL())
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

    }

}
