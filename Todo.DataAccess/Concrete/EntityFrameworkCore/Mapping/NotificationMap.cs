using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Entities.Concrete;

namespace Todo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Explanation).HasColumnType("ntext").IsRequired();
            builder.HasOne(x => x.AppUser).WithMany(x => x.Notifications).HasForeignKey
                    (x => x.AppUserId);

        }
    }
}
