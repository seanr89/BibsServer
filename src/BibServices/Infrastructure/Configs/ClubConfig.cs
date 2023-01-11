using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    internal class ClubConfig : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> entity)
        {
            #region Properties

            entity.HasKey(a => a.Id);
            entity.Property(p => p.Id).HasDefaultValueSql("NEWID()");
            entity.Property(p => p.Name).IsRequired().HasMaxLength(150);
            entity.Property(p => p.Active).IsRequired().HasDefaultValue(true);
            entity.Property(p => p.Private).IsRequired().HasDefaultValue(false);

            #endregion

            #region Relationships
            // entity
            //     .HasMany(c => c.Members)
            //     .WithOne(m => m.Club)
            //     .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}