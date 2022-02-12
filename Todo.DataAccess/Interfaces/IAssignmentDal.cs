using System.Linq.Expressions;
using Todo.Entities.Concrete;

namespace Todo.DataAccess.Interfaces
{
    public interface IAssignmentDal : IGenericDal<Assignment>
    {
        List<Assignment> ListUrgencyNonCompleted();
        List<Assignment> GetAllProperty();
        List<Assignment> GetAllProperty(Expression<Func<Assignment, bool>> filter);
        List<Assignment> GetAllPropertyNonCompleted(out int totalPage, int userId, int activepage);
        Assignment GetUrgencyWithId(int id);
        List<Assignment> GetAppUserId(int id);
        Assignment GetReportId(int id);
        int GetAssignmentCompletedCountAppUserId(int id);
        int GetAssignmentNonCompletedCountAppUserId(int id);
        int GetAssignmentWithNonStaff();
        int GetAssignmentCompletedCount();

    }
}
