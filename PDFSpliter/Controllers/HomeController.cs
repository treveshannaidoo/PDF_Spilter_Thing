using System;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PDFSpliter.Models;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace PDFSpliter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ClaimDocumentModel claimDocumentModel)
        {
            var files = claimDocumentModel.files;
            var fileExt = Path.GetExtension(files.FileName)?.ToUpper();

            if (fileExt == ".PDF")
            {
                var documentName = claimDocumentModel.ClaimNumber + " " + claimDocumentModel.DocumentName + ".pdf";
                var stream = files.InputStream;
                var pdfDocument = PdfReader.Open(stream, PdfDocumentOpenMode.Import);
                var pageNumbers = claimDocumentModel.Pages.Split(new []{','},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
                var pdfDocumentPages = pdfDocument.Pages;

                var documentOfPageOne = new PdfDocument();
                foreach (var pageNumber in pageNumbers)
                {
                    documentOfPageOne.AddPage(pdfDocumentPages[pageNumber]);
                }

                documentOfPageOne.Info.Author = "Chillisoft";
             
                var path = Server.MapPath("~/Uploads");
                var combine = Path.Combine(path, documentName);
                documentOfPageOne.Save(combine);
                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.FileStatus = "Invalid file format.";
                return View();

            }

        }

        public ActionResult PdfRender()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}