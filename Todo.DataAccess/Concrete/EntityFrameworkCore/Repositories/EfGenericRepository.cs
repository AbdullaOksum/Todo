using Todo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Todo.DataAccess.Interfaces;
using Todo.Entities.Interface;

namespace Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Tablo> : IGenericDal<Tablo> where Tablo : class, ITablo, new()
    {
        public List<Tablo> ListAll()
        {
            using var context = new TodoContext();
            return context.Set<Tablo>().ToList();
        }



        public Tablo GetId(int id)
        {
            using var context = new TodoContext();
            return context.Set<Tablo>().Find(id);
        }
        public void Update(Tablo tablo)
        {
            using var context = new TodoContext();
            context.Set<Tablo>().Update(tablo);
            context.SaveChanges();
        }


        public void Delete(Tablo tablo)
        {

            using var context = new TodoContext();
            context.Set<Tablo>().Remove(tablo);
            context.SaveChanges(true);
        }

        public void Save(Tablo tablo)
        {
            using var context = new TodoContext();
            context.Set<Tablo>().Add(tablo);
            context.SaveChanges(true);
        }


    }
}
