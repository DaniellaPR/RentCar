using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Identidad.DataAccess.Entities;

namespace MS.Identidad.DataAccess.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<RolEntity>
    {
        public void Configure(EntityTypeBuilder<RolEntity> builder)
        {
            builder.ToTable("rol");
            builder.HasKey(x => x.ROL_id);

            builder.Property(x => x.ROL_id).HasColumnName("rol_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.ROL_nombre).HasColumnName("rol_nombre").IsRequired().HasMaxLength(50);
            builder.Property(x => x.ROL_descripcion).HasColumnName("rol_descripcion");

            builder.Property(x => x.ROL_fechaCreacion).HasColumnName("rol_fechacreacion");
            builder.Property(x => x.ROL_usuarioCreacion).HasColumnName("rol_usuariocreacion");
            builder.Property(x => x.ROL_fechaModificacion).HasColumnName("rol_fechamodificacion");
            builder.Property(x => x.ROL_usuarioModificacion).HasColumnName("rol_usuariomodificacion");
        }
    }
}