using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Todo.Business.DiContainer;
using Todo.Entities.Concrete;
using Todo.WebUi;
using Todo.WebUi.CustomCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

CustomExtension.AddValidator(builder.Services);

builder.Services.AddControllersWithViews().AddFluentValidation();

Todo.Business.DiContainer.CustomExtension.AddContainerWithDepencies(builder.Services);

CollectionExtension.AddCustomIdentity(builder.Services);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");
app.UseRouting();

using IServiceScope serviceScope = app.Services.CreateScope();

IServiceProvider services = serviceScope.ServiceProvider;

UserManager<AppUser> UserManager = services.GetRequiredService<UserManager<AppUser>>();
RoleManager<AppRole> RoleManager = services.GetRequiredService<RoleManager<AppRole>>();

IdentityInitializer.SeedData(UserManager, RoleManager).Wait();






app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
       name: "areas",
       pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
        );

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"

        );
});

app.Run();
