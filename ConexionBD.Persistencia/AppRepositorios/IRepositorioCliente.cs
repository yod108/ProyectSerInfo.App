using System.Collections.Generic;
using ProyectSerInfo.Dominio;

namespace ConexionBD.Persistencia
{
    public interface IRepositorioCliente
    {
         IEnumerable<Cliente> GetAllClientes();

         Cliente AddCliente(Cliente cliente);

         Cliente UpdateCliente(Cliente cliente);

         void DeleteCliente(int idCliente);

         Cliente GetCliente(int idCliente);

         Tecnico AsignarTecnico(int idCliente, int idTecnico);

         EvidenciaPc AsignarEvidenciaPc(int idCliente, int idEvidenciaPc);
    }
}