using GymManagementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementDAL.Data.Configurations
{
    internal class SessionConfigurations : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(S => S.Capacity);

            builder.HasOne(X => X.Category)
                .WithMany(X => X.Sessions)
                .HasForeignKey(X => X.CategrotyId);

            builder.HasOne(X => X.SessionTrainer)
                .WithMany(X => X.TrainerSessions)
                .HasForeignKey(X => X.TrainerId);

            builder.ToTable(Tb =>
            {
                Tb.HasCheckConstraint("SessionCapacityCheck","Capacity Between 1 and 25");
                Tb.HasCheckConstraint("SessionEndDateCheck","EndDate > StartDate");
            });

        }
    }
}
