using Microsoft.EntityFrameworkCore;
using ProyectSerInfo.Dominio;

namespace ConexionBD.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas {get; set;}

        public DbSet<Tecnico> Tecnicos {get; set;}

        public DbSet<EvidenciaPC> EvidenciaPCs {get; set;}

        public DbSet<Equipos> Equipos {get; set;}

        //Método para implementar la conexión con la BD

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Initial Catalog=ProyectSerInfo2021; Data Source=DESKTOP-QSPJBQ4; Integrated Security=true");
                /*
                    Initial catalog: nombre de la BD
                    data source: nombre del servidor de la base de datos(Equipo)
                    integrated security: Seguridad con la misma configuracion del inicio de sesion
                */
            }
        }
    }
}