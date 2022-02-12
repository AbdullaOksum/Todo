using Todo.Entities.Concrete;

namespace Todo.DataAccess.Interfaces
{
    public interface IAppUserDal
    {
        List<AppUser> ListNonAdmins();
        List<AppUser> ListNonAdmins(out int totalPage, string wordToSearch, int activePage = 1);
        List<DualHelper> ListMostAssignmentCompletedStaff();
        List<DualHelper> ListStaffWorkingOnAssignment();

    }
}
