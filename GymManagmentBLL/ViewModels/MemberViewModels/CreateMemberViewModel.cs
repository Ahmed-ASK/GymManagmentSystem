using GymManagementDAL.Entities.Enums;
using GymManagementDAL.Entities.Health;
using GymManagementDAL.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.MemberViewModel
{
    public class CreateMemberViewModel
    {
        [Required(ErrorMessage = "Name Is Required")]
        [StringLength(50 , MinimumLength = 2, ErrorMessage = "Name Must Be Between 2 and 50 Char")]
        [RegularExpression(@"^[A-ZA-Z\s]+$")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email Is Required ")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100,MinimumLength = 5 , ErrorMessage = "Email Must Be Between 5 and 100 char")]
        public string Email { get; set; } = null!;
        
        [Required(ErrorMessage = "Phone Is Required ")]
        [Phone(ErrorMessage = "Invalid Phone Format")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$" , ErrorMessage = "Phone Number must be valid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = null!;
        
        [Required(ErrorMessage = "Gender Is Required ")]
        public Gender Gender { get; set; }
        
        [Required(ErrorMessage = "Date of birth is reqiured")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Building Number Is Required")]
        [Range(1,9000,ErrorMessage = "Building Number Must Be Between 1 and 9000")]
        public string BuildingNumber { get; set; } = null!;

        [Required(ErrorMessage = "Street Is Required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Street Must Be Between 2 and 30")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "City Is Required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "City Must Be Between 2 and 30")]
        [RegularExpression(@"^[A-ZA-Z\s]+$")]
        public string City { get; set; } = null!;
        
        [Required(ErrorMessage = "Health Record is Required")]
        public HealthRecord HealthRecord { get; set; } = null!;
    }
}
