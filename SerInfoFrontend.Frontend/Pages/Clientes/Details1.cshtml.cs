using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectSerInfo.Dominio;
using ConexionBD.Persistencia;

namespace  SerInfoFrontend.Frontend.Pages.Clientes
{
    public class Details1Model : PageModel
    {
        private readonly IRepositorioCliente _repoCliente;

        public Cliente cliente {get; set;}

        public Details1Model(IRepositorioCliente repoCliente)
        {
            _repoCliente= repoCliente;
        }
        public IActionResult OnGet(int id)
        {
            cliente = _repoCliente.GetCliente(id);
            if (cliente == null)
            {
                return NotFound();
            } else
            {
                return Page();
            }
        }
    }
}
