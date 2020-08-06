using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure
{
    public class BadMetaData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BadMetaData()
        {
            this.Container = new HashSet<Container>();
        }

        public int BadID { get; set; }
        [Required, Display(Name = "BL Number"), StringLength(50)]
        public string BLNumber { get; set; }

        [Required, Display(Name = "Issue Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> DateEmission { get; set; }

        [Required, Display(Name = "Cargo Weight"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> DateValidite { get; set; }

        [Display(Name = "Customer Ninea"), StringLength(15)]
        public string CustomerNinea { get; set; }

        [Required, Display(Name = "Customer Name"), StringLength(250)]
        public string CustomerName { get; set; }

        [Required, Display(Name = "Customer PhoneNumber"), StringLength(20)]
        public string CustomerPhoneNumber { get; set; }

        [Display(Name = "Customer Email"), Required(ErrorMessage = "Please enter your e-mail address."), StringLength(80), DataType(DataType.EmailAddress)]
        //[EmailValidation(ErrorMessage = "The Email Address already exists")]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", ErrorMessage = "Invalid email format.")]
        public string CustomerEmail { get; set; }

        [Required, Display(Name = "Customer Address"), StringLength(250)]
        public string CustomerAddress { get; set; }

        

        [Required, Display(Name = "Shipper Name"), StringLength(250)]
        public string ShipperName { get; set; }

        [Required, Display(Name = "Shipper Address"), StringLength(250)]
        public string ShipperAddress { get; set; }

        [Required, Display(Name = "Consignee Name"), StringLength(250)]
        public string ConsigneeName { get; set; }

        [Required, Display(Name = "Consignee Address"), StringLength(250)]
        public string ConsigneeAddress { get; set; }

        [Required, Display(Name = "Notify Party"), StringLength(250)]
        public string NotifyParty { get; set; }

        public Nullable<int> VoyageID { get; set; }
        public Nullable<bool> Status { get; set; }

        public virtual Voyage Voyage { get; set; }
        public virtual ICollection<Container> Container { get; set; }

        public int CountContainer { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Select PDF DO File")]
        public HttpPostedFileBase PdfFile { get; set; }
    }

    [MetadataType(typeof(BadMetaData))]
    partial class Bad
    {

    }
}
