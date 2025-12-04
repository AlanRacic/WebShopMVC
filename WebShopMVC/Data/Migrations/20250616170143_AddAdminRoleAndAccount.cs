using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.AspNetCore.Identity;
using System.Text;

#nullable disable

namespace WebShopMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminRoleAndAccount : Migration
    {
        const string ADMIN_USER_GUID = "c3840a95-30c4-4644-a5fe-bd16fe9fc85c";
        const string ADMIN_ROLE_GUID = "714eca16-b0c4-414c-9d4a-748be171a7f4";

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var passwordHash = hasher.HashPassword(null, "Password12345!");

            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName, Email, ");
            sb.Append("NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, ");
            sb.Append("PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, ");
            sb.AppendLine("Address, City, Country, FirstName, LastName, ZIP) ");
            sb.Append("VALUES('" + ADMIN_USER_GUID + "','admin@admin.com','ADMIN@ADMIN.COM','admin@admin.com',");
            sb.Append("'ADMIN@ADMIN.COM',1,'" + passwordHash + "','','',0,0,null,1,0,null,null,null,null,null,null)");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql("INSERT INTO AspNetRoles(Id, Name, NormalizedName) VALUES('" +
                ADMIN_ROLE_GUID + "','Admin','ADMIN')");

            migrationBuilder.Sql("INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES('" +
                ADMIN_USER_GUID + "','" + ADMIN_ROLE_GUID + "')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetUserRoles where UserId='" + ADMIN_USER_GUID +
                "' and RoleId='" + ADMIN_ROLE_GUID + "'");

            migrationBuilder.Sql($"DELETE FROM AspNetRoles where Id='{ADMIN_ROLE_GUID}'");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers where Id='{ADMIN_USER_GUID}'");
        }
    }
}
