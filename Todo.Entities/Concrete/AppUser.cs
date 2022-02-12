using Microsoft.AspNetCore.Identity;
using Todo.Entities.Interface;

namespace Todo.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITablo
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Picture { get; set; } = "default.png";
        public List<Notification> Notifications { get; set; }
        public List<Assignment> Assignments { get; set; }

    }
}
