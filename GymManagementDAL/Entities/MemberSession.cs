using GymManagementDAL.Entities.Base;
using GymManagementDAL.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    public class MemberSession : BaseEntity
    {
        // booking date - CreatedAt of BaseEntity
        public int MemberId { get; set; }
        public int SessionId { get; set; }
        public bool IsAttended { get; set; }
        public Member Member { get; set; } = null!;
        public Session Session { get; set; } = null!;
    }
}
