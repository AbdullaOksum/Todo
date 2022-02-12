using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Entities.Concrete;

namespace Todo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Definition).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Detail).HasColumnType("ntext");

            builder.HasOne(x => x.Assignment).WithMany(x => x.Reports).HasForeignKey(x => x.AssignmentId);
        }
    }
}
