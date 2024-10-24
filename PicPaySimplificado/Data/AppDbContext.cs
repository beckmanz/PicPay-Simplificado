using Microsoft.EntityFrameworkCore;

namespace PicPaySimplificado.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}