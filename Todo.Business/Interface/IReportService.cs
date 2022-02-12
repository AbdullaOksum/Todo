using Todo.Entities.Concrete;

namespace Todo.Business.Interface
{
    public interface IReportService : IGenericService<Report>
    {
        Report GetWithAssignmentId(int id);
        int GetReportCountId(int id);
        int GetReportCount();

    }
}
