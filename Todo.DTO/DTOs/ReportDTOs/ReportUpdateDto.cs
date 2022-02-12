using Todo.Entities.Concrete;

namespace Todo.DTO.DTOs.ReportDTOs
{
    public class ReportUpdateDto
    {
        public int Id { get; set; }

        public string Definition { get; set; }

        public string Detail { get; set; }

        public Assignment Assignment { get; set; }
        public int AssignmentId { get; set; }
    }
}
