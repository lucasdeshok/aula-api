using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientes.Model
{
	public class Cliente
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public int Filhos { get; set; }
		public string Endereco { get; set; }
		public DateTime DataNascimento { get; set; }	
	}
}
