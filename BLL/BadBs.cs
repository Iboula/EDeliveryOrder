using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BadBs
    {
        private BADEntities db;
        public BadBs()
        {
            db = new BADEntities();
        }
        public IEnumerable<Bad> getAll()
        {
            var bads = db.Bad.ToList();
            return bads;
        }

        public Bad getById(int? id)
        {
            var bad = db.Bad.Find(id);
            return bad;
        }

        public Int32 Insert(Bad bad)
        {
            var obj = db.Bad.Add(bad);
            Save();

            return obj.BadID;

        }

        public void Update(Bad bad)
        {
            db.Entry(bad).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        public void Delete(int? id)
        {
            db.Bad.Remove(getById(id));
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
