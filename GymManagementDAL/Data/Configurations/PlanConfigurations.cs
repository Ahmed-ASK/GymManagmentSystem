using GymManagementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementDAL.Data.Configurations
{
    internal class PlanConfigurations : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder
                .Property(P => P.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder
                .Property(P => P.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);

            builder
                .Property(P => P.Price)
                .HasColumnType("DECIMAL(10,2)");

            builder
                .Property(P => P.DurationDays)
                .HasColumnType("SMALLINT");

            builder.ToTable(Tb =>
            {
                Tb.HasCheckConstraint("PlanDurationDaysChack", "DurationDays between 1 and 365");
            });
        }
    }
}
