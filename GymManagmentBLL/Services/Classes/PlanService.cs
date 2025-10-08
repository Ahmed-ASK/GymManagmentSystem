using GymManagementDAL.Entities;
using GymManagementDAL.Repositiry.Interfaces;
using GymManagmentBLL.Services.Interfaces;
using GymManagmentBLL.ViewModels.PlanViewModels;

namespace GymManagmentBLL.Services.Classes
{
    public class PlanService(IUnitOfWork unitOfWork) : IPlanService
    {
        public IEnumerable<PlanViewModel> GetAllPlans()
        {
            var plans = unitOfWork.GetRepository<Plan>().GetAll();
            if (plans is null || !plans.Any()) return [];

            return plans.Select(p => new PlanViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                DurationDays = p.DurationDays,
                IsActive = p.IsActive,
                Price = p.Price,
            });
        }

        public PlanViewModel GetPlanById(int id)
        {
           var plan = unitOfWork.GetRepository<Plan>().GetById(id);
            if (plan is null) return null!;
            return new PlanViewModel()
            {
                Id = plan.Id,
                Name = plan.Name,
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                IsActive = plan.IsActive,
                Price = plan.Price,
            };
        }

        public UpdatePlanViewModel? GetPlanToUpdate(int planId)
        {
            var plan = unitOfWork.GetRepository<Plan>().GetById(planId);
            if (plan is null || plan.IsActive == false || HasActiveMemberships(planId)) return null!;
            return new UpdatePlanViewModel() 
            {
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                PlanName = plan.Name,
                Price = plan.Price
            };
        }

        public bool ToggleStatus(int planId)
        {
            var repo = unitOfWork.GetRepository<Plan>();
            var plan = repo.GetById(planId);
            if (plan is null || HasActiveMemberships(planId)) return false;
            plan.IsActive = !plan.IsActive;
            plan.UpdatedAt = DateTime.Now;
            try
            {
                repo.Update(plan);
                return unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePlan(int planId, UpdatePlanViewModel updatedPlan)
        {
            try
            {
                var plan = unitOfWork.GetRepository<Plan>().GetById(planId);
                if (plan is null || HasActiveMemberships(planId)) return false;
                (plan.Description, plan.Price, plan.DurationDays, plan.UpdatedAt) = (updatedPlan.Description, updatedPlan.Price, updatedPlan.DurationDays, DateTime.Now);
                unitOfWork.GetRepository<Plan>().Update(plan);
                return unitOfWork.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        private bool HasActiveMemberships(int planId)
        {
            var activeMemberships = unitOfWork.GetRepository<Membership>().GetAll(x => x.PlanId == planId && x.Status == "Active");
            return activeMemberships.Any();
        }
    }
}
