using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common.Repositories
{
    public interface IRepository<TEntity,TId>
    {
        TEntity Get(TId id);
        IEnumerable<TEntity> Get();
        TId Insert(TEntity entity);
        bool Update(TId id, TEntity entity);
        bool Delete(TId id);
    }
}
