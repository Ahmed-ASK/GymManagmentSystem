using GymManagementDAL.Entities.Base;
using GymManagementDAL.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositiry.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        IEnumerable<TEntity> GetAll(Func<TEntity,bool> condition = null!, bool withTracking = false);
        TEntity? GetById(int id);
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        bool Exists(Func<TEntity, bool> predicate);
    }
}
