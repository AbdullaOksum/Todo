using Todo.DTO.DTOs.AssignmentDTOs;

namespace Todo.DTO.DTOs.AppUserDTOs
{
    public class ListAssignStaffDto
    {
        public AppUserListDto AppUser { get; set; }
        public AssignmentListDto Assignment { get; set; }
    }
}

