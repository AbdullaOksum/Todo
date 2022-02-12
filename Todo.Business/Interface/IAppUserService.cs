using Todo.Entities.Concrete;

namespace Todo.Business.Interface
{
    public interface IAppUserService
    {

        List<AppUser> ListNonAdmins();
        List<AppUser> ListNonAdmins(out int totalPage, string wordToSearch, int activePage = 1);
        List<DualHelper> ListMostAssignmentCompletedStaff();
        List<DualHelper> ListStaffWorkingOnAssignment();

    }
}
