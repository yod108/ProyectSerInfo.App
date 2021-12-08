using System;
using System.Collections.Generic;
using ProyectSerInfo.Dominio;
using ConexionBD.Persistencia;

namespace SerInfoConsola.Consola
{
    class Program
    {

        private static IRepositorioCliente _repoCliente = new RepositorioCliente();

        private static IRepositorioTecnico _repoTecnico = new RepositorioTecnico();

        private static IRepositorioEvidenciaPc _repoEvidenciaPc = new RepositorioEvidenciaPc();

        static void Main(string[] args)
        {
            Console.WriteLine("¡Bienvenidos al SerInfo!...");

            //AddCliente();
            //BuscarCliente(3);
            MostrarClientes();
            //EliminarCliente(1);
            //AddTecnico();
            //AsignarTecnico();
            //AddEvidenciaPc();
            //AsignarEvidenciaPc();
            //AsignarCliente();            
        }

        private static void AddCliente()
        {
            var cliente = new Cliente
                {
                    Nombre = "Ruben",
                    Apellido = "Rios",
                    Celular = "3137026969",
                    Genero=Genero.Masculino,
                    Direccion = "Calle 63a No 14-19",
                    Ciudad = "Manizales",
                    FechaIngreso = new DateTime(2021, 08, 24)
                };
                _repoCliente.AddCliente(cliente);
        }

        private static void MostrarClientes()
        {
            IEnumerable<Cliente> clientes = _repoCliente.GetAllClientes();
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(cliente.Id +" "+ cliente.Nombre + " " + cliente.Apellido +" "+ cliente.Genero);
                }
        }
        //Buscar Cliente
        /*
        private static void BuscarCliente(int idCliente)
        {
            var cliente = _repoCliente.GetCliente(idCliente);
            Console.WriteLine(cliente.Id +" "+ cliente.Nombre +" "+ cliente.Apellido +" "+ cliente.Genero);
        }
        */
        public Cliente GetCliente(int idCliente)
        {            
            var cliente = _appContext.Clientes
                       .Where(p => p.Id == idCliente)
                       .Include(p => p.Tecnico)
                       .Include(p=> p.EvidenciasPcs)
                       .FirstOrDefault();
            return cliente;
        }

        //Eliminar Cliente
        /*
        private static void EliminarCliente(int idCliente)
        {
            _repoCliente.DeleteCliente(idCliente);
            Console.WriteLine("Cliente Eliminado...");
        }
        */

        public void DeleteCliente(int idCliente)
        {
            var clienteEncontrado = _appContext.Clientes.Find(idCliente);
            if (clienteEncontrado == null)
                return;
            _appContext.Clientes.Remove(clienteEncontrado);
            _appContext.SaveChanges();
        }

        //Método para Agregar Técnico
        private static void AddTecnico()
        {
            var tecnico = new Tecnico
            {
                Nombre = "Laura",
                Apellido = "Cortes",
                Celular = "3012556960",
                Genero = Genero.Femenino,
                Area = "Laboratorio",
                Codigo = "6969",
                RegistroRethus = "10001"
            };
            _repoTecnico.AddTecnico(tecnico);
        }

        private static void AsignarTecnico()
        {
            var tecnico = _repoCliente.AsignarTecnico(3, 4);
            Console.WriteLine(tecnico.Nombre + " " + tecnico.Apellido);
        }

        //Método EvidenciaPC
        private static void AddEvidenciaPc()
        {
            var evidenciaPc = new EvidenciaPc
            {
                FechaInicio = new DateTime(2021, 10, 05),
                Fallas = FallasPc.Pantalla_LCD_Rota                
            };
            _repoEvidenciaPc.AddEvidenciaPc(evidenciaPc);
        }

        //Asignar EvidenciaPc
        private static void AsignarEvidenciaPc()
        {
            var evidenciaPc = _repoCliente.AsignarEvidenciaPc(1, 1);
            Console.WriteLine(evidenciaPc.Fallas +" "+ evidenciaPc.FechaInicio);
        }

        //Asignar Cliente
        private static void AsignarCliente()
        {
            var cliente = _repoEvidenciaPc.AsignarCliente(1, 1);
            Console.WriteLine(cliente.Nombre + " " + cliente.Apellido);
        }

        //Actualizar Cliente
        public Cliente UpdateCliente(Cliente cliente)
        {
            var clienteEncontrado = _appContext.Clientes.Find(cliente.Id);
            if (clienteEncontrado != null)
            {
                clienteEncontrado.Nombre = cliente;
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
    }
}
