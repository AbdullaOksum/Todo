using Todo.Entities.Interface;

namespace Todo.Entities.Concrete
{
    public class Report : ITablo
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public string Detail { get; set; }

        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

    }
}
