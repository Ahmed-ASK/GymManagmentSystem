using GymManagementDAL.Data;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositiry.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymManagementDAL.Repositiry.Classes
{
    public class PlanRepository (GymDbContext _dbContext): IPlanRepository
    {

        public IEnumerable<Plan> GetAll(bool withTracking = false) 
            => withTracking ? 
            _dbContext.Plans.ToList() :
            _dbContext.Plans.AsNoTracking().ToList();

        public Plan? GetById(int id) => _dbContext.Plans.SingleOrDefault(p => p.Id == id);

        public int Update(Plan plan)
        {
            _dbContext.Plans.Update(plan);
            return _dbContext.SaveChanges();
        }
    }
}
