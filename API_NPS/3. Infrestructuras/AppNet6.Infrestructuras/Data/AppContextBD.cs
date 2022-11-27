using AppNet6.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AppNet6.Infrestructuras.Data
{
    public partial class AppContextBD : DbContext
    {
        public AppContextBD()
        { 
        }
        public AppContextBD(DbContextOptions<AppContextBD> options) : base(options)
        { 
        }
        public virtual DbSet<Usuario>? Usuario { get; set; }
        public virtual DbSet<Seguridad> Seguridad { get; set; }
        public virtual DbSet<UsuarioCalificacionNps> UsuarioCalificacionNps { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
