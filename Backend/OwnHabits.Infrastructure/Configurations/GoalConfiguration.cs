using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnHabits.Domain.Models;

namespace OwnHabits.Infrastructure.Configurations;

public class GoalConfiguration: IEntityTypeConfiguration<Goal>
{
    public void Configure(EntityTypeBuilder<Goal> builder)
    {
        builder.ToTable("Goals");
        builder.HasKey(g => g.Id);
        builder.HasMany(g => g.UpgradableSkills)
            .WithOne(g=>g.Goal)
            .HasForeignKey(g=>g.GoalId);
        builder.HasMany(g=>g.UserGoals)
            .WithOne(u=>u.Goal)
            .HasForeignKey(u=>u.GoalId);

    }
}