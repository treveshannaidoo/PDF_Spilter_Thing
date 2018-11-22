using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDFSpliter.Models
{
    public class ClaimDocumentModel
    {
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Select File")]
        public HttpPostedFileBase files { get; set; }
        public string ClaimNumber { get; set; }
        public string DocumentName { get; set; }
        public string Pages { get; set; }
        //public IEnumerable<DocumentPage> DocumentPages { get; set; }
    }

    public class FileDetailsModel
    {
        public int Id { get; set; }
        [Display(Name = "Uploaded File")]
        public String FileName { get; set; }
        public byte[] FileContent { get; set; }
        
    }

    public class DocumentPage
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }
}