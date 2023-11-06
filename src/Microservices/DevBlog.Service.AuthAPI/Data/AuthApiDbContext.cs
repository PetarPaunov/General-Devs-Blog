namespace DevBlog.Service.AuthAPI.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using DevBlog.Service.AuthAPI.Models.DbModels;

    public class AuthApiDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthApiDbContext(DbContextOptions<AuthApiDbContext> options) 
            : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
