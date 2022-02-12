using AutoMapper;
using Todo.DTO.DTOs.AppUserDTOs;
using Todo.DTO.DTOs.AssignmentDTOs;
using Todo.DTO.DTOs.NotificationDTOs;
using Todo.DTO.DTOs.ReportDTOs;
using Todo.DTO.DTOs.UrgencyDTOs;
using Todo.Entities.Concrete;

namespace Todo.WebUi.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Urgency - UrgencyDto
            CreateMap<UrgencyAddDto, Urgency>();
            CreateMap<Urgency, UrgencyAddDto>();
            CreateMap<UrgencyListDto, Urgency>();
            CreateMap<Urgency, UrgencyListDto>();
            CreateMap<UrgencyUpdateDto, Urgency>();
            CreateMap<Urgency, UrgencyUpdateDto>();
            #endregion

            #region Report - ReportDto
            CreateMap<ReportAddDto, Report>();
            CreateMap<Report, ReportAddDto>();
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>();
            CreateMap<ReportFileDto, Report>();
            CreateMap<Report, ReportFileDto>();
            #endregion

            #region NotificationDto - Notification
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

            #region Assignment - AssignmentAddDto
            CreateMap<AssignmentAddDto, Assignment>();
            CreateMap<Assignment, AssignmentAddDto>();
            CreateMap<AssignmentListDto, Assignment>();
            CreateMap<Assignment, AssignmentListDto>();
            CreateMap<AssignmentUpdateDto, Assignment>();
            CreateMap<Assignment, AssignmentUpdateDto>();
            CreateMap<AssignmentListAllDto, Assignment>();
            CreateMap<Assignment, AssignmentListAllDto>();
            #endregion

            #region AppUser - AppUserDto
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();

            #endregion
        }

    }
}
