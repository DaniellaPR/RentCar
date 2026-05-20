using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Identidad.DataAccess.Entities;

namespace MS.Identidad.DataAccess.Configurations
{
    public class UsuarioAppConfiguration : IEntityTypeConfiguration<UsuarioAppEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioAppEntity> builder)
        {
            builder.ToTable("usuarioapp");
            builder.HasKey(x => x.USU_id);

            builder.Property(x => x.USU_id).HasColumnName("usu_id").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.ROL_id).HasColumnName("rol_id").IsRequired();
            builder.Property(x => x.USU_email).HasColumnName("usu_email").IsRequired().HasMaxLength(100);
            builder.Property(x => x.USU_passwordHash).HasColumnName("usu_passwordhash").IsRequired();

            builder.Property(x => x.USU_fechaCreacion).HasColumnName("usu_fechacreacion");
            builder.Property(x => x.USU_usuarioCreacion).HasColumnName("usu_usuariocreacion");
            builder.Property(x => x.USU_fechaModificacion).HasColumnName("usu_fechamodificacion");
            builder.Property(x => x.USU_usuarioModificacion).HasColumnName("usu_usuariomodificacion");

            builder.HasIndex(x => x.USU_email).IsUnique();

            builder.HasOne(x => x.Rol)
                   .WithMany(r => r.UsuariosApp)
                   .HasForeignKey(x => x.ROL_id)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}