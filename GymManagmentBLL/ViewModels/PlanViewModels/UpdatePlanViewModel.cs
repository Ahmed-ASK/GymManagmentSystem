using System.ComponentModel.DataAnnotations;

namespace GymManagmentBLL.ViewModels.PlanViewModels
{
    public class UpdatePlanViewModel
    {
        [Required(ErrorMessage = "Plan Name Is Required")]
        [StringLength(50 , ErrorMessage = "Plan Name Must Be Less Than 51 Char")]
        public string PlanName { get; set; } = null!;
        [Required(ErrorMessage = "Plan Name Is Required")]
        [StringLength(200, MinimumLength = 5 ,ErrorMessage = "Plan Name Must Be Between 5 and 200 Char")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "Duration Days Is Required")]
        [Range(1 , 356,ErrorMessage ="Duration Days Must Be Between  1 and 365")]
        public int DurationDays { get; set; }

        [Required(ErrorMessage = "Price Is Required")]
        [Range(0.1, 1000, ErrorMessage = "Price Must Be Between 0.1 and 10,000")]
        public decimal Price { get; set; }
    }
}
