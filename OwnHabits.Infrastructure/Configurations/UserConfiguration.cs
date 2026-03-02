using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Infrastructure.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(user => user.Id);
        builder.HasMany(u=>u.UserToRoles)
            .WithOne(r=>r.User)
            .HasForeignKey(r=>r.UserId);
        builder.HasMany(u=>u.Goals)
            .WithOne(g=>g.User).
            HasForeignKey(g=>g.UserId);
        builder.HasMany(u=>u.Characteristics)
            .WithOne(g=>g.User).
            HasForeignKey(g=>g.UserId);
        builder.HasMany(u=>u.Skills)
            .WithOne(g=>g.User).
            HasForeignKey(g=>g.UserId);
    }
}