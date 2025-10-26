using GymManagementDAL.Data;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositiry.Classes;
using GymManagementDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymManagementDAL.Repositories.Classes
{
	public class MemberSessionRepository : GenericRepository<MemberSession>, IMemberSessionRepository
	{
		private readonly GymDbContext _dbContext;

		public MemberSessionRepository(GymDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<MemberSession> GetBySessionId(int sessionId)
		{
			return _dbContext.MemberSessions.Include(X => X.Member)
									  .Where(X => X.SessionId == sessionId).ToList();
		}

	}
}
