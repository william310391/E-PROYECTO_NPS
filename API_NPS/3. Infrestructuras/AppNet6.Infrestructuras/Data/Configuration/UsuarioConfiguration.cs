using AppNet6.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AppNet6.Infrestructuras.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //TALBLA
            builder.ToTable("USUARIO");

            //CLAVE PK SQL
            builder.HasKey(e => e.Id)
                .HasName("PK_USUARIO");

            //CAMPOS
            builder.Property(e => e.Id)
                .HasColumnName("IdUsuario")
                .HasColumnType("int");

            builder.Property(e => e.Nombres)
                .HasColumnName("Nombres")
                .HasColumnType("varchar(250)")
                .IsUnicode(false);

            builder.Property(e => e.Apellidos)
                .HasColumnName("Apellidos")
                .HasColumnType("varchar(250)")
                .IsUnicode(false);

            builder.Property(e => e.Cuenta)
                .HasColumnName("Cuenta")
                .HasColumnType("varchar(250)")
                .IsUnicode(false);  

            builder.Property(e => e.Contrasena)
                .HasColumnName("Contrasena")
                .HasColumnType("varchar(200)")
                .IsUnicode(false);

            builder.Property(e => e.Correo)
                .HasColumnName("Correo")
                .HasColumnType("varchar(50)")
                .IsUnicode(false);

            builder.Property(e => e.IdPerfil)
                .HasColumnName("I001Perfil")
                .HasColumnType("int");

            builder.Property(e => e.IndActivo)
                .HasColumnName("IndActivo")
                .HasColumnType("bit")
                .HasDefaultValue(true)
                .IsUnicode(false);

            builder.Property(e => e.IdUsuarioRegistro)
                .HasColumnName("IdUsuarioRegistro")
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsUnicode(false);

            builder.Property(e => e.FechaRegistro)
                .HasColumnName("FechaRegistro")
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now)
                .IsUnicode(false);

            builder.Property(e => e.IdUsuarioModificacion)
               .HasColumnName("IdUsuarioModificacion")
               .HasColumnType("int")
               .HasDefaultValue(0)
               .IsUnicode(false);

            builder.Property(e => e.FechaModificacion)
                .HasColumnName("FechaModificacion")
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now)
                .IsUnicode(false);

        }
    }
}
