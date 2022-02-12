using Todo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Todo.Entities.Concrete;

namespace Todo.WebUi.CustomCollectionExtensions
{
    public static class CollectionExtension
    {
        public static void AddCustomIdentity(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>();
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequireUppercase = false;
                x.Password.RequiredLength = 1;
                x.Password.RequireLowercase = false;
                x.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<TodoContext>();

            services.ConfigureApplicationCookie(x =>
            {
                x.Cookie.Name = "TodoCookie";

                // Baska sayfalardan bu cookieye ulasilabilinsin istemiyoruz.
                x.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;

                // ilgili kisi document.cookie diyerek ulasamasin diye.
                x.Cookie.HttpOnly = true;

                // Ne kadar sure Cookie ayakda kalacak?
                x.ExpireTimeSpan = TimeSpan.FromDays(20);

                // Istek neyse o sekilde favran. yani Http mi Https mi ? ona gøre davran
                x.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;


                x.LoginPath = "/Home/Index";

            });

        }
    }
}
