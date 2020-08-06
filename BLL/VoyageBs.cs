using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VoyageBs
    {
        BADEntities bd;
        public VoyageBs()
        {
            bd = new BADEntities();
        }

        // Recupérer tous les voyages
        public IEnumerable<Voyage> getAll()
        {
            return bd.Voyage.ToList();
        }

        // Recupérer les voyages du shipping courant
        public IEnumerable<Voyage> getAllById(int? id)
        {
            return bd.Voyage.ToList().Where(v => v.ShippingLineID == id);
        }

        // Recupérer un voyageen fonction du id
        public Voyage getById(int? id)
        {
            return bd.Voyage.Find(id);
        }

        public int Insert(Voyage voyage)
        {
            var obj = bd.Voyage.Add(voyage);
            Save();

            return obj.VoyageID;
        }

        public void Update(Voyage voyage)
        {
            bd.Entry(voyage).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        public void Delete(int? id)
        {
            bd.Voyage.Remove(getById(id));
            Save();
        }

        public void Save()
        {
            bd.SaveChanges();
        }
    }
}
