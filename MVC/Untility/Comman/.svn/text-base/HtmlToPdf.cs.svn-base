using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpertPdf.HtmlToPdf;
using System.Web;

using System.Configuration;
using Elmah;

namespace Untility.Comman
{
    public class HtmlToPdf
    {
        /// <summary>
        /// 打印到文件
        /// </summary>
        public void PrintToPDF(string sPrintContent)
        {
            try
            {
                string htmlString = sPrintContent;
                bool selectablePDF = true;

                PdfConverter pdfConverter = new PdfConverter();
                // pdfConverterKey
                pdfConverter.LicenseKey = ConfigurationManager.AppSettings["pdfConverterKey"];
                pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
                pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Normal;
                pdfConverter.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Portrait;

                pdfConverter.PdfDocumentOptions.ShowHeader = true;
                pdfConverter.PdfDocumentOptions.ShowFooter = true;
                pdfConverter.PdfDocumentOptions.GenerateSelectablePdf = true;
                pdfConverter.PdfDocumentOptions.FitWidth = true;
                pdfConverter.PdfDocumentOptions.EmbedFonts = false;
                pdfConverter.PdfDocumentOptions.LiveUrlsEnabled = true;

                if (true)
                {
                    pdfConverter.ScriptsEnabled = true;
                    pdfConverter.ActiveXEnabled = true;
                }
                else
                {
                    pdfConverter.ScriptsEnabledInImage = true;
                    pdfConverter.ActiveXEnabledInImage = true;
                }

                pdfConverter.PdfDocumentOptions.JpegCompressionEnabled = true;

                if (false)
                {
                    pdfConverter.PdfBookmarkOptions.TagNames = new string[] { "H1", "H2" };
                }

                pdfConverter.PdfDocumentInfo.AuthorName = "ExperPDF HTML to PDF Converter";

                if (true)
                    AddHeader(pdfConverter);
                if (true)
                    AddFooter(pdfConverter);

                byte[] pdfBytes = null;
                pdfBytes = pdfConverter.GetPdfBytesFromHtmlString(htmlString);

                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.AddHeader("Content-Type", "binary/octet-stream");
                response.AddHeader("Content-Disposition",
                    string.Format("attachment; filename={0}.pdf; size={1}", Guid.NewGuid(), pdfBytes.Length.ToString()));
                response.Flush();
                response.BinaryWrite(pdfBytes);
                response.Flush();
                response.End();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
            }
        }

        /// <summary>
        /// 页头
        /// </summary>
        /// <param name="pdfConverter"></param>
        private void AddHeader(PdfConverter pdfConverter)
        {
            string thisPageURL = HttpContext.Current.Request.Url.AbsoluteUri;
            string headerAndFooterHtmlUrl = thisPageURL.Substring(0, thisPageURL.LastIndexOf('/')) + "/HeaderAndFooterHtml.htm";

            pdfConverter.PdfDocumentOptions.ShowHeader = true;
            pdfConverter.PdfHeaderOptions.HeaderHeight = 60;
            pdfConverter.PdfHeaderOptions.HtmlToPdfArea = new HtmlToPdfArea(0, 0, -1, pdfConverter.PdfHeaderOptions.HeaderHeight,
                        headerAndFooterHtmlUrl, 1024, -1);
            pdfConverter.PdfHeaderOptions.HtmlToPdfArea.FitHeight = true;
            pdfConverter.PdfHeaderOptions.HtmlToPdfArea.EmbedFonts = false;
        }

        /// <summary>
        /// 页脚
        /// </summary>
        /// <param name="pdfConverter"></param>
        private void AddFooter(PdfConverter pdfConverter)
        {
            string thisPageURL = HttpContext.Current.Request.Url.AbsoluteUri;
            string headerAndFooterHtmlUrl = thisPageURL.Substring(0, thisPageURL.LastIndexOf('/')) + "/HeaderAndFooterHtml.htm";

            pdfConverter.PdfDocumentOptions.ShowFooter = true;
            pdfConverter.PdfFooterOptions.FooterHeight = 60;
            pdfConverter.PdfFooterOptions.TextArea = new TextArea(0, 30, "This is page &p; of &P;  ",
                new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10, System.Drawing.GraphicsUnit.Point));
            pdfConverter.PdfFooterOptions.TextArea.EmbedTextFont = true;
            pdfConverter.PdfFooterOptions.TextArea.TextAlign = HorizontalTextAlign.Right;
            pdfConverter.PdfFooterOptions.HtmlToPdfArea = new HtmlToPdfArea(0, 0, -1, pdfConverter.PdfFooterOptions.FooterHeight,
                        headerAndFooterHtmlUrl, 1024, -1);
            pdfConverter.PdfFooterOptions.HtmlToPdfArea.FitHeight = true;
            pdfConverter.PdfFooterOptions.HtmlToPdfArea.EmbedFonts = false;
        }
    }
}
