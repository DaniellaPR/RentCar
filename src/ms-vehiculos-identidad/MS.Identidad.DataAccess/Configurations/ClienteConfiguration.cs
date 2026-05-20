using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Identidad.DataAccess.Entities;

namespace MS.Identidad.DataAccess.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("cliente");
            builder.HasKey(x => x.CLI_id);

            builder.Property(x => x.CLI_id).HasColumnName("cli_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.CLI_nombres).HasColumnName("cli_nombres").IsRequired().HasMaxLength(100);
            builder.Property(x => x.CLI_apellidos).HasColumnName("cli_apellidos").IsRequired().HasMaxLength(100);
            builder.Property(x => x.CLI_cedula).HasColumnName("cli_cedula").IsRequired().HasMaxLength(15);
            builder.Property(x => x.CLI_telefono).HasColumnName("cli_telefono").HasMaxLength(20);

            builder.Property(x => x.CLI_fechaCreacion).HasColumnName("cli_fechacreacion");
            builder.Property(x => x.CLI_usuarioCreacion).HasColumnName("cli_usuariocreacion");
            builder.Property(x => x.CLI_fechaModificacion).HasColumnName("cli_fechamodificacion");
            builder.Property(x => x.CLI_usuarioModificacion).HasColumnName("cli_usuariomodificacion");

            builder.HasIndex(x => x.CLI_cedula).IsUnique();
        }
    }
}