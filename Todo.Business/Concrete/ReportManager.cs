using Todo.Business.Interface;
using Todo.DataAccess.Interfaces;
using Todo.Entities.Concrete;

namespace Todo.Business.Concrete
{
    public class ReportManager : IReportService
    {

        private readonly IReportDal _raporDal;

        public ReportManager(IReportDal raporDal)
        {
            _raporDal = raporDal;

        }


        public List<Report> GetAll()
        {
            return _raporDal.ListAll();
        }

        public void Update(Report tablo)
        {
            _raporDal.Update(tablo);
        }

        public Report GetId(int Id)
        {
            return _raporDal.GetId(Id);
        }

        public void Save(Report tablo)
        {
            _raporDal.Save(tablo);
        }

        public void Delete(Report tablo)
        {
            _raporDal.Delete(tablo);
        }

        public Report GetWithAssignmentId(int id)
        {
            return _raporDal.GetWithAssignmentId(id);
        }

        public int GetReportCountId(int id)
        {
            return _raporDal.GetReportCountId(id);
        }

        public int GetReportCount()
        {
            return _raporDal.GetReportCount();
        }
    }
}
