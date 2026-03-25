using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for clsKhachHang
/// </summary>
public class clsKhachHang
{
    clsConnect cnstr = new clsConnect();
    //lay danh sach khu

    //lay danh sách khach hang
    public DataTable get_danh_sach_khach_hang()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select a.* from khach_hang a, dm_khu b, dm_huyen c, dm_phuong_xa d, tram_bien_ap e where a.id_khu = b.id_khu and a.id_huyen = c.id_huyen and a.id_phuong_xa = d.id_phuong_xa and a.id_tram_bien_ap = e.id_tram_bien_ap ";
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

    //lay danh sách khach hang theo trạm biến áp
    public DataTable get_danh_sach_khach_hang_theo_tram_bien_ap(String id_tramBAp)
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            if (id_tramBAp == "0")
            {
                cmd.CommandText = "select a.*, b.ten_khu, d.ten_phuong_xa, e.ten_tram_bien_ap from khach_hang a, dm_khu b, dm_huyen c, dm_phuong_xa d, tram_bien_ap e where a.id_khu = b.id_khu and a.id_huyen = c.id_huyen and a.id_phuong_xa = d.id_phuong_xa and a.id_tram_bien_ap = e.id_tram_bien_ap order by a.thu_tu";
            }
            else
            {
                cmd.CommandText = "select a.*, b.ten_khu, d.ten_phuong_xa, e.ten_tram_bien_ap from khach_hang a, dm_khu b, dm_huyen c, dm_phuong_xa d, tram_bien_ap e where a.id_khu = b.id_khu and a.id_huyen = c.id_huyen and a.id_phuong_xa = d.id_phuong_xa and a.id_tram_bien_ap = e.id_tram_bien_ap and a.id_tram_bien_ap ='" + id_tramBAp + "' order by a.thu_tu";
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

    //them moi khach hang
    public int them_moi_bang_gia_dien(string ten_bang_gia, string ten_viet_tat, double don_gia, double tien_thue_vat, double phan_tram_thue, double gia_ban, int kich_hoat)
    {
        int recordsAffected = 0;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = "insert into bang_gia_dien(ten_bang_gia,ten_viet_tat,don_gia,tien_thue_vat,phan_tram_thue,gia_ban,kich_hoat) values(N'" + ten_bang_gia + "','" + ten_viet_tat + "','" + don_gia + "','" + tien_thue_vat + "','" + phan_tram_thue + "','" + gia_ban + "','" + kich_hoat + "') ";
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        catch (SqlException)
        {
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
        return recordsAffected;
    }

    //hienthi danh sach gia dien
    public DataTable get_danh_muc_bang_gia_dien()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select * from bang_gia_dien";
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
    public DataTable get_danh_muc_bang_gia_dien_chi_tiet()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select a.*, b.ten_bang_gia, c.ten_bang_gia as ten_bang_gia_ty_le from bang_gia_dien_chi_tiet as a left join bang_gia_dien as c on a.id_bang_gia_ty_le = c.id_bang_gia inner join bang_gia_dien as b on a.id_bang_gia = b.id_bang_gia";
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
    //Them moi gia dien
    public int them_moi_gia_dien(string ten_bang_gia, string ten_viet_tat, double don_gia, double tien_thue_vat, double phan_tram_thue, double gia_ban, int kich_hoat, string loaiBG)
    {
        int recordsAffected = 0;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = string.Format("insert into bang_gia_dien (ten_bang_gia, ten_viet_tat, don_gia, tien_thue_vat, phan_tram_thue, gia_ban, kich_hoat, loai_bg) values(N'{0}', '{1}', {2}, {3}, {4}, {5}, {6}, '{7}')", ten_bang_gia, ten_viet_tat, don_gia, tien_thue_vat, phan_tram_thue, gia_ban, kich_hoat, loaiBG);
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
        return recordsAffected;
    }

    public int them_moi_gia_dien_chi_tiet(int id_bang_gia, double tu_so, double den_so, double gia_khong_vat, string muc_thu, double phan_tram_thue, int id_bang_gia_ty_le, double ty_le, string mo_ta)
    {
        int recordsAffected = 0;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = string.Format("insert into bang_gia_dien_chi_tiet (id_bang_gia, tu_so, den_so, gia_ko_vat, mo_ta, muc_thu, phan_tram_thue, id_bang_gia_ty_le, ty_le) values({0}, {1}, {2}, {3}, N'{4}', N'{5}', {6}, {7}, {8})", id_bang_gia, tu_so, den_so, gia_khong_vat, mo_ta, muc_thu, phan_tram_thue, id_bang_gia_ty_le, ty_le);
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
        return recordsAffected;
    }

     public void cap_nhat_gia_dien(int id, string ten_bang_gia, string ten_viet_tat, double don_gia, double tien_thue_vat, double phan_tram_thue, double gia_ban, int kich_hoat, string loaiBG)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();

        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = "update bang_gia_dien set ten_bang_gia=N'" + ten_bang_gia + "',ten_viet_tat='" + ten_viet_tat + "',don_gia='" + don_gia + "',tien_thue_vat='" + tien_thue_vat + "',phan_tram_thue='" + phan_tram_thue + "', don_gia_cu='" + gia_ban + "',kich_hoat='" + kich_hoat + "',loai_bg='" + loaiBG + "' where id_bang_gia='" + id + "'";
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            int recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }
        catch (SqlException e)
        {
            // test loi
            throw e;
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
    }
    public void cap_nhat_gia_dien_chi_tiet(int id, double tu_so, double den_so, double gia_khong_vat, string muc_thu, double dongiacu, int id_bang_gia_ty_le, double ty_le, string mo_ta)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();

        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = string.Format("update bang_gia_dien_chi_tiet set tu_so = {1}, den_so = {2}, gia_ko_vat = {3}, mo_ta = N'{4}', muc_thu = N'{5}', gia_ko_vat_cu = {6}, id_bang_gia_ty_le = {7}, ty_le = {8} where id = {0}", id, tu_so, den_so, gia_khong_vat, mo_ta, muc_thu, dongiacu, id_bang_gia_ty_le, ty_le);
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            int recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }
        catch (SqlException e)
        {
            // test loi
            throw e;
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
    }

