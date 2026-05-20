using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Monitoreo.DataAccess.Entities;

namespace MS.Monitoreo.DataAccess.Configurations
{
    public class AuditoriaConfiguration : IEntityTypeConfiguration<AuditoriaEntity>
    {
        public void Configure(EntityTypeBuilder<AuditoriaEntity> builder)
        {
            builder.ToTable("auditoria");
            builder.HasKey(x => x.AUD_id);

            builder.Property(x => x.AUD_id).HasColumnName("aud_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.AUD_nombreTabla).HasColumnName("aud_nombretabla").IsRequired().HasMaxLength(50);
            builder.Property(x => x.AUD_operacion).HasColumnName("aud_operacion").IsRequired().HasMaxLength(10);
            builder.Property(x => x.AUD_usuario).HasColumnName("aud_usuario").HasMaxLength(100);
            builder.Property(x => x.AUD_fecha).HasColumnName("aud_fecha");

            // Magia de Npgsql: mapea el string de C# a un JSONB real de Postgres
            builder.Property(x => x.AUD_detalleJsonb)
                   .HasColumnName("aud_detallejsonb")
                   .HasColumnType("jsonb");
        }
    }
}