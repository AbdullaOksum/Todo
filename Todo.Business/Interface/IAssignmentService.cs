using System.Linq.Expressions;
using Todo.Entities.Concrete;

namespace Todo.Business.Interface
{
    public interface IAssignmentService : IGenericService<Assignment>
    {
        List<Assignment> ListUrgencyNonCompleted();
        List<Assignment> GetAllProperty();
        List<Assignment> GetAllProperty(Expression<Func<Assignment, bool>> filter);
        List<Assignment> GetAllPropertyNonCompleted(out int totalPage, int userId, int activepage = 1);
        Assignment GetUrgencyWithId(int id);
        List<Assignment> GetAppUserId(int id);
        Assignment GetReportId(int id);
        int GetAssignmentCompletedCountAppUserId(int id);
        int GetAssignmentNonCompletedCountAppUserId(int id);
        int GetAssignmentWithNonStaff();
        int GetAssignmentCompletedCount();


    }
}
