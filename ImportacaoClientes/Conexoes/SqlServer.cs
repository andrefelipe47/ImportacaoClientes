using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace ImportacaoClientes.Conexoes
{
    public class SqlServer
    {
        private readonly SqlConnection _conexao;

        public SqlServer()
        {
            string stringConexao = File.ReadAllText("C:\\HYPER-V\\StringConexao_aluno.txt");
            _conexao = new SqlConnection(stringConexao);
        }

        public void InserirCliente(Entidades.Cliente cliente)
        {
            try
            {
                _conexao.Open();

                string query = @"INSERT INTO Cliente
                                       (Nome
                                       ,Cpf
                                       ,Idade
                                       ,Genero
                                       ,Nacionalidade)
                                 VALUES
                                       (@Nome
                                       ,@Cpf
                                       ,@Idade
                                       ,@Genero
                                       ,@Nacionalidade);";

                using(var cmd = new SqlCommand(query, _conexao))
                {
                    cmd.Parameters.AddWithValue("@Nacionalidade", cliente.Nacionalidade);
                    cmd.Parameters.AddWithValue("@Idade", cliente.Idade);

                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("@Genero", cliente.Sexo);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }
        }
    }
}
