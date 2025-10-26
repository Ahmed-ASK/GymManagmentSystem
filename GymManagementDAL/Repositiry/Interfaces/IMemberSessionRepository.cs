using GymManagementDAL.Entities;
using GymManagementDAL.Repositiry.Interfaces;

namespace GymManagementDAL.Repositories.Interfaces
{
    public interface IMemberSessionRepository : IGenericRepository<MemberSession>
    {

		IEnumerable<MemberSession> GetBySessionId(int sessionId);
 
	}
}