    public void xoa_gia_dien_chi_tiet(int id)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();

        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = string.Format("delete from bang_gia_dien_chi_tiet where id = {0}", id);
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            int recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }
        catch (SqlException e)
        {
            // test loi
            throw e;
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
    }
    //kiemtratrangthai
    public int kt_trang_thai(int id)
    {
        int recordsAffected;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = myConn;
        cmd.CommandText = "select kich_hoat from bang_gia_dien where id_bang_gia = '" + id + "'";
        cmd.CommandType = CommandType.Text;
        myConn.Open();
        recordsAffected = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return recordsAffected;
    }

    //hienthi danh sach tram bien ap
    public DataTable get_danh_muc_tram_bien_ap()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select id_tram_bien_ap, ten_tram_bien_ap, dia_chi, nguoi_phu_trach, ma_so_cong_to, he_so_nhan, trang_thai from tram_bien_ap";
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

    //them moi tram bien ap
    public int them_moi_tram_bien_ap(string id_tram_bien_ap, string ten_tram_bien_ap, string dia_chi, string nguoi_phu_trach, string ma_so_cong_to, int he_so_nhan, int trang_thai)
    {
        int recordsAffected = 0;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = "insert into tram_bien_ap (id_tram_bien_ap, ten_viet_tat, ten_tram_bien_ap, dia_chi, nguoi_phu_trach, ma_so_cong_to, he_so_nhan, trang_thai) values('" + id_tram_bien_ap + "', '', N'" + ten_tram_bien_ap + "',N'" + dia_chi + "',N'" + nguoi_phu_trach + "','" + ma_so_cong_to + "','" + he_so_nhan + "','" + trang_thai + "') ";
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        catch (SqlException)
        {
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
        return recordsAffected;
    }

    //Sua tram bien ap
    public void cap_nhat_tram_bien_ap(string id_tram, string ten_tram_bien_ap, string dia_chi, string nguoi_phu_trach, string ma_so_cong_to, int he_so_nhan, int trang_thai)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();

        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = "update tram_bien_ap set ten_tram_bien_ap=N'" + ten_tram_bien_ap + "',dia_chi=N'" + dia_chi + "',nguoi_phu_trach=N'" + nguoi_phu_trach + "',ma_so_cong_to='" + ma_so_cong_to + "',he_so_nhan='" + he_so_nhan + "',trang_thai='" + trang_thai + "' where id_tram_bien_ap='" + id_tram + "'";
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            int recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }
        catch (SqlException e)
        {
            // test loi
            throw e;
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
    }

    //lay danh sach khu
    public DataTable get_danh_muc_khu()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select a.*, b.ten_phuong_xa from dm_khu as a LEFT JOIN dm_phuong_xa as b ON a.id_phuong_xa = b.id_phuong_xa order by id_khu;";
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

    public DataTable get_danh_muc_huyen()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select id_huyen, ten_huyen from dm_huyen order by id_huyen";
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

    public DataTable get_danh_muc_phuong_xa()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select id_phuong_xa, ten_phuong_xa from dm_phuong_xa order by id_phuong_xa";
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

    public int them_moi_khu(string ten_khu, int id_phuong_xa)
    {
        int recordsAffected = 0;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();

        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = "insert into dm_khu values(N'" + ten_khu + "','" + id_phuong_xa + "') ";
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }
        catch (SqlException e)
        {
            // test loi
            throw e;
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
        return recordsAffected;
    }

    public void cap_nhat_khu(int id, string ten_khu, int id_phuong_xa)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();

        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = "update dm_khu set ten_khu=N'" + ten_khu + "',id_phuong_xa='" + id_phuong_xa + "' where id_khu='" + id + "'";
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            int recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }
        catch (SqlException e)
        {
            // test loi
            throw e;
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
    }

    //lay danh sach nhan vien
    public DataTable get_danh_sach_nhan_vien()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select * from nhan_vien";
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

    //them moi nhan vien
    public int them_moi_nhan_vien(string ma_nv, string ten_nv, string dia_chi, string dien_thoai, string ghi_chu)
    {
        int recordsAffected = 0;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = "insert into nhan_vien values('" + ma_nv + "',N'" + ten_nv + "',N'" + dia_chi + "','" + dien_thoai + "',N'" + ghi_chu + "') ";
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        catch (SqlException)
        {
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
        return recordsAffected;
    }

    //Sua thong tin nhan vien
    public void cap_nhat_nhan_vien(string ma_nv, string ten_nv, string dia_chi, string dien_thoai, string ghi_chu)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();

        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = "update nhan_vien set ten_nv=N'" + ten_nv + "',dia_chi=N'" + dia_chi + "',dien_thoai='" + dien_thoai + "',ghi_chu=N'" + ghi_chu + "' where ma_nv='" + ma_nv + "'";
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            int recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }
        catch (SqlException e)
        {
            e.Message.ToString();
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
    }

    //end 

    public DataTable get_khach_hang_theo_makh(string maKh)
    {
        string sqlQuery = string.Format("select * from khach_hang where ma_kh = '{0}'", maKh);
        DataTable new_table = cnstr.GetDataTable(sqlQuery);
        return new_table;
    }

    public DataTable get_danh_sach_khach_hang_dia_ban(int id_dia_ban)
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            if (id_dia_ban == 0)
                cmd.CommandText = "select a.ma_kh,a.ten_kh,a.dia_chi,a.so_dt,a.nam_bh,a.id_dia_ban,b.ten_dia_ban, b.vung from khach_hang a, dm_dia_ban b where a.id_dia_ban = b.id_dia_ban";
            else
                cmd.CommandText = "select a.ma_kh,a.ten_kh,a.dia_chi,a.so_dt,a.nam_bh,a.id_dia_ban,b.ten_dia_ban, b.vung from khach_hang a, dm_dia_ban b where a.id_dia_ban = b.id_dia_ban and a.id_dia_ban=" + id_dia_ban + " ";
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
    public DataTable get_dia_ban()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select id_khu,ten_khu from dm_khu order by id_khu asc";
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
    public string get_ma_kh_addmodal()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select max(ma_kh) as ma_kh from khach_hang";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            return dts.Tables[0].Rows[0]["ma_kh"].ToString();
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
    public List<string> get_danh_sach_khac_hang_searchtext(string searchtext)
    {
        List<string> customers = new List<string>();
        clsConnect cnstr = new clsConnect();
        using (SqlConnection myConn = cnstr.ConnectSQL())
        {
            myConn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select a.ma_kh,a.ten_kh,a.dia_chi,b.ten_dia_ban,a.so_dt from khach_hang a, dm_dia_ban b where a.id_dia_ban = b.id_dia_ban and  (a.ten_kh like N'%" + searchtext + "' or a.ten_kh like N'%" + searchtext + "(%' or a.ten_kh like N'%" + searchtext + ")')";
            cmd.CommandType = CommandType.Text;
            using (SqlDataReader myData = cmd.ExecuteReader())
            {
                while (myData.Read())
                {
                    customers.Add(string.Format("{0}${1}${2}${3}${4}", myData["ma_kh"], myData["ten_kh"], myData["ten_dia_ban"], myData["dia_chi"], myData["so_dt"]));
                }
            }
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
        }
        return customers;
        // return dts;    
    }

    public string get_ma_kh_tu_sinh()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = " SELECT NEXT VALUE FOR  khachhang_seq ";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            return dts.Tables[0].Rows[0][0].ToString();
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

    public int cap_nhat_cong_to(string ma_cong_to, string chungLoai, string nhaSanXuat, string ngaySD, string ngayHetHan, string he_so_ti)
    {
        int ma = 0;
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            string str_sql = "";
            if (ngaySD.Trim() == "" & ngayHetHan.Trim() == "")
            {
                str_sql = string.Format("update dm_cong_to set chung_loai = N'{1}', nha_san_xuat = N'{2}',he_so_ti={5} where ma_cong_to = '{0}'", ma_cong_to, chungLoai, nhaSanXuat, ngaySD, ngayHetHan, he_so_ti);
            }
            else if (ngaySD.Trim() == "")
            {
                str_sql = string.Format("update dm_cong_to set chung_loai = N'{1}', nha_san_xuat = N'{2}', ngay_het_han = CONVERT(datetime, '{3}'),he_so_ti={5} where ma_cong_to = '{0}'", ma_cong_to, chungLoai, nhaSanXuat, ngayHetHan, he_so_ti);
            }
            else if (ngayHetHan.Trim() == "")
            {
                str_sql = string.Format("update dm_cong_to set chung_loai = N'{1}', nha_san_xuat = N'{2}', ngay_sd = CONVERT(datetime, '{3}'),he_so_ti={5} where ma_cong_to = '{0}'", ma_cong_to, chungLoai, nhaSanXuat, ngaySD, he_so_ti);
            }
            else
            {
                str_sql = string.Format("update dm_cong_to set chung_loai = N'{1}', nha_san_xuat = N'{2}', ngay_sd = CONVERT(datetime, '{3}'), ngay_het_han = CONVERT(datetime, '{4}'),he_so_ti={5} where ma_cong_to = '{0}'", ma_cong_to, chungLoai, nhaSanXuat, ngaySD, ngayHetHan, he_so_ti);
            }
            cmd.CommandText = str_sql;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataTable dts = new DataTable();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            ma = dts.Rows.Count;
            return ma;
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
    
    public int check_ma_cong_to(string ma_cong_to)
    {
        int ma = 0;
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = " SELECT * from dm_cong_to where ma_cong_to = '" + ma_cong_to + "'  ";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            ma = dts.Tables[0].Rows.Count;
            return ma;
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

    //Kiểm tra danh sách mã công tơ có bị trùng
    public int check_list_ma_cong_to(string ma_cong_to)
    {
        int ma = 0;
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = " SELECT * from dm_cong_to where ma_cong_to in (" + ma_cong_to + ")";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            ma = dts.Tables[0].Rows.Count;
            return ma;
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

    //Kiểm tra mã khách hàng bị trùng
    public int check_ma_khach_hang(string ma_kh)
    {
        int ma = 0;
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = string.Format("SELECT * from khach_hang where ma_kh = '{0}'", ma_kh);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            ma = dts.Tables[0].Rows.Count;
            return ma;
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

    public string get_ten_viet_tat_TBA(string id_tram_bien_ap)
    {
        string ten_viet_tat = "";
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = " SELECT * from tram_bien_ap where id_tram_bien_ap='" + id_tram_bien_ap + "'  ";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            ten_viet_tat = dts.Tables[0].Rows[0]["ten_viet_tat"].ToString();
            return ten_viet_tat;
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
    public int them_moi_khach_hang(string ma_kh, string ten_kh, int id_bang_gia, string dia_chi, int id_khu, string id_tram_bien_ap, int so_ho, float he_so_ti, string dien_thoai, string mst_kh, string cot_dien_so, int sl_dong_ho, string ma_cong_to, int trang_thai, int thu_tu, int id_phuong_xa, int id_huyen, int sms, int id_doanh_nghiep)
    {
        int recordsAffected = 0;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = string.Format("insert into khach_hang(ma_kh, ten_kh, id_bang_gia, dia_chi, id_khu, id_tram_bien_ap, so_ho,he_so_ti, dien_thoai, mst_kh, cot_dien_so, sl_dong_ho, ma_cong_to, trang_thai, thu_tu, id_phuong_xa, id_huyen, sms, id_doanh_nghiep) values('{0}', N'{1}', {2}, N'{3}', {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, '{12}', {13}, {14}, {15}, {16}, {17}, {18})", ma_kh, ten_kh, id_bang_gia, dia_chi, id_khu, id_tram_bien_ap, so_ho, he_so_ti, dien_thoai, mst_kh, cot_dien_so, sl_dong_ho, ma_cong_to, trang_thai, thu_tu, id_phuong_xa, id_huyen, sms, id_doanh_nghiep);
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        catch (SqlException)
        {
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
        return recordsAffected;
    }

    public DataTable get_cong_to_theo_maCTo(string maCTo)
    {
        string sqlQuery = string.Format("select * from dm_cong_to where ma_cong_to = '{0}'", maCTo);
        DataTable new_table = cnstr.GetDataTable(sqlQuery);
        return new_table;
    }

    public int them_moi_cong_to(string ma_cong_to, string ma_kh, float he_so_ti, int id_doanh_nghiep, int trang_thai)
    {
        int recordsAffected = 0;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = string.Format("insert into dm_cong_to(ma_cong_to, ma_kh, he_so_ti, id_doanh_nghiep, trang_thai) values('{0}', '{1}', {2}, {3}, {4})", ma_cong_to, ma_kh, he_so_ti, id_doanh_nghiep, trang_thai);
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        catch (SqlException)
        {
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
        return recordsAffected;
    }

    public void cap_nhat_trang_thai_cong_to(string ma_cong_to, int trang_thai)
    {
        string sqlQuery = string.Format("update dm_cong_to set trang_thai = {1} where ma_cong_to = '{0}'", ma_cong_to, trang_thai);
        cnstr.InsertUpdateDataTable(sqlQuery);
    }

    public int them_moi_full_field_cong_to(string ma_cong_to, string ma_kh, float he_so_ti)
    {
        int recordsAffected = 0;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = "insert into dm_cong_to(ma_cong_to,ma_kh,he_so_ti,trang_thai) values('" + ma_cong_to + "','" + ma_kh + "'," + he_so_ti + ",1)";
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        catch (SqlException)
        {
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
        return recordsAffected;
    }

    public int them_moi_chi_so_cong_to(string ma_cong_to, float cs_cu, float cs_moi, string ky_hd, int id_doanh_nghiep)
    {
        int recordsAffected = 0;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = string.Format("insert into chi_so_cong_to(ma_cong_to, cs_cu, cs_moi, ky, trang_thai, id_doanh_nghiep) values('{0}', '{1}', '{2}', '{3}', 1, {4})", ma_cong_to, cs_cu, cs_moi, ky_hd, id_doanh_nghiep);
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        catch (SqlException)
        {
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
        return recordsAffected;
    }
    public void cap_nhat_chi_so_cong_to(string ma_cong_to, string ky, float chi_so)
    {
        string sqlQuery = string.Format("update chi_so_cong_to set cs_moi = {2} where ma_cong_to = '{0}' and ky = '{1}'", ma_cong_to, ky, chi_so);
        cnstr.InsertUpdateDataTable(sqlQuery);
    }

    public DataTable get_chi_so_cto_theo_ma_cong_to_va_ky(string ma_cong_to, string ky)
    {
        string sqlQuery = string.Format("select * from chi_so_cong_to where ma_cong_to = '{0}' and ky = '{1}'", ma_cong_to, ky);
        return cnstr.GetDataTable(sqlQuery);
    }

    public int check_ma_cong_to_theo_ky(string ma_cong_to, string ky)
    {
        int ma = 0;
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = string.Format("select * from chi_so_cong_to where ma_cong_to = '{0}' and ky = '{1}'", ma_cong_to, ky);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            ma = dts.Tables[0].Rows.Count;
            return ma;
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

    public void cap_nhat_khach_hang(string ma_kh, string ten_kh, int id_bang_gia, string dia_chi, int id_khu, string id_tram_bien_ap, int so_ho, float he_so_ti, string dien_thoai, string mst_kh, string cot_dien_so, int sl_dong_ho, string ma_cong_to, int trang_thai, int thu_tu, int id_phuong_xa, int id_huyen, int sms, string ma_tt)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();

        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = "update khach_hang set ten_kh=N'" + ten_kh + "',dia_chi=N'" + dia_chi + "',id_bang_gia='" + id_bang_gia + "',id_khu=" + id_khu + ",id_tram_bien_ap='" + id_tram_bien_ap + "',so_ho=" + so_ho + ",he_so_ti=" + he_so_ti + ",dien_thoai='" + dien_thoai + "',mst_kh='" + mst_kh + "',cot_dien_so='" + cot_dien_so + "',sl_dong_ho=" + sl_dong_ho + ",ma_cong_to='" + ma_cong_to + "',trang_thai=" + trang_thai + ",thu_tu=" + thu_tu + ",id_phuong_xa=" + id_phuong_xa + ", id_huyen=" + id_huyen + ", sms=" + sms + ", ma_tt='" + ma_tt + "' where ma_kh='" + ma_kh + "' ";
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            int recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }
        catch (SqlException)
        {
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
    }

    public void cap_nhat_cong_to_khach_hang(string ma_kh, string ma_cong_to)
    {
        string sqlQuery = string.Format("update khach_hang set ma_cong_to = '{0}'where ma_kh = '{1}' ", ma_cong_to, ma_kh);
        cnstr.InsertUpdateDataTable(sqlQuery);
    }

    public void xoa_khach_hang(string ma_kh)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = "delete khach_hang  where ma_kh=" + ma_kh + " ";
            cmd.CommandType = CommandType.Text;
            int recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        catch (SqlException)
        {
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
    }

    public DataTable get_danh_muc_cong_to_theo_tram_BA(int idTramBA)
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = string.Format("select a.ma_cong_to, a.ma_kh, a.chung_loai, a.nha_san_xuat, a.trang_thai, a.he_so_ti, REPLACE(ISNULL(CONVERT(DATE, a.ngay_sd), ''), '1900-01-01', '') AS ngay_sd, REPLACE(ISNULL(CONVERT(DATE, a.ngay_het_han), ''), '1900-01-01', '') AS ngay_het_han from dm_cong_to as a, khach_hang as b, tram_bien_ap as c where a.ma_kh = b.ma_kh and b.id_tram_bien_ap = c.id_tram_bien_ap and c.id_tram_bien_ap = {0}", idTramBA);
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

    //hienthi danh sach công tơ tổng
    public DataTable get_danh_muc_cong_to_tong()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select * from chi_so_cong_to_tong";
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

    //Them moi công tơ tổng
    public int them_moi_cong_to_tong(string ten_bang_gia, string ten_viet_tat, double don_gia, double tien_thue_vat, double phan_tram_thue, double gia_ban, int kich_hoat)
    {
        int recordsAffected = 0;
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = "insert into chi_so_cong_to_tong (ten_bang_gia,ten_viet_tat,don_gia,tien_thue_vat,phan_tram_thue,gia_ban,kich_hoat) values(N'" + ten_bang_gia + "','" + ten_viet_tat + "','" + don_gia + "','" + tien_thue_vat + "','" + phan_tram_thue + "','" + gia_ban + "','" + kich_hoat + "') ";
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        catch (SqlException)
        {
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
        return recordsAffected;
    }

    //Sua công tơ tổng
    public void cap_nhat_cong_to_tong(int id, string ten_bang_gia, string ten_viet_tat, double don_gia, double tien_thue_vat, double phan_tram_thue, double gia_ban, int kich_hoat)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();

        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = "update chi_so_cong_to_tong set ten_bang_gia=N'" + ten_bang_gia + "',ten_viet_tat='" + ten_viet_tat + "',don_gia='" + don_gia + "',tien_thue_vat='" + tien_thue_vat + "',phan_tram_thue='" + phan_tram_thue + "', gia_ban='" + gia_ban + "',kich_hoat='" + kich_hoat + "' where id_bang_gia='" + id + "'";
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            int recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }
        catch (SqlException e)
        {
            // test loi
            throw e;
        }
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
    }

}