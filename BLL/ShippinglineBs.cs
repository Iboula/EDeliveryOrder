using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ShippinglineBs
    {
        private BADEntities db;
        public ShippinglineBs()
        {
            db = new BADEntities();
        }
        public IEnumerable<ShippingLine> getAll()
        {
            var sl = db.ShippingLine.ToList();
            return sl;
        }

        public ShippingLine getById(int? id)
        {
            var sl = db.ShippingLine.Find(id);
            return sl;
        }
    }
}
