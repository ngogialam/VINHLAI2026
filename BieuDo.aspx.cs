using System;
using System.Data;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;


namespace baocao
{
    public partial class BaoCao_BieuDo : System.Web.UI.Page
    {
        clsBaocao myBaocao = new clsBaocao();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet donvi = myBaocao.SELECT_DANH_SACH_DON_VI();
            txtErr.Text = " ";
            if (!IsPostBack)
            {
                DataSet upe = myBaocao.SELECT_DANH_SACH_UPE("BDPT");
                DataSet port = myBaocao.SELECT_DANH_SACH_PORT("PTO00PTO");
                //cmdSelectDonVi.Items.Add(new ListItem("All", "-1"));
                cmdSelectDonVi.DataSource = donvi;
                cmdSelectDonVi.DataBind();
                cmdSelectUPE.DataSource = upe;
                cmdSelectUPE.DataBind();
                cmdSelectPort.DataSource = port;
                cmdSelectPort.DataBind();
                string strupe = cmdSelectUPE.SelectedValue.ToString();
                string strport = cmdSelectPort.SelectedValue.ToString();
                string sql = "select DESCRIPTION as DIENGIAI from mane_solieu where UPE ='" + strupe + "' and PORT = '" + strport + "' ";
                DataTable dt = myBaocao.SELECT_QUERY(sql);
                txtDienGiai.Text = dt.Rows[0]["DIENGIAI"].ToString();
            }
        }
        protected void cmdSelectDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet upe = myBaocao.SELECT_DANH_SACH_UPE(cmdSelectDonVi.SelectedValue);
            cmdSelectUPE.DataSource = upe;
            cmdSelectUPE.DataBind();
            DataSet port = myBaocao.SELECT_DANH_SACH_PORT(cmdSelectUPE.SelectedValue);
            cmdSelectPort.DataSource = port;
            cmdSelectPort.DataBind();

        }
        protected void cmdSelectUPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet port = myBaocao.SELECT_DANH_SACH_PORT(cmdSelectUPE.SelectedValue);
            cmdSelectPort.DataSource = port;
            cmdSelectPort.DataBind();

        }
        protected void cmdSelectPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string upe = cmdSelectUPE.SelectedValue;
            string port = cmdSelectPort.SelectedValue;
            string sql = "select DESCRIPTION as DIENGIAI from mane_solieu where UPE ='" + upe + "' and PORT = '" + port + "' ";
            DataTable dt = myBaocao.SELECT_QUERY(sql);
            txtDienGiai.Text = dt.Rows[0]["DIENGIAI"].ToString();

        }
        protected void XemBieuDo(object sender, EventArgs e)
        {

            string tungay = Request.Form["strTuNgay"].ToString();
            string denngay = Request.Form["strDenNgay"].ToString();
            // string txttungay = tungay.Substring(6, 2).ToString() + "\\/" + tungay.Substring(4, 2).ToString() + "\\/" + tungay.Substring(0, 4).ToString();


            if (tungay != "-1" && denngay != "-1")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "xembieudo(" + tungay + "," + denngay + ")", true);
                int inttungay = Convert.ToInt32(tungay);
                int intdenngay = Convert.ToInt32(denngay);
                if (inttungay > intdenngay)
                {
                    txtErr.Text = "Thời gian từ ngày phải nhỏ hơn đến ngày";

                }
                else
                {
                    DataSet dts = myBaocao.XEM_BIEU_DO(cmdSelectUPE.SelectedValue, cmdSelectPort.SelectedValue, tungay, denngay);
                    if (dts.Tables[0].Rows.Count > 0)
                    {
                        
                        Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                        Chart1.BorderlineColor = System.Drawing.Color.FromArgb(26, 59, 105);
                        Chart1.BorderlineWidth = 1;
                        Chart1.BackColor = Color.RoyalBlue;

                        Chart1.ChartAreas.Add("chtArea");
                        Chart1.ChartAreas[0].AxisX.Title = "Day";
                        Chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                        Chart1.ChartAreas[0].AxisY.Title = "% BANDWIDTH";
                        Chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                        Chart1.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
                        Chart1.ChartAreas[0].BorderWidth = 2;

                        Chart1.Legends.Add("INPUT");
                        Chart1.Series.Add("INPUT");
                        Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                        Chart1.Series[0].Points.DataBindXY(dts.Tables[0].DefaultView, "NGAY", dts.Tables[0].DefaultView, "INPUT");
                        //Chart1.Series[0].Points.AddY(20);
                        // Chart1.Series[0].Points.AddY(40);

                        //decimal[] y = new decimal[200];
                        //for (int i = 0; i < 200; i++)
                        //{
                        //    x[i] = dt.Rows[i][0].ToString();
                        //    y[i] = Convert.ToInt32(dts.Tables[0].Rows[i][1]);
                        //    Chart1.Series[0].Points.AddY(y[i]);

                        //}
                        //Chart1.Series[0].IsVisibleInLegend = true;
                        //Chart1.Series[0].IsValueShownAsLabel = true;
                        Chart1.Series[0].ToolTip = "INPUT: #VALY{G}";

                        // Setting Line Width
                        Chart1.Series[0].BorderWidth = 1;
                        Chart1.Series[0].Color = Color.Red;


                        Chart1.Series.Add("OUTPUT");
                        Chart1.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                        Chart1.Series[1].Points.DataBindXY(dts.Tables[0].DefaultView, "NGAY", dts.Tables[0].DefaultView, "OUTPUT");

                        Chart1.Series[1].BorderWidth = 1;
                        Chart1.Series[1].Color = Color.Green;
                        Chart1.Series[1].ToolTip = "OUTPUT: #VALY{G}";
                        // Setting Line Shadow
                        //Chart1.Series[0].ShadowOffset = 5;

                        //Legend Properties
                        Chart1.Legends[0].LegendStyle = LegendStyle.Table;
                        Chart1.Legends[0].TableStyle = LegendTableStyle.Wide;
                        Chart1.Legends[0].Docking = Docking.Bottom;
                    }
                    else
                    {
                        txtErr.Text = "Không có dữ liệu!";
                    }
                }
            }
            else
            {
                txtErr.Text = "Chưa nhập khoảng ngày!";
            }

        }

       
    }
}