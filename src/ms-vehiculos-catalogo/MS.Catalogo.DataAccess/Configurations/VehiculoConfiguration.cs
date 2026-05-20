using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Catalogo.DataAccess.Entities;

namespace MS.Catalogo.DataAccess.Configurations
{
    /// <summary>
    /// ACTUALIZACIÓN: Se añaden las columnas veh_marca y veh_disponibilidad
    /// que estaban en la BD pero ausentes en la configuración original.
    /// </summary>
    public class VehiculoConfiguration : IEntityTypeConfiguration<VehiculoEntity>
    {
        public void Configure(EntityTypeBuilder<VehiculoEntity> builder)
        {
            builder.ToTable("vehiculo");
            builder.HasKey(x => x.VEH_id);

            builder.Property(x => x.VEH_id)
                   .HasColumnName("veh_id")
                   .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(x => x.CAT_id)
                   .HasColumnName("cat_id")
                   .IsRequired();

            builder.Property(x => x.SUC_id)
                   .HasColumnName("suc_id")
                   .IsRequired();

            builder.Property(x => x.VEH_placa)
                   .HasColumnName("veh_placa")
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(x => x.VEH_marca)
                   .HasColumnName("veh_marca")             // ← AÑADIDO
                   .HasMaxLength(50);

            builder.Property(x => x.VEH_modelo)
                   .HasColumnName("veh_modelo")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.VEH_anio)
                   .HasColumnName("veh_anio")
                   .IsRequired();

            builder.Property(x => x.VEH_color)
                   .HasColumnName("veh_color")
                   .HasMaxLength(30);

            builder.Property(x => x.VEH_kilometraje)
                   .HasColumnName("veh_kilometraje")
                   .HasColumnType("numeric(10,2)");

            builder.Property(x => x.VEH_disponibilidad)
                   .HasColumnName("veh_disponibilidad")    // ← AÑADIDO
                   .HasDefaultValue(true);

            builder.Property(x => x.VEH_estado)
                   .HasColumnName("veh_estado")
                   .HasMaxLength(20)
                   .HasDefaultValue("ACTIVO");

            builder.Property(x => x.VEH_imagenUrl)
                   .HasColumnName("veh_imagenurl");

            builder.Property(x => x.VEH_fechaCreacion)
                   .HasColumnName("veh_fechacreacion");

            builder.Property(x => x.VEH_usuarioCreacion)
                   .HasColumnName("veh_usuariocreacion");

            builder.Property(x => x.VEH_fechaModificacion)
                   .HasColumnName("veh_fechamodificacion");

            builder.Property(x => x.VEH_usuarioModificacion)
                   .HasColumnName("veh_usuariomodificacion");

            builder.HasIndex(x => x.VEH_placa).IsUnique();

            builder.HasOne(x => x.Categoria)
                   .WithMany(c => c.Vehiculos)
                   .HasForeignKey(x => x.CAT_id)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Sucursal)
                   .WithMany(s => s.Vehiculos)
                   .HasForeignKey(x => x.SUC_id)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}