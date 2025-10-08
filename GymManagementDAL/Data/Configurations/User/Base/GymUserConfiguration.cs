using GymManagementDAL.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementDAL.Data.Configurations.User.Base
{
    internal class GymUserConfiguration<T> : IEntityTypeConfiguration<T>
        where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                .Property(G => G.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder
                .Property(G => G.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);
            
            builder
                .Property(G => G.Phone)
                .HasColumnType("VARCHAR")
                .HasMaxLength(11);

            builder.ToTable(Tb => 
            {
                Tb.HasCheckConstraint("GymUserValidEmailCheck","Email Like '_%@%._%'");
                Tb.HasCheckConstraint("GymUserValidPhoneCheck","Phone Like '01%' and phone not like '%[^0-9]%'");
            });

            builder.HasIndex(X => X.Email).IsUnique();
            builder.HasIndex(X => X.Phone).IsUnique();

            builder.OwnsOne(X => X.Address , AddressBuilder => 
            {
                AddressBuilder
                .Property(X => X.Street)
                .HasColumnName("Street")
                .HasColumnType("VARCHAR")
                .HasMaxLength(30);

                AddressBuilder
                .Property(X => X.City)
                .HasColumnName("City")
                .HasColumnType("VARCHAR")
                .HasMaxLength(30);
                
                AddressBuilder
                .Property(X => X.BuildingNumber)
                .HasColumnName("BuildingNumber")
                .HasColumnType("VARCHAR")
                .HasMaxLength(30);
            });

        }
    }
}
