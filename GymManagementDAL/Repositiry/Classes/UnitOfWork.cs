using GymManagementDAL.Data;
using GymManagementDAL.Entities.Base;
using GymManagementDAL.Repositiry.Interfaces;
using GymManagementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositiry.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        public ISessionRepository SessionRepository { get; }


        private readonly Dictionary<string, object> repositories = [];
        private readonly GymDbContext _dbContext;
        public UnitOfWork(GymDbContext dbContext,
            ISessionRepository sessionRepository)
        {
            _dbContext = dbContext;
            SessionRepository = sessionRepository;
        }


        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity , new()
        {
            var typeName = typeof(TEntity).Name;
            if (repositories.TryGetValue(typeName, out object? value))
                return (IGenericRepository<TEntity>)value;
            var Repo = new GenericRepository<TEntity>(_dbContext);
            repositories[typeName] = Repo;
            return Repo;
        }

        public int SaveChanges()
        => _dbContext.SaveChanges();
    }
}
