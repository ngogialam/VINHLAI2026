using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for QuanTriReport
/// </summary>
public class QuanTriReport : DevExpress.XtraReports.UI.XtraReport
{
    private XRTableCell lblMaKh;
    private XRTableCell lblDiaChi;
    private XRTableRow xrTableRow1;
    private XRTableCell lblStt;
    private XRTableCell lblTenKh;
    private XRTableCell lblSoHo;
    private DetailBand Detail;
    private XRTable xrTable1;
    private BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private TopMarginBand TopMargin;
    private XRLabel xrLabel3;
    private XRLabel lblLoaiBaoCao;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell17;
    private XRLabel lblTenTramBA;
    private XRLabel lblXomKhu;
    private ReportFooterBand ReportFooter;
    private XRLabel lblDonViBanDien;
    private XRLabel lblThamSo;
    private XRLabel lblThangNam;
    private XRTableCell xrTableCell27;
    private XRTableCell lblSauThue;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell lblLoaiHinh;
    private XRTableCell lblCSDK;
    private XRTableCell lblCSCK;
    private XRTableCell lblTieuThu;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public QuanTriReport()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.lblMaKh = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblDiaChi = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblStt = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblTenKh = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblSoHo = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblLoaiHinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblCSDK = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblCSCK = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblTieuThu = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblSauThue = new DevExpress.XtraReports.UI.XRTableCell();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.lblThamSo = new DevExpress.XtraReports.UI.XRLabel();
            this.lblThangNam = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDonViBanDien = new DevExpress.XtraReports.UI.XRLabel();
            this.lblXomKhu = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTenTramBA = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblLoaiBaoCao = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // lblMaKh
            // 
            this.lblMaKh.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.lblMaKh.Name = "lblMaKh";
            this.lblMaKh.StylePriority.UseFont = false;
            this.lblMaKh.StylePriority.UseTextAlignment = false;
            this.lblMaKh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblMaKh.Weight = 1.0106796380872229D;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.StylePriority.UseFont = false;
            this.lblDiaChi.StylePriority.UseTextAlignment = false;
            this.lblDiaChi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblDiaChi.Weight = 1.776695816214398D;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblStt,
            this.lblMaKh,
            this.lblTenKh,
            this.lblDiaChi,
            this.lblSoHo,
            this.lblLoaiHinh,
            this.lblCSDK,
            this.lblCSCK,
            this.lblTieuThu,
            this.lblSauThue});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // lblStt
            // 
            this.lblStt.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.lblStt.Name = "lblStt";
            this.lblStt.StylePriority.UseFont = false;
            this.lblStt.Weight = 0.31882194404669989D;
            // 
            // lblTenKh
            // 
            this.lblTenKh.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.lblTenKh.Name = "lblTenKh";
            this.lblTenKh.StylePriority.UseFont = false;
            this.lblTenKh.StylePriority.UseTextAlignment = false;
            this.lblTenKh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblTenKh.Weight = 1.898502874425348D;
            // 
            // lblSoHo
            // 
            this.lblSoHo.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.lblSoHo.Name = "lblSoHo";
            this.lblSoHo.StylePriority.UseFont = false;
            this.lblSoHo.StylePriority.UseTextAlignment = false;
            this.lblSoHo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblSoHo.Weight = 0.77053206727971579D;
            // 
            // lblLoaiHinh
            // 
            this.lblLoaiHinh.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.lblLoaiHinh.Name = "lblLoaiHinh";
            this.lblLoaiHinh.StylePriority.UseFont = false;
            this.lblLoaiHinh.Weight = 0.77053258982985429D;
            // 
            // lblCSDK
            // 
            this.lblCSDK.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.lblCSDK.Name = "lblCSDK";
            this.lblCSDK.StylePriority.UseFont = false;
            this.lblCSDK.StylePriority.UseTextAlignment = false;
            this.lblCSDK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblCSDK.Weight = 0.77053051223185487D;
            // 
            // lblCSCK
            // 
            this.lblCSCK.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.lblCSCK.Name = "lblCSCK";
            this.lblCSCK.StylePriority.UseFont = false;
            this.lblCSCK.StylePriority.UseTextAlignment = false;
            this.lblCSCK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblCSCK.Weight = 0.770531696534515D;
            // 
            // lblTieuThu
            // 
            this.lblTieuThu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTieuThu.Name = "lblTieuThu";
            this.lblTieuThu.StylePriority.UseFont = false;
            this.lblTieuThu.StylePriority.UseTextAlignment = false;
            this.lblTieuThu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblTieuThu.Weight = 0.77053162647822182D;
            // 
            // lblSauThue
            // 
            this.lblSauThue.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSauThue.Name = "lblSauThue";
            this.lblSauThue.StylePriority.UseFont = false;
            this.lblSauThue.StylePriority.UseTextAlignment = false;
            this.lblSauThue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblSauThue.Weight = 0.93695315435344062D;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1144F, 25F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UsePadding = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 27F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblThamSo,
            this.lblThangNam,
            this.lblDonViBanDien,
            this.lblXomKhu,
            this.lblTenTramBA,
            this.xrTable3,
            this.lblLoaiBaoCao,
            this.xrLabel3});
            this.PageHeader.HeightF = 169.7088F;
            this.PageHeader.Name = "PageHeader";
            // 
            // lblThamSo
            // 
            this.lblThamSo.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblThamSo.LocationFloat = new DevExpress.Utils.PointFloat(265.9717F, 95.78577F);
            this.lblThamSo.Name = "lblThamSo";
            this.lblThamSo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblThamSo.SizeF = new System.Drawing.SizeF(281.1756F, 23F);
            this.lblThamSo.StylePriority.UseFont = false;
            this.lblThamSo.StylePriority.UseTextAlignment = false;
            this.lblThamSo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblThangNam
            // 
            this.lblThangNam.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblThangNam.LocationFloat = new DevExpress.Utils.PointFloat(611.3991F, 95.78577F);
            this.lblThangNam.Name = "lblThangNam";
            this.lblThangNam.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblThangNam.SizeF = new System.Drawing.SizeF(219.7917F, 23F);
            this.lblThangNam.StylePriority.UseFont = false;
            this.lblThangNam.StylePriority.UseTextAlignment = false;
            this.lblThangNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblDonViBanDien
            // 
            this.lblDonViBanDien.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lblDonViBanDien.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23.00001F);
            this.lblDonViBanDien.Multiline = true;
            this.lblDonViBanDien.Name = "lblDonViBanDien";
            this.lblDonViBanDien.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDonViBanDien.SizeF = new System.Drawing.SizeF(441F, 23F);
            this.lblDonViBanDien.StylePriority.UseFont = false;
            this.lblDonViBanDien.StylePriority.UseTextAlignment = false;
            this.lblDonViBanDien.Text = "\r\n";
            this.lblDonViBanDien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblXomKhu
            // 
            this.lblXomKhu.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblXomKhu.LocationFloat = new DevExpress.Utils.PointFloat(944.624F, 95.78577F);
            this.lblXomKhu.Name = "lblXomKhu";
            this.lblXomKhu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblXomKhu.SizeF = new System.Drawing.SizeF(197.1956F, 23F);
            this.lblXomKhu.StylePriority.UseFont = false;
            this.lblXomKhu.StylePriority.UseTextAlignment = false;
            this.lblXomKhu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblTenTramBA
            // 
            this.lblTenTramBA.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblTenTramBA.LocationFloat = new DevExpress.Utils.PointFloat(3.400104F, 95.78577F);
            this.lblTenTramBA.Name = "lblTenTramBA";
            this.lblTenTramBA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTenTramBA.SizeF = new System.Drawing.SizeF(220.7286F, 23F);
            this.lblTenTramBA.StylePriority.UseFont = false;
            this.lblTenTramBA.StylePriority.UseTextAlignment = false;
            this.lblTenTramBA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable3
            // 
            this.xrTable3.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 139.7088F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1144F, 30F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell15,
            this.xrTableCell17,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell27,
            this.xrTableCell7});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.CanGrow = false;
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "STT\r\n";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 6.8655280774098246D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.CanGrow = false;
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Mã KH";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 21.763988493212704D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.CanGrow = false;
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Họ tên";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 40.882390814674885D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.CanGrow = false;
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "Địa chỉ";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell4.Weight = 38.25940981611069D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.CanGrow = false;
            this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.Text = "Số hộ";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell15.Weight = 16.592638533960724D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.CanGrow = false;
            this.xrTableCell17.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StylePriority.UseFont = false;
            this.xrTableCell17.StylePriority.UseTextAlignment = false;
            this.xrTableCell17.Text = "Loại hình";
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell17.Weight = 16.592638642754675D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.CanGrow = false;
            this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.Text = "CSĐK";
            this.xrTableCell5.Weight = 16.592638450695333D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.CanGrow = false;
            this.xrTableCell6.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.Text = "CSCK";
            this.xrTableCell6.Weight = 16.592638450695329D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.CanGrow = false;
            this.xrTableCell27.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StylePriority.UseFont = false;
            this.xrTableCell27.Text = "Tiêu thụ";
            this.xrTableCell27.Weight = 16.592638346519209D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.CanGrow = false;
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.Text = "Sau thuế";
            this.xrTableCell7.Weight = 20.176358905961806D;
            // 
            // lblLoaiBaoCao
            // 
            this.lblLoaiBaoCao.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.lblLoaiBaoCao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 57.52412F);
            this.lblLoaiBaoCao.Multiline = true;
            this.lblLoaiBaoCao.Name = "lblLoaiBaoCao";
            this.lblLoaiBaoCao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblLoaiBaoCao.SizeF = new System.Drawing.SizeF(1152.933F, 23F);
            this.lblLoaiBaoCao.StylePriority.UseFont = false;
            this.lblLoaiBaoCao.StylePriority.UseTextAlignment = false;
            this.lblLoaiBaoCao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(441F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "ĐƠN VỊ QUẢN LÝ BÁN ĐIỆN";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 27F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel2});
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(704.4065F, 14.83335F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(448.5266F, 22.99998F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "CTHĐQT - GIÁM ĐỐC";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(37.23927F, 14.83339F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(402.2761F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Người lập biểu";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // QuanTriReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(15, 0, 27, 27);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "12.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    public void AddBindings(string tenTramBA, string xomKhu, string thangNam, string loaiBaoCao, string thamSo, string tenDonViBanDien)
    {
        lblTenTramBA.Text = tenTramBA.Trim();
        lblXomKhu.Text = xomKhu.Trim();
        lblThangNam.Text = thangNam.Trim();
        lblThamSo.Text = thamSo.Trim();
        lblLoaiBaoCao.Text = loaiBaoCao.Trim();
        lblDonViBanDien.Text = tenDonViBanDien.Trim();

        lblStt.DataBindings.Add("Text", DataSource, "stt");
        lblTenKh.DataBindings.Add("Text", DataSource, "ten_kh");
        lblMaKh.DataBindings.Add("Text", DataSource, "ma_kh");
        lblDiaChi.DataBindings.Add("Text", DataSource, "dia_chi");
        lblSoHo.DataBindings.Add("Text", DataSource, "so_ho");
        lblLoaiHinh.DataBindings.Add("Text", DataSource, "ten_viet_tat");
        lblCSDK.DataBindings.Add("Text", DataSource, "chi_so_cu", "{0:#,# ;(#,#);0}");
        lblCSCK.DataBindings.Add("Text", DataSource, "chi_so_moi", "{0:#,# ;(#,#);0}");
        lblTieuThu.DataBindings.Add("Text", DataSource, "dien_nang_tt", "{0:#,# ;(#,#);0}");
        lblSauThue.DataBindings.Add("Text", DataSource, "tong_tien_sau_thue", "{0:#,# ;(#,#);0}");
    }
}
