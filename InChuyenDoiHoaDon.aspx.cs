using System;
using System.Web.UI.WebControls;
using System.Data;
using NReco.PdfGenerator;
using System.IO;
using System.Text;
using System.Collections.Generic;
public partial class InChuyenDoiHoaDon : System.Web.UI.Page
{


    HtmlToPdfConverter htmlToPdf = new HtmlToPdfConverter();    
    clsHoaDon myINV = new clsHoaDon();
    clsNguoiBan mySeller = new clsNguoiBan();
    clsNhapChiSo myNCS = new clsNhapChiSo();
    DataTable invList = new DataTable();

    private static string adminName = "eman";
    private static string adminPass = "Einv@oi@vn#pt21";
    private static string userName = "emanws";
    private static string userPass = "Einv@oi@vn#pt20";
    private static string pattern = "1/001";
    private static string serial = "C22TVL";

    protected void Page_Load(object sender, EventArgs e)
    {
        txtErr.Text = "";
        if (!IsPostBack)
        {
            drpTram.DataSource = myNCS.get_danh_sach_tba_notall();
            drpTram.DataBind();

            drpKy.DataSource = myNCS.get_danhsach_ky();
            drpKy.DataBind();

            gv_bind();
        }
    }

    protected void gv_bind()
    {
        string id_tram = drpTram.SelectedValue.ToString();
        string kyhd = drpKy.SelectedItem.ToString();
        invList = myINV.get_danh_sach_hddt(id_tram, kyhd, "2");
        GridViewEman.DataSource = invList;
        GridViewEman.DataBind();

        if (invList.Rows.Count > 0)
        {
            GridViewEman.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btnInLoHD_Click(object sender, EventArgs e)
    {
        string id_tram = drpTram.SelectedValue.ToString();
        string kyhd = drpKy.SelectedItem.ToString();
        
        invList = myINV.get_danh_sach_chuyen_doi(id_tram, kyhd, "2");
        
        // Xử lý theo batch để tránh OutOfMemory
        const int BATCH_SIZE = 100; // Giới hạn 50 hóa đơn mỗi batch
        int totalInvoices = invList.Rows.Count;
        
        if (totalInvoices == 0)
        {
            txtErr.Text = "Không có hóa đơn nào để chuyển đổi.";
            return;
        }
        
        try
        {
            // Nếu số lượng nhỏ (<=50), xử lý 1 file PDF duy nhất
            if (totalInvoices <= BATCH_SIZE)
            {
                ProcessSinglePDF(invList, id_tram, kyhd);
            }
            else
            {
                // Nếu nhiều hơn 50, tạo nhiều file PDF và nén ZIP
                ProcessMultipleBatchesAsZip(invList, totalInvoices, BATCH_SIZE, id_tram, kyhd);
            }
        }
        catch (OutOfMemoryException)
        {
            txtErr.Text = "Lỗi: Hết bộ nhớ. Vui lòng giảm số lượng hóa đơn hoặc liên hệ quản trị viên.";
        }
        catch (Exception ex)
        {
            txtErr.Text = "Lỗi: " + ex.Message;
        }
    }
    
    // Xử lý 1 file PDF duy nhất (dùng cho <=50 hóa đơn)
    private void ProcessSinglePDF(DataTable invoices, string id_tram, string kyhd)
    {
        StringBuilder htmlInvBuilder = new StringBuilder();
        int processedCount = 0;
        
        for (int i = 0; i < invoices.Rows.Count; i++)
        {
            try
            {
                string fkey = invoices.Rows[i]["id"].ToString();
                string invoiceHtml = myINV.PrintInvoice(fkey, userName, userPass);
                
                if (!invoiceHtml.Contains("ERR"))
                {
                    if (processedCount > 0)
                        htmlInvBuilder.Append("<p style='page-break-after:always;'></p>");
                    htmlInvBuilder.Append(invoiceHtml);
                    processedCount++;
                }
                
                // Clear memory mỗi 10 hóa đơn
                if (i % 10 == 0)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
            catch (Exception ex)
            {
                txtErr.Text += "<br/>Lỗi hóa đơn: " + ex.Message;
            }
        }
        
        if (processedCount > 0)
        {
            string htmlInv = htmlInvBuilder.ToString();
            htmlInvBuilder.Clear();
            
            htmlToPdf.Orientation = PageOrientation.Landscape;
            htmlToPdf.Zoom = 1.40f;
            htmlToPdf.Margins.Top = 1;
            htmlToPdf.Margins.Bottom = 1;
            htmlToPdf.Margins.Left = 1;
            htmlToPdf.Margins.Right = 1;
            htmlToPdf.Size = NReco.PdfGenerator.PageSize.A4;
            
            var pdfBytes = htmlToPdf.GeneratePdf(htmlInv);
            string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm");
            string pdfdownloadname = timestamp + "_inv_" + id_tram + "_" + kyhd.Replace("/", string.Empty) + ".pdf";
            
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + pdfdownloadname);
            Response.BinaryWrite(pdfBytes);
            Response.End();
        }
    }
    
    // Xử lý nhiều batch và lưu file PDF ra thư mục
    private void ProcessMultipleBatchesAsZip(DataTable invoices, int totalInvoices, int batchSize, string id_tram, string kyhd)
    {
        int batchCount = (int)Math.Ceiling((double)totalInvoices / batchSize);
        string folderName = "RepConvertInv";
        string folderPath = Server.MapPath("~/" + folderName);
        
        // Tạo folder nếu chưa có
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        
        txtErr.Text = string.Format("Đang xử lý {0} hóa đơn thành {1} file PDF...<br/>", totalInvoices, batchCount);
        
        List<string> savedFiles = new List<string>();
        
        // Xử lý từng batch và lưu PDF ra file
        for (int batchIndex = 0; batchIndex < batchCount; batchIndex++)
        {
            int startIndex = batchIndex * batchSize;
            int count = Math.Min(batchSize, totalInvoices - startIndex);
            
            try
            {
                byte[] pdfBytes = CreatePDFFromBatch(invoices, startIndex, count);
                if (pdfBytes != null && pdfBytes.Length > 0)
                {
                    string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm");
                    string pdfFileName = string.Format("{0}_inv_{1}_{2}_batch{3}.pdf", 
                        timestamp, id_tram, kyhd.Replace("/", string.Empty), batchIndex + 1);
                    string pdfFilePath = Path.Combine(folderPath, pdfFileName);
                    
                    // Lưu PDF ra file
                    File.WriteAllBytes(pdfFilePath, pdfBytes);
                    savedFiles.Add(pdfFileName);
                    
                    txtErr.Text += string.Format("✓ Đã tạo: <a href='{0}/{1}' target='_blank'>{1}</a> ({2} KB)<br/>", 
                        folderName, pdfFileName, pdfBytes.Length / 1024);
                }
                
                // Clear memory sau mỗi batch
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                txtErr.Text += string.Format("<br/>❌ Lỗi batch {0}: {1}", batchIndex + 1, ex.Message);
            }
        }
        
        if (savedFiles.Count > 0)
        {
            txtErr.Text += string.Format("<br/><br/><b>✅ Hoàn thành! Đã tạo {0} file PDF.</b><br/>", savedFiles.Count);
            txtErr.Text += "Các file đã được lưu vào thư mục <b>RepConvertInv</b>. Click vào link ở trên để download từng file.";
        }
    }
    
    // Tạo 1 PDF từ 1 batch
    private byte[] CreatePDFFromBatch(DataTable invoices, int startIndex, int count)
    {
        StringBuilder htmlInvBuilder = new StringBuilder();
        int processedCount = 0;
        
        for (int i = startIndex; i < startIndex + count && i < invoices.Rows.Count; i++)
        {
            try
            {
                string fkey = invoices.Rows[i]["id"].ToString();
                string invoiceHtml = myINV.PrintInvoice(fkey, userName, userPass);
                
                if (!invoiceHtml.Contains("ERR"))
                {
                    if (processedCount > 0)
                        htmlInvBuilder.Append("<p style='page-break-after:always;'></p>");
                    htmlInvBuilder.Append(invoiceHtml);
                    processedCount++;
                }
            }
            catch { /* Skip lỗi */ }
        }
        
        if (processedCount > 0)
        {
            string htmlInv = htmlInvBuilder.ToString();
            htmlInvBuilder.Clear();
            
            htmlToPdf.Orientation = PageOrientation.Landscape;
            htmlToPdf.Zoom = 1.40f;
            htmlToPdf.Margins.Top = 1;
            htmlToPdf.Margins.Bottom = 1;
            htmlToPdf.Margins.Left = 1;
            htmlToPdf.Margins.Right = 1;
            htmlToPdf.Size = NReco.PdfGenerator.PageSize.A4;
            
            byte[] pdfBytes = htmlToPdf.GeneratePdf(htmlInv);
            htmlInv = null;
            
            return pdfBytes;
        }
        
        return null;
    }


    protected void drpTram_SelectedIndexChanged(object sender, EventArgs e)
    {
        gv_bind();
    }
}
