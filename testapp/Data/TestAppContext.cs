using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testapp.Models;

namespace testapp.Data
{
    public class TestAppContext : IdentityDbContext<IdentityUser>
    {
        public TestAppContext(DbContextOptions<TestAppContext> options) : base(options)
        {
        }

        public DbSet<Item>? Items { get; set; }
    }
}
