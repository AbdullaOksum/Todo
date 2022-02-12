using Todo.Entities.Concrete;

namespace Todo.DTO.DTOs.AssignmentDTOs
{
    public class AssignmentListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Explanation { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool Situation { get; set; }
        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }

    }
}
