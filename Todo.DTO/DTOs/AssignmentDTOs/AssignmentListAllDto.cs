using Todo.Entities.Concrete;

namespace Todo.DTO.DTOs.AssignmentDTOs
{
    public class AssignmentListAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Urgency Urgency { get; set; }
        public AppUser AppUser { get; set; }
        public List<Report> Reports { get; set; }
    }
}
