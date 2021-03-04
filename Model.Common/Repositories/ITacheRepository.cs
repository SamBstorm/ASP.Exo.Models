using Model.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common.Repositories
{
    public interface ITacheRepository : IRepository<Tache,int>
    {
        void IsDone(int id);
    }
}
