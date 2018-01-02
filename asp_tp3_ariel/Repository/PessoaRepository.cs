using asp_tp3_ariel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace asp_tp3_ariel.Repository
{
    public class PessoaRepository
    {
        public IEnumerable<PessoaModel> GetAllPessoas()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ariel\Desktop\teste-de-performance-3-asp.net\asp_tp3_ariel\App_Data\Pessoa_db.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Pessoa";
                var selectCommand = new SqlCommand(commandText, connection);
                PessoaModel pessoa = null;
                var pessoas = new List<PessoaModel>();
                try
                {
                    connection.Open();
                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            pessoa = new PessoaModel();
                            pessoa.Id = (int)reader["Id"];
                            pessoa.Nome = reader["Nome"].ToString();
                            pessoa.Sobrenome = reader["Sobrenome"].ToString();
                            pessoa.DataNascimento = Convert.ToDateTime(reader["Nascimento"]);
                            pessoas.Add(pessoa);
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
                return pessoas;
            }
        }
    }
}