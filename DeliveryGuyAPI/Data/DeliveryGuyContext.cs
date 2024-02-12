using DeliveryGuyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryGuyAPI.Data;

public class DeliveryGuyContext : DbContext
{
    public DeliveryGuyContext(DbContextOptions<DeliveryGuyContext> options)
    : base(options) { }

    public DbSet<DeliveryGuy> DeliveryGuys { get; set; }
}
