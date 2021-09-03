using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositores
{
    public class AluguelRepository : IAluguelRepository
    {
        private string StringConexao = "data source=HALLISONSIARA\\SQLEXPRESS; initial Catalog=T_Rental_Israel; user Id=sa; pwd=senai@132";
        public void AtualizarUrl(int IdAluguel, AluguelDomai AluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryUpdate = "Update Aluguel Set DataAluguel = @DataAluguel, DataDevolucao = @DataDevolucao, VeiculoId = @IdVeiculo, ClienteID = @IdCliente WHERE AluguelId = @IdAluguel";
                
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@DataAluguel", AluguelAtualizado.DataAluguel);
                    cmd.Parameters.AddWithValue("@DataDevolucao", AluguelAtualizado.DataDevolucao);
                    cmd.Parameters.AddWithValue("@IdVeiculo", AluguelAtualizado.VeiculoId);
                    cmd.Parameters.AddWithValue("@IdCliente", AluguelAtualizado.ClienteId);
                    cmd.Parameters.AddWithValue("@IdAluguel", IdAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomai BuscarPorId(int IdAluguel)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryListar = "Select AluguelId, DataAluguel, DataDevolucao, Cliente.Nome, Veiculo.Placa PlacaCarro From Aluguel Inner Join Veiculo On Aluguel.VeiculoId = Veiculo.VeiculoId Inner Join Cliente On Aluguel.ClienteId = Cliente.ClienteId WHERE AluguelId = @IdAluguel";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryListar, con))
                {
                    cmd.Parameters.AddWithValue("@IdAluguel", IdAluguel);
                    
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomai AluguelBuscado = new AluguelDomai()
                        {
                            AluguelId = Convert.ToInt32(rdr[0]),

                            DataAluguel = Convert.ToDateTime(rdr[1]),

                            DataDevolucao = Convert.ToDateTime(rdr[2]),

                            Cliente = new ClienteDomain()
                            {
                                Nome = rdr[3].ToString()
                            },

                            Veiculo = new VeiculoDomain()
                            {
                                Placa = rdr[4].ToString()
                            }

                        };
                        return AluguelBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomai NovoAluguel)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryInsert = "Insert Into Aluguel (VeiculoId, ClienteId, DataAluguel, DataDevolucao) Values (@VeiculoId, @ClienteId, @DataAluguel, @DataDevolucao)";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@VeiculoId", NovoAluguel.VeiculoId);
                    cmd.Parameters.AddWithValue("@ClienteId", NovoAluguel.ClienteId);
                    cmd.Parameters.AddWithValue("@DataAluguel", NovoAluguel.DataAluguel);
                    cmd.Parameters.AddWithValue("@DataDevolucao", NovoAluguel.DataDevolucao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdAluguel)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryDelete = "Delete From Aluguel Where AluguelId = @IdAluguel";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdAluguel", IdAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomai> ListarTodas()
        {
            List<AluguelDomai> ListarAluguel = new List<AluguelDomai>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryListar = "Select AluguelId, DataAluguel, DataDevolucao, Cliente.Nome, Veiculo.Placa PlacaCarro From Aluguel Inner Join Veiculo On Aluguel.VeiculoId = Veiculo.VeiculoId Inner Join Cliente On Aluguel.ClienteId = Cliente.ClienteId";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryListar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        AluguelDomai Aluguel = new AluguelDomai()
                        {
                            AluguelId = Convert.ToInt32(rdr[0]),

                            DataAluguel = Convert.ToDateTime(rdr[1]),

                            DataDevolucao = Convert.ToDateTime(rdr[2]),

                            Cliente = new ClienteDomain()

                            {
                                Nome = rdr[3].ToString()
                            },

                            Veiculo = new VeiculoDomain()
                            {
                                Placa = rdr[4].ToString()
                            }                            

                        };
                        ListarAluguel.Add(Aluguel);
                    }
                }
            }
            return ListarAluguel;
        }
    }
}
