using AppNet6.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Infrestructuras.Data.Configuration
{
    public class UsuarioCalificacionNpsConfiguration:IEntityTypeConfiguration<UsuarioCalificacionNps>
    {
        public void Configure(EntityTypeBuilder<UsuarioCalificacionNps> builder)
        {
            //TALBLA
            builder.ToTable("USUARIO_CALIFICION_NPS");
            //CLAVE PK SQL
            builder.HasKey(e => e.Id)
                
                .HasName("PK_USUARIO_CALIFICION_NPS");
                

            //CAMPOS
            //builder.Property(e => e.Id)
            //    .HasColumnName("IdUsuarioCalificacionNPS")
            //    .HasColumnType("int");

            builder.Property(e => e.Id)
            .HasColumnName("IdUsuarioCalificacionNPS")
            .HasColumnType("int");


            builder.Property(e => e.IdUsuario)
                .HasColumnName("IdUsuario")
                .HasColumnType("int");

            builder.Property(e => e.CalificacionPuntuacion)
                .HasColumnName("CalificacionPuntuacion")
                .HasColumnType("int");

            builder.Property(e => e.CalificacionDescripcion)
                .HasColumnName("CalificacionDescripcion")
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
