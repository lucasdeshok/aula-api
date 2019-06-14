using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace PrimeiroProjeto.Models
{
    [Serializable]
    public class Cliente
    {
        [Display(Name ="Código")]
        public int IDCliente { get; set; }
        public string Nome { get; set; }
        public int Filhos { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public static async System.Threading.Tasks.Task<IEnumerable<Cliente>> GetClientesAsync()
        {
			List<Cliente> clientes = new List<Cliente>();

			using (var c = new HttpClient())
			{
				var response = await c.GetAsync(new Uri("https://first-app-senac.herokuapp.com/v1/clientes"));
				if (response.IsSuccessStatusCode)
				{
					string respostaAPI = response.Content.ReadAsStringAsync().Result;
					clientes = (List<Cliente>)JsonConvert.DeserializeObject(respostaAPI, clientes.GetType());
				}
			}

			return clientes;
        }
    }
}