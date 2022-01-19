using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoClientes.Entidades
{
    public class Cliente
    {
        public int Identificador { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string Nacionalidade { get; set; }
        public short Idade { get; set; }
    }
}
