using Microsoft.AspNetCore.Identity;

namespace RoleMenuDemo.Data
{
    public static class SeedData

    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = new[] { "Admin", "Accountant", "Inventory", "Purchase" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create sample users (password: Pass@123)
            await EnsureUser(userManager, "admin@example.com", "Admin");
            await EnsureUser(userManager, "acct@example.com", "Accountant");
            await EnsureUser(userManager, "inv@example.com", "Inventory");
            await EnsureUser(userManager, "pur@example.com", "Purchase");
        }

        private static async Task EnsureUser(UserManager<IdentityUser> userManager, string email, string role)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true };
                await userManager.CreateAsync(user, "Pass@123");
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
