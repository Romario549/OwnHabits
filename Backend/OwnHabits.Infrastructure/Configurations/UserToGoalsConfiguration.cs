using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Infrastructure.Configurations;

public class UserToGoalsConfiguration : IEntityTypeConfiguration<UserToGoals>
{
    public void Configure(EntityTypeBuilder<UserToGoals> builder)
    {
        builder.ToTable("UserToGoals");
        
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.User)
            .WithMany(u => u.Goals)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Goal)
            .WithMany(g => g.UserGoals)
            .HasForeignKey(x => x.GoalId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}