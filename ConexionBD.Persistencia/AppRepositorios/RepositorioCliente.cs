using System.Collections.Generic;
using System.Linq;
using ProyectSerInfo.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ConexionBD.Persistencia
{
    public class RepositorioCliente : IRepositorioCliente
    {   //Método para Agregar un Cliente.
        private readonly AppContext _appContext = new AppContext();
        Cliente IRepositorioCliente.AddCliente(Cliente cliente)
        {
            var clienteAdicionado = _appContext.Clientes.Add(cliente);
            _appContext.SaveChanges();
            return clienteAdicionado.Entity;
        }

        //Método para Eliminar un Cliente.
        void IRepositorioCliente.DeleteCliente(int idCliente)
        {
            var clienteEncontrado = _appContext.Clientes.Find(idCliente);
            if (clienteEncontrado == null)
                return;
            _appContext.Clientes.Remove(clienteEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Cliente> IRepositorioCliente.GetAllClientes()
        {
            return _appContext.Clientes;
        }
        
        //Metodo de busqueda cliente.

        Cliente IRepositorioCliente.GetCliente(int idCliente)
        {
            return _appContext.Clientes.Find(idCliente);
        }

        //Método para Actualizar Cliente.
        Cliente IRepositorioCliente.UpdateCliente(Cliente cliente)
        {
            var clienteEncontrado = _appContext.Clientes.Find(cliente.Id);
            if (clienteEncontrado != null)
            {
                clienteEncontrado.Nombre = cliente.Nombre;
                clienteEncontrado.Apellido = cliente.Apellido;
                clienteEncontrado.Celular = cliente.Celular;
                clienteEncontrado.Genero = cliente.Genero;
                clienteEncontrado.Direccion = cliente.Direccion;
                clienteEncontrado.Ciudad = cliente.Ciudad;
                clienteEncontrado.FechaIngreso = cliente.FechaIngreso;
                _appContext.SaveChanges();
            }
            return clienteEncontrado;
        }


        Tecnico IRepositorioCliente.AsignarTecnico(int idCliente, int idTecnico)
        {
            var clienteEncontrado = _appContext.Clientes.Find(idCliente);
            if (clienteEncontrado != null)
            {
                var tecnicoEncontrado = _appContext.Tecnicos.Find(idTecnico);
                if (tecnicoEncontrado != null)
                {
                    clienteEncontrado.Tecnico = tecnicoEncontrado;
                    _appContext.SaveChanges();
                }
                return tecnicoEncontrado;
            }
            return null;
        }
        EvidenciaPc IRepositorioCliente.AsignarEvidenciaPc(int idCliente, int idEvidenciaPc)
        {
            var clienteEncontrado = _appContext.Clientes
            .Where(p => p.Id == idCliente)
            .Include(p => p.EvidenciaPcs)
            .SingleOrDefault();
            if (clienteEncontrado != null)
            {
                var evidenciaPcEncontrado = _appContext.EvidenciaPcs.Find(idEvidenciaPc);
                if (evidenciaPcEncontrado != null)
                {
                    clienteEncontrado.EvidenciaPcs.Add(evidenciaPcEncontrado);
                    _appContext.SaveChanges();
                }
                return evidenciaPcEncontrado;
            }
            return null;
        }
    }
}