using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Infraestructure.Maps;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("produto");

        builder.HasMany(x => x.ListOrderItem).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);

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

        builder.Property(x => x.Code).HasColumnName("codigo");
        builder.Property(x => x.Code).IsRequired();
        builder.Property(x => x.Code).HasColumnType("VARCHAR(20)");
        builder.Property(x => x.Code).ValueGeneratedNever();

        builder.Property(x => x.Description).HasColumnName("descricao");
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Description).HasColumnType("VARCHAR(100)");
        builder.Property(x => x.Description).ValueGeneratedNever();

        builder.Property(x => x.Price).HasColumnName("preco");
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Price).HasColumnType("DECIMAL(10,2)");
        builder.Property(x => x.Price).ValueGeneratedNever();

        builder.Property(x => x.Size).HasColumnName("tamanho");
        builder.Property(x => x.Size).IsRequired();
        builder.Property(x => x.Size).HasColumnType("VARCHAR(10)");
        builder.Property(x => x.Size).ValueGeneratedNever();

        builder.Property(x => x.Color).HasColumnName("cor");
        builder.Property(x => x.Color).HasColumnType("VARCHAR(30)");
        builder.Property(x => x.Color).ValueGeneratedNever();

        builder.Property(x => x.Brand).HasColumnName("marca");
        builder.Property(x => x.Brand).HasColumnType("VARCHAR(50)");
        builder.Property(x => x.Brand).ValueGeneratedNever();

        builder.Property(x => x.Quantity).HasColumnName("quantidade");
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Quantity).HasColumnType("INT");
        builder.Property(x => x.Quantity).ValueGeneratedNever();

        builder.Property(x => x.Category).HasColumnName("categoria");
        builder.Property(x => x.Category).HasColumnType("VARCHAR(100)");
        builder.Property(x => x.Category).ValueGeneratedNever();
    }
}