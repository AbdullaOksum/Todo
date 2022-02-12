using Todo.Business.Interface;
using Todo.DataAccess.Interfaces;
using Todo.Entities.Concrete;

namespace Todo.Business.Concrete
{
    public class UrgencyManager : IUrgencyService
    {


        private readonly IUrgencyDal _urgencytDal;

        public UrgencyManager(IUrgencyDal urgencytDal)
        {
            _urgencytDal = urgencytDal;
        }


        public List<Urgency> GetAll()
        {
            return _urgencytDal.ListAll();
        }

        public void Update(Urgency tablo)
        {
            _urgencytDal.Update(tablo);
        }



        public Urgency GetId(int Id)
        {
            return _urgencytDal.GetId(Id);
        }

        public void Save(Urgency tablo)
        {
            _urgencytDal.Save(tablo);
        }

        public void Delete(Urgency tablo)
        {
            _urgencytDal.Delete(tablo);
        }
    }
}
