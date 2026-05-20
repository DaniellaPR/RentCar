using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Configurations
{
    public class SeguroConfiguration : IEntityTypeConfiguration<SeguroEntity>
    {
        public void Configure(EntityTypeBuilder<SeguroEntity> builder)
        {
            builder.ToTable("seguro");
            builder.HasKey(x => x.SEG_id);

            builder.Property(x => x.SEG_id).HasColumnName("seg_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.SEG_nombre).HasColumnName("seg_nombre").IsRequired().HasMaxLength(100);
            builder.Property(x => x.SEG_costoDiario).HasColumnName("seg_costodiario").HasColumnType("numeric(10,2)").IsRequired();
            builder.Property(x => x.SEG_cobertura).HasColumnName("seg_cobertura");

            builder.Property(x => x.SEG_fechaCreacion).HasColumnName("seg_fechacreacion");
            builder.Property(x => x.SEG_usuarioCreacion).HasColumnName("seg_usuariocreacion");
            builder.Property(x => x.SEG_fechaModificacion).HasColumnName("seg_fechamodificacion");
            builder.Property(x => x.SEG_usuarioModificacion).HasColumnName("seg_usuariomodificacion");
        }
    }
}