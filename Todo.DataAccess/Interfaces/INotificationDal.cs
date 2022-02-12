using Todo.Entities.Concrete;

namespace Todo.DataAccess.Interfaces
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        List<Notification> ListAllUnread(int AppUserId);
        int UnreadCountWithAppUserId(int AppUserId);

    }
}
