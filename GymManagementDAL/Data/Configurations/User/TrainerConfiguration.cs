using GymManagementDAL.Data.Configurations.User.Base;
using GymManagementDAL.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementDAL.Data.Configurations.User
{
    internal class TrainerConfiguration : GymUserConfiguration<Trainer> ,IEntityTypeConfiguration<Trainer>
    {
        public new void Configure(EntityTypeBuilder<Trainer> builder)
        {
            base.Configure(builder);

            builder
                .Property(T => T.CreatedAt)
                .HasColumnName("HireDate")
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
