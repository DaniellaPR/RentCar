using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Configurations
{
    public class TarifaConfiguration : IEntityTypeConfiguration<TarifaEntity>
    {
        public void Configure(EntityTypeBuilder<TarifaEntity> builder)
        {
            builder.ToTable("tarifa");
            builder.HasKey(x => x.TAR_id);

            builder.Property(x => x.TAR_id).HasColumnName("tar_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.CAT_id).HasColumnName("cat_id").IsRequired();
            builder.Property(x => x.TAR_precioDiario).HasColumnName("tar_preciodiario").HasColumnType("numeric(10,2)").IsRequired();

            builder.Property(x => x.TAR_fechaCreacion).HasColumnName("tar_fechacreacion");
            builder.Property(x => x.TAR_usuarioCreacion).HasColumnName("tar_usuariocreacion");
            builder.Property(x => x.TAR_fechaModificacion).HasColumnName("tar_fechamodificacion");
            builder.Property(x => x.TAR_usuarioModificacion).HasColumnName("tar_usuariomodificacion");

            // Relaciones
            builder.HasOne(x => x.Categoria)
                   .WithMany(c => c.Tarifas)
                   .HasForeignKey(x => x.CAT_id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}