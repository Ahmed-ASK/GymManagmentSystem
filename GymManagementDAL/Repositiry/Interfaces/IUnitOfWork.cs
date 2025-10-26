using GymManagementDAL.Entities;
using GymManagementDAL.Entities.Base;
using GymManagementDAL.Repositiry.Interfaces;

namespace GymManagementDAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IMembershipRepository MembershipRepository { get; }
        public ISessionRepository SessionRepository { get; }
        public IMemberSessionRepository MemberSessionRepository { get; }
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity,new();
        int SaveChanges();

    }
}
