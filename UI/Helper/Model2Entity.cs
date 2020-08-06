using Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace UI.Helper
{
    public class Model2Entity
    {
        public static Bad ToBad(BadMetaData badMeta)
        {
            Bad bad = new Bad();

            bad.BadID = badMeta.BadID;
            bad.BLNumber = badMeta.BLNumber;
            bad.DateEmission = badMeta.DateEmission;
            bad.DateValidite = badMeta.DateValidite;
            bad.CustomerNinea = badMeta.CustomerNinea;
            bad.CustomerName = badMeta.CustomerName;
            bad.CustomerPhoneNumber = badMeta.CustomerPhoneNumber;
            bad.CustomerEmail = badMeta.CustomerEmail;
            bad.CustomerAddress = badMeta.CustomerAddress;
            bad.PDF = Pdf2ByteArray(badMeta.PdfFile);
            bad.ShipperName = badMeta.ShipperName;
            bad.ShipperAddress = badMeta.ShipperAddress;
            bad.ConsigneeName = badMeta.ConsigneeName;
            bad.ConsigneeAddress = badMeta.ConsigneeAddress;
            bad.NotifyParty = badMeta.NotifyParty;
            bad.VoyageID = badMeta.VoyageID;
            bad.Status = badMeta.Status;

            //public virtual Voyage Voyage 
            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //public virtual ICollection<Container> Container 
            //public int CountContainer 

            return bad;
        }

        public static byte[] Pdf2ByteArray(HttpPostedFileBase file)
        {
            try
            {
                Stream str = file.InputStream;
                BinaryReader Br = new BinaryReader(str);
                return Br.ReadBytes((Int32)str.Length);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}