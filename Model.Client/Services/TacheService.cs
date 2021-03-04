using Model.Common.Models;
using Model.Common.Repositories;
using Model.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Services
{
    public class TacheService : ITacheRepository
    {
        private ITacheRepository _repo;

        public TacheService()
        {
            _repo = new TacheRepository();
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public Tache Get(int id)
        {
            return _repo.Get(id);
        }

        public IEnumerable<Tache> Get()
        {
            return _repo.Get();
        }

        public int Insert(Tache entity)
        {
            return _repo.Insert(entity);
        }

        public void IsDone(int id)
        {
            _repo.IsDone(id);
        }

        public bool Update(int id, Tache entity)
        {
            return _repo.Update(id, entity);
        }
    }
}
