using Microsoft.EntityFrameworkCore;
using Todo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Todo.DataAccess.Interfaces;
using Todo.Entities.Concrete;

namespace Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUsersRepository : IAppUserDal
    {
        public List<AppUser> ListNonAdmins()
        {
            /*
             select * from aspnetUsers inner join AspNetUserRoles on AspNetUsers.Id=AspNetUserRoles.UserId 
inner join AspNetRoles
on AspNetUserRoles.RoleId = AspNetRoles.Id
where AspNetRoles.Name='admin'

             */
            using var Context = new TodoContext();

            return Context.Users.Join(Context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,

                userRole = resultUserRole
            }).Join(Context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role =>
              role.Id, (resultTable, resultRole) => new
              {
                  user = resultTable.user,
                  userRole = resultTable.userRole,
                  roles = resultRole
              }).Where(x => x.roles.Name == "Member").Select(x => new AppUser()
              {
                  Id = x.user.Id,
                  AccessFailedCount = x.user.AccessFailedCount,
                  Name = x.user.Name,
                  SurName = x.user.SurName,
                  Picture = x.user.Picture,
                  Email = x.user.Email,
                  UserName = x.user.UserName
              }).ToList();

        }


        public List<AppUser> ListNonAdmins(out int totalPage, string wordToSearch, int activePage = 1)
        {

            using var Context = new TodoContext();

            var result = Context.Users.Join(Context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,

                userRole = resultUserRole
            }).Join(Context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role =>
              role.Id, (resultTable, resultRole) => new
              {
                  user = resultTable.user,
                  userRole = resultTable.userRole,
                  roles = resultRole
              }).Where(x => x.roles.Name == "Member").Select(x => new AppUser()
              {
                  Id = x.user.Id,
                  AccessFailedCount = x.user.AccessFailedCount,
                  Name = x.user.Name,
                  SurName = x.user.SurName,
                  Picture = x.user.Picture,
                  Email = x.user.Email,
                  UserName = x.user.UserName
              });

            totalPage = (int)Math.Ceiling((double)result.Count() / 3);

            if (!string.IsNullOrWhiteSpace(wordToSearch))
            {
                result = result.Where(x => x.Name.ToLower().Contains
                (wordToSearch.ToLower()) || x.SurName.ToLower().Contains
                (wordToSearch.ToLower()));
                totalPage = (int)Math.Ceiling((double)result.Count() / 3);


            }

            result = result.Skip((activePage - 1) * 3).Take(3);

            return result.ToList();

        }

        public List<DualHelper> ListMostAssignmentCompletedStaff()
        {
            using var context = new TodoContext();
            return context.Assignments.Include(x => x.AppUser).Where(x => x.Situation).GroupBy(
                x => x.AppUser.UserName).OrderByDescending(x => x.Count()).Take(5).Select(x =>
                new DualHelper
                {
                    Name = x.Key,
                    NumberOfTasks = x.Count()
                }).ToList();


        }

        public List<DualHelper> ListStaffWorkingOnAssignment()
        {
            using var context = new TodoContext();
            return context.Assignments.Include(x => x.AppUser).Where(x => !x.Situation && x.AppUserId != null).GroupBy(
                x => x.AppUser.UserName).OrderByDescending(x => x.Count()).Take(5).Select(x =>
                new DualHelper
                {
                    Name = x.Key,
                    NumberOfTasks = x.Count()
                }).ToList();


        }

    }
}
