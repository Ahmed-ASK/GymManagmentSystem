using GymManagementDAL.Entities.Enums;

namespace GymManagementDAL.Entities.User
{
    public class Trainer : GymUser
    {
        //HireDate - CreatedAt fo BaseEntity
        public Specialities Specialities{ get; set; }

        public ICollection<Session> TrainerSessions { get; set; } = null!;
    }
}
