using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OutfitTrack.Domain.Entities;
using System.IO;

namespace OutfitTrack.Infraestructure.Maps;

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("cliente");

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

        builder.Property(x => x.FirstName).HasColumnName("primeiro_nome");
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.FirstName).HasColumnType("VARCHAR(50)");
        builder.Property(x => x.FirstName).ValueGeneratedNever();
        
        builder.Property(x => x.LastName).HasColumnName("sobrenome");
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.LastName).HasColumnType("VARCHAR(50)");
        builder.Property(x => x.LastName).ValueGeneratedNever();

        builder.Property(x => x.BirthDate).HasColumnName("data_nascimento");
        builder.Property(x => x.BirthDate).IsRequired();
        builder.Property(x => x.BirthDate).HasColumnType("DATETIME");
        builder.Property(x => x.BirthDate).ValueGeneratedNever();

        builder.Property(x => x.Cpf).HasColumnName("cpf");
        builder.Property(x => x.Cpf).IsRequired();
        builder.Property(x => x.Cpf).HasColumnType("VARCHAR(11)");
        builder.Property(x => x.Cpf).ValueGeneratedNever();
        
        builder.Property(x => x.Street).HasColumnName("endereco");
        builder.Property(x => x.Street).IsRequired();
        builder.Property(x => x.Street).HasColumnType("VARCHAR(100)");
        builder.Property(x => x.Street).ValueGeneratedNever();
        
        builder.Property(x => x.Complement).HasColumnName("complemento");
        builder.Property(x => x.Complement).IsRequired();
        builder.Property(x => x.Complement).HasColumnType("VARCHAR(100)");
        builder.Property(x => x.Complement).ValueGeneratedNever();

        builder.Property(x => x.Neighborhood).HasColumnName("bairro");
        builder.Property(x => x.Neighborhood).IsRequired();
        builder.Property(x => x.Neighborhood).HasColumnType("VARCHAR(50)");
        builder.Property(x => x.Neighborhood).ValueGeneratedNever();

        builder.Property(x => x.Number).HasColumnName("numero");
        builder.Property(x => x.Number).IsRequired();
        builder.Property(x => x.Number).HasColumnType("VARCHAR(10)");
        builder.Property(x => x.Number).ValueGeneratedNever();

        builder.Property(x => x.CityName).HasColumnName("nome_cidade");
        builder.Property(x => x.CityName).IsRequired();
        builder.Property(x => x.CityName).HasColumnType("VARCHAR(50)");
        builder.Property(x => x.CityName).ValueGeneratedNever();

        builder.Property(x => x.StateAbbreviation).HasColumnName("sigla_estado");
        builder.Property(x => x.StateAbbreviation).IsRequired();
        builder.Property(x => x.StateAbbreviation).HasColumnType("VARCHAR(2)");
        builder.Property(x => x.StateAbbreviation).ValueGeneratedNever();

        builder.Property(x => x.Rg).HasColumnName("rg");
        builder.Property(x => x.Rg).IsRequired();
        builder.Property(x => x.Rg).HasColumnType("VARCHAR(9)");
        builder.Property(x => x.Rg).ValueGeneratedNever();        
        
        builder.Property(x => x.MobilePhoneNumber).HasColumnName("numero_celular");
        builder.Property(x => x.MobilePhoneNumber).IsRequired();
        builder.Property(x => x.MobilePhoneNumber).HasColumnType("VARCHAR(13)");
        builder.Property(x => x.MobilePhoneNumber).ValueGeneratedNever();    
        
        builder.Property(x => x.Email).HasColumnName("email");
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Email).HasColumnType("VARCHAR(256)");
        builder.Property(x => x.Email).ValueGeneratedNever();
    }
}