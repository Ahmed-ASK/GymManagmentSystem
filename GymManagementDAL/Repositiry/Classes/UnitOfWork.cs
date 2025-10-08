using GymManagementDAL.Data;
using GymManagementDAL.Entities.Base;
using GymManagementDAL.Repositiry.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositiry.Classes
{
    public class UnitOfWork(GymDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = new();
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new()
        {
            var EntityType = typeof(TEntity);
            if (_repositories.TryGetValue(EntityType, out var Repo)) 
                return (IGenericRepository<TEntity>) Repo;

            var newRepo = new GenericRepository<TEntity>(_dbContext);
            _repositories[EntityType] = newRepo;
            return newRepo;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
