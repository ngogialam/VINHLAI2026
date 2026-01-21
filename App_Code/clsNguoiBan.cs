using System;
using System.Data;

public class clsNguoiBan
{
    clsConnect cnstr = new clsConnect();

    public DataTable get_danh_sach_nguoi_ban()
    {
        string sqlQuery = "select 0 ma_nguoiban, N'--Chọn người bán--' ten_nguoiban union all select ma_nguoiban,ten_nguoiban from nguoiban";
        DataTable new_table = cnstr.GetDataTable(sqlQuery);
        return new_table;
    }
}