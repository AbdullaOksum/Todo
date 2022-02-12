using Todo.Business.Interface;
using Todo.DataAccess.Interfaces;
using Todo.Entities.Concrete;

namespace Todo.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _userDal;
        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<AppUser> ListNonAdmins()
        {
            return _userDal.ListNonAdmins();
        }

        public List<AppUser> ListNonAdmins(out int totalPage, string wordToSearch, int activePage)
        {
            return _userDal.ListNonAdmins(out totalPage, wordToSearch, activePage);
        }

        public List<DualHelper> ListStaffWorkingOnAssignment()
        {
            return _userDal.ListStaffWorkingOnAssignment();
        }

        public List<DualHelper> ListMostAssignmentCompletedStaff()
        {
            return _userDal.ListMostAssignmentCompletedStaff();
        }
    }
}
