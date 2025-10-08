using GymManagementDAL.Data.Configurations.User.Base;
using GymManagementDAL.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementDAL.Data.Configurations.User
{
    internal class MemberConfigurations : GymUserConfiguration<Member> , IEntityTypeConfiguration<Member>
    {
        public new void Configure(EntityTypeBuilder<Member> builder) 
        {
            base.Configure(builder);

            builder
                .Property(M => M.CreatedAt)
                .HasColumnName("JoinDate");
        }
    }
}
