﻿using GymManagementDAL.Entities.Base;

namespace GymManagementDAL.Entities
{
    public class Plan : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int DurationDays { get; set; } 
        public decimal Price{ get; set; }
        public bool IsActive{ get; set; }

        #region Relationship
        public ICollection<Membership> Memberships { get; set; } = null!;
        #endregion
    }
}
