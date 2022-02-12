using Todo.Business.Interface;
using Todo.DataAccess.Interfaces;
using Todo.Entities.Concrete;

namespace Todo.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal bildirimDal)
        {
            _notificationDal = bildirimDal;
        }


        public Notification GetId(int Id)
        {
            return _notificationDal.GetId(Id);
        }

        public List<Notification> ListAllUnread(int AppUserId)
        {
            return _notificationDal.ListAllUnread(AppUserId);
        }

        public int UnreadCountWithAppUserId(int AppUserId)
        {
            return _notificationDal.UnreadCountWithAppUserId(AppUserId);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.ListAll();
        }

        public void Update(Notification tablo)
        {
            _notificationDal.Update(tablo);
        }

        public void Save(Notification tablo)
        {
            _notificationDal.Save(tablo);
        }

        public void Delete(Notification tablo)
        {
            _notificationDal.Delete(tablo);
        }
    }
}
