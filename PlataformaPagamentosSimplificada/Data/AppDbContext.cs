using Microsoft.EntityFrameworkCore;
using PlataformaPagamentosSimplificada.Data.Map;
using PlataformaPagamentosSimplificada.Models;

namespace PlataformaPagamentosSimplificada.Data;

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