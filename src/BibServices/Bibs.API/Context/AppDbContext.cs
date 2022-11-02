using Microsoft.EntityFrameworkCore;

namespace Bibs.API.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}