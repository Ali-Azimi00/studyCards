using Microsoft.EntityFrameworkCore;

namespace StudyCards.Models
{
    public class CardsContext : DbContext
    {
        public CardsContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Cards> cards { get; set; }
    }
}
