using IT_RunCourseSecondPartAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT_RunCourseSecondPartAPI.Infrastructure.EntityConfigurations;

public class ShoppingConfiguration : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.ShoppingCarts)
            .HasForeignKey(x => x.UserId);

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}