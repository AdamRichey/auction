using Microsoft.EntityFrameworkCore;
 
namespace Plate.Models
{
    public class platecontext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public platecontext(DbContextOptions<platecontext> options) : base(options) { }
        public DbSet<Person> Users { get; set; }
        public DbSet<Auctions> Auctions { get; set; }
        public DbSet<Bids> Bids { get; set; }
    }
}