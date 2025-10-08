using GymManagmentBLL.ViewModels.TrainerViewModels;

namespace GymManagmentBLL.Services.Interfaces
{
    public interface ITrainerService
    {
        IEnumerable<TrainerViewModel> GetAllTrainers();
        TrainerViewModel GetTrainer(int Id);
        TrainerViewModel GetTrainerDetails(int Id);
        TrainerToUpdateViewModel GetTrainerToUpdate(int Id);
        bool UpdateTrainer(int Id,TrainerToUpdateViewModel model);
        bool DeleteTrainer(int Id);
        bool CreateTrainer(CreateTrainerViewModel model);

    }
}
