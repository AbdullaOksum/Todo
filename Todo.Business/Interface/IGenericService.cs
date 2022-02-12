using Todo.Entities.Interface;

namespace Todo.Business.Interface
{
    public interface IGenericService<Tablo> where Tablo : class, ITablo, new()
    {
        void Save(Tablo tablo);
        void Delete(Tablo tablo);
        void Update(Tablo tablo);

        Tablo GetId(int Id);
        List<Tablo> GetAll();
    }
}
