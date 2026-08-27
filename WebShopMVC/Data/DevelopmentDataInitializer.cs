using Microsoft.AspNetCore.Identity;

namespace WebShopMVC.Data;

public static class DevelopmentDataInitializer
{
    private const string AdminRole = "Admin";

    public static async Task SeedAsync(
        IServiceProvider services,
        IConfiguration configuration)
    {
        var email = configuration["DevelopmentAdmin:Email"];
        var password = configuration["DevelopmentAdmin:Password"];

        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            throw new InvalidOperationException(
                "Development admin credentials are missing. " +
                "Configure DevelopmentAdmin:Email and " +
                "DevelopmentAdmin:Password using User Secrets " +
                "or environment variables.");
        }

        var roleManager =
            services.GetRequiredService<RoleManager<IdentityRole>>();

        var userManager =
            services.GetRequiredService<UserManager<ApplicationUser>>();

        if (!await roleManager.RoleExistsAsync(AdminRole))
        {
            var roleResult =
                await roleManager.CreateAsync(new IdentityRole(AdminRole));

            EnsureSucceeded(roleResult, "create Admin role");
        }

        var adminUser = await userManager.FindByEmailAsync(email);

        if (adminUser is null)
        {
            adminUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var createResult =
                await userManager.CreateAsync(adminUser, password);

            EnsureSucceeded(
                createResult,
                "create development admin user");
        }
        else if (!await userManager.CheckPasswordAsync(adminUser, password))
        {
            var resetToken =
                await userManager.GeneratePasswordResetTokenAsync(adminUser);

            var resetResult =
                await userManager.ResetPasswordAsync(
                    adminUser,
                    resetToken,
                    password);

            EnsureSucceeded(
                resetResult,
                "reset development admin password");
        }

        if (!await userManager.IsInRoleAsync(adminUser, AdminRole))
        {
            var roleResult =
                await userManager.AddToRoleAsync(adminUser, AdminRole);

            EnsureSucceeded(
                roleResult,
                "assign Admin role to development user");
        }
    }

    private static void EnsureSucceeded(
        IdentityResult result,
        string operation)
    {
        if (result.Succeeded)
        {
            return;
        }

        var errors = string.Join(
            "; ",
            result.Errors.Select(error => error.Description));

        throw new InvalidOperationException(
            $"Failed to {operation}: {errors}");
    }
}