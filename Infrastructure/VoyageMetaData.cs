using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class VoyageMetaData
    {
        public VoyageMetaData()
        {
            this.Bad = new HashSet<Bad>();
        }

        public int VoyageID { get; set; }
        public Nullable<int> ShippingLineID { get; set; }
        [Required]
        [Display(Name = "POL")]
        public Nullable<int> PortOfLoading { get; set; }
        [Required]
        [Display(Name = "POD")]
        public Nullable<int> PortOfDischarge { get; set; }
        [Required]
        [Display(Name = "Port Of Final Place")]
        public Nullable<int> PortOfFinalPlaceOfDevlivery { get; set; }
        [Required]
        [Display(Name = "Port Of Recept")]
        public Nullable<int> PortOfRecept { get; set; }
        [Required]
        [Display(Name = "Vessel Name")]
        public string VesselName { get; set; }
        [Required]
        [Display(Name = "Voyage Number")]
        public string VoyageNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> ETD { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> ETA { get; set; }

        public virtual ShippingLine ShippingLine { get; set; }
        public virtual ICollection<Bad> Bad { get; set; }
        [Display(Name = "POL")]
        public virtual Port Port { get; set; }
        [Display(Name = "POD")]
        public virtual Port Port1 { get; set; }
        [Display(Name = "Port Of Final Place")]
        public virtual Port Port2 { get; set; }
        [Display(Name = "Port Of Recept")]
        public virtual Port Port3 { get; set; }
        public int CountBad { get; set; }
    }

    [MetadataType(typeof(VoyageMetaData))]
    partial class Voyage
    {

    }
}
