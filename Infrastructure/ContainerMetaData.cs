using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ContainerMetaData
    {
        public int ContainerID { get; set; }
        public Nullable<int> BadID { get; set; }
        [Required]
        [Display(Name = "Container Number")]
        [StringLength(12, MinimumLength = 11, ErrorMessage = "Maximum 12 characters")]
        public string ContainerNumber { get; set; }
        [Required]
        [Display(Name = "Container Size")]
        public Nullable<int> ContainerSize { get; set; }
        [Required]
        [Display(Name = "Container Type")]
        public string ContainerType { get; set; }
        [Required]
        [Display(Name = "Container Tare")]
        public Nullable<decimal> ContainerTare { get; set; }
        [Required]
        [Display(Name = "Cargo Weight")]
        public Nullable<decimal> CargoWeight { get; set; }

        public virtual Bad Bad { get; set; }
    }

    public enum CtType
    {
        Dry,
        Reefer
    }

    [MetadataType(typeof(ContainerMetaData))]
    partial class Container
    {

    }
}
