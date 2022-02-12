using System.Linq.Expressions;
using Todo.Business.Interface;
using Todo.DataAccess.Interfaces;
using Todo.Entities.Concrete;

namespace Todo.Business.Concrete
{
    public class AssignmentManager : IAssignmentService
    {
        private readonly IAssignmentDal _assignmentDal;
        public AssignmentManager(IAssignmentDal AssignmentDal)
        {
            _assignmentDal = AssignmentDal;
        }

        public Assignment GetUrgencyWithId(int id)
        {
            return _assignmentDal.GetUrgencyWithId(id);
        }

        public List<Assignment> ListUrgencyNonCompleted()
        {
            return _assignmentDal.ListUrgencyNonCompleted();
        }

        public List<Assignment> GetAppUserId(int id)
        {
            return _assignmentDal.GetAppUserId(id);
        }

        public List<Assignment> GetAllProperty()
        {
            return _assignmentDal.GetAllProperty();
        }

        public List<Assignment> GetAll()
        {
            return _assignmentDal.ListAll();
        }

        public void Update(Assignment tablo)
        {
            _assignmentDal.Update(tablo);
        }

        public Assignment GetId(int Id)
        {
            return _assignmentDal.GetId(Id);
        }

        public void Save(Assignment tablo)
        {
            _assignmentDal.Save(tablo);
        }

        public void Delete(Assignment tablo)
        {
            _assignmentDal.Delete(tablo);
        }

        public Assignment GetReportId(int id)
        {
            return _assignmentDal.GetReportId(id);
        }

        public List<Assignment> GetAllProperty(Expression<Func<Assignment, bool>> filter)
        {
            return _assignmentDal.GetAllProperty(filter);
        }

        public List<Assignment> GetAllPropertyNonCompleted(out int totalPage, int userId, int activepage)
        {
            return _assignmentDal.GetAllPropertyNonCompleted(out totalPage, userId, activepage);
        }

        public int GetAssignmentCompletedCountAppUserId(int id)
        {
            return _assignmentDal.GetAssignmentCompletedCountAppUserId(id);
        }

        public int GetAssignmentNonCompletedCountAppUserId(int id)
        {
            return _assignmentDal.GetAssignmentNonCompletedCountAppUserId(id);
        }

        public int GetAssignmentWithNonStaff()
        {
            return _assignmentDal.GetAssignmentWithNonStaff();
        }

        public int GetAssignmentCompletedCount()
        {
            return _assignmentDal.GetAssignmentCompletedCount();
        }
    }
}
