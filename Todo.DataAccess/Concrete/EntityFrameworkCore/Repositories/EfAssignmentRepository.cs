using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Todo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Todo.DataAccess.Interfaces;
using Todo.Entities.Concrete;

namespace Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAssignmentRepository : EfGenericRepository<Assignment>, IAssignmentDal
    {
        public Assignment GetUrgencyWithId(int id)
        {
            using var context = new TodoContext();
            // Eager loading...
            return context.Assignments.Include(x => x.Urgency).FirstOrDefault(x => !x.Situation && x.Id == id);
        }

        public List<Assignment> ListUrgencyNonCompleted()
        {
            using var context = new TodoContext();
            // Eager loading...
            return context.Assignments.Include(x => x.Urgency).Where(x => !x.Situation).
                 OrderByDescending(x => x.CreatedDate).ToList();
        }

        public List<Assignment> GetAppUserId(int id)
        {
            using var context = new TodoContext();

            return context.Assignments.Where(x => x.AppUserId == id).ToList();
        }

        public List<Assignment> GetAllProperty()
        {
            using (var context = new TodoContext())
            {
                // Eager loading...
                return context.Assignments.Include(x => x.Urgency).Include(x => x.Reports).Include(x => x.AppUser)
                    .Where(x => !x.Situation).
                     OrderByDescending(x => x.CreatedDate).ToList();

            }

        }

        public Assignment GetReportId(int id)
        {
            using var context = new TodoContext();
            return context.Assignments.Include(x => x.Reports).Include(x => x.AppUser).Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Assignment> GetAllProperty(Expression<Func<Assignment, bool>> filter)
        {
            using (var context = new TodoContext())
            {
                // Eager loading...
                return context.Assignments.Include(x => x.Urgency).Include(x => x.Reports).Include(x => x.AppUser)
                    .Where(filter).OrderByDescending(x => x.CreatedDate).ToList();

            }
        }

        public List<Assignment> GetAllPropertyNonCompleted(out int totalPage, int userId, int
            activepage = 1)
        {
            using (var context = new TodoContext())
            {
                var returnValue = context.Assignments.Include(x => x.Urgency).Include(x =>
                x.Reports).Include(x => x.AppUser).Where(x => x.AppUserId == userId &&
                x.Situation).OrderByDescending(x => x.CreatedDate);

                totalPage = (int)Math.Ceiling((double)returnValue.Count() / 3);
                return returnValue.Skip((activepage - 1) * 3).Take(3).ToList();
            }
        }

        public int GetAssignmentCompletedCountAppUserId(int id)
        {
            using var context = new TodoContext();
            return context.Assignments.Count(x => x.AppUserId == id && x.Situation);
        }

        public int GetAssignmentNonCompletedCountAppUserId(int id)
        {
            using var context = new TodoContext();
            return context.Assignments.Count(x => x.AppUserId == id && !x.Situation);
        }

        public int GetAssignmentWithNonStaff()
        {
            using var context = new TodoContext();
            return context.Assignments.Count(x => x.AppUserId == null && !x.Situation);

        }

        public int GetAssignmentCompletedCount()
        {
            using var context = new TodoContext();
            return context.Assignments.Count(x => x.Situation);

        }
    }
}
