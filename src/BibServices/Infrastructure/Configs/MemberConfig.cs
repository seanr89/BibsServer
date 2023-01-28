using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    internal class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> entity)
        {
            #region Properties

            entity.HasKey(a => a.Id);
            entity.Property(p => p.Id).HasDefaultValueSql("NEWID()");
            entity.Property(p => p.Name).IsRequired().HasMaxLength(150);
            entity.Property(p => p.Email).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Active).IsRequired().HasDefaultValue(true);

            #endregion

            #region Relationships
            #endregion
        }
    }
}