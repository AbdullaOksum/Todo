using Todo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Todo.DataAccess.Interfaces;
using Todo.Entities.Concrete;

namespace Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        public List<Notification> ListAllUnread(int AppUserId)
        {
            using var context = new TodoContext();
            return context.Notifications.Where(x => x.AppUserId == AppUserId && !x.Situation).ToList();
        }

        public int UnreadCountWithAppUserId(int AppUserId)
        {
            using var context = new TodoContext();
            return context.Notifications.Count(x => x.AppUserId == AppUserId && !x.Situation);
        }
    }
}
