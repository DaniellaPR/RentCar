using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Configurations
{
    public class SucursalConfiguration : IEntityTypeConfiguration<SucursalEntity>
    {
        public void Configure(EntityTypeBuilder<SucursalEntity> builder)
        {
            builder.ToTable("sucursal");
            builder.HasKey(x => x.SUC_id);

            builder.Property(x => x.SUC_id).HasColumnName("suc_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.SUC_nombre).HasColumnName("suc_nombre").IsRequired().HasMaxLength(100);
            builder.Property(x => x.SUC_ciudad).HasColumnName("suc_ciudad").IsRequired().HasMaxLength(50);
            builder.Property(x => x.SUC_direccion).HasColumnName("suc_direccion").IsRequired();
            builder.Property(x => x.SUC_coordenadas).HasColumnName("suc_coordenadas").HasMaxLength(50);

            builder.Property(x => x.SUC_fechaCreacion).HasColumnName("suc_fechacreacion");
            builder.Property(x => x.SUC_usuarioCreacion).HasColumnName("suc_usuariocreacion");
            builder.Property(x => x.SUC_fechaModificacion).HasColumnName("suc_fechamodificacion");
            builder.Property(x => x.SUC_usuarioModificacion).HasColumnName("suc_usuariomodificacion");
        }
    }
}