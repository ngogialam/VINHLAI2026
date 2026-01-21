using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class clsBanHang
{
    public void them_moi_don_hang(string ma_kh, string tongbh, string tongbk1, string tongbk2, string tongbc, string ngay_nhap, string nguoi_nhap_id)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            //cmd.CommandText = "SET IDENTITY_INSERT hoa_don ON";            
            // cmd.CommandType = CommandType.Text;
            // int recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into hoa_don(ma_kh,tong_bh,tong_bk1,tong_bk2,tong_bc,ngay_nhap,nguoi_nhap_id,trangthai_id,nam) values(" + ma_kh + ",'" + tongbh + "','" + tongbk1 + "','" + tongbk2 + "','" + tongbc + "', CONVERT( Datetime, '" + ngay_nhap + "' ,103),'" + nguoi_nhap_id + "',1,YEAR(getdate())) ";
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

    public void them_moi_don_hang_chitiet(string ma_hd, string ma_kh, string ma_hang, string so_luong, string ngay_nhap)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.CommandText = "insert into hoa_don_chi_tiet(ma_hd,ma_kh,ma_hang,so_luong,ngay_nhap) values ('" + ma_hd + "','" + ma_kh + "','" + ma_hang + "'," + so_luong + ",CONVERT( Datetime, '" + ngay_nhap + "' ,103))";
            cmd.CommandType = CommandType.Text;
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

    public List<string> get_sohd(string nam)
    {
        List<string> listSohd = new List<string>();
        int sohd;
        clsConnect cnstr = new clsConnect();
        using (SqlConnection myConn = cnstr.ConnectSQL())
        {
            myConn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select max(ma_hd) as sohd from hoa_don where nam =" + nam;
            cmd.CommandType = CommandType.Text;
            using (SqlDataReader myData = cmd.ExecuteReader())
            {
                while (myData.Read())
                {
                    int colIndex = myData.GetOrdinal("sohd");
                    if (myData.IsDBNull(colIndex))
                    {
                        sohd = 1;
                        listSohd.Add(string.Format("{0}", sohd.ToString()));
                    }
                    else
                    {
                        sohd = Convert.ToInt32(myData["sohd"]) + 1;
                        listSohd.Add(string.Format("{0}", sohd.ToString()));
                    }
                }
            }
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
        }
        return listSohd;
        // return dts;    
    }

    public List<string> laysolieuTHca(string i)
    {
        string sql = "";
        string tongsl;
        sql = "select case when sum(a.so_luong) is null then 0 else sum(a.so_luong) end tong_sl from hoa_don_chi_tiet a,hoa_don c ";
        sql = sql + " where c.ma_hd=a.ma_hd and  c.trangthai_id=1 and c.ca is null and a.ngay_nhap  >= DATEADD(day,-1,CONVERT(datetime,GETDATE())) AND  a.ngay_nhap <= CONVERT(datetime,GETDATE()) ";
        sql = sql + " and a.ma_hang= ";

        List<string> solieu = new List<string>();
        clsConnect cnstr = new clsConnect();
        using (SqlConnection myConn = cnstr.ConnectSQL())
        {
            myConn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = sql + i;
            cmd.CommandType = CommandType.Text;
            using (SqlDataReader myData = cmd.ExecuteReader())
            {
                while (myData.Read())
                {
                    tongsl = myData["tong_sl"].ToString();
                    solieu.Add(string.Format("{0}", tongsl));
                }
            }
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
        }
        return solieu;
    }

    public DataTable tracuugiaodich()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select a.ma_hd,b.ten_kh,c.ten_dia_ban,a.tong_bh,a.tong_bk1,a.tong_bk2,a.tong_bc,a.ca,a.ngay_nhap as ngayban,a.nguoiban, d.ten_trangthai from hoa_don a,khach_hang b,dm_dia_ban c,trangthai d where a.ma_kh = b.ma_kh and b.id_dia_ban=c.id_dia_ban and a.trangthai_id = d.trangthai_id order by a.ma_hd DESC";
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
    public DataTable layphieuthu(string ma_hd)
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select a.ma_hd,b.ten_kh,b.dia_chi,b.so_dt,e.ten_dia_ban,a.tong_bh,a.tong_bk1,a.tong_bk2,a.tong_bc,a.ngay_nhap as ngayban from hoa_don a,khach_hang b,dm_dia_ban e where a.ma_kh = b.ma_kh and b.id_dia_ban=e.id_dia_ban and a.ma_hd=" + ma_hd;
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
    public DataTable phieuchuachotca()
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select a.ma_hd,b.ten_kh,a.tong_bh,a.tong_bk1,a.tong_bk2,a.tong_bc,a.ca,a.ngay_nhap as ngayban,c.name as nguoiban, d.ten_trangthai from hoa_don a,khach_hang b,users c,trangthai d where a.ma_kh = b.ma_kh and a.nguoi_nhap_id = c.user_name and a.trangthai_id = d.trangthai_id and a.ca is null order by a.ma_hd DESC";
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
    public int huyphieu(string ma_hd)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.CommandText = "update hoa_don set trangthai_id=0 where ma_hd=" + ma_hd;
            cmd.CommandType = CommandType.Text;
            int recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return recordsAffected;
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

    public void chotca(string sophieu, string ca, string nguoiban)
    {
        clsConnect cnstr = new clsConnect();
        SqlConnection myConn = cnstr.ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            myConn.Open();
            cmd.Connection = myConn;
            cmd.CommandText = "update hoa_don set ca=" + ca + ", nguoiban=N'" + nguoiban + "' where ma_hd in (" + sophieu + ")";
            cmd.CommandType = CommandType.Text;
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
    public String NumberToTextVN(decimal total)
    {
        try
        {
            string rs = "";
            total = Math.Round(total, 0);
            string[] ch = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] rch = { "lẻ", "mốt", "", "", "", "lăm" };
            string[] u = { "", "mươi", "trăm", "ngàn", "", "", "triệu", "", "", "tỷ", "", "", "ngàn", "", "", "triệu" };
            string nstr = total.ToString();

            int[] n = new int[nstr.Length];
            int len = n.Length;
            for (int i = 0; i < len; i++)
            {
                n[len - 1 - i] = Convert.ToInt32(nstr.Substring(i, 1));
            }

            for (int i = len - 1; i >= 0; i--)
            {
                if (i % 3 == 2)// số 0 ở hàng trăm
                {
                    if (n[i] == 0 && n[i - 1] == 0 && n[i - 2] == 0) continue;//nếu cả 3 số là 0 thì bỏ qua không đọc
                }
                else if (i % 3 == 1) // số ở hàng chục
                {
                    if (n[i] == 0)
                    {
                        if (n[i - 1] == 0) { continue; }// nếu hàng chục và hàng đơn vị đều là 0 thì bỏ qua.
                        else
                        {
                            rs += " " + rch[n[i]]; continue;// hàng chục là 0 thì bỏ qua, đọc số hàng đơn vị
                        }
                    }
                    if (n[i] == 1)//nếu số hàng chục là 1 thì đọc là mười
                    {
                        rs += " mười"; continue;
                    }
                }
                else if (i != len - 1)// số ở hàng đơn vị (không phải là số đầu tiên)
                {
                    if (n[i] == 0)// số hàng đơn vị là 0 thì chỉ đọc đơn vị
                    {
                        if (i + 2 <= len - 1 && n[i + 2] == 0 && n[i + 1] == 0) continue;
                        rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                        continue;
                    }
                    if (n[i] == 1)// nếu là 1 thì tùy vào số hàng chục mà đọc: 0,1: một / còn lại: mốt
                    {
                        rs += " " + ((n[i + 1] == 1 || n[i + 1] == 0) ? ch[n[i]] : rch[n[i]]);
                        rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                        continue;
                    }
                    if (n[i] == 5) // cách đọc số 5
                    {
                        if (n[i + 1] != 0) //nếu số hàng chục khác 0 thì đọc số 5 là lăm
                        {
                            rs += " " + rch[n[i]];// đọc số 
                            rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
                            continue;
                        }
                    }
                }

                rs += (rs == "" ? " " : ", ") + ch[n[i]];// đọc số
                rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
            }


            if (rs.Length > 2)
            {
                string rs1 = rs.Substring(0, 2);
                rs1 = rs1.ToUpper();
                rs = rs.Substring(2);
                rs = rs1 + rs;
            }
            return rs.Trim().Replace("lẻ,", "lẻ").Replace("mươi,", "mươi").Replace("trăm,", "trăm").Replace("mười,", "mười");
        }
        catch
        {
            return "";
        }
    }
}