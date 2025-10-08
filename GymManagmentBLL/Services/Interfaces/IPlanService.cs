using GymManagmentBLL.ViewModels.PlanViewModels;

namespace GymManagmentBLL.Services.Interfaces
{
    public interface IPlanService
    {
        IEnumerable<PlanViewModel> GetAllPlans();
        PlanViewModel GetPlanById(int id);
        UpdatePlanViewModel? GetPlanToUpdate(int planId);
        bool UpdatePlan(int planId, UpdatePlanViewModel updatedPlan);
        bool ToggleStatus(int planId);
    }
}
