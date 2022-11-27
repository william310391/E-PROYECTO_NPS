using AppNet6.Core.Entities;
using AppNet6.Core.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppNet6.Infrestructuras.Data.Configuration
{
    public class SeguridadConfiguration : IEntityTypeConfiguration<Seguridad>
    {
        public void Configure(EntityTypeBuilder<Seguridad> builder)
        {
            //TALBLA
            builder.ToTable("SEGURIDAD");
            //CLAVE PK SQL
            builder.HasKey(e => e.Id)
                .HasName("PK_SEGURIDAD");

            //CAMPOS
            builder.Property(e => e.Id)
                .HasColumnName("IdSeguridad")
                .HasColumnType("int");

            builder.Property(e => e.Usuario)
                .HasColumnName("Usuario")
                .HasColumnType("varchar(200)")
                .IsUnicode(false);

            builder.Property(e => e.Contrasena)
                .HasColumnName("Contrasena")
                .HasColumnType("varchar(200)")
                .IsUnicode(false);   
            
            builder.Property(e => e.NombreUsuario)
                .HasColumnName("NombreUsuario")
                .HasColumnType("varchar(250)")
                .IsUnicode(false);


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
