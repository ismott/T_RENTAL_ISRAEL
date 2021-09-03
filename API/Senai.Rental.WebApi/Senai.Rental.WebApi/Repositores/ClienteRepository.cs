using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositores
{
    public class ClienteRepository : IClienteRepository
    {

        private string StringConexao = "data source=HALLISONSIARA\\SQLEXPRESS; initial Catalog=T_Rental_Israel; user Id=sa; pwd=senai@132";
        public void AtualizarUrl(int IdCliente, ClienteDomain ClienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryUpdateUrl = "Update Cliente Set Cliente.Nome = @nomeCliente, Cliente.Sobrenome = @SomebrenomeCliente, CNH = @CNH WHERE ClienteId = @idCliente";

                using (SqlCommand cmd = new SqlCommand(QueryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", ClienteAtualizado.Nome);
                    cmd.Parameters.AddWithValue("@SomebrenomeCliente", ClienteAtualizado.Sobrenome);
                    cmd.Parameters.AddWithValue("@CNH", ClienteAtualizado.CNH);
                    cmd.Parameters.AddWithValue("@idCliente", IdCliente);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int IdCliente)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryBuscar = "Select * From Cliente Where ClienteId = @IdCliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryBuscar, con))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", IdCliente);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        ClienteDomain ClienteBuscado = new ClienteDomain()
                        {
                            ClienteId = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString(),
                            CNH = rdr[3].ToString()

                        };

                        return ClienteBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain NovoCliente)
        {
            using (SqlConnection con = new  SqlConnection(StringConexao))
            {
                string QueryInsert = "Insert Into Cliente (Nome, Sobrenome, CNH) Values (@Nome, @Sobrenome, @CNH)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", NovoCliente.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", NovoCliente.Sobrenome);
                    cmd.Parameters.AddWithValue("@CNH", NovoCliente.CNH);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdCliente)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryDelete = "Delete From Cliente Where ClienteId = @IdCliente";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", IdCliente);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodas()
        {
            List<ClienteDomain> ListarClientes = new List<ClienteDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryListar = "Select ClienteId, Nome, Sobrenome, CNH From Cliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryListar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        ClienteDomain Cliente = new ClienteDomain()
                        {

                            ClienteId = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString(),
                            CNH = rdr[3].ToString()

                        };
                        ListarClientes.Add(Cliente);
                    }
                }
            }
            return ListarClientes;
        }
    }
}
