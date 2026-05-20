using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Alquiler.DataAccess.Entities;

namespace MS.Alquiler.DataAccess.Configurations
{
    public class ReservaConfiguration : IEntityTypeConfiguration<ReservaEntity>
    {
        public void Configure(EntityTypeBuilder<ReservaEntity> builder)
        {
            builder.ToTable("reserva");
            builder.HasKey(x => x.RES_id);

            builder.Property(x => x.RES_id).HasColumnName("res_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.CLI_id).HasColumnName("cli_id").IsRequired();
            builder.Property(x => x.VEH_id).HasColumnName("veh_id").IsRequired();
            builder.Property(x => x.RES_fechaReserva).HasColumnName("res_fechareserva").IsRequired();
            builder.Property(x => x.RES_fechaInicio).HasColumnName("res_fechainicio").IsRequired();
            builder.Property(x => x.RES_fechaFin).HasColumnName("res_fechafin").IsRequired();
            builder.Property(x => x.RES_estado).HasColumnName("res_estado").HasMaxLength(20).HasDefaultValue("PENDIENTE");
            builder.Property(x => x.RES_total).HasColumnName("res_total").HasColumnType("numeric(10,2)");

            builder.Property(x => x.RES_fechaCreacion).HasColumnName("res_fechacreacion");
            builder.Property(x => x.RES_usuarioCreacion).HasColumnName("res_usuariocreacion");
            builder.Property(x => x.RES_fechaModificacion).HasColumnName("res_fechamodificacion");
            builder.Property(x => x.RES_usuarioModificacion).HasColumnName("res_usuariomodificacion");
        }
    }
}