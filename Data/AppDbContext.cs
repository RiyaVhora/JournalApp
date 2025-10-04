using JournalApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JournalApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<JournalEntry> JournalEntries { get; set; }
    }
}
