using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Infrastructure.Configurations;

public class UserToSkillsConfiguration : IEntityTypeConfiguration<UserToSkills>
{
    public void Configure(EntityTypeBuilder<UserToSkills> builder)
    {
        builder.ToTable("UserToSkills");
        
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.User)
            .WithMany(u => u.Skills)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Skill)
            .WithMany(s => s.UserSkills)
            .HasForeignKey(x => x.SkillId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}