using AppNet6.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppNet6.Infrestructuras.Data.Configuration
{
    public class ParamtroConfiguration : IEntityTypeConfiguration<Parametro>
    {
        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
            //TALBLA
            builder.ToTable("PARAMETRO");
            //CLAVE PK SQL
            builder.HasKey(e => e.Id)
                .HasName("PK_PARAMETRO");

            //CAMPOS
            builder.Property(e => e.Id)
                .HasColumnName("IdParametro")
                .HasColumnType("int");

            builder.Property(e => e.IdTipo)
                .HasColumnName("IdTipo")
                .HasColumnType("int");

            builder.Property(e => e.CampoValor)
                .HasColumnName("CampoValor")
                .HasColumnType("decimal(17,2)");

            builder.Property(e => e.CampoDescripcion)
                .HasColumnName("CampoDescripcion")
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
