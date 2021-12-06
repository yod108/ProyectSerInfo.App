using System.Collections.Generic;
using ProyectSerInfo.Dominio;
namespace ConexionBD.Persistencia
{
    public interface IRepositorioEvidenciaPc
    {
        IEnumerable<EvidenciaPc> GetAllEvidenciaPcs();
        EvidenciaPc AddEvidenciaPc(EvidenciaPc evidenciaPc);
        EvidenciaPc GetEvidenciaPc(int idEvidenciaPc);
        Cliente AsignarCliente(int idEvidenciaPc, int idCliente);
   }
}
