using Microsoft.EntityFrameworkCore;
using TechNotes.Domain.Notes;

namespace TechNotes.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Note> Notes { get; set; }
}
