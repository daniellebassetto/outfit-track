using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutfitTrack.Domain.Entities;

namespace OutfitTrack.Infraestructure.Maps;

public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("pedido");

        builder.HasMany(x => x.ListOrderItem).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
        builder.HasOne(x => x.Customer).WithMany(x => x.ListOrder).HasForeignKey(x => x.CustomerId);

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

        builder.Property(x => x.Number).HasColumnName("numero");
        builder.Property(x => x.Number).IsRequired();
        builder.Property(x => x.Number).HasColumnType("BIGINT");
        builder.Property(x => x.Number).ValueGeneratedNever();

        builder.Property(x => x.CustomerId).HasColumnName("id_cliente");
        builder.Property(x => x.CustomerId).IsRequired();
        builder.Property(x => x.CustomerId).HasColumnType("BIGINT");
        builder.Property(x => x.CustomerId).ValueGeneratedNever();

        builder.Property(x => x.Status).HasColumnName("status");
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.Status).HasColumnType("INT");
        builder.Property(x => x.Status).ValueGeneratedNever();

        builder.Property(x => x.ClosingDate).HasColumnName("data_encerramento");
        builder.Property(x => x.ClosingDate).HasColumnType("DATETIME");
        builder.Property(x => x.ClosingDate).ValueGeneratedNever();
    }
}