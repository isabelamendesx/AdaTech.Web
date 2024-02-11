using Microsoft.EntityFrameworkCore;
using PropertiesAPI.Models;

namespace PropertiesAPI.Data
{
    public class PropertyContext : DbContext
    {
        public PropertyContext(DbContextOptions options) : base(options) { }
        public DbSet<Property> Properties { get; set; }
    }
}
