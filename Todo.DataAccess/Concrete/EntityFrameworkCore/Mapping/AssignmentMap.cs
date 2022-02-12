using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Entities.Concrete;


namespace Todo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AssignmentMap : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Explanation).HasColumnType("ntext");

            builder.HasOne(x => x.Urgency).WithMany(x => x.Assignments).HasForeignKey(x => x.UrgencyId);
        }
    }
}
