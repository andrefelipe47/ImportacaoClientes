using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoClientes
{
    public class Fluxo
    {
        public void Start()
        {
            var clientes = ObterClientes();

            var sql = new Conexoes.SqlServer();
            foreach (var cliente in clientes)
            {
                bool isClienteExiste = sql.VerificarExistenciaCliente(cliente.Cpf);
                if (isClienteExiste)
                    sql.AtualizarCliente(cliente);
                else
                    sql.InserirCliente(cliente);
            }

        }

        public List<Entidades.Cliente> ObterClientes()
        {
            var clientes = new List<Entidades.Cliente>();

            var conteudoArquivo = File.ReadAllText("C:\\HYPER-V\\Clientes.txt");

            var linhas = conteudoArquivo.Split("\r\n");

            foreach (var linha in linhas)
            {
                string cpf = linha.Substring(0, 11);
                string nome = linha.Substring(11, 80);
                string sexo = linha.Substring(91, 1);
                short idade = short.Parse(linha.Substring(92, 3));
                string nacionalidade = linha.Substring(95, 20);

                var cliente = new Entidades.Cliente();
                cliente.Nome = nome.Trim();
                cliente.Idade = idade;
                cliente.Sexo = sexo.Trim();
                cliente.Cpf = cpf.Trim();
                cliente.Nacionalidade = nacionalidade.Trim();

                clientes.Add(cliente);
            }

            return clientes;
        }
    }
}
