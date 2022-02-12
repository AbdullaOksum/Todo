using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Todo.Business.Concrete;
using Todo.Business.Interface;
using Todo.Business.ValidationRules.FluentValidation;
using Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Todo.DataAccess.Interfaces;
using Todo.DTO.DTOs.AppUserDTOs;
using Todo.DTO.DTOs.AssignmentDTOs;
using Todo.DTO.DTOs.ReportDTOs;
using Todo.DTO.DTOs.UrgencyDTOs;

namespace Todo.Business.DiContainer
{
    public static class CustomExtension
    {
        public static void AddContainerWithDepencies(IServiceCollection services)
        {

            services.AddScoped<IAssignmentService, AssignmentManager>();
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<IAssignmentDal, EfAssignmentRepository>();
            services.AddScoped<IUrgencyDal, EfUrgencyRepository>();
            services.AddScoped<IReportDal, EfReportRepository>();
            services.AddScoped<IAppUserDal, EfAppUsersRepository>();
            services.AddScoped<INotificationDal, EfNotificationRepository>();

        }

        public static void AddValidator(IServiceCollection services)
        {

            services.AddTransient<IValidator<UrgencyAddDto>, urgencyAddValidator>();
            services.AddTransient<IValidator<UrgencyUpdateDto>, UrgencyUpdateValidator>();
            services.AddTransient<IValidator<ReportAddDto>, ReportAddValidation>();
            services.AddTransient<IValidator<ReportUpdateDto>, ReportUpdateValidator>();
            services.AddTransient<IValidator<AssignmentUpdateDto>, AssignmentUpdateValidator>();
            services.AddTransient<IValidator<AssignmentAddDto>, AssignmentAddValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
            services.AddTransient<IValidator<AppUserListDto>, AppUserListValidator>();

        }
    }
}
