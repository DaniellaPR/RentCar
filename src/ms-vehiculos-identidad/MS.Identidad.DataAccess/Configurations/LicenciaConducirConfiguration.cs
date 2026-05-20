using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Identidad.DataAccess.Entities;

namespace MS.Identidad.DataAccess.Configurations
{
    public class LicenciaConducirConfiguration : IEntityTypeConfiguration<LicenciaConducirEntity>
    {
        public void Configure(EntityTypeBuilder<LicenciaConducirEntity> builder)
        {
            builder.ToTable("licenciaconducir");
            builder.HasKey(x => x.LIC_id);

            builder.Property(x => x.LIC_id).HasColumnName("lic_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.CLI_id).HasColumnName("cli_id").IsRequired();
            builder.Property(x => x.LIC_numero).HasColumnName("lic_numero").IsRequired().HasMaxLength(50);
            builder.Property(x => x.LIC_categoria).HasColumnName("lic_categoria").IsRequired().HasMaxLength(10);
            builder.Property(x => x.LIC_vigencia).HasColumnName("lic_vigencia").HasColumnType("date").IsRequired();

            builder.Property(x => x.LIC_fechaCreacion).HasColumnName("lic_fechacreacion");
            builder.Property(x => x.LIC_usuarioCreacion).HasColumnName("lic_usuariocreacion");
            builder.Property(x => x.LIC_fechaModificacion).HasColumnName("lic_fechamodificacion");
            builder.Property(x => x.LIC_usuarioModificacion).HasColumnName("lic_usuariomodificacion");

            builder.HasIndex(x => x.LIC_numero).IsUnique();

            builder.HasOne(x => x.Cliente)
                   .WithMany(c => c.Licencias)
                   .HasForeignKey(x => x.CLI_id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}