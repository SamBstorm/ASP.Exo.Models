using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Common.Models;
using Model.Common.Repositories;

namespace Model.Global.Repositories
{
    public class TacheRepository : ITacheRepository
    {
        public bool Delete(int id)
        {
            if (DBContext.DB.taches.Select(t => t.Id).Contains(id))
            {
                Tache oldData = this.Get(id);
                DBContext.DB.taches.Remove(oldData);
                return true;
            }
            return false;
        }

        public Tache Get(int id)
        {
            return DBContext.DB.taches.Where(t=>t.Id == id).SingleOrDefault();
        }

        public IEnumerable<Tache> Get()
        {
            return DBContext.DB.taches;
        }

        public int Insert(Tache entity)
        {
            int maxId = (DBContext.DB.taches.Count() > 0 )? DBContext.DB.taches.Max(t => t.Id) : -1;
            maxId += 1;
            entity.Id = maxId;
            DBContext.DB.taches.Add(entity);
            return entity.Id;
        }

        public void IsDone(int id)
        {
            if (DBContext.DB.taches.Select(t => t.Id).Contains(id))
            {
                Tache oldData = this.Get(id);
                oldData.IsDone = true;
            }
        }

        public bool Update(int id, Tache entity)
        {
            if (DBContext.DB.taches.Select(t => t.Id).Contains(id))
            {
                Tache oldData = this.Get(id);
                oldData.Intitule = entity.Intitule;
                oldData.Description = entity.Description;
                oldData.CreationDate = entity.CreationDate;
                oldData.IsDone = entity.IsDone;
                oldData.AttributeTo = entity.AttributeTo;
                return true;
            }
            return false;
        }
    }
}
