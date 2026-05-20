using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Alquiler.DataAccess.Entities;

namespace MS.Alquiler.DataAccess.Configurations
{
    public class ReservaDetalleConfiguration : IEntityTypeConfiguration<ReservaDetalleEntity>
    {
        public void Configure(EntityTypeBuilder<ReservaDetalleEntity> builder)
        {
            builder.ToTable("reservadetalle");
            builder.HasKey(x => x.DET_id);

            builder.Property(x => x.DET_id).HasColumnName("det_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.RES_id).HasColumnName("res_id").IsRequired();
            builder.Property(x => x.EXT_id).HasColumnName("ext_id").IsRequired();
            builder.Property(x => x.DET_cantidad).HasColumnName("det_cantidad").IsRequired();
            builder.Property(x => x.DET_subtotal).HasColumnName("det_subtotal").HasColumnType("numeric(10,2)").IsRequired();

            builder.Property(x => x.DET_fechaCreacion).HasColumnName("det_fechacreacion");
            builder.Property(x => x.DET_usuarioCreacion).HasColumnName("det_usuariocreacion");
            builder.Property(x => x.DET_fechaModificacion).HasColumnName("det_fechamodificacion");
            builder.Property(x => x.DET_usuarioModificacion).HasColumnName("det_usuariomodificacion");

            // Relación
            builder.HasOne(x => x.Reserva)
                   .WithMany(r => r.Detalles)
                   .HasForeignKey(x => x.RES_id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}