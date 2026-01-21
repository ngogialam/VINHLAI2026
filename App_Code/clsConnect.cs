using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;

public class clsConnect
{
    public SqlConnection ConnectSQL()
    {
        string constr = "Data Source=10.24.30.12;Initial Catalog=VINHLAI_EMAN;user id=eman;password=Eman@2019;";
        // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection myConn = new SqlConnection(constr);
        return myConn;
    }

    public DataTable GetDataTable(string sql)
    {
        SqlConnection myConn = null;
        try
        {
            myConn = ConnectSQL();
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

    public int InsertUpdateDataTable(string sql)
    {
        int recordsAffected = 0;
        SqlConnection myConn = null;
        myConn = ConnectSQL();
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.Connection = myConn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            myConn.Open();
            recordsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        catch (SqlException) {}
        finally
        {
            cmd.Connection.Close();
            myConn.Close();
        }
        return recordsAffected;
    }

    public static string MD5Hash(string text)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        //compute hash from the bytes of text  
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
        //get hash result after compute it  
        byte[] result = md5.Hash;
        StringBuilder strBuilder = new StringBuilder();
        for (int i = 0; i < result.Length; i++)
        {
            //change it into 2 hexadecimal digits  
            //for each byte  
            strBuilder.Append(result[i].ToString("x2"));
        }
        return strBuilder.ToString();
    }

    public int Authenticate(string ten_dang_nhap, string mat_khau)
    {
        int loginSuccess = 0;
        string pass = MD5Hash(mat_khau);
        try
        {
            clsConnect cnstr = new clsConnect();
            SqlConnection myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select * from users where user_name='" + ten_dang_nhap + "' and password='" + pass + "' and status=1 ";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            myConn.Close();
            if (dts.Tables[0].Rows.Count == 1)
                loginSuccess = 1;
            else
                loginSuccess = 0;
        }
        catch (SqlException) { }
        return loginSuccess;
    }

    public DataTable getUser(string ten_dang_nhap)
    {
        string sqlquery = string.Format("select users.*, doanh_nghiep.ten_doanh_nghiep,doanh_nghiep.id_doanh_nghiep from users, doanh_nghiep where users.user_name='{0}'and users.status=1 and users.id_doanh_nghiep = doanh_nghiep.id_doanh_nghiep", ten_dang_nhap);
        DataTable new_table = GetDataTable(sqlquery);
        return new_table;
    }

    public int change_pass(string user_name, string passnew)
    {
        string sqlquery = string.Format("update users set password = '{1}' where user_name = '{0}' ", user_name, passnew);
        return InsertUpdateDataTable(sqlquery);
    }

    protected string GetIPAddress()
    {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }
        return context.Request.ServerVariables["REMOTE_ADDR"];
    }

    //loai =1 dang nhap
    //loai = 2 ban hang
    //loai = 3 huy don
    //loai = 4 them kh
    //loai = 5 chot ca
    public int save_log(string user_name, string thao_tac, string loai)
    {
        string IPAddress = GetIPAddress();
        string sqlquery = string.Format("insert into ghi_log(user_name, thao_tac, ip, loai, thoigian) values(N'{0}', N'{1}', '{2}', '{3}', CONVERT( Datetime, GETDATE() ,103)) ", user_name, thao_tac, IPAddress, loai);
        return InsertUpdateDataTable(sqlquery);
    }

    public string get_tenND(string user_name)
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select name from users where user_name='" + user_name + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            return dts.Tables[0].Rows[0]["name"].ToString();
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

    public string get_iddoanhnghiep(string user_name)
    {
        SqlConnection myConn = null;
        try
        {
            clsConnect cnstr = new clsConnect();
            myConn = cnstr.ConnectSQL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "select id_doanh_nghiep from users where user_name='" + user_name + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter myData = new SqlDataAdapter(cmd);
            DataSet dts = new DataSet();
            myConn.Open();
            myData.Fill(dts);
            myData.Dispose();
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            return dts.Tables[0].Rows[0]["id_doanh_nghiep"].ToString();
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
}
