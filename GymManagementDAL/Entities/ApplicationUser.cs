using Microsoft.AspNet.Identity.EntityFramework;

namespace GymManagementDAL.Entities
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
	}
}
