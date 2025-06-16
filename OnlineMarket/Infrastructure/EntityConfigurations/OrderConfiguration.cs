using IT_RunCourseSecondPartAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT_RunCourseSecondPartAPI.Infrastructure.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TotalPrice)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}