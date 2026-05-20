using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Configurations
{
    public class HorarioAtencionConfiguration : IEntityTypeConfiguration<HorarioAtencionEntity>
    {
        public void Configure(EntityTypeBuilder<HorarioAtencionEntity> builder)
        {
            builder.ToTable("horarioatencion");
            builder.HasKey(x => x.HOR_id);

            builder.Property(x => x.HOR_id).HasColumnName("hor_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.SUC_id).HasColumnName("suc_id").IsRequired();
            builder.Property(x => x.HOR_diaSemana).HasColumnName("hor_diasemana").IsRequired().HasMaxLength(15);
            builder.Property(x => x.HOR_apertura).HasColumnName("hor_apertura").IsRequired();
            builder.Property(x => x.HOR_cierre).HasColumnName("hor_cierre").IsRequired();

            builder.Property(x => x.HOR_fechaCreacion).HasColumnName("hor_fechacreacion");
            builder.Property(x => x.HOR_usuarioCreacion).HasColumnName("hor_usuariocreacion");
            builder.Property(x => x.HOR_fechaModificacion).HasColumnName("hor_fechamodificacion");
            builder.Property(x => x.HOR_usuarioModificacion).HasColumnName("hor_usuariomodificacion");

            // Relación (Una Sucursal tiene muchos Horarios)
            builder.HasOne(x => x.Sucursal)
                   .WithMany(s => s.HorariosAtencion)
                   .HasForeignKey(x => x.SUC_id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}