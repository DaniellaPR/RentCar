using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Alquiler.DataAccess.Entities;

namespace MS.Alquiler.DataAccess.Configurations
{
    public class PagoConfiguration : IEntityTypeConfiguration<PagoEntity>
    {
        public void Configure(EntityTypeBuilder<PagoEntity> builder)
        {
            builder.ToTable("pago");
            builder.HasKey(x => x.PAG_id);

            builder.Property(x => x.PAG_id).HasColumnName("pag_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.RES_id).HasColumnName("res_id").IsRequired();
            builder.Property(x => x.PAG_monto).HasColumnName("pag_monto").HasColumnType("numeric(10,2)").IsRequired();
            builder.Property(x => x.PAG_metodo).HasColumnName("pag_metodo").IsRequired().HasMaxLength(50);
            builder.Property(x => x.PAG_estado).HasColumnName("pag_estado").IsRequired().HasMaxLength(20).HasDefaultValue("PENDIENTE");
            builder.Property(x => x.PAG_fechaPago).HasColumnName("pag_fechapago");

            // Relación
            builder.HasOne(x => x.Reserva)
                   .WithMany(r => r.Pagos)
                   .HasForeignKey(x => x.RES_id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}