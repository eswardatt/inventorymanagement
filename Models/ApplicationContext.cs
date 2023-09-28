using Microsoft.EntityFrameworkCore;

namespace inventorymanagement.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<InventoryItem> InventoryItems { get; set; }
    }
}
