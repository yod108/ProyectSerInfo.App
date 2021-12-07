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
    public class Create1Model : PageModel
    {
        private readonly IRepositorioCliente _repoCliente;

        public Cliente cliente {get; set;}

        public Create1Model(IRepositorioCliente repoCliente)
        {
            _repoCliente = repoCliente;
        }

        public void OnGet()
        {
            cliente = new Cliente();
        }

        public IActionResult OnPost(Cliente cliente)
        {
            if (ModelState.Isvalid)
            {
                _repoCliente.AddCliente(cliente);
                return RedirectToPage("Index1");
            } else{
                return Pages();
            }
        }
    }
}
