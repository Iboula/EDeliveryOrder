using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UI
{
    public class PdfMetaData
    {
        
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Select PDF DO File")]
        public HttpPostedFileBase PdfFile { get; set; }
    }
}
