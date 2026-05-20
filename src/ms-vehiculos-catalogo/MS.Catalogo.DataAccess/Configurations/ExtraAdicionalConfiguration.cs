using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Configurations
{
    public class ExtraAdicionalConfiguration : IEntityTypeConfiguration<ExtraAdicionalEntity>
    {
        public void Configure(EntityTypeBuilder<ExtraAdicionalEntity> builder)
        {
            builder.ToTable("extraadicional");
            builder.HasKey(x => x.EXT_id);

            builder.Property(x => x.EXT_id).HasColumnName("ext_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.EXT_nombre).HasColumnName("ext_nombre").IsRequired().HasMaxLength(100);
            builder.Property(x => x.EXT_costo).HasColumnName("ext_costo").HasColumnType("numeric(10,2)").IsRequired();

            builder.Property(x => x.EXT_fechaCreacion).HasColumnName("ext_fechacreacion");
            builder.Property(x => x.EXT_usuarioCreacion).HasColumnName("ext_usuariocreacion");
            builder.Property(x => x.EXT_fechaModificacion).HasColumnName("ext_fechamodificacion");
            builder.Property(x => x.EXT_usuarioModificacion).HasColumnName("ext_usuariomodificacion");
        }
    }
}