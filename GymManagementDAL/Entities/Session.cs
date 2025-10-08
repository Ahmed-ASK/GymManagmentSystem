using GymManagementDAL.Entities.Base;
using GymManagementDAL.Entities.User;

namespace GymManagementDAL.Entities
{
    public class Session : BaseEntity
    {
        public string Description { get; set; } = null!;
        public int Capacity{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }

        #region RelationShips

        #region Session - Category
        public int CategrotyId { get; set; }
        public Category Category { get; set; } = null!;
        #endregion

        #region Trainer - Session
        public int TrainerId { get; set; }
        public Trainer SessionTrainer { get; set; } = null!;

        #endregion

        #region Session - MemberSession
        public ICollection<MemberSession> MemberSessions { get; set; } = null!;
        #endregion
        #endregion
    }
}
