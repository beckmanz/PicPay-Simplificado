using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Data.Map;
using PicPaySimplificado.Models;

namespace PicPaySimplificado.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<UserModel> Users { get; set; }
    public DbSet<TransactionModel> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new TransactionMap());
        base.OnModelCreating(modelBuilder);
    }
}