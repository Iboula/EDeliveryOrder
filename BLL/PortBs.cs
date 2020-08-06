using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PortBs
    {
        private BADEntities db;
        public PortBs()
        {
            db = new BADEntities();
        }
        public IEnumerable<Port> getAll()
        {
            var ports = db.Port.ToList();
            return ports;
        }

        public Port getById(int? id)
        {
            var port = db.Port.Find(id);
            return port;
        }
    }
}
