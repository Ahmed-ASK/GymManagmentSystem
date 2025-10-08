using GymManagementDAL.Entities.Base;
using GymManagementDAL.Entities.User;
using Microsoft.Extensions.Logging.Abstractions;
using System.Reflection.Metadata.Ecma335;

namespace GymManagementDAL.Entities
{
    public class Membership : BaseEntity
    {
        // Start Date - CreatedAt of BaseEntity
        public int MemberId { get; set; }
        public int PlanId { get; set; }
        public DateTime EndDate { get; set; }
        public string Status 
        {
            get 
            {
                if (EndDate <= DateTime.Now)
                    return "Expired";
                else
                    return "Active";
            }
        }
        public Member Member { get; set; } = null!;
        public Plan Plan{ get; set; } = null!;
    }
}
