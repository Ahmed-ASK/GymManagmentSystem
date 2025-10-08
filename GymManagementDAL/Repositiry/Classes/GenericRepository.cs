using GymManagementDAL.Data;
using GymManagementDAL.Entities.Base;
using GymManagementDAL.Repositiry.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymManagementDAL.Repositiry.Classes
{
    public class GenericRepository<TEntity> (GymDbContext _dbContext): IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public int Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> condition = null!, bool withTracking = false)
            => condition is null ? 
                withTracking ? 
                _dbContext.Set<TEntity>().ToList() :
                _dbContext.Set<TEntity>().AsNoTracking().ToList() :
                 withTracking ?
                _dbContext.Set<TEntity>().Where(condition).ToList() :
                _dbContext.Set<TEntity>().AsNoTracking().Where(condition).ToList();

        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().FirstOrDefault(x => x.Id == id);

        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
