using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for TongHopReport
/// </summary>
public class TongHopReport : DevExpress.XtraReports.UI.XtraReport
{
    private DetailBand Detail;
    private BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private TopMarginBand TopMargin;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRLabel xrLabel3;
    private XRLabel lblDonViBanDien;
    private XRLabel lblLoaiBaoCao;
    private XRLabel lblThangNam;
    private XRLabel lblNgayIn;
    private XRLabel lblTenXomKhu;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell5;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell lblStt;
    private XRTableCell lblTenKh;
    private XRTableCell lblTenXomKhuTable;
    private XRTableCell lblSanLuong;
    private XRTableCell lblTruocThue;
    private XRTableCell lblThueVAT;
    private XRTableCell lblSauThue;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public TongHopReport()
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
            string resourceFileName = "TongHopReport.resx";
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblStt = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblTenKh = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblTenXomKhuTable = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblSanLuong = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblTruocThue = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblThueVAT = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblSauThue = new DevExpress.XtraReports.UI.XRTableCell();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDonViBanDien = new DevExpress.XtraReports.UI.XRLabel();
            this.lblLoaiBaoCao = new DevExpress.XtraReports.UI.XRLabel();
            this.lblThangNam = new DevExpress.XtraReports.UI.XRLabel();
            this.lblNgayIn = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTenXomKhu = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
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
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1147.699F, 25F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UsePadding = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblStt,
            this.lblTenKh,
            this.lblTenXomKhuTable,
            this.lblSanLuong,
            this.lblTruocThue,
            this.lblThueVAT,
            this.lblSauThue});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // lblStt
            // 
            this.lblStt.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblStt.Name = "lblStt";
            this.lblStt.StylePriority.UseFont = false;
            this.lblStt.StylePriority.UseTextAlignment = false;
            this.lblStt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblStt.Weight = 0.54727096305207745D;
            // 
            // lblTenKh
            // 
            this.lblTenKh.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblTenKh.Name = "lblTenKh";
            this.lblTenKh.StylePriority.UseFont = false;
            this.lblTenKh.StylePriority.UseTextAlignment = false;
            this.lblTenKh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblTenKh.Weight = 1.3043121485768281D;
            // 
            // lblTenXomKhuTable
            // 
            this.lblTenXomKhuTable.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblTenXomKhuTable.Name = "lblTenXomKhuTable";
            this.lblTenXomKhuTable.StylePriority.UseFont = false;
            this.lblTenXomKhuTable.StylePriority.UseTextAlignment = false;
            this.lblTenXomKhuTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblTenXomKhuTable.Weight = 2.902661420055074D;
            // 
            // lblSanLuong
            // 
            this.lblSanLuong.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblSanLuong.Name = "lblSanLuong";
            this.lblSanLuong.StylePriority.UseFont = false;
            this.lblSanLuong.StylePriority.UseTextAlignment = false;
            this.lblSanLuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblSanLuong.Weight = 1.1483710720823785D;
            // 
            // lblTruocThue
            // 
            this.lblTruocThue.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblTruocThue.Name = "lblTruocThue";
            this.lblTruocThue.StylePriority.UseFont = false;
            this.lblTruocThue.StylePriority.UseTextAlignment = false;
            this.lblTruocThue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblTruocThue.Weight = 2.1554216307029308D;
            // 
            // lblThueVAT
            // 
            this.lblThueVAT.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblThueVAT.Name = "lblThueVAT";
            this.lblThueVAT.StylePriority.UseFont = false;
            this.lblThueVAT.StylePriority.UseTextAlignment = false;
            this.lblThueVAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblThueVAT.Weight = 2.1554240780908818D;
            // 
            // lblSauThue
            // 
            this.lblSauThue.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblSauThue.Name = "lblSauThue";
            this.lblSauThue.StylePriority.UseFont = false;
            this.lblSauThue.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:#,#.00}";
            this.lblSauThue.Summary = xrSummary1;
            this.lblSauThue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblSauThue.Weight = 2.1554195512651306D;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 27.00005F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.lblDonViBanDien,
            this.lblLoaiBaoCao,
            this.lblThangNam,
            this.lblNgayIn,
            this.lblTenXomKhu,
            this.xrTable3});
            this.PageHeader.HeightF = 171.7922F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0.0713688F, 2.088951F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(441F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "ĐƠN VỊ QUẢN LÝ BÁN ĐIỆN";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblDonViBanDien
            // 
            this.lblDonViBanDien.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lblDonViBanDien.LocationFloat = new DevExpress.Utils.PointFloat(0.0713688F, 25.08895F);
            this.lblDonViBanDien.Multiline = true;
            this.lblDonViBanDien.Name = "lblDonViBanDien";
            this.lblDonViBanDien.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDonViBanDien.SizeF = new System.Drawing.SizeF(441F, 23.00001F);
            this.lblDonViBanDien.StylePriority.UseFont = false;
            this.lblDonViBanDien.StylePriority.UseTextAlignment = false;
            this.lblDonViBanDien.Text = "\r\n";
            this.lblDonViBanDien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblLoaiBaoCao
            // 
            this.lblLoaiBaoCao.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.lblLoaiBaoCao.LocationFloat = new DevExpress.Utils.PointFloat(0.0713688F, 60.42222F);
            this.lblLoaiBaoCao.Multiline = true;
            this.lblLoaiBaoCao.Name = "lblLoaiBaoCao";
            this.lblLoaiBaoCao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblLoaiBaoCao.SizeF = new System.Drawing.SizeF(1154F, 23F);
            this.lblLoaiBaoCao.StylePriority.UseFont = false;
            this.lblLoaiBaoCao.StylePriority.UseTextAlignment = false;
            this.lblLoaiBaoCao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblThangNam
            // 
            this.lblThangNam.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblThangNam.LocationFloat = new DevExpress.Utils.PointFloat(0F, 101.361F);
            this.lblThangNam.Name = "lblThangNam";
            this.lblThangNam.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblThangNam.SizeF = new System.Drawing.SizeF(219.7917F, 23F);
            this.lblThangNam.StylePriority.UseFont = false;
            this.lblThangNam.StylePriority.UseTextAlignment = false;
            this.lblThangNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblNgayIn
            // 
            this.lblNgayIn.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblNgayIn.LocationFloat = new DevExpress.Utils.PointFloat(441.0714F, 101.361F);
            this.lblNgayIn.Name = "lblNgayIn";
            this.lblNgayIn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblNgayIn.SizeF = new System.Drawing.SizeF(219.7917F, 23F);
            this.lblNgayIn.StylePriority.UseFont = false;
            this.lblNgayIn.StylePriority.UseTextAlignment = false;
            this.lblNgayIn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblTenXomKhu
            // 
            this.lblTenXomKhu.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblTenXomKhu.LocationFloat = new DevExpress.Utils.PointFloat(926.8992F, 101.361F);
            this.lblTenXomKhu.Name = "lblTenXomKhu";
            this.lblTenXomKhu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTenXomKhu.SizeF = new System.Drawing.SizeF(220.7286F, 23F);
            this.lblTenXomKhu.StylePriority.UseFont = false;
            this.lblTenXomKhu.StylePriority.UseTextAlignment = false;
            this.lblTenXomKhu.Text = "Khu: ";
            this.lblTenXomKhu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTable3
            // 
            this.xrTable3.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 141.7922F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1147.699F, 30F);
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
            this.xrTableCell5});
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
            this.xrTableCell1.Text = "  TT\r\n";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell1.Weight = 9.3621035544653353D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.CanGrow = false;
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "  Mã KH";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell2.Weight = 22.312693207314226D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.CanGrow = false;
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "  Tên\r\n";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell3.Weight = 49.655436918138271D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.CanGrow = false;
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "  Sản lượng";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell4.Weight = 19.645037933986135D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.CanGrow = false;
            this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.Text = "  Trước thuế";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell15.Weight = 36.87252435117346D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.CanGrow = false;
            this.xrTableCell17.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StylePriority.UseFont = false;
            this.xrTableCell17.StylePriority.UseTextAlignment = false;
            this.xrTableCell17.Text = "  Thuế VAT";
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell17.Weight = 36.872525365985325D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.CanGrow = false;
            this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "  Sau thuế";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell5.Weight = 36.87253099228613D;
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
            // TongHopReport
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

    public void AddBindings(string tenXomKhu, string loaiBaoCao, string thangNam, string ngayIn, string tenDonViBanDien)
    {
        lblTenXomKhu.Text = tenXomKhu.Trim();
        lblThangNam.Text = thangNam.Trim();
        lblNgayIn.Text = ngayIn.Trim();
        lblDonViBanDien.Text = tenDonViBanDien.Trim();
        lblLoaiBaoCao.Text = loaiBaoCao.Trim();

        lblStt.DataBindings.Add("Text", DataSource, "stt");
        lblTenKh.DataBindings.Add("Text", DataSource, "ma");
        lblTenXomKhuTable.DataBindings.Add("Text", DataSource, "ten");
        lblSanLuong.DataBindings.Add("Text", DataSource, "dien_nang_tt", "{0:#,# ;(#,#);0}");
        lblTruocThue.DataBindings.Add("Text", DataSource, "tong_tien_truoc_thue", "{0:#,# ;(#,#);0}");
        lblThueVAT.DataBindings.Add("Text", DataSource, "thue_gtgt", "{0:#,# ;(#,#);0}");
        lblSauThue.DataBindings.Add("Text", DataSource, "tong_tien_sau_thue", "{0:#,# ;(#,#);0}");
    }
}
