using Todo.Entities.Concrete;

namespace Todo.DataAccess.Interfaces
{
    public interface IReportDal : IGenericDal<Report>
    {
        Report GetWithAssignmentId(int id);
        int GetReportCountId(int id);
        int GetReportCount();
    }
}
