using Todo.Entities.Interface;

namespace Todo.Entities.Concrete
{
    public class Urgency : ITablo
    {
        public int Id { get; set; }
        public string Definition { get; set; }

        public List<Assignment> Assignments { get; set; }

    }
}
