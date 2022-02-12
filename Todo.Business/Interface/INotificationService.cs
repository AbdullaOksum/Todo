using Todo.Entities.Concrete;

namespace Todo.Business.Interface
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> ListAllUnread(int AppUserId);
        int UnreadCountWithAppUserId(int AppUserId);

    }
}
