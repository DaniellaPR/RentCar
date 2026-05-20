using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Configurations
{
    public class CategoriaVehiculoConfiguration : IEntityTypeConfiguration<CategoriaVehiculoEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriaVehiculoEntity> builder)
        {
            builder.ToTable("categoriavehiculo");
            builder.HasKey(x => x.CAT_id);

            builder.Property(x => x.CAT_id).HasColumnName("cat_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.CAT_nombre).HasColumnName("cat_nombre").IsRequired().HasMaxLength(50);
            builder.Property(x => x.CAT_descripcion).HasColumnName("cat_descripcion");
            builder.Property(x => x.CAT_costoBase).HasColumnName("cat_costobase").HasColumnType("numeric(10,2)");
            builder.Property(x => x.CAT_capacidadPasajeros).HasColumnName("cat_capacidadpasajeros");
            builder.Property(x => x.CAT_capacidadMaletas).HasColumnName("cat_capacidadmaletas");
            builder.Property(x => x.CAT_tipoTransmision).HasColumnName("cat_tipotransmision").HasMaxLength(20);

            // Auditoría base
            builder.Property(x => x.CAT_fechaCreacion).HasColumnName("cat_fechacreacion");
            builder.Property(x => x.CAT_usuarioCreacion).HasColumnName("cat_usuariocreacion").HasMaxLength(50);
            builder.Property(x => x.CAT_fechaModificacion).HasColumnName("cat_fechamodificacion");
            builder.Property(x => x.CAT_usuarioModificacion).HasColumnName("cat_usuariomodificacion").HasMaxLength(50);
        }
    }
}