using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ShippingLineMetaData
    {
        public ShippingLineMetaData()
        {
            this.Voyage = new HashSet<Voyage>();
        }

        public int ShippingLineID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string Sigle { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Voyage> Voyage { get; set; }
        [Required(ErrorMessage = "Enter captcha")]
        public string CaptchaCode { get; set; }
    }

    [MetadataType(typeof(ShippingLineMetaData))]
    partial class ShippingLine
    {

    }
}
