using System.Collections.Generic;
using ProyectSerInfo.Dominio;

namespace ConexionBD.Persistencia
{
    public class RepositorioEvidenciaPc : IRepositorioEvidenciaPc
    {
        private readonly AppContext _appContext = new AppContext();

        EvidenciaPc IRepositorioEvidenciaPc.AddEvidenciaPc(EvidenciaPc evidenciaPc)
        {
            var evidenciaPcAdicionado = _appContext.EvidenciaPcs.Add(evidenciaPc);
            _appContext.SaveChanges();
            return evidenciaPcAdicionado.Entity;
        }

        IEnumerable<EvidenciaPc> IRepositorioEvidenciaPc.GetAllEvidenciaPcs()
        {
            return _appContext.EvidenciaPcs;
        }

        EvidenciaPc IRepositorioEvidenciaPc.GetEvidenciaPc(int idEvidenciaPc)
        {
            return _appContext.EvidenciaPcs.Find(idEvidenciaPc);
        }

        Cliente IRepositorioEvidenciaPc.AsignarCliente(int idEvidenciaPc, int idCliente){
        {
            var evidenciaPcEncontrado = _appContext.EvidenciaPcs.Find(idEvidenciaPc);
            if (evidenciaPcEncontrado != null)
            {
                var clienteEncontrado = _appContext.Clientes.Find(idCliente);
                if (clienteEncontrado != null)
                {
                    evidenciaPcEncontrado.Cliente = clienteEncontrado;
                    _appContext.SaveChanges();
                }
                return clienteEncontrado;
            }
            return null;
        }

        }

    }
}
