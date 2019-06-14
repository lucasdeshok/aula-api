using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeiroProjeto.Models;

namespace PrimeiroProjeto.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> Listar(int? quantidade)
        {           
            IEnumerable<Cliente> clientes = await Cliente.GetClientesAsync();
            clientes = clientes.OrderBy(c => c.Nome);
            if (quantidade != null)
                clientes = clientes.Take(quantidade.Value);
            return View(clientes);
        }
    }
}