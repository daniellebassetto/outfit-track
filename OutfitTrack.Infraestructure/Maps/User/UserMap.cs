using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Infraestructure.Maps;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("usuario");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Id).HasColumnType("BIGINT");
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.CreationDate).HasColumnName("data_cadastro");
        builder.Property(x => x.CreationDate).IsRequired();
        builder.Property(x => x.CreationDate).HasColumnType("DATETIME");
        builder.Property(x => x.CreationDate).ValueGeneratedNever();

        builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");
        builder.Property(x => x.ChangeDate).HasColumnType("DATETIME");
        builder.Property(x => x.ChangeDate).ValueGeneratedNever();

        builder.Property(x => x.Email).HasColumnName("email");
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Email).HasColumnType("VARCHAR(256)");
        builder.Property(x => x.Email).ValueGeneratedNever();

        builder.Property(x => x.Password).HasColumnName("senha");
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Password).HasColumnType("VARCHAR(200)");
        builder.Property(x => x.Password).ValueGeneratedNever();

        builder.Property(x => x.TokenExpirationDate).HasColumnName("data_expiracao_token");
        builder.Property(x => x.TokenExpirationDate).IsRequired();
        builder.Property(x => x.TokenExpirationDate).HasColumnType("DATETIME");
        builder.Property(x => x.TokenExpirationDate).ValueGeneratedNever();
    }
}