using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Infraestructure.Maps;

public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("pedido_item");

        builder.HasOne(x => x.Order).WithMany(x => x.ListOrderItem).HasForeignKey(x => x.OrderId);
        builder.HasOne(x => x.Product).WithMany(x => x.ListOrderItem).HasForeignKey(x => x.ProductId);

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

        builder.Property(x => x.Item).HasColumnName("item");
        builder.Property(x => x.Item).IsRequired();
        builder.Property(x => x.Item).HasColumnType("INT");
        builder.Property(x => x.Item).ValueGeneratedNever();

        builder.Property(x => x.OrderId).HasColumnName("id_pedido");
        builder.Property(x => x.OrderId).IsRequired();
        builder.Property(x => x.OrderId).HasColumnType("BIGINT");
        builder.Property(x => x.OrderId).ValueGeneratedNever();

        builder.Property(x => x.ProductId).HasColumnName("id_produto");
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.ProductId).HasColumnType("BIGINT");
        builder.Property(x => x.ProductId).ValueGeneratedNever();

        builder.Property(x => x.Color).HasColumnName("cor");
        builder.Property(x => x.Color).HasColumnType("VARCHAR(30)");
        builder.Property(x => x.Color).ValueGeneratedNever();

        builder.Property(x => x.Size).HasColumnName("tamanho");
        builder.Property(x => x.Size).HasColumnType("VARCHAR(10)");
        builder.Property(x => x.Size).ValueGeneratedNever();

        builder.Property(x => x.Status).HasColumnName("status");
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.Status).HasColumnType("INT");
        builder.Property(x => x.Status).ValueGeneratedNever();
    }
}