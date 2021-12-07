using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectSerInfo.Dominio;
using ConexionBD.Persistencia;

namespace SerInfoFrontend.Frontend.Pages.Clientes
{
    public class Index1Model : PageModel
    {
        private readonly IRepositorioCliente _repoCliente;
        public IEnumerable<Cliente> clientes {get; set;}
        public Index1Model(IRepositorioCliente repoCliente)
        {
            _repoCliente = repoCliente;
        }
        public void OnGet()
        {
            clientes = _repoCliente.GetAllClientes();
        }
    }
}
