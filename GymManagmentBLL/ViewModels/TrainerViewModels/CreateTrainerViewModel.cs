using GymManagementDAL.Entities.Enums;
using GymManagmentBLL.ViewModels.MemberViewModel;
using System.ComponentModel.DataAnnotations;

namespace GymManagmentBLL.ViewModels.TrainerViewModels
{
    public class CreateTrainerViewModel : CreateMemberViewModel
    {
        [Required(ErrorMessage = "Speciality Is Required")]
        [AllowedValues(1,2,3,4)]
        public Specialities Specialities { get; set; }
    }
}
