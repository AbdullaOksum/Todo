using Microsoft.EntityFrameworkCore;
using Todo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Todo.DataAccess.Interfaces;
using Todo.Entities.Concrete;

namespace Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReportRepository : EfGenericRepository<Report>, IReportDal
    {
        public Report GetWithAssignmentId(int id)
        {
            using var context = new TodoContext();
            return context.Reports.Include(I => I.Assignment).
                ThenInclude(I => I.Urgency).Where(I => I.Id == id).FirstOrDefault();

        }

        public int GetReportCount()
        {
            using var context = new TodoContext();
            return context.Reports.Count();
        }

        public int GetReportCountId(int id)
        {
            using var context = new TodoContext();
            var result = context.Assignments.Include(x => x.Reports).Where(x => x.AppUserId == id);
            return result.SelectMany(x => x.Reports).Count();

        }
    }
}
