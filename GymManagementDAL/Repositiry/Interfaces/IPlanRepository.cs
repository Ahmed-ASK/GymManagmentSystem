using GymManagementDAL.Entities;

namespace GymManagementDAL.Repositiry.Interfaces
{
    public interface IPlanRepository
    {
        IEnumerable<Plan> GetAll(bool withTracking = false);
        Plan? GetById(int id);
        int Update(Plan paln);
    }
}
