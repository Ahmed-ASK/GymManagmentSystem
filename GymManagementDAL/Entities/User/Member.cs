using GymManagementDAL.Entities.Health;

namespace GymManagementDAL.Entities.User
{
    public class Member : GymUser
    {
        // Join Date == Created At
        public string Photo { get; set; } = null!;

        #region RelationShips

        #region Member - HealthRecord

        public HealthRecord HealthRecord { get; set; } = null!;

        #endregion

        #region Member - MemberShips
        public ICollection<Membership> Memberships { get; set; } = null!;
        #endregion

        #region Member - MemberSession 
        public ICollection<MemberSession> MemberSessions { get; set; } = null!;
        #endregion
        #endregion
    }
}
