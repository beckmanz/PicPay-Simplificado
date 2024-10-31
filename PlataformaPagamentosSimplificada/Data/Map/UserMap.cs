using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaPagamentosSimplificada.Models;

namespace PlataformaPagamentosSimplificada.Data.Map;

public class UserMap : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.FirstName)
            .IsRequired();
        
        builder.Property(u => u.LastName)
            .IsRequired();
        
        builder.Property(u => u.Document)
            .IsRequired();
        
        builder.HasIndex(u => u.Document)
            .IsUnique();
        
        builder.Property(u => u.Email)
            .IsRequired();
        
        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Balance)
            .HasColumnType("decimal(18, 2)");

        builder.Property(u => u.UserType)
            .HasConversion<string>();

    }
}