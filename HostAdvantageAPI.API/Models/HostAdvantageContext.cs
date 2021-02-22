using Microsoft.EntityFrameworkCore;


namespace HostAdvantageAPI.API.Models
{
    public class HostAdvantageContext : DbContext
    {
        public HostAdvantageContext(DbContextOptions<HostAdvantageContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
