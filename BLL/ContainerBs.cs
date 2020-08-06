using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ContainerBs
    {
        private BADEntities db;
        public ContainerBs()
        {
            db = new BADEntities();
        }
        public IEnumerable<Container> getAll()
        {
            var containers = db.Container.ToList();
            return containers;
        }

        public Container getById(int? id)
        {
            var container = db.Container.Find(id);
            return container;
        }

        public void Insert(Container container)
        {
            db.Container.Add(container);
            Save();
        }

        public void Update(Container container)
        {
            db.Entry(container).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        public void Delete(int? id)
        {
            db.Container.Remove(getById(id));
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
