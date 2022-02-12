using Todo.Entities.Interface;

namespace Todo.Entities.Concrete
{
    public class Assignment : ITablo
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Explanation { get; set; }
        public bool Situation { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }


        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Report> Reports { get; set; }




    }
}
