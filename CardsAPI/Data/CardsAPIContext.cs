using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CardsAPI.Models;


namespace CardsAPI.Data
{
    public class CardsAPIContext : DbContext
    {
        public CardsAPIContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SCards> sCards { get; set; }
    }
}
