using GymManagementDAL.Entities;
using GymManagementDAL.Repositiry.Interfaces;

namespace GymManagementDAL.Repositories.Interfaces
{
	public interface IMembershipRepository : IGenericRepository<Membership>
	{
		IEnumerable<Membership> GetAllMembershipsWithMemberAndPlan(Func<Membership, bool> predicate);
	}
}
