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
                // abre a conexao
                _conexao.Open();

                // apenas a query de insert
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

                // recebe a conexao para preparar instrucoes a serem enviadas para a base
                using(var cmd = new SqlCommand(query, _conexao))
                {
                    // adiciona o parametro e valor mapeado na query acima
                    cmd.Parameters.AddWithValue("@Nacionalidade", cliente.Nacionalidade);
                    cmd.Parameters.AddWithValue("@Idade", cliente.Idade);
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("@Genero", cliente.Sexo);

                    // envia o insert para o banco de dados
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                // fecha a conexao
                _conexao.Close();
            }
        }
    }
}
