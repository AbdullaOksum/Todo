using Todo.DataAccess.Interfaces;
using Todo.Entities.Concrete;

namespace Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUrgencyRepository : EfGenericRepository<Urgency>, IUrgencyDal
    {
    }
}
