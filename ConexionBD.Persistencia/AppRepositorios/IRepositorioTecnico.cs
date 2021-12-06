using System.Collections.Generic;
using ProyectSerInfo.Dominio;

namespace ConexionBD.Persistencia
{
    public interface IRepositorioTecnico
    {
        IEnumerable<Tecnico> GetAllTecnicos();
        Tecnico AddTecnico(Tecnico tecnico);
        Tecnico UpdateTecnico(Tecnico tecnico);
        void DeleteTecnico(int idTecnico);    
        Tecnico GetTecnico(int idTecnico);
   }
}