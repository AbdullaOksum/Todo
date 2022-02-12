using Todo.Entities.Interface;

namespace Todo.Entities.Concrete
{
    public class Notification : ITablo
    {
        public int Id { get; set; }
        public string Explanation { get; set; }
        public bool Situation { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
