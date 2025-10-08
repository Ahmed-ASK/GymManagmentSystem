using GymManagementDAL.Entities.Base;

namespace GymManagementDAL.Entities.Health
{
    // 1-1 RelationShip with member [Shared PK]
    public class HealthRecord : BaseEntity
    {
        public decimal Hight { get; set; }
        public decimal Weight { get; set; }
        public string BloodType { get; set; } = null!;
        public string? Note { get; set; }
    }
}
