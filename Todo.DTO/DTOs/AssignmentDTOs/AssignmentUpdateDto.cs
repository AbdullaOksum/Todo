namespace Todo.DTO.DTOs.AssignmentDTOs
{
    public class AssignmentUpdateDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Ad alani gereklidir")]
        public string Name { get; set; }
        public string Explanation { get; set; }

        //[Range(0, int.MaxValue, ErrorMessage = "Lutfen bir Urgency durumu seciniz")]
        public int UrgencyId { get; set; }
    }
}
