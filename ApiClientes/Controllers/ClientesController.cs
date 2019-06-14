using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiClientes.Model;

namespace ApiClientes.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
		private static List<Cliente> clientes = new List<Cliente>();

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
			if (clientes.Count == 0)
			{
				clientes.Add(new Cliente()
				{
					Id = 1,
					Nome = "Lucas Alves",
					Endereco = "São João",
					Filhos = 1,
					DataNascimento = DateTime.Now

				});

				clientes.Add(new Cliente()
				{
					Id = 2,
					Nome = "João",
					Endereco = "Centro",
					Filhos = 0,
					DataNascimento = DateTime.Now
				});
			}

			return clientes;
        }

        // GET: api/Clientes/5
        [HttpGet("{id}", Name = "Get")]
        public Cliente Get(int id)
        {
			var clienteEncontrado = clientes.FirstOrDefault(c => c.Id == id);
			return clienteEncontrado;
        }

        // POST: api/Clientes
        [HttpPost]
        public Cliente Post([FromBody] Cliente value)
        {
			clientes.Add(new Cliente()
			{
				Id = value.Id,
				Nome = value.Nome,
				Endereco = value.Endereco,
				Filhos = value.Filhos,
				DataNascimento = value.DataNascimento
			});

			return value;
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cliente value)
        {
			var clienteEncontrado = clientes.FirstOrDefault(c => c.Id == id);

			if (clienteEncontrado.Id > 0)
			{
				clienteEncontrado.Id = value.Id;
				clienteEncontrado.Nome = value.Nome;
				clienteEncontrado.Endereco = value.Endereco;
				clienteEncontrado.Filhos = value.Filhos;
				clienteEncontrado.DataNascimento = value.DataNascimento;
			}
		}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			var clienteEncontrado = clientes.RemoveAll(c => c.Id == id);
		}
    }
}
