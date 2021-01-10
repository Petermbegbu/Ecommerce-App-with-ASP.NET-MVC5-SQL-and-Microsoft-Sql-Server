using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ECommerceApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext", throwIfV1Schema: false)
        {
        }

        public DbSet<Tbl_Cart> Tbl_Carts { get; set; }
        public DbSet<Tbl_CartStatus> Tbl_CartStatus { get; set; }
        public DbSet<Tbl_Category> Tbl_Categories { get; set; }
        public DbSet<Tbl_MemberRole> Tbl_MemberRoles { get; set; }
        public DbSet<Tbl_Member> Tbl_Members { get; set; }
        public DbSet<Tbl_Product> Tbl_Products { get; set; }
        public DbSet<Tbl_Role> Tbl_Roles { get; set; }
        public DbSet<Tbl_ShippingDetail> Tbl_ShippingDetails { get; set; }
        public DbSet<Tbl_SlideImage> Tbl_SlideImages { get; set; }
        public DbSet<Tbl_OrderTransaction> Tbl_OrderTransactions { get; set; }
        public DbSet<Tbl_OrderDetail> Tbl_OrderDetails { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}