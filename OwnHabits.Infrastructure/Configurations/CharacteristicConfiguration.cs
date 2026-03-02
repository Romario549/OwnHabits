using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnHabits.Domain.Models;

namespace OwnHabits.Infrastructure.Configurations;

public class CharacteristicConfiguration: IEntityTypeConfiguration<Characteristic>
{
    public void Configure(EntityTypeBuilder<Characteristic> builder)
    {
        builder.ToTable("Characteristics");
        builder.HasKey(c => c.Id);
        builder.HasMany(c => c.RequiredSkills)
            .WithOne(c => c.Characteristic)
            .HasForeignKey(c => c.CharacteristicId);
        builder.HasMany(c => c.UserCharacteristics)
            .WithOne(c => c.Characteristic)
            .HasForeignKey(c => c.CharacteristicId);
    }
}