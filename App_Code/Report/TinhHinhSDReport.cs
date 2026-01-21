using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for TongHopReport
/// </summary>
public class TinhHinhSDReport : DevExpress.XtraReports.UI.XtraReport
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
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell lblTenTram;
    private XRTableCell lblMuc1;
    private XRTableCell lblMuc2;
    private XRTableCell lblMuc3;
    private XRTableCell lblMuc4;
    private XRTableCell lblMuc5;
    private XRTableCell lblMuc6;
    private XRTableCell lblSX;
    private XRTableCell lblKD;
    private XRTableCell lblCS;
    private XRTableCell lblDX;
    private XRTableCell lblNT;
    private XRTableCell lblBN;
    private XRTableCell lblGBT;
    private XRTableCell lblGCD;
    private XRTableCell lblGTD;
    private XRTableCell lblTongCong;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell17;
    private XRTableCell lblTDKD;
    private XRTableCell xrTableCell18;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public TinhHinhSDReport()
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
            string resourceFileName = "TinhHinhSDReport.resx";
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblTenTram = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblMuc1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblMuc2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblMuc3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblMuc4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblMuc5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblMuc6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblSX = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblKD = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblCS = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblDX = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblNT = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblBN = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblGBT = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblGCD = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblGTD = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblTongCong = new DevExpress.XtraReports.UI.XRTableCell();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDonViBanDien = new DevExpress.XtraReports.UI.XRLabel();
            this.lblLoaiBaoCao = new DevExpress.XtraReports.UI.XRLabel();
            this.lblThangNam = new DevExpress.XtraReports.UI.XRLabel();
            this.lblNgayIn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblTDKD = new DevExpress.XtraReports.UI.XRTableCell();
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
            this.lblTenTram,
            this.lblMuc1,
            this.lblMuc2,
            this.lblMuc3,
            this.lblMuc4,
            this.lblMuc5,
            this.lblMuc6,
            this.lblSX,
            this.lblKD,
            this.lblTDKD,
            this.lblCS,
            this.lblDX,
            this.lblNT,
            this.lblBN,
            this.lblGBT,
            this.lblGCD,
            this.lblGTD,
            this.lblTongCong});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // lblTenTram
            // 
            this.lblTenTram.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblTenTram.Name = "lblTenTram";
            this.lblTenTram.StylePriority.UseFont = false;
            this.lblTenTram.StylePriority.UseTextAlignment = false;
            this.lblTenTram.Text = "lblTenTram";
            this.lblTenTram.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblTenTram.Weight = 1.2828535398285441D;
            // 
            // lblMuc1
            // 
            this.lblMuc1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblMuc1.Name = "lblMuc1";
            this.lblMuc1.StylePriority.UseFont = false;
            this.lblMuc1.StylePriority.UseTextAlignment = false;
            this.lblMuc1.Text = "lblMuc1";
            this.lblMuc1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblMuc1.Weight = 0.61801621559619313D;
            // 
            // lblMuc2
            // 
            this.lblMuc2.Name = "lblMuc2";
            this.lblMuc2.Text = "lblMuc2";
            this.lblMuc2.Weight = 0.61801621559619324D;
            // 
            // lblMuc3
            // 
            this.lblMuc3.Multiline = true;
            this.lblMuc3.Name = "lblMuc3";
            this.lblMuc3.Text = "lblMuc3";
            this.lblMuc3.Weight = 0.61801621559619313D;
            // 
            // lblMuc4
            // 
            this.lblMuc4.Name = "lblMuc4";
            this.lblMuc4.Text = "lblMuc4";
            this.lblMuc4.Weight = 0.61801621559619313D;
            // 
            // lblMuc5
            // 
            this.lblMuc5.Name = "lblMuc5";
            this.lblMuc5.Text = "lblMuc5";
            this.lblMuc5.Weight = 0.61801621559619324D;
            // 
            // lblMuc6
            // 
            this.lblMuc6.Name = "lblMuc6";
            this.lblMuc6.Text = "lblMuc6";
            this.lblMuc6.Weight = 0.61801621559619313D;
            // 
            // lblSX
            // 
            this.lblSX.Name = "lblSX";
            this.lblSX.Text = "lblSX";
            this.lblSX.Weight = 0.51501351051146682D;
            // 
            // lblKD
            // 
            this.lblKD.Name = "lblKD";
            this.lblKD.Text = "lblKD";
            this.lblKD.Weight = 0.51501351796754913D;
            // 
            // lblCS
            // 
            this.lblCS.Name = "lblCS";
            this.lblCS.Text = "lblCS";
            this.lblCS.Weight = 0.51501353015767359D;
            // 
            // lblDX
            // 
            this.lblDX.Name = "lblDX";
            this.lblDX.Text = "lblDX";
            this.lblDX.Weight = 0.5150135301576737D;
            // 
            // lblNT
            // 
            this.lblNT.Name = "lblNT";
            this.lblNT.Text = "lblNT";
            this.lblNT.Weight = 0.51501347121905294D;
            // 
            // lblBN
            // 
            this.lblBN.Name = "lblBN";
            this.lblBN.Text = "lblBN";
            this.lblBN.Weight = 0.618016215596193D;
            // 
            // lblGBT
            // 
            this.lblGBT.Name = "lblGBT";
            this.lblGBT.Text = "lblGBT";
            this.lblGBT.Weight = 0.61801621559619313D;
            // 
            // lblGCD
            // 
            this.lblGCD.Name = "lblGCD";
            this.lblGCD.Text = "lblGCD";
            this.lblGCD.Weight = 0.61801621559619324D;
            // 
            // lblGTD
            // 
            this.lblGTD.Name = "lblGTD";
            this.lblGTD.Text = "lblGTD";
            this.lblGTD.Weight = 0.61801624269848232D;
            // 
            // lblTongCong
            // 
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Text = "lblTongCong";
            this.lblTongCong.Weight = 1.2685130998994931D;
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
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell6,
            this.xrTableCell5,
            this.xrTableCell7,
            this.xrTableCell4,
            this.xrTableCell9,
            this.xrTableCell8,
            this.xrTableCell10,
            this.xrTableCell18,
            this.xrTableCell1,
            this.xrTableCell13,
            this.xrTableCell12,
            this.xrTableCell14,
            this.xrTableCell11,
            this.xrTableCell16,
            this.xrTableCell15,
            this.xrTableCell17});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.StylePriority.UseTextAlignment = false;
            this.xrTableRow3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.CanGrow = false;
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Tên trạm biến áp";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell2.Weight = 21.9456076010116D;
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
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Mức 1";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 10.572323424600882D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.CanGrow = false;
            this.xrTableCell6.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.StylePriority.UsePadding = false;
            this.xrTableCell6.Text = "Mức 2";
            this.xrTableCell6.Weight = 10.572324768941336D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.CanGrow = false;
            this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UsePadding = false;
            this.xrTableCell5.Text = "Mức 3";
            this.xrTableCell5.Weight = 10.572324096771112D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.CanGrow = false;
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.Text = "Mức 4";
            this.xrTableCell7.Weight = 10.572324096771112D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.CanGrow = false;
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UsePadding = false;
            this.xrTableCell4.Text = "Mức 5";
            this.xrTableCell4.Weight = 10.572324096771109D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.CanGrow = false;
            this.xrTableCell9.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.StylePriority.UsePadding = false;
            this.xrTableCell9.Text = "Mức 6";
            this.xrTableCell9.Weight = 10.572324096771112D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.CanGrow = false;
            this.xrTableCell8.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.Text = "SX";
            this.xrTableCell8.Weight = 8.81026949545353D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.CanGrow = false;
            this.xrTableCell10.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.Text = "KD";
            this.xrTableCell10.Weight = 8.8102699066802561D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.CanGrow = false;
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UsePadding = false;
            this.xrTableCell1.Text = "CS";
            this.xrTableCell1.Weight = 8.81026949545353D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.CanGrow = false;
            this.xrTableCell13.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.StylePriority.UsePadding = false;
            this.xrTableCell13.Text = "DX";
            this.xrTableCell13.Weight = 8.81026983153864D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.CanGrow = false;
            this.xrTableCell12.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.StylePriority.UsePadding = false;
            this.xrTableCell12.Text = "NT";
            this.xrTableCell12.Weight = 8.8102721841344529D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.CanGrow = false;
            this.xrTableCell14.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell14.StylePriority.UseFont = false;
            this.xrTableCell14.StylePriority.UsePadding = false;
            this.xrTableCell14.Text = "BN";
            this.xrTableCell14.Weight = 10.572324096771112D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.CanGrow = false;
            this.xrTableCell11.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.StylePriority.UsePadding = false;
            this.xrTableCell11.Text = "GBT";
            this.xrTableCell11.Weight = 10.572324096771109D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.CanGrow = false;
            this.xrTableCell16.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell16.StylePriority.UseFont = false;
            this.xrTableCell16.StylePriority.UsePadding = false;
            this.xrTableCell16.Text = "GCD";
            this.xrTableCell16.Weight = 10.572324096771112D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.CanGrow = false;
            this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UsePadding = false;
            this.xrTableCell15.Text = "GTD";
            this.xrTableCell15.Weight = 10.572324096771112D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.CanGrow = false;
            this.xrTableCell17.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StylePriority.UseFont = false;
            this.xrTableCell17.Text = "Tổng cộng";
            this.xrTableCell17.Weight = 21.700279716305296D;
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
            // xrTableCell18
            // 
            this.xrTableCell18.CanGrow = false;
            this.xrTableCell18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StylePriority.UseFont = false;
            this.xrTableCell18.Text = "TĐKD";
            this.xrTableCell18.Weight = 8.8102695705951426D;
            // 
            // lblTDKD
            // 
            this.lblTDKD.Name = "lblTDKD";
            this.lblTDKD.Text = "lblTDKD";
            this.lblTDKD.Weight = 0.515013517967549D;
            // 
            // TinhHinhSDReport
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

    public void AddBindings(string loaiBaoCao, string thangNam, string ngayIn, string tenDonViBanDien)
    {
        
        lblThangNam.Text = thangNam.Trim();
        lblNgayIn.Text = ngayIn.Trim();
        lblDonViBanDien.Text = tenDonViBanDien.Trim();
        lblLoaiBaoCao.Text = loaiBaoCao.Trim();

        lblTenTram.DataBindings.Add("Text", DataSource, "ten_tram_bien_ap");
        lblMuc1.DataBindings.Add("Text", DataSource, "muc1");
        lblMuc2.DataBindings.Add("Text", DataSource, "muc2");
        lblMuc3.DataBindings.Add("Text", DataSource, "muc3");
        lblMuc4.DataBindings.Add("Text", DataSource, "muc4");
        lblMuc5.DataBindings.Add("Text", DataSource, "muc5");
        lblMuc6.DataBindings.Add("Text", DataSource, "muc6");
        lblSX.DataBindings.Add("Text", DataSource, "SX");
        lblTDKD.DataBindings.Add("Text", DataSource, "TDKD");
        lblKD.DataBindings.Add("Text", DataSource, "KD");
        lblCS.DataBindings.Add("Text", DataSource, "CS");
        lblDX.DataBindings.Add("Text", DataSource, "DX");
        lblNT.DataBindings.Add("Text", DataSource, "NT");
        lblBN.DataBindings.Add("Text", DataSource, "BN");
        lblGBT.DataBindings.Add("Text", DataSource, "GBT");
        lblGCD.DataBindings.Add("Text", DataSource, "GCD");
        lblGTD.DataBindings.Add("Text", DataSource, "GTD");
        lblTongCong.DataBindings.Add("Text", DataSource, "TongCong");
    }
}
